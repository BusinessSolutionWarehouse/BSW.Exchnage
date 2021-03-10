/****** Object:  StoredProcedure [dbo].[MUS_DataValFailureNotificationSend]    Script Date: 2015-08-24 12:17:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MUS_DataValFailureNotificationSend]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MUS_DataValFailureNotificationSend]
GO

/****** Object:  StoredProcedure [dbo].[MUS_DataValFailureNotificationSend]    Script Date: 2015-08-24 12:17:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MUS_DataValFailureNotificationSend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ===================================================================
-- Author:		Carlo Smit
-- Create date: 2015-08-24
-- Description:	Send out Mustek Data Validation faild Notifications
-- ===================================================================
Create PROCEDURE [dbo].[MUS_DataValFailureNotificationSend]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Subject varchar(100)
	Declare @HTMLBody varchar(MAX)

	Declare @CLass varchar(30)
	Declare @Detail varchar(200)
	Declare @FileName varchar(100)
	Declare @MessageID varchar(100)
	Declare @OrderNo varchar(20)
	Declare @SupplierCode varchar(20)
	Declare @SupplierName varchar(100)
	Declare @MeggaseDt varchar(19)
	Declare @ImpMessageID bigint
	Declare @MailProfile varchar(30), @SendTO varchar(max)
	Declare @ProfileID tinyint
	Declare @NGroupID smallint

	--get all the Import Messages that failed - and no notifications where send
	Declare crsMessages cursor For
		Select M.MessageID,M.ProfileID From ImportMessage M Inner Join ImportMessageHistory H ON H.ImportMessageID = M.MessageID
		Where H.MessageClass = 3 And H.MessageStatus = 4 And H.NotificationSend = 0
		And M.ProfileID in (1,2)
		Group By M.MessageID,M.ProfileID

		Open crsMessages
		Fetch Next From crsMessages INTO @ImpMessageID,@ProfileID

		While (@@FETCH_STATUS <> -1)
			BEGIN
				
				--get all the user that needs to get this mail
				Set @SendTO = ''''

				Select @SendTO = @SendTO + RTRIM(R.ReceipientEmail) + '';'',@NGroupID = G.NotificationGroupID From ProfileNotification PN
				Inner Join NotificationGroupRecipient GR On GR.NotificationGroupID = PN.NotificationGroupID
				Inner Join NotificationRecipient R On R.RecepientID = GR.RecepientID
				Inner Join NotificationGroup G On G.NotificationGroupID = GR.NotificationGroupID
				Where PN.ProfileID = @ProfileID And PN.MessageClassification = 3 And PN.IsActive = 1
				And R.IsActive = 1 And G.UseEmail = 1

				--remove the last '';''
				Set @SendTO = SUBSTRING(@SendTo,0,LEN(@SendTO))

				--get the needed settings for this group
				Select @MailProfile = DatabaseMailProfile From NotificationGroupConfig Where NotificationGroupID = @NGroupID

				--Get all the details needed fo this mail
				Select @FileName = ClientReference1,@MessageID = ClientReference2,@MeggaseDt = convert(varchar(19), ImportDT, 120) From ImportMessage
				Where MessageID = @ImpMessageID

				--Read some of the values form the actually xml file
				select @OrderNo = T.N.value(''OrderNo[1]'',''varchar(20)'') From ImportMessage AS M
				cross apply M.XMLMessage.nodes(''/Message/MessageBody/Order'') as T(N)
				Where MessageID = @ImpMessageID

				select @SupplierCode = T.N.value(''SupplierCode[1]'',''varchar(20)'') From ImportMessage AS M
				cross apply M.XMLMessage.nodes(''/Message/MessageBody/Order/Supplier'') as T(N)
				Where MessageID = @ImpMessageID

				--Get the Supplier name
				Select @SupplierName = BusinessEntityName From SupplyChainSolution.dbo.BusinessEntity Where BusinessEntityCode = @SupplierCode

				--Create the mail Subject
				if(@OrderNo IS NOT NULL)
					Set @Subject = ''Import Failure Notification - '' + @OrderNo
				Else
					Set @Subject = ''Import Failure Notification''

				--Lets start the HTML Body - MS OUtlook uses MS Word to render HTML
				set @HtmlBody = ''<html xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office" 
								xmlns:w="urn:schemas-microsoft-com:office:word" 
								xmlns:m="http://schemas.microsoft.com/office/2004/12/omml" 
								xmlns="http://www.w3.org/TR/REC-html40">
								<head>
								<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=us-ascii">
								<meta name=Generator content="Microsoft Word 15 (filtered medium)" />
								<style type="text/css" media="all"> 
											table { margin-bottom: 2em; border-collapse: collapse; } 
											td,th {border= 1 solid #999; padding: 0.2em 0.2em; font-size: 12;} 
											.style1 {color: #FFFFFF; font-weight: bold;line-height: 10px } 
									p.MsoNormal
									{margin-bottom:.0001pt;
									font-size:11.0pt;
									font-family:"Calibri","sans-serif";margin-left: 0cm;margin-right: 0cm;margin-top: 0cm;}
										</style> 
								</headr><body>
							<div>
								<p class="MsoNormal" style="font-weight: bold">
									This is an automated response message, please do not reply to this message.<o:p></o:p></p>
								<br />
								<p class="MsoNormal"> The following file import failed:<o:p></o:p></p>
								<br />
								<p class="MsoNormal"><o:p>Message ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @MessageID +''</o:p></p>
								<p class="MsoNormal"><o:p>Import Date:&nbsp;&nbsp;&nbsp;&nbsp;'' + @MeggaseDt + ''</o:p></p>
								<p class="MsoNormal"><o:p>Importer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;MUSTEK</o:p></p>''
								--we need to check if we actualy have order number
								if(@OrderNo IS NOT NULL)
									Set @HTMLBody = @HTMLBody + ''<p class="MsoNormal"><o:p>Order No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @OrderNo + ''</o:p></p>''
								else
									Set @HTMLBody = @HTMLBody + ''<p class="MsoNormal"><o:p>Order No:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</o:p></p>''
				
								--also check to make sure we have the supplier
								if(@SupplierName IS NOT NULL)
									Set @HTMLBody = @HTMLBody + ''<p class="MsoNormal"><o:p>Supplier:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @SupplierName + '' ('' + @SupplierCode + '')</o:p></p>''
								else
									Set @HTMLBody = @HTMLBody + ''<p class="MsoNormal"><o:p>Supplier:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</o:p></p>''

								set @HTMLBody = @HTMLBody + ''<br />
								<p class="MsoNormal"><o:p>Due to the following:</o:p></p>
								<p class="MsoNormal"><o:p></o:p></p>
							</div>
							<table width="100%"> 
								<tr style="page-break-before:always"> 
								<td width=250 valign=middle style="background:#2E74B5;padding:0cm 5.4pt 0cm 5.4pt"><p class=MsoNormal><span style="color:white">Reason</span></p></td>
								<td valign=top style="background:#2E74B5;padding:0cm 5.4pt 0cm 5.4pt"><p class=MsoNormal><span style="color:white">Description</span></p>''

								--Biuld the body of the table - all the reasons this file failed
								SELECT 	@HtmlBody =  @HTMLBody  + ''</td></tr>'' + ''<tr style="page-break-before:always"><td>'' + RTrim(C.Description) +
									''</td><td>'' + RTrim(H.Description) 
								From ImportMessageHistory H Inner Join MessageStatusClassification C
								On H.MessageClass = C.MessageClassID
								Where ImportMessageID = @ImpMessageID
								And MessageStatus = 4
								And MessageClass = 3
								And NotificationSend = 0
								Order By H.ImportMessageID

								Set @HTMLBody = @HTMLBody + +''</td></tr>''
								--close f the HTML body of the mail
								--add the footer part
						Set @HTMLBody = @HTMLBody + ''</table><br /><div><p class="MsoNormal">
							<o:p>Regards</o:p></p><p class="MsoNormal">
							<o:p>R-G Supply Chain Solution</o:p></p>
							</div></body></htmL>''


					--send the mail
					EXEC msdb.dbo.sp_send_dbmail
					@profile_name = @MailProfile,
					@recipients = @SendTO,
					@body = @HTMLBody,
					@subject = @Subject,
					@body_format = ''HTML'',
					@importance = ''High'' ;

					--Update this message
					Update ImportMessageHistory Set NotificationSend = 1 Where ImportMessageID = @ImpMessageID

			Fetch Next From crsMessages INTO @ImpMessageID,@ProfileID
		End

		Close crsMessages
		DEALLOCATE crsMessages
END
' 
END
GO


