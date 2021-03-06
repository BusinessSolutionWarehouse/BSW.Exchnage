IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'v_BMWCN2History', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPaneCount' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_BMWCN2History'

GO
IF  EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'v_BMWCN2History', NULL,NULL))
EXEC sys.sp_dropextendedproperty @name=N'MS_DiagramPane1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_BMWCN2History'

GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatusClassification]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] DROP CONSTRAINT [FK_ExportMessageHistory_MessageStatusClassification]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] DROP CONSTRAINT [FK_ExportMessageHistory_MessageStatus]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_ExportMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] DROP CONSTRAINT [FK_ExportMessageHistory_ExportMessage]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_Profile]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [FK_ExportMessage_Profile]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageType]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [FK_ExportMessage_MessageType]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [FK_ExportMessage_MessageStatus]
GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessageHistory_NotificationSend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageHistory] DROP CONSTRAINT [DF_ExportMessageHistory_NotificationSend]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_HistoryDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageHistory] DROP CONSTRAINT [DF_ExportMessage_HistoryDT]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessageBatch_BatchStartDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageBatch] DROP CONSTRAINT [DF_ExportMessageBatch_BatchStartDT]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_MessageVersion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [DF_ExportMessage_MessageVersion]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_IsProcessed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [DF_ExportMessage_IsProcessed]
END

GO
IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_ExportDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] DROP CONSTRAINT [DF_ExportMessage_ExportDT]
END

