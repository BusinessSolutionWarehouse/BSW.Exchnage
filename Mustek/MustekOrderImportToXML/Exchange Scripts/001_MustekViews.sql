/****** Object:  View [dbo].[v_MustekOrders]    Script Date: 2013-12-20 12:30:35 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_MustekOrders]'))
DROP VIEW [dbo].[v_MustekOrders]
GO
/****** Object:  StoredProcedure [dbo].[MS_OrderReceiveNotificationSend]    Script Date: 2013-12-20 12:30:35 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MS_OrderReceiveNotificationSend]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[MS_OrderReceiveNotificationSend]
GO
/****** Object:  StoredProcedure [dbo].[MS_OrderReceiveNotificationSend]    Script Date: 2013-12-20 12:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MS_OrderReceiveNotificationSend]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'-- ===================================================================
-- Author:		Carlo Smit
-- Create date: 2013-12-20
-- Description:	Send out Mustek Order Receive Notification
-- ===================================================================
CREATE PROCEDURE [dbo].[MS_OrderReceiveNotificationSend]
	
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
	Declare @NewTrackOrderNo varchar(30)
	Declare @MeggaseDt varchar(19)
	Declare @ImpMessageID bigint
	Declare @MailProfile varchar(30), @SendTO varchar(max)
	Declare @ProfileID tinyint
	Declare @NGroupID smallint

	--get all the Import Messages that was processed successfully
	Declare crsMessages cursor For
		Select M.MessageID,M.ProfileID From ImportMessage M Inner Join ImportMessageHistory H ON H.ImportMessageID = M.MessageID
		Where M.ProfileID = 5 And M.MessageStatus = 1 And H.NotificationSend = 0
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
				Where PN.ProfileID = @ProfileID And PN.MessageClassification = 4 And PN.IsActive = 1
				And R.IsActive = 1 And G.UseEmail = 1

				--remove the last '';''
				Set @SendTO = SUBSTRING(@SendTo,0,LEN(@SendTO))

				--get the needed settings for this group
				Select @MailProfile = DatabaseMailProfile From NotificationGroupConfig Where NotificationGroupID = @NGroupID

				--Get all the details needed fo this mail
				Select @FileName = ClientReference1,@MessageID = ClientReference2,@MeggaseDt = convert(varchar(19), ImportDT, 120) From ImportMessage
				Where MessageID = @ImpMessageID

				--Read some needed values
				select @OrderNo = ImportMessageBatch.BatchUniqueKey,@NewTrackOrderNo = ClientReference2
				From ImportMessage 
				Inner Join ImportMessageBatch On ImportMessage.ImportBatchID = ImportMessageBatch.ImportBatchID
				Where MessageID = @ImpMessageID


				
				--Create the mail Subject
				Set @Subject = ''New Order Received - '' + @OrderNo

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
								<p class="MsoNormal"> The following Mustek Purchase Order was created:<o:p></o:p></p>
								<br />
								<p class="MsoNormal"><o:p>New Order received and processed -&nbsp;&nbsp;'' + @OrderNo + ''&nbsp;&nbsp; on &nbsp;&nbsp;'' + CONVERT(varchar,  GETDATE(), 120) +''</o:p></p>
								<p class="MsoNormal"><o:p>Rohlig File Reference :&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;'' + @NewTrackOrderNo +''</o:p></p>''
								set @HTMLBody = @HTMLBody + ''<br />
								<p class="MsoNormal"><o:p></o:p></p>
							</div>
							<p class="MsoNormal">
							<o:p>Regards</o:p></p><p class="MsoNormal">
							<o:p>R-G Supply Chain Solution</o:p></p>
							</div></body></htmL>''

					--select @HTMLBody
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
/****** Object:  View [dbo].[v_MustekOrders]    Script Date: 2013-12-20 12:30:35 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_MustekOrders]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[v_MustekOrders]
With SCHEMABINDING
AS
Select
 M.MessageID
,M.ImportDT As DateImported
,M.ClientReference1 As FileName
,M.ClientReference2 as NewtrackFileNo
,T.N.value(''ImporterCode[1]'',''varchar(15)'') As ImporterCode
,T.N.value(''PurchaseOrderId[1]'',''int'') as PurchaseOrderID
,convert(datetime, substring(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),1,4) +''/''+ substring(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),5,2) + ''/'' + substring(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),7,2) + '' '' + SUBSTRING(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),9,2) + '':'' + SUBSTRING(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),11,2) + '':'' + SUBSTRING(T.N.value(''PurchaseOrderDate[1]'',''varchar(14)''),13,2))  as PurchaseOrderDate
,T.N.value(''PurchaseOrderStatus[1]'',''varchar(30)'') as PurchaseOrderStatus
,T.N.value(''PurchaseOrderReference[1]'',''varchar(50)'') as Reference
,T.N.value(''PurchaseOrderNote[1]'',''varchar(50)'') as OrderNote
,T.N.value(''PurchaseOrderCreatedBy[1]'',''varchar(50)'') as CreatedBY
,T.N.value(''PurchaseOrderCreatedByEmail[1]'',''varchar(100)'') as CreatedByEMail
,T.N.value(''SupplierCode[1]'',''varchar(50)'') as SupplierCode
,T.N.value(''SupplierName[1]'',''varchar(100)'') as SupplierName
,T.N.value(''PurchaseOrderINCOTerm[1]'',''varchar(30)'') as INCOTerm
,T.N.value(''PurchaseOrderTransportMode[1]'',''varchar(20)'') as TransPortMode
,T.N.value(''SupplierCountry[1]'',''varchar(50)'') as SupplierCountry
,T.N.value(''SupplierPort[1]'',''varchar(50)'') as SupplierPort
,T.N.value(''PurchaseOrderItemId[1]'',''int'') as OrderLineID
,T.N.value(''ProductCode[1]'',''varchar(50)'') as ProductCode
,T.N.value(''ProductDescription[1]'',''varchar(150)'') as ProductDescription
,T.N.value(''SupplierProductCode[1]'',''varchar(50)'') as SupplierProductCode
,T.N.value(''ProductQty[1]'',''int'') as Qty
,T.N.value(''ProductNote[1]'',''varchar(80)'') as ProductNote
,T.N.value(''UnitPrice[1]'',''money'') as UnitPrice
,T.N.value(''UnitCurrency[1]'',''varchar(20)'') as UnitCurrency
,T.N.value(''UnitType[1]'',''varchar(50)'') as UnitType
,T.N.value(''UnitVolume[1]'',''varchar(50)'') as UnitVolume
,T.N.value(''UnitWeight[1]'',''varchar(50)'') as UnitWeight
,T.N.value(''UnitsPerPackage[1]'',''int'') as UniterPerPackage
,T.N.value(''ProductManager[1]'',''varchar(50)'') as ProductManager
,T.N.value(''ProductManagerEmail[1]'',''varchar(100)'') as ProductManagerEMail
,T.N.value(''TrackingStatus[1]'',''varchar(50)'') as TrackingStatus
,M.MessageStatus
,M.ImportBatchID
,M.MessageVersion
From dbo.ImportMessage M
cross apply M.XMLMessage.nodes(''/Orders/OrderLine'') as T(N)
Where MessageTypeID = 7
' 
GO
