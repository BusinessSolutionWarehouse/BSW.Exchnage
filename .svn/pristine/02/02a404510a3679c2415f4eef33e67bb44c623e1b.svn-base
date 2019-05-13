PRINT '-------------------------- Stored Procedures : SELECT --------------------------------'
GO

PRINT 'CREATE PROCEDURE : ImportMessageGet'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageGet]
GO

CREATE PROCEDURE [dbo].[BSWXImportMessageGet]
	@ClientReference varchar(100)=NULL,
	@ImportDT datetime=NULL,
	@MessageID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@ProfileID tinyint=NULL,
	@XMLMessage xml=NULL,
	@SortByField varchar(128)=NULL,
	@SortOrder smallint=NULL
AS
BEGIN
	SELECT
	ClientReference,
	ImportDT,
	MessageID,
	MessageStatus,
	MessageTypeID,
	ProfileID,
	XMLMessage
	FROM ImportMessage
	WHERE
	(@ClientReference IS NULL OR ClientReference=@ClientReference)
	AND (@ImportDT IS NULL OR ImportDT=@ImportDT)
	AND (@MessageID IS NULL OR MessageID=@MessageID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	AND (@MessageTypeID IS NULL OR MessageTypeID=@MessageTypeID)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@XMLMessage IS NULL OR XMLMessage=@XMLMessage)
	ORDER BY CASE @SortOrder WHEN 0 THEN
	CASE @SortByField
		WHEN 'ClientReference' THEN ClientReference
		WHEN 'ImportDT' THEN ImportDT
		WHEN NULL THEN MessageID
		WHEN 'MessageID' THEN MessageID
		WHEN 'MessageStatus' THEN MessageStatus
		WHEN 'MessageTypeID' THEN MessageTypeID
		WHEN 'ProfileID' THEN ProfileID
		WHEN 'XMLMessage' THEN XMLMessage
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'ClientReference' THEN ClientReference
		WHEN 'ImportDT' THEN ImportDT
		WHEN NULL THEN MessageID
		WHEN 'MessageID' THEN MessageID
		WHEN 'MessageStatus' THEN MessageStatus
		WHEN 'MessageTypeID' THEN MessageTypeID
		WHEN 'ProfileID' THEN ProfileID
		WHEN 'XMLMessage' THEN XMLMessage
	END
	END
	DESC
END
GO

PRINT 'CREATE PROCEDURE : ImportMessageHistoryGet'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryGet]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageHistoryGet]
GO

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
		WHEN 'Description' THEN Description
		WHEN 'HistoryDT' THEN HistoryDT
		WHEN 'ImportMessageID' THEN ImportMessageID
		WHEN NULL THEN MessageHistoryID
		WHEN 'MessageHistoryID' THEN MessageHistoryID
		WHEN 'MessageStatus' THEN MessageStatus
	END
	END
	ASC,
	CASE @SortOrder WHEN 1 THEN
	CASE @SortByField
		WHEN 'Description' THEN Description
		WHEN 'HistoryDT' THEN HistoryDT
		WHEN 'ImportMessageID' THEN ImportMessageID
		WHEN NULL THEN MessageHistoryID
		WHEN 'MessageHistoryID' THEN MessageHistoryID
		WHEN 'MessageStatus' THEN MessageStatus
	END
	END
	DESC
END
GO

PRINT '-------------------------- Stored Procedures : INSERT --------------------------------'
GO

PRINT 'CREATE PROCEDURE : ImportMessageInsert'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageInsert]
GO

CREATE PROCEDURE [dbo].[BSWXImportMessageInsert]
	@ClientReference varchar(100),
	@ImportDT datetime,
	@MessageStatus tinyint,
	@MessageTypeID tinyint,
	@ProfileID tinyint,
	@XMLMessage xml
AS
BEGIN
	INSERT ImportMessage (
	ClientReference,
	ImportDT,
	MessageStatus,
	MessageTypeID,
	ProfileID,
	XMLMessage
	) VALUES (
	@ClientReference,
	@ImportDT,
	@MessageStatus,
	@MessageTypeID,
	@ProfileID,
	@XMLMessage)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT 'CREATE PROCEDURE : ImportMessageHistoryInsert'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryInsert]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageHistoryInsert]
