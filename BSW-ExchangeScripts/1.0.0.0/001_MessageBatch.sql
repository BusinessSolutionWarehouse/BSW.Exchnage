IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ImportMessageBatch_BatchStartDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ImportMessageBatch] DROP CONSTRAINT [DF_ImportMessageBatch_BatchStartDT]
END

GO
/****** Object:  Index [IX_ImportMessageBatch]    Script Date: 2013-07-08 01:02:46 PM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageBatch]') AND name = N'IX_ImportMessageBatch')
DROP INDEX [IX_ImportMessageBatch] ON [dbo].[ImportMessageBatch]
GO
/****** Object:  Table [dbo].[ImportMessageBatch]    Script Date: 2013-07-08 01:02:46 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageBatch]') AND type in (N'U'))
DROP TABLE [dbo].[ImportMessageBatch]
GO
/****** Object:  Table [dbo].[ImportMessageBatch]    Script Date: 2013-07-08 01:02:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageBatch]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ImportMessageBatch](
	[ImportBatchID] [bigint] IDENTITY(1,1) NOT NULL,
	[BatchUniqueKey] [varchar](50) NOT NULL,
	[BatchStartDT] [datetime] NOT NULL,
	[BatchCompleteDT] [datetime] NULL,
 CONSTRAINT [PK_ImportMessageBatch] PRIMARY KEY CLUSTERED 
(
	[ImportBatchID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_ImportMessageBatch]    Script Date: 2013-07-08 01:02:46 PM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[ImportMessageBatch]') AND name = N'IX_ImportMessageBatch')
CREATE UNIQUE NONCLUSTERED INDEX [IX_ImportMessageBatch] ON [dbo].[ImportMessageBatch]
(
	[BatchUniqueKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[DF_ImportMessageBatch_BatchStartDT]') AND type = 'D')
BEGIN
ALTER TABLE [dbo].[ImportMessageBatch] ADD  CONSTRAINT [DF_ImportMessageBatch_BatchStartDT]  DEFAULT (getdate()) FOR [BatchStartDT]
END

GO



Insert Into ImportMessageBatch(BatchUniqueKey)
Select Distinct T.OrderNo From 
(select T.N.value('OrderNo[1]','varchar(20)') As OrderNo,M.MessageID From ImportMessage AS M
cross apply M.XMLMessage.nodes('/Message/MessageBody/Order') as T(N)) T
Group By T.OrderNo
GO

Update M Set M.ImportBatchID = B.ImportBatchID
 from ImportMessageBatch B
Inner Join
 (select T.N.value('OrderNo[1]','varchar(20)') As OrderNo,M.MessageID From ImportMessage AS M
cross apply M.XMLMessage.nodes('/Message/MessageBody/Order') as T(N)) T
On T.OrderNo = B.BatchUniqueKey
Inner Join ImportMessage M On M.MessageID = T.MessageID
GO

Update M Set M.MessageVersion = S.seq 
From 
ImportMessage M
Inner Join
(Select MessageID, ImportBatchID ,row_number() over(partition by ImportBatchID order by ImportBatchID) as seq from ImportMessage)
 S on S.MessageID = M.MessageID
GO

