/****** Object:  StoredProcedure [dbo].[RPT_OrderImportExceptionGet]    Script Date: 2013-07-10 03:29:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportExceptionGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RPT_OrderImportExceptionGet]
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportAuditGet]    Script Date: 2013-07-10 03:29:47 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RPT_OrderImportAuditGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[RPT_OrderImportAuditGet]
GO
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportAuditGet]    Script Date: 2013-07-10 03:29:47 PM ******/
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
/****** Object:  StoredProcedure [dbo].[RPT_OrderImportExceptionGet]    Script Date: 2013-07-10 03:29:47 PM ******/
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
		M.ImportDt,M.ClientReference1,M.Clientreference2,
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
		,cte.ImportDT
		,cte.MessageVersion
		,DATEDIFF(DAY,cte.ImportDT,Getdate()) AS DaysInStatus
		From cte
		Inner Join ImportMessageHistory H On H.ImportMessageID = MessageID
		Inner Join MessageStatus S On S.MessageStatusID = H.MessageStatus
		Inner Join MessageStatusClassification C ON C.MessageClassID = H.MessageClass
		Where rn = 1 And cte.MessageStatus = 4 And H.MessageClass = 3
		And DATEDIFF(DAY,cte.ImportDT,Getdate()) >= @DaysInStatus
		Order By cte.BatchUniqueKey ASC,cte.MessageVersion ASC
END
' 
END
GO
/****** Object:  Index [IX_ImportMessageHistory_3]    Script Date: 2013-07-10 03:32:15 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_3')
DROP INDEX [IX_ImportMessageHistory_3] ON [dbo].[ImportMessageHistory]
GO
/****** Object:  Index [IX_ImportMessageHistory_2]    Script Date: 2013-07-10 03:32:15 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_2')
DROP INDEX [IX_ImportMessageHistory_2] ON [dbo].[ImportMessageHistory]
GO
/****** Object:  Index [IX_ImportMessageHistory_1]    Script Date: 2013-07-10 03:32:15 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_1')
DROP INDEX [IX_ImportMessageHistory_1] ON [dbo].[ImportMessageHistory]
GO
/****** Object:  Index [IX_ImportMessageHistory]    Script Date: 2013-07-10 03:32:15 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory')
DROP INDEX [IX_ImportMessageHistory] ON [dbo].[ImportMessageHistory]
GO
/****** Object:  Index [IX_ImportMessageHistory]    Script Date: 2013-07-10 03:32:15 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory')
CREATE NONCLUSTERED INDEX [IX_ImportMessageHistory] ON [dbo].[ImportMessageHistory]
(
	[ImportMessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImportMessageHistory_1]    Script Date: 2013-07-10 03:32:15 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_1')
CREATE NONCLUSTERED INDEX [IX_ImportMessageHistory_1] ON [dbo].[ImportMessageHistory]
(
	[MessageStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImportMessageHistory_2]    Script Date: 2013-07-10 03:32:15 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_2')
CREATE NONCLUSTERED INDEX [IX_ImportMessageHistory_2] ON [dbo].[ImportMessageHistory]
(
	[MessageClass] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ImportMessageHistory_3]    Script Date: 2013-07-10 03:32:15 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageHistory]') AND name = N'IX_ImportMessageHistory_3')
CREATE NONCLUSTERED INDEX [IX_ImportMessageHistory_3] ON [dbo].[ImportMessageHistory]
(
	[MessageStatus] ASC
)
INCLUDE ( 	[ImportMessageID],
	[Description],
	[MessageClass]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [SecondaryXmlIndex-20130710-142340]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-142340')
DROP INDEX [SecondaryXmlIndex-20130710-142340] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [SecondaryXmlIndex-20130710-141958]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-141958')
DROP INDEX [SecondaryXmlIndex-20130710-141958] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [SecondaryXmlIndex-20130710-141922]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-141922')
DROP INDEX [SecondaryXmlIndex-20130710-141922] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [PrimaryXmlIndex-20130710-141755]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'PrimaryXmlIndex-20130710-141755')
DROP INDEX [PrimaryXmlIndex-20130710-141755] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [IX_ImportMessage_3]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_3')
DROP INDEX [IX_ImportMessage_3] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [IX_ImportMessage_2]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_2')
DROP INDEX [IX_ImportMessage_2] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [IX_ImportMessage_1]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_1')
DROP INDEX [IX_ImportMessage_1] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [IX_ImportMessage]    Script Date: 2013-07-10 03:34:42 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage')
DROP INDEX [IX_ImportMessage] ON [dbo].[ImportMessage]
GO
/****** Object:  Index [IX_ImportMessage]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage')
CREATE NONCLUSTERED INDEX [IX_ImportMessage] ON [dbo].[ImportMessage]
(
	[ProfileID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImportMessage_1]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_1')
CREATE NONCLUSTERED INDEX [IX_ImportMessage_1] ON [dbo].[ImportMessage]
(
	[MessageTypeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImportMessage_2]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_2')
CREATE NONCLUSTERED INDEX [IX_ImportMessage_2] ON [dbo].[ImportMessage]
(
	[MessageStatus] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_ImportMessage_3]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'IX_ImportMessage_3')
CREATE NONCLUSTERED INDEX [IX_ImportMessage_3] ON [dbo].[ImportMessage]
(
	[ImportDT] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [PrimaryXmlIndex-20130710-141755]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'PrimaryXmlIndex-20130710-141755')
CREATE PRIMARY XML INDEX [PrimaryXmlIndex-20130710-141755] ON [dbo].[ImportMessage]
(
	[XMLMessage]
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [SecondaryXmlIndex-20130710-141922]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-141922')
CREATE XML INDEX [SecondaryXmlIndex-20130710-141922] ON [dbo].[ImportMessage]
(
	[XMLMessage]
)
USING XML INDEX [PrimaryXmlIndex-20130710-141755] FOR PATH WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [SecondaryXmlIndex-20130710-141958]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-141958')
CREATE XML INDEX [SecondaryXmlIndex-20130710-141958] ON [dbo].[ImportMessage]
(
	[XMLMessage]
)
USING XML INDEX [PrimaryXmlIndex-20130710-141755] FOR VALUE WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
SET ARITHABORT ON
SET CONCAT_NULL_YIELDS_NULL ON
SET QUOTED_IDENTIFIER ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
SET NUMERIC_ROUNDABORT OFF

GO
/****** Object:  Index [SecondaryXmlIndex-20130710-142340]    Script Date: 2013-07-10 03:34:42 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessage]') AND name = N'SecondaryXmlIndex-20130710-142340')
CREATE XML INDEX [SecondaryXmlIndex-20130710-142340] ON [dbo].[ImportMessage]
(
	[XMLMessage]
)
USING XML INDEX [PrimaryXmlIndex-20130710-141755] FOR PROPERTY WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)
GO