GO

CREATE PROCEDURE [dbo].[BSWXImportMessageHistoryInsert]
	@Description varchar(200),
	@HistoryDT datetime,
	@ImportMessageID bigint,
	@MessageStatus tinyint
AS
BEGIN
	INSERT ImportMessageHistory (
	Description,
	HistoryDT,
	ImportMessageID,
	MessageStatus
	) VALUES (
	@Description,
	@HistoryDT,
	@ImportMessageID,
	@MessageStatus)
	
	
	
	SELECT SCOPE_IDENTITY()
END
GO

PRINT '-------------------------- Stored Procedures : UPDATE --------------------------------'
GO

PRINT 'CREATE PROCEDURE : ImportMessageUpdate'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageUpdate]
GO

CREATE PROCEDURE [dbo].[BSWXImportMessageUpdate]
	@ClientReference varchar(100)=NULL,
	@ImportDT datetime=NULL,
	@MessageID bigint,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@ProfileID tinyint=NULL,
	@XMLMessage xml=NULL,
	@CheckNull bit=NULL
AS
BEGIN
	IF @CheckNull IS NULL SET @CheckNull=0

	IF @CheckNull=1
	BEGIN
		UPDATE ImportMessage SET
			ClientReference=ISNULL(@ClientReference, ClientReference),
			ImportDT=ISNULL(@ImportDT, ImportDT),
			MessageStatus=ISNULL(@MessageStatus, MessageStatus),
			MessageTypeID=ISNULL(@MessageTypeID, MessageTypeID),
			ProfileID=ISNULL(@ProfileID, ProfileID),
			XMLMessage=ISNULL(@XMLMessage, XMLMessage)
		WHERE
			MessageID=@MessageID
	END
	ELSE
	BEGIN
		UPDATE ImportMessage SET
			ClientReference=@ClientReference,
			ImportDT=@ImportDT,
			MessageStatus=@MessageStatus,
			MessageTypeID=@MessageTypeID,
			ProfileID=@ProfileID,
			XMLMessage=@XMLMessage
		WHERE
			MessageID=@MessageID
	END
END
GO

PRINT 'CREATE PROCEDURE : ImportMessageHistoryUpdate'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryUpdate]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageHistoryUpdate]
GO

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
GO

PRINT '-------------------------- Stored Procedures : DELETE --------------------------------'
GO

PRINT 'CREATE PROCEDURE : ImportMessageDelete'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageDelete]
GO

CREATE PROCEDURE [dbo].[BSWXImportMessageDelete]
	@ClientReference varchar(100)=NULL,
	@ImportDT datetime=NULL,
	@MessageID bigint=NULL,
	@MessageStatus tinyint=NULL,
	@MessageTypeID tinyint=NULL,
	@ProfileID tinyint=NULL,
	@XMLMessage xml=NULL
AS
BEGIN
	DELETE ImportMessage
	WHERE
	(@ClientReference IS NULL OR ClientReference=@ClientReference)
	AND (@ImportDT IS NULL OR ImportDT=@ImportDT)
	AND (@MessageID IS NULL OR MessageID=@MessageID)
	AND (@MessageStatus IS NULL OR MessageStatus=@MessageStatus)
	AND (@MessageTypeID IS NULL OR MessageTypeID=@MessageTypeID)
	AND (@ProfileID IS NULL OR ProfileID=@ProfileID)
	AND (@XMLMessage IS NULL OR XMLMessage=@XMLMessage)
END
GO

PRINT 'CREATE PROCEDURE : ImportMessageHistoryDelete'
GO

IF OBJECT_ID(N'[dbo].[BSWXImportMessageHistoryDelete]', N'P') IS NOT NULL
	DROP PROCEDURE [dbo].[BSWXImportMessageHistoryDelete]
GO

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
GO

