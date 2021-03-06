USE [BSWExchange]
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportExceptionGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportExceptionGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RPT_OrderImportExceptionGet]
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportAuditGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportAuditGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RPT_OrderImportAuditGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXServiceNotificationSend]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXServiceNotificationSend]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXServiceNotificationSend]
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXScheduleInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXScheduleFrequencyTypeInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXScheduleFrequencyTypeGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXScheduleFrequencyTypeDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXScheduleDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXReprocessOrderProducts]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXReprocessOrderProducts]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXReprocessOrderProducts]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileTypeInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileTypeGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileTypeDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileScheduleInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileScheduleGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileScheduleDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileHistoryLastRunGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileHistoryLastRunGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileHistoryLastRunGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileHistoryInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileHistoryInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileConfigFolderInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileConfigFolderGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileConfigFolderDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageUpdate]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageUpdate]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryUpdate]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryUpdate]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageHistoryUpdate]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageHistoryInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageHistoryGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageHistoryDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportMessageGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportBatchInsertGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportBatchInsertGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXImportBatchInsertGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXEventLogInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXEventLogInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXEventLogInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorTypeInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorTypeGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorTypeDelete]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorGet]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorDelete]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXAdaptorDelete]
GO
/****** Object:  StoredProcedure [dbo].[AZ_OrdersALL]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AZ_OrdersALL]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AZ_OrdersALL]
GO
/****** Object:  StoredProcedure [dbo].[AZ_ExceptionOrder]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AZ_ExceptionOrder]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AZ_ExceptionOrder]
GO
/****** Object:  StoredProcedure [dbo].[AZ_DataValFailureNotificationSend]    Script Date: 2013-07-18 09:06:13 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AZ_DataValFailureNotificationSend]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[AZ_DataValFailureNotificationSend]
GO
/****** Object:  StoredProcedure [dbo].[AZ_DataValFailureNotificationSend]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AZ_DataValFailureNotificationSend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ===================================================================
-- Author:		Carlo Smit
-- Create date: 2013-06-24
-- Description:	Send out AutoZone Data Validation faild Notifications
-- ===================================================================
CREATE PROCEDURE [dbo].[AZ_DataValFailureNotificationSend]
	
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
								<p class="MsoNormal"><o:p>File Name:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @FileName + ''</o:p></p>
								<p class="MsoNormal"><o:p>Message ID:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @MessageID +''</o:p></p>
								<p class="MsoNormal"><o:p>Import Date:&nbsp;&nbsp;&nbsp;&nbsp;'' + @MeggaseDt + ''</o:p></p>
								<p class="MsoNormal"><o:p>Importer:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;AUTOZONE</o:p></p>''
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

/****** Object:  StoredProcedure [dbo].[BSWXAdaptorDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorDelete]
	@AdaptorID tinyint=NULL,
	@AdaptorName varchar(50)=NULL,
	@AdaptorType tinyint=NULL,
	@ServiceName varchar(100)=NULL
AS
BEGIN
	DELETE Adaptor
	WHERE
	(@AdaptorID IS NULL OR AdaptorID=@AdaptorID)
	AND (@AdaptorName IS NULL OR AdaptorName=@AdaptorName)
	AND (@AdaptorType IS NULL OR AdaptorType=@AdaptorType)
	AND (@ServiceName IS NULL OR ServiceName=@ServiceName)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorGet]
	@AdaptorID tinyint=NULL,
	@AdaptorName varchar(50)=NULL,
	@AdaptorType tinyint=NULL,
	@ServiceName varchar(100)=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	AdaptorID,
	AdaptorName,
	AdaptorType,
	ServiceName
	FROM Adaptor
	WHERE
	(@AdaptorID IS NULL OR AdaptorID=@AdaptorID)
	AND (@AdaptorName IS NULL OR AdaptorName=@AdaptorName)
	AND (@AdaptorType IS NULL OR AdaptorType=@AdaptorType)
	AND (@ServiceName IS NULL OR ServiceName=@ServiceName)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN NULL THEN AdaptorID
		WHEN ''AdaptorID'' THEN AdaptorID
		WHEN ''AdaptorName'' THEN AdaptorName
		WHEN ''AdaptorType'' THEN AdaptorType
		WHEN ''ServiceName'' THEN ServiceName
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN NULL THEN AdaptorID
		WHEN ''AdaptorID'' THEN AdaptorID
		WHEN ''AdaptorName'' THEN AdaptorName
		WHEN ''AdaptorType'' THEN AdaptorType
		WHEN ''ServiceName'' THEN ServiceName
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorInsert]
	@AdaptorName varchar(50),
	@AdaptorType tinyint,
	@ServiceName varchar(100)
AS
BEGIN
	INSERT Adaptor (
	AdaptorName,
	AdaptorType,
	ServiceName
	) VALUES (
	@AdaptorName,
	@AdaptorType,
	@ServiceName)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorTypeDelete]
	@AdaptorTypeID tinyint=NULL,
	@Description varchar(20)=NULL
AS
BEGIN
	DELETE AdaptorType
	WHERE
	(@AdaptorTypeID IS NULL OR AdaptorTypeID=@AdaptorTypeID)
	AND (@Description IS NULL OR Description=@Description)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorTypeGet]
	@AdaptorTypeID tinyint=NULL,
	@Description varchar(20)=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	AdaptorTypeID,
	Description
	FROM AdaptorType
	WHERE
	(@AdaptorTypeID IS NULL OR AdaptorTypeID=@AdaptorTypeID)
	AND (@Description IS NULL OR Description=@Description)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN NULL THEN AdaptorTypeID
		WHEN ''AdaptorTypeID'' THEN AdaptorTypeID
		WHEN ''Description'' THEN Description
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN NULL THEN AdaptorTypeID
		WHEN ''AdaptorTypeID'' THEN AdaptorTypeID
		WHEN ''Description'' THEN Description
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXAdaptorTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXAdaptorTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXAdaptorTypeInsert]
	@Description varchar(20)
AS
BEGIN
	INSERT AdaptorType (
	Description
	) VALUES (
	@Description)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXEventLogInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXEventLogInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

CREATE PROCEDURE [dbo].[BSWXEventLogInsert]
	 @EventTypeID tinyint,
	 @EventProcess varchar(100),
	 @EventDescription varchar(1000)
	
AS
BEGIN
	
	Set NOCOUNT ON;

	-- we need to check if the same event was not logged with in 5 min - so stop duplicate
	if Not EXISTS(Select EventID From EventLog Where EventTypeID = @EventTypeID And EventDescription = @EventDescription And DATEDIFF(MINUTE,eventdt,getdate()) <= 10)
		Begin

			INSERT INTO [dbo].[EventLog]
				   ([EventDT]
				   ,[EventTypeID]
				   ,[EventProcess]
				   ,[EventDescription])
			 VALUES
				   (GETDATE()
				   ,@EventTypeID
				   ,@EventProcess
				   ,@EventDescription
				   )
		End
END


' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportBatchInsertGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportBatchInsertGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ===============================================
-- Author:		Carlo Smit
-- Create date: 2013-07-03
-- Description:	Create/Update Import Message Batch
-- ===============================================
CREATE PROCEDURE [dbo].[BSWXImportBatchInsertGet]
	@BatchUniqueKey varchar(50)
AS
BEGIN
	Declare @BatchID bigint
	Declare @NewVersion smallint

	SET NOCOUNT ON;

	--Firt check if we do not already have a matching batch
     Select @BatchID = ImportBatchID From ImportMessageBatch Where BatchUniqueKey = @BatchUniqueKey

	 if @BatchID IS NULL
		Begin
			--create new batch
			Insert Into ImportMessageBatch
			(BatchUniqueKey
			,BatchStartDT
			)
			Values(
			@BatchUniqueKey
			,GetDate()
			)

			Select @BatchID = SCOPE_IDENTITY()
			Set @NewVersion = 1
		End
	Else
		Begin
			--Update the existing batch and get the version count
			Update ImportMessageBatch Set BatchCompleteDT = GETDATE() Where ImportBatchID = @BatchID

			Select @NewVersion = Count(MessageID) + 1 From ImportMessage Where ImportBatchID = @BatchID
		End
	
	Select @BatchID As ImportBatchID,@NewVersion As NextVersion

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageGet]
	@ClientReference varchar(100)=NULL,
	@MessageID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@ProfileID tinyint=NULL
	
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
	ClientReference1,
	ImportDT,
	MessageID,
	MessageStatus,
	MessageTypeID,
	ProfileID,
	XMLMessage,
	ClientReference2,
	MessageDT
	FROM ImportMessage
	WHERE
	(@ClientReference IS NULL OR ClientReference1=@ClientReference)
	AND (@MessageID IS NULL OR MessageID=@MessageID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	AND (@MessageTypeID IS NULL OR MessageTypeID=@MessageTypeID)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	Order By ImportDT ASC
	
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageHistoryDelete]
	@Description varchar(200)=NULL,
	@HistoryDT datetime=NULL,
	@ImportMessageID bigint=NULL,
	@MessageHistoryID bigint=NULL,
	@MessageStatus tinyint=NULL
AS
BEGIN
	DELETE ImportMessageHistory
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@HistoryDT IS NULL OR HistoryDT=@HistoryDT)
	AND (@ImportMessageID IS NULL OR ImportMessageID=@ImportMessageID)
	AND (@MessageHistoryID IS NULL OR MessageHistoryID=@MessageHistoryID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageHistoryGet]
	@Description varchar(200)=NULL,
	@HistoryDT datetime=NULL,
	@ImportMessageID bigint=NULL,
	@MessageHistoryID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	Description,
	HistoryDT,
	ImportMessageID,
	MessageHistoryID,
	MessageStatus
	FROM ImportMessageHistory
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@HistoryDT IS NULL OR HistoryDT=@HistoryDT)
	AND (@ImportMessageID IS NULL OR ImportMessageID=@ImportMessageID)
	AND (@MessageHistoryID IS NULL OR MessageHistoryID=@MessageHistoryID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN ''HistoryDT'' THEN HistoryDT
		WHEN ''ImportMessageID'' THEN ImportMessageID
		WHEN NULL THEN MessageHistoryID
		WHEN ''MessageHistoryID'' THEN MessageHistoryID
		WHEN ''MessageStatus'' THEN MessageStatus
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN ''HistoryDT'' THEN HistoryDT
		WHEN ''ImportMessageID'' THEN ImportMessageID
		WHEN NULL THEN MessageHistoryID
		WHEN ''MessageHistoryID'' THEN MessageHistoryID
		WHEN ''MessageStatus'' THEN MessageStatus
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageHistoryInsert]
	@Description varchar(200),
	@ImportMessageID bigint,
	@MessageStatus tinyint,
	@MessageClass tinyint
AS
BEGIN

	INSERT ImportMessageHistory (
	Description,
	HistoryDT,
	ImportMessageID,
	MessageStatus,
	MessageClass
	) VALUES (
	@Description,
	GETDATE(),
	@ImportMessageID,
	@MessageStatus,
	@MessageClass)
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageHistoryUpdate]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageHistoryUpdate]
	@Description varchar(200)=NULL,
	@HistoryDT datetime=NULL,
	@ImportMessageID bigint=NULL,
	@MessageHistoryID bigint,
	@MessageStatus tinyint=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE ImportMessageHistory SET
			Description=ISNULL(@Description, Description),
			HistoryDT=ISNULL(@HistoryDT, HistoryDT),
			ImportMessageID=ISNULL(@ImportMessageID, ImportMessageID),
			MessageStatus=ISNULL(@MessageStatus, MessageStatus)
		WHERE
			MessageHistoryID=@MessageHistoryID
	END
	ELSE
	BEGIN
		UPDATE ImportMessageHistory SET
			Description=@Description,
			HistoryDT=@HistoryDT,
			ImportMessageID=@ImportMessageID,
			MessageStatus=@MessageStatus
		WHERE
			MessageHistoryID=@MessageHistoryID
	END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageInsert]
	@ClientReference1 varchar(100),
	@MessageStatus tinyint,
	@MessageTypeID tinyint,
	@ProfileID tinyint,
	@XMLMessage xml,
	@ClientReference2 varchar(100),
	@MessageDT datetime,
	@ImportBatchID bigint = null,
	@Version smallint
AS
BEGIN
	INSERT ImportMessage (
	ClientReference1,
	ImportDT,
	MessageStatus,
	MessageTypeID,
	ProfileID,
	XMLMessage,
	ClientReference2,
	MessageDT,
	ImportBatchID,
	MessageVersion
	) VALUES (
	@ClientReference1,
	Getdate(),
	@MessageStatus,
	@MessageTypeID,
	@ProfileID,
	@XMLMessage,
	@ClientReference2,
	@MessageDT,
	@ImportBatchID,
	@Version
	)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXImportMessageUpdate]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXImportMessageUpdate]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXImportMessageUpdate]
	@ClientReference1 varchar(100)=NULL,
	@ImportDT datetime=NULL,
	@MessageID bigint,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@ProfileID tinyint=NULL,
	@XMLMessage xml=NULL,
	@CheckNull bit=NULL,
	@ClientReference2 varchar(100) = null,
	@MessageDT datetime = null
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE ImportMessage SET
			ClientReference1=ISNULL(@ClientReference1, ClientReference1),
			ClientReference2=ISNULL(@ClientReference2, ClientReference2),
			ImportDT=ISNULL(@ImportDT, ImportDT),
			MessageStatus=ISNULL(@MessageStatus, MessageStatus),
			MessageTypeID=ISNULL(@MessageTypeID, MessageTypeID),
			ProfileID=ISNULL(@ProfileID, ProfileID),
			XMLMessage=ISNULL(@XMLMessage, XMLMessage),
			MessageDT = ISNULL(@MessageDT,MessageDT)

		WHERE
			MessageID=@MessageID
	END
	ELSE
	BEGIN
		UPDATE ImportMessage SET
			ClientReference1=@ClientReference1,
			ClientReference2=@ClientReference2,
			ImportDT=@ImportDT,
			MessageStatus=@MessageStatus,
			MessageTypeID=@MessageTypeID,
			ProfileID=@ProfileID,
			XMLMessage=@XMLMessage,
			MessageDT = @MessageDT
		WHERE
			MessageID=@MessageID
	END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileConfigFolderDelete]
	@ErrorFolder varchar(150)=NULL,
	@FileExtention char(4)=NULL,
	@FolderConfigID smallint=NULL,
	@ProcessedFolder varchar(150)=NULL,
	@ProfileID tinyint=NULL,
	@SourceFolder varchar(150)=NULL
AS
BEGIN
	DELETE ProfileConfigFolder
	WHERE
	(@ErrorFolder IS NULL OR ErrorFolder=@ErrorFolder)
	AND (@FileExtention IS NULL OR FileExtention=@FileExtention)
	AND (@FolderConfigID IS NULL OR FolderConfigID=@FolderConfigID)
	AND (@ProcessedFolder IS NULL OR ProcessedFolder=@ProcessedFolder)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@SourceFolder IS NULL OR SourceFolder=@SourceFolder)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileConfigFolderGet]
	@ErrorFolder varchar(150)=NULL,
	@FileExtention char(4)=NULL,
	@FolderConfigID smallint=NULL,
	@ProcessedFolder varchar(150)=NULL,
	@ProfileID tinyint=NULL,
	@SourceFolder varchar(150)=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	ErrorFolder,
	FileExtention,
	FolderConfigID,
	ProcessedFolder,
	ProfileID,
	SourceFolder
	FROM ProfileConfigFolder
	WHERE
	(@ErrorFolder IS NULL OR ErrorFolder=@ErrorFolder)
	AND (@FileExtention IS NULL OR FileExtention=@FileExtention)
	AND (@FolderConfigID IS NULL OR FolderConfigID=@FolderConfigID)
	AND (@ProcessedFolder IS NULL OR ProcessedFolder=@ProcessedFolder)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@SourceFolder IS NULL OR SourceFolder=@SourceFolder)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN ''ErrorFolder'' THEN ErrorFolder
		WHEN ''FileExtention'' THEN FileExtention
		WHEN NULL THEN FolderConfigID
		WHEN ''FolderConfigID'' THEN FolderConfigID
		WHEN ''ProcessedFolder'' THEN ProcessedFolder
		WHEN ''ProfileID'' THEN ProfileID
		WHEN ''SourceFolder'' THEN SourceFolder
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN ''ErrorFolder'' THEN ErrorFolder
		WHEN ''FileExtention'' THEN FileExtention
		WHEN NULL THEN FolderConfigID
		WHEN ''FolderConfigID'' THEN FolderConfigID
		WHEN ''ProcessedFolder'' THEN ProcessedFolder
		WHEN ''ProfileID'' THEN ProfileID
		WHEN ''SourceFolder'' THEN SourceFolder
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileConfigFolderInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileConfigFolderInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileConfigFolderInsert]
	@ErrorFolder varchar(150),
	@FileExtention char(4),
	@ProcessedFolder varchar(150),
	@ProfileID tinyint,
	@SourceFolder varchar(150)
AS
BEGIN
	INSERT ProfileConfigFolder (
	ErrorFolder,
	FileExtention,
	ProcessedFolder,
	ProfileID,
	SourceFolder
	) VALUES (
	@ErrorFolder,
	@FileExtention,
	@ProcessedFolder,
	@ProfileID,
	@SourceFolder)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileDelete]
	@AdaptorID tinyint=NULL,
	@ProfileDescription varchar(100)=NULL,
	@ProfileID tinyint=NULL,
	@ProfileName varchar(50)=NULL,
	@ProfileTypeID tinyint=NULL
AS
BEGIN
	DELETE Profile
	WHERE
	(@AdaptorID IS NULL OR AdaptorID=@AdaptorID)
	AND (@ProfileDescription IS NULL OR ProfileDescription=@ProfileDescription)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@ProfileName IS NULL OR ProfileName=@ProfileName)
	AND (@ProfileTypeID IS NULL OR ProfileTypeID=@ProfileTypeID)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileGet]
	@IsActive bit = 1
AS
BEGIN
	SELECT
	AdaptorID,
	ProfileDescription,
	ProfileID,
	ProfileName,
	ProfileTypeID,
	IsActive
	FROM Profile
	WHERE
	IsActive = @IsActive
	Order by ProfileName ASC

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileHistoryInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileHistoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileHistoryInsert]
	@ProfileID tinyint,
	@EventDescription varchar(1000),
	@EventTypeID tinyint
	AS
BEGIN
	
	SET NOCOUNT ON;

    INSERT INTO [dbo].[ProfileHistory]
           ([ProfileID]
           ,[EventDescription]
           ,[EventTypeID])
     VALUES
           (@ProfileID
		   ,@EventDescription
		   ,@EventTypeID)

	Select SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileHistoryLastRunGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileHistoryLastRunGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileHistoryLastRunGet]
	@ProfileID tinyint
AS
BEGIN
	
	SET NOCOUNT ON;

	--get the last time the profile process started
	SELECT [ProfileHistoryID]
      ,[ProfileID]
      ,[EventDt]
      ,[EventDescription]
      ,[EventTypeID]
  FROM [dbo].[ProfileHistory]
  Where ProfileID = @ProfileID
  And EventTypeID = 4
  Order By EventDt DESC

    
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileInsert]
	@AdaptorID tinyint,
	@ProfileDescription varchar(100),
	@ProfileName varchar(50),
	@ProfileTypeID tinyint
AS
BEGIN
	INSERT Profile (
	AdaptorID,
	ProfileDescription,
	ProfileName,
	ProfileTypeID
	) VALUES (
	@AdaptorID,
	@ProfileDescription,
	@ProfileName,
	@ProfileTypeID)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileScheduleDelete]
	@ProfileID tinyint=NULL,
	@ScheduleID tinyint=NULL
AS
BEGIN
	DELETE ProfileSchedule
	WHERE
	(@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@ScheduleID IS NULL OR ScheduleID=@ScheduleID)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileScheduleGet]
	@ProfileID tinyint
AS
BEGIN
	
	SET NOCOUNT ON;

	Select 
	   S.[ScheduleID]
      ,S.[ScheduleName]
      ,S.[ScheduleDescription]
      ,S.[FrequencyTypeID]
      ,S.[RecursEvery]
      ,S.[OccursOnce]
      ,S.[OccursOnceAt]
      ,S.[OccursEveryHour]
      ,S.[OccursEveryMinute]
	From 
	Schedule S 
	Inner Join ProfileSchedule PS On S.ScheduleID = PS.ScheduleID
	Where PS.ProfileID = @ProfileID

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileScheduleInsert]
	@ProfileID tinyint
AS
BEGIN
	INSERT ProfileSchedule (
	ProfileID
	) VALUES (
	@ProfileID)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileTypeDelete]
	@Description varchar(50)=NULL,
	@ProfileTypeID tinyint=NULL
AS
BEGIN
	DELETE ProfileType
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@ProfileTypeID IS NULL OR ProfileTypeID=@ProfileTypeID)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileTypeGet]
	@Description varchar(50)=NULL,
	@ProfileTypeID tinyint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	Description,
	ProfileTypeID
	FROM ProfileType
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@ProfileTypeID IS NULL OR ProfileTypeID=@ProfileTypeID)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN NULL THEN ProfileTypeID
		WHEN ''ProfileTypeID'' THEN ProfileTypeID
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN NULL THEN ProfileTypeID
		WHEN ''ProfileTypeID'' THEN ProfileTypeID
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXProfileTypeInsert]
	@Description varchar(50)
AS
BEGIN
	INSERT ProfileType (
	Description
	) VALUES (
	@Description)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXReprocessOrderProducts]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXReprocessOrderProducts]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXReprocessOrderProducts]
	
AS
BEGIN
	
	SET NOCOUNT ON;

		--update the latest version of any order files that was rejected before - containing these products
		with cte as
			(
			Select M.MessageID,M.MessageVersion,M.ImportBatchID,B.BatchUniqueKey,H.MessageStatus,H.MessageClass,
			M.ImportDt,M.ClientReference1,M.Clientreference2,
			ROW_NUMBER() over(partition by M.ImportBatchID order by M.MessageID DESC) as rn
			From ImportMessage M
			Inner Join ImportMessageBatch B On B.ImportBatchID = M.ImportBatchID
			Inner Join ImportMessageHistory H ON H.ImportMessageID = M.MessageID
			)
			Update IM Set IM.MessageStatus = 1 
			From cte
			Inner Join ImportMessage IM On IM.MessageID = cte.MessageID
			Inner Join
			(select MessageID,T.N.value(''ItemCode[1]'',''varchar(20)'') AS ProductCode From ImportMessage AS M 
			cross apply M.XMLMessage.nodes(''/Message/MessageBody/Order/OrderLine'') as T(N)
			Where MessageStatus = 4
			) x On X.MessageID = IM.MessageID
			Inner Join SupplyChainSolution.dbo.Product P On P.ProductCode COLLATE DAtABASE_DEFAULT = X.ProductCode COLLATE DATABASE_DEFAULT
			And P.ProductStatusID = 4
			Where rn = 1 And cte.MessageStatus = 4 
			And IM.ImportDT > ''2013-07-15''

		--Update all the products
		Update SupplyChainSolution.dbo.Product Set ProductStatusID = 1 Where ProductStatusID = 4
   
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXScheduleDelete]
	@FrequencyTypeID tinyint=NULL,
	@OccursEveryHour tinyint=NULL,
	@OccursEveryMinute tinyint=NULL,
	@OccursOnce bit=NULL,
	@OccursOnceAt time=NULL,
	@RecursEvery tinyint=NULL,
	@ScheduleDescription varchar(100)=NULL,
	@ScheduleID tinyint=NULL,
	@ScheduleName varchar(50)=NULL
AS
BEGIN
	DELETE Schedule
	WHERE
	(@FrequencyTypeID IS NULL OR FrequencyTypeID=@FrequencyTypeID)
	AND (@OccursEveryHour IS NULL OR OccursEveryHour=@OccursEveryHour)
	AND (@OccursEveryMinute IS NULL OR OccursEveryMinute=@OccursEveryMinute)
	AND (@OccursOnce IS NULL OR OccursOnce=@OccursOnce)
	AND (@OccursOnceAt IS NULL OR OccursOnceAt=@OccursOnceAt)
	AND (@RecursEvery IS NULL OR RecursEvery=@RecursEvery)
	AND (@ScheduleDescription IS NULL OR ScheduleDescription=@ScheduleDescription)
	AND (@ScheduleID IS NULL OR ScheduleID=@ScheduleID)
	AND (@ScheduleName IS NULL OR ScheduleName=@ScheduleName)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeDelete]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeDelete]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXScheduleFrequencyTypeDelete]
	@Description varchar(10)=NULL,
	@FrequencyTypeID tinyint=NULL
AS
BEGIN
	DELETE ScheduleFrequencyType
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@FrequencyTypeID IS NULL OR FrequencyTypeID=@FrequencyTypeID)
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXScheduleFrequencyTypeGet]
	@Description varchar(10)=NULL,
	@FrequencyTypeID tinyint=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	Description,
	FrequencyTypeID
	FROM ScheduleFrequencyType
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@FrequencyTypeID IS NULL OR FrequencyTypeID=@FrequencyTypeID)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN NULL THEN FrequencyTypeID
		WHEN ''FrequencyTypeID'' THEN FrequencyTypeID
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN ''Description'' THEN Description
		WHEN NULL THEN FrequencyTypeID
		WHEN ''FrequencyTypeID'' THEN FrequencyTypeID
	END
	END
	DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleFrequencyTypeInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleFrequencyTypeInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXScheduleFrequencyTypeInsert]
	@Description varchar(10)
AS
BEGIN
	INSERT ScheduleFrequencyType (
	Description
	) VALUES (
	@Description)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXScheduleInsert]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXScheduleInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXScheduleInsert]
	@FrequencyTypeID tinyint,
	@OccursEveryHour tinyint,
	@OccursEveryMinute tinyint,
	@OccursOnce bit,
	@OccursOnceAt time,
	@RecursEvery tinyint,
	@ScheduleDescription varchar(100),
	@ScheduleName varchar(50)
AS
BEGIN
	INSERT Schedule (
	FrequencyTypeID,
	OccursEveryHour,
	OccursEveryMinute,
	OccursOnce,
	OccursOnceAt,
	RecursEvery,
	ScheduleDescription,
	ScheduleName
	) VALUES (
	@FrequencyTypeID,
	@OccursEveryHour,
	@OccursEveryMinute,
	@OccursOnce,
	@OccursOnceAt,
	@RecursEvery,
	@ScheduleDescription,
	@ScheduleName)
	
	
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXServiceNotificationSend]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXServiceNotificationSend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ===================================================================
-- Author:		Carlo Smit
-- Create date: 2013-06-28
-- Description:	Send out Notifications about the service
-- ===================================================================
CREATE PROCEDURE [dbo].[BSWXServiceNotificationSend]
	
AS
BEGIN
	
	SET NOCOUNT ON;

	DECLARE @Subject varchar(100)
	Declare @HTMLBody varchar(MAX)

	Declare @MailProfile varchar(30), @SendTO varchar(max)
	Declare @NGroupID smallint

	--Check to see if any notifications was setup for the service
	IF EXISTS(Select NotificationGroupID From ServiceNotification Where NotifyOnServiceNotResponding = 1)
		Begin
			
			--check if the service is responding or not - if no new entiers where made in the last 30 min
			IF NOT EXISTS(Select * From EventLog Where DATEDIFF(MINUTE,EventDT,getdate()) <= 30)
				Begin

					--get all the user that needs to get this mail
					Set @SendTO = ''''

					Select @SendTO = @SendTO + RTRIM(R.ReceipientEmail) + '';'',@NGroupID = G.NotificationGroupID From ServiceNotification SN
					Inner Join NotificationGroupRecipient GR On GR.NotificationGroupID = SN.NotificationGroupID
					Inner Join NotificationRecipient R On R.RecepientID = GR.RecepientID
					Inner Join NotificationGroup G On G.NotificationGroupID = GR.NotificationGroupID
					Where SN.NotifyOnServiceNotResponding = 1 And R.IsActive = 1 And G.UseEmail = 1

					--remove the last '';''
					Set @SendTO = SUBSTRING(@SendTo,0,LEN(@SendTO))

					--get the needed settings for this group
					Select @MailProfile = DatabaseMailProfile From NotificationGroupConfig Where NotificationGroupID = @NGroupID

					
					Set @Subject = ''BSW Exchange service on server '' + @@SERVERNAME + '' is not responding''
					

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
									<p class="MsoNormal"> The BSW Exchange service was unresponsive the last 30 min.<o:p></o:p></p>
									<br />
									<p class="MsoNormal"><o:p>The service may have stopped working. Please log on to server - '' + @@SERVERNAME + '' and verify.</o:p></p>
									<br />
									<p class="MsoNormal"><o:p>This message will be repeated every 30 min until the issue is corrected.</o:p></p>
									
								</div>
								<br /><div><p class="MsoNormal">
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

				END	
		END
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportAuditGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportAuditGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[RPT_OrderImportAuditGet]
	@ImportDateFrom date = null,
	@ImportDateTo date = null,
	@ImportStatusID tinyint = null
AS
BEGIN
	
	SET NOCOUNT ON;
		--set the default values if needed
		if @ImportDateFrom IS NULL
			Set @ImportDateFrom = DATEADD(DAY,-30,Getdate())
		
		if @ImportDateTo IS NULL
			Set @ImportDateTo = Getdate()

		if @ImportStatusID IS NULL
			Set @ImportStatusID = 1

		Select 
		M.ClientReference2 as MessageNo
		,B.BatchUniqueKey As OrderNo
		,M.ClientReference1 as FileName
		,S.Description As ImportStatus
		,C.Description As SubStatus
		,H.Description AS ReasonFailed
		,M.ImportDT
		,X.ProductCode
		,X.UnitPrice
		,M.MessageVersion
		,DATEDIFF(DAY,M.ImportDT,Getdate()) AS DaysInStatus
		From ImportMessage M
		Inner Join ImportMessageHistory H On H.ImportMessageID = M.MessageID
		Inner Join MessageStatus S On S.MessageStatusID = H.MessageStatus
		Inner Join MessageStatusClassification C ON C.MessageClassID = H.MessageClass
		Inner Join ImportMessageBatch B ON B.ImportBatchID = M.ImportBatchID
		Inner join 
		(
		select MessageID,T.N.value(''ItemCode[1]'',''varchar(20)'') AS ProductCode, T.N.value(''UnitPrice[1]'',''varchar(20)'') AS UnitPrice From ImportMessage AS M 
		cross apply M.XMLMessage.nodes(''/Message/MessageBody/Order/OrderLine[1]'') as T(N)
		) X On X.MessageID = M.MessageID
		Where H.MessageStatus >= @ImportStatusID 
		And M.ImportDT >= @ImportDateFrom And M.ImportDT <= @ImportDateTo
		Order By M.ImportBatchID,M.MessageVersion
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportExceptionGet]    Script Date: 2013-07-18 09:06:13 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportExceptionGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[RPT_OrderImportExceptionGet]
	@DaysInStatus tinyint = 0
AS
BEGIN
	
	SET NOCOUNT ON;

		with cte as
		(
		Select M.MessageID,M.MessageVersion,M.ImportBatchID,B.BatchUniqueKey,H.MessageStatus,H.MessageClass,
		H.HistoryDT,M.ClientReference1,M.Clientreference2,M.ImportDT,
		ROW_NUMBER() over(partition by M.ImportBatchID order by M.MessageID DESC) as rn
		From ImportMessage M
		Inner Join ImportMessageBatch B On B.ImportBatchID = M.ImportBatchID
		Inner Join ImportMessageHistory H ON H.ImportMessageID = M.MessageID
		)
		select
		cte.ClientReference2 as MessageNo
		,cte.BatchUniqueKey As OrderNo
		,cte.ClientReference1 as FileName
		,S.Description As ImportStatus
		,C.Description As SubStatus
		,H.Description AS ReasonFailed
		,H.HistoryDT As ImportDT
		,cte.MessageVersion
		,DATEDIFF(DAY,cte.ImportDT,Getdate()) AS DaysInStatus
		From cte
		Inner Join ImportMessageHistory H On H.ImportMessageID = MessageID
		Inner Join MessageStatus S On S.MessageStatusID = H.MessageStatus
		Inner Join MessageStatusClassification C ON C.MessageClassID = H.MessageClass
		Where rn = 1 And cte.MessageStatus = 4 And H.MessageClass = 3
		And DATEDIFF(DAY,cte.ImportDT,Getdate()) >= @DaysInStatus
		And H.HistoryDT > ''2013-07-15''
		Order By cte.BatchUniqueKey ASC,cte.MessageVersion ASC
END
' 
END
GO