GO
/****** Object:  View [dbo].[v_BMWCN2History]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_BMWCN2History]'))
DROP VIEW [dbo].[v_BMWCN2History]
GO
/****** Object:  Table [dbo].[ExportMessageHistory]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]') AND type in (N'U'))
DROP TABLE [dbo].[ExportMessageHistory]
GO
/****** Object:  Table [dbo].[ExportMessageBatch]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessageBatch]') AND type in (N'U'))
DROP TABLE [dbo].[ExportMessageBatch]
GO
/****** Object:  Table [dbo].[ExportMessage]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessage]') AND type in (N'U'))
DROP TABLE [dbo].[ExportMessage]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileScheduleInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleGet]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXProfileScheduleGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXProfileScheduleGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageUpdateStatus]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageUpdateStatus]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageUpdateStatus]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageHistoryInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageHistoryInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageHistoryInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageHistoryGet]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageHistoryGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageHistoryGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageGet]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageGet]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageGet]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageBatchInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageBatchInsert]') AND type in (N'P', N'PC'))
DROP PROCEDURE [dbo].[BSWXExportMessageBatchInsert]
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageBatchInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageBatchInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageBatchInsert]
	@BatchUniqueKey varchar(50)
AS
BEGIN

	SET NOCOUNT ON;

	INSERT ExportMessageBatch (
	BatchStartDT,
	BatchUniqueKey
	) VALUES (
	GETDATE(),
	@BatchUniqueKey)
    	
	SELECT SCOPE_IDENTITY()

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageGet]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageGet]
	@ClientReference1 varchar(100)=NULL,
	@ClientReference2 varchar(100)=NULL,
	@ExportBatchID bigint=NULL,
	@ExportDT datetime=NULL,
	@MessageDT datetime=NULL,
	@MessageID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@MessageVersion smallint=NULL,
	@ProfileID tinyint=NULL,
	@XMLMessage xml=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder tinyint=NULL
AS
BEGIN
	
	SET NOCOUNT ON;

SELECT
	ClientReference1,
	ClientReference2,
	ExportBatchID,
	ExportDT,
	MessageDT,
	MessageID,
	MessageStatus,
	MessageTypeID,
	MessageVersion,
	ProfileID,
	XMLMessage
	FROM ExportMessage
	WHERE
	(@ClientReference1 IS NULL OR ClientReference1=@ClientReference1)
	AND (@ClientReference2 IS NULL OR ClientReference2=@ClientReference2)
	AND (@ExportBatchID IS NULL OR ExportBatchID=@ExportBatchID)
	AND (@ExportDT IS NULL OR ExportDT=@ExportDT)
	AND (@MessageDT IS NULL OR MessageDT=@MessageDT)
	AND (@MessageID IS NULL OR MessageID=@MessageID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	AND (@MessageTypeID IS NULL OR MessageTypeID=@MessageTypeID)
	AND (@MessageVersion IS NULL OR MessageVersion=@MessageVersion)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	ORDER BY 
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''ExportBatchID'' THEN ExportBatchID
			 WHEN ''MessageID'' THEN MessageID
			 WHEN ''MessageStatus'' THEN MessageStatus
			 WHEN ''MessageTypeID'' THEN MessageTypeID
			 WHEN ''MessageVersion'' THEN MessageVersion
			 WHEN ''ProfileID'' THEN ProfileID
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''ClientReference1'' THEN ClientReference1
			 WHEN ''ClientReference2'' THEN ClientReference2
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''ExportDT'' THEN ExportDT
			 WHEN ''MessageDT'' THEN MessageDT
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''ExportBatchID'' THEN ExportBatchID
			 WHEN ''MessageID'' THEN MessageID
			 WHEN ''MessageStatus'' THEN MessageStatus
			 WHEN ''MessageTypeID'' THEN MessageTypeID
			 WHEN ''MessageVersion'' THEN MessageVersion
			 WHEN ''ProfileID'' THEN ProfileID
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''ClientReference1'' THEN ClientReference1
			 WHEN ''ClientReference2'' THEN ClientReference2
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''ExportDT'' THEN ExportDT
			 WHEN ''MessageDT'' THEN MessageDT
		 END
	 END
	 DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageHistoryGet]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageHistoryGet]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageHistoryGet]
	@Description varchar(200)=NULL,
	@ExportMessageID bigint=NULL,
	@HistoryDT datetime=NULL,
	@MessageClass tinyint=NULL,
	@MessageHistoryID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@NotificationSend bit=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder tinyint=NULL
AS
BEGIN
	
	SET NOCOUNT ON;

SELECT
	Description,
	ExportMessageID,
	HistoryDT,
	MessageClass,
	MessageHistoryID,
	MessageStatus,
	NotificationSend
	FROM ExportMessageHistory
	WHERE
	(@Description IS NULL OR Description=@Description)
	AND (@ExportMessageID IS NULL OR ExportMessageID=@ExportMessageID)
	AND (@HistoryDT IS NULL OR HistoryDT=@HistoryDT)
	AND (@MessageClass IS NULL OR MessageClass=@MessageClass)
	AND (@MessageHistoryID IS NULL OR MessageHistoryID=@MessageHistoryID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	AND (@NotificationSend IS NULL OR NotificationSend=@NotificationSend)
	ORDER BY 
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''ExportMessageID'' THEN ExportMessageID
			 WHEN ''MessageClass'' THEN MessageClass
			 WHEN ''MessageHistoryID'' THEN MessageHistoryID
			 WHEN ''MessageStatus'' THEN MessageStatus
			 WHEN ''NotificationSend'' THEN NotificationSend
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''Description'' THEN Description
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 0 THEN
		 CASE @SortByField
			 WHEN ''HistoryDT'' THEN HistoryDT
		 END
	 END
	 ASC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''ExportMessageID'' THEN ExportMessageID
			 WHEN ''MessageClass'' THEN MessageClass
			 WHEN ''MessageHistoryID'' THEN MessageHistoryID
			 WHEN ''MessageStatus'' THEN MessageStatus
			 WHEN ''NotificationSend'' THEN NotificationSend
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''Description'' THEN Description
		 END
	 END
	 DESC,
	 CASE @SortOrder WHEN 1 THEN
		 CASE @SortByField
			 WHEN ''HistoryDT'' THEN HistoryDT
		 END
	 END
	 DESC
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageHistoryInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageHistoryInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageHistoryInsert]
	@Description varchar(200),
	@ExportMessageID bigint,
	@MessageClass tinyint,
	@MessageStatus tinyint
	
AS
BEGIN
	INSERT ExportMessageHistory (
	Description,
	ExportMessageID,
	HistoryDT,
	MessageClass,
	MessageStatus,
	NotificationSend
	) VALUES (
	@Description,
	@ExportMessageID,
	Getdate(),
	@MessageClass,
	@MessageStatus,
	0)
	
	SELECT SCOPE_IDENTITY()
END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageInsert]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageInsert]
	@ClientReference1 varchar(100) = null,
	@ClientReference2 varchar(100) = null,
	@ExportBatchID bigint = null,
	@ExportDT datetime = null,
	@MessageDT datetime = null,
	@MessageStatus tinyint,
	@MessageTypeID tinyint,
	@MessageVersion smallint = null,
	@ProfileID tinyint,
	@XMLMessage xml
AS
BEGIN
	INSERT ExportMessage (
	ClientReference1,
	ClientReference2,
	ExportBatchID,
	ExportDT,
	MessageDT,
	MessageStatus,
	MessageTypeID,
	MessageVersion,
	ProfileID,
	XMLMessage
	) VALUES (
	@ClientReference1,
	@ClientReference2,
	@ExportBatchID,
	Getdate(),
	@MessageDT,
	@MessageStatus,
	@MessageTypeID,
	@MessageVersion,
	@ProfileID,
	@XMLMessage)
	
	
	SELECT SCOPE_IDENTITY()

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXExportMessageUpdateStatus]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[BSWXExportMessageUpdateStatus]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'
CREATE PROCEDURE [dbo].[BSWXExportMessageUpdateStatus]
	@MessageID bigint,
	@MessageStatus tinyint
AS
BEGIN
	
	SET NOCOUNT ON;

	Update ExportMessage
	Set MessageStatus = @MessageStatus
	Where 
	MessageID = @MessageID

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleGet]    Script Date: 2013-10-02 02:13:31 PM ******/
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
	  ,S.[StartDate]
	  ,S.[EndDate]
	  ,S.[StartTime]
	  ,S.[EndTime]
	From 
	Schedule S 
	Inner Join ProfileSchedule PS On S.ScheduleID = PS.ScheduleID
	Where PS.ProfileID = @ProfileID

END
' 
END
GO
/****** Object:  StoredProcedure [dbo].[BSWXProfileScheduleInsert]    Script Date: 2013-10-02 02:13:31 PM ******/
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
/****** Object:  Table [dbo].[ExportMessage]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExportMessage](
	[MessageID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProfileID] [tinyint] NOT NULL,
	[ExportDT] [datetime] NOT NULL,
	[MessageTypeID] [tinyint] NOT NULL,
	[ClientReference1] [varchar](100) NULL,
	[ClientReference2] [varchar](100) NULL,
	[MessageDT] [datetime] NULL,
	[XMLMessage] [xml] NOT NULL,
	[MessageStatus] [tinyint] NOT NULL,
	[ExportBatchID] [bigint] NULL,
	[MessageVersion] [smallint] NOT NULL,
 CONSTRAINT [PK_ExportMessage] PRIMARY KEY CLUSTERED 
(
	[MessageID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExportMessageBatch]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessageBatch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExportMessageBatch](
	[ExportBatchID] [bigint] IDENTITY(1,1) NOT NULL,
	[BatchUniqueKey] [varchar](50) NOT NULL,
	[BatchStartDT] [datetime] NOT NULL,
	[BatchCompleteDT] [datetime] NULL,
 CONSTRAINT [PK_ExportMessageBatch] PRIMARY KEY CLUSTERED 
(
	[ExportBatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ExportMessageHistory]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExportMessageHistory](
	[MessageHistoryID] [bigint] IDENTITY(1,1) NOT NULL,
	[HistoryDT] [datetime] NOT NULL,
	[ExportMessageID] [bigint] NOT NULL,
	[MessageStatus] [tinyint] NOT NULL,
	[Description] [varchar](200) NOT NULL,
	[MessageClass] [tinyint] NOT NULL,
	[NotificationSend] [bit] NOT NULL,
 CONSTRAINT [PK_ExportMessageHistory] PRIMARY KEY CLUSTERED 
(
	[MessageHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[v_BMWCN2History]    Script Date: 2013-10-02 02:13:31 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[v_BMWCN2History]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[v_BMWCN2History]
AS
Select
 M.MessageID
,M.ExportDT As DateSend
,M.ClientReference1 As FileName
,T.N.value(''ManifestNo[1]'',''varchar(50)'') As ManifestNo
,T.N.value(''ManifestDate[1]'',''DateTime'') As ManifestDate
,T.N.value(''RefeNo[1]'',''varchar(50)'') As ManifestRefNo
,T.N.value(''MRNNumber[1]'',''varchar(50)'') As MRNNumber
,T.N.value(''TruckReg[1]'',''varchar(20)'') As TruckRegNo
,T.N.value(''UCRNo[1]'',''varchar(100)'') As UCRNUmber
,T.N.value(''CustomsValue[1]'',''varchar(20)'') As CustomsValue
,T.N.value(''VehiclesInManifest[1]'',''tinyint'') As VehiclesInManifest
,T.N.value(''ManifestCode[1]'',''varchar(5)'') As Type
,T.N.value(''AgentCode[1]'',''varchar(15)'') As AgentCode
,T.N.value(''ManifestStatus[1]'',''varchar(10)'') As ManifestStatus
,H.Description As TrackingDetail
,S.Description As TrackingStatus
From ExportMessage M
cross apply M.XMLMessage.nodes(''/CN2Data/NTCN2DataModel'') as T(N)
Inner Join ExportMessageHistory H ON H.ExportMessageID = M.MessageID
Inner Join MessageStatus S On S.MessageStatusID = H.MessageStatus

' 
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_ExportDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] ADD  CONSTRAINT [DF_ExportMessage_ExportDT]  DEFAULT (getdate()) FOR [ExportDT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_IsProcessed]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] ADD  CONSTRAINT [DF_ExportMessage_IsProcessed]  DEFAULT ((0)) FOR [MessageStatus]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_MessageVersion]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessage] ADD  CONSTRAINT [DF_ExportMessage_MessageVersion]  DEFAULT ((1)) FOR [MessageVersion]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessageBatch_BatchStartDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageBatch] ADD  CONSTRAINT [DF_ExportMessageBatch_BatchStartDT]  DEFAULT (getdate()) FOR [BatchStartDT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessage_HistoryDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageHistory] ADD  CONSTRAINT [DF_ExportMessage_HistoryDT]  DEFAULT (getdate()) FOR [HistoryDT]
END

GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ExportMessageHistory_NotificationSend]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ExportMessageHistory] ADD  CONSTRAINT [DF_ExportMessageHistory_NotificationSend]  DEFAULT ((0)) FOR [NotificationSend]
END

GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage]  WITH CHECK ADD  CONSTRAINT [FK_ExportMessage_MessageStatus] FOREIGN KEY([MessageStatus])
REFERENCES [dbo].[MessageStatus] ([MessageStatusID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] CHECK CONSTRAINT [FK_ExportMessage_MessageStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageType]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage]  WITH CHECK ADD  CONSTRAINT [FK_ExportMessage_MessageType] FOREIGN KEY([MessageTypeID])
REFERENCES [dbo].[MessageType] ([MessageTypeID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_MessageType]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] CHECK CONSTRAINT [FK_ExportMessage_MessageType]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_Profile]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage]  WITH CHECK ADD  CONSTRAINT [FK_ExportMessage_Profile] FOREIGN KEY([ProfileID])
REFERENCES [dbo].[Profile] ([ProfileID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessage_Profile]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessage]'))
ALTER TABLE [dbo].[ExportMessage] CHECK CONSTRAINT [FK_ExportMessage_Profile]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_ExportMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory]  WITH CHECK ADD  CONSTRAINT [FK_ExportMessageHistory_ExportMessage] FOREIGN KEY([ExportMessageID])
REFERENCES [dbo].[ExportMessage] ([MessageID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_ExportMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] CHECK CONSTRAINT [FK_ExportMessageHistory_ExportMessage]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory]  WITH CHECK ADD  CONSTRAINT [FK_ExportMessageHistory_MessageStatus] FOREIGN KEY([MessageStatus])
REFERENCES [dbo].[MessageStatus] ([MessageStatusID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatus]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] CHECK CONSTRAINT [FK_ExportMessageHistory_MessageStatus]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatusClassification]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory]  WITH NOCHECK ADD  CONSTRAINT [FK_ExportMessageHistory_MessageStatusClassification] FOREIGN KEY([MessageClass])
REFERENCES [dbo].[MessageStatusClassification] ([MessageClassID])
NOT FOR REPLICATION 
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ExportMessageHistory_MessageStatusClassification]') AND parent_object_id = OBJECT_ID(N'[dbo].[ExportMessageHistory]'))
ALTER TABLE [dbo].[ExportMessageHistory] CHECK CONSTRAINT [FK_ExportMessageHistory_MessageStatusClassification]
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPane1' , N'SCHEMA',N'dbo', N'VIEW',N'v_BMWCN2History', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4[60] 2) )"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2) )"
      End
      ActivePaneConfig = 14
   End
   Begin DiagramPane = 
      PaneHidden = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      PaneHidden = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      PaneHidden = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_BMWCN2History'
GO
IF NOT EXISTS (SELECT * FROM ::fn_listextendedproperty(N'MS_DiagramPaneCount' , N'SCHEMA',N'dbo', N'VIEW',N'v_BMWCN2History', NULL,NULL))
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'v_BMWCN2History'
GO
