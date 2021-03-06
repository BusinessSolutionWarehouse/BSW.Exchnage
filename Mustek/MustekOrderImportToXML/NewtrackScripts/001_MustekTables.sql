IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MustekSupplierMapping_ImportSupplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]'))
ALTER TABLE [dbo].[MustekSupplierMapping] DROP CONSTRAINT [FK_MustekSupplierMapping_ImportSupplier]
GO
/****** Object:  Index [IX_MustekSupplierMapping_1]    Script Date: 2013-12-20 11:26:51 AM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND name = N'IX_MustekSupplierMapping_1')
DROP INDEX [IX_MustekSupplierMapping_1] ON [dbo].[MustekSupplierMapping]
GO
/****** Object:  Index [IX_MustekSupplierMapping]    Script Date: 2013-12-20 11:26:51 AM ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND name = N'IX_MustekSupplierMapping')
DROP INDEX [IX_MustekSupplierMapping] ON [dbo].[MustekSupplierMapping]
GO
/****** Object:  Table [dbo].[MustekSupplierMapping]    Script Date: 2013-12-20 11:26:51 AM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND type in (N'U'))
DROP TABLE [dbo].[MustekSupplierMapping]
GO
/****** Object:  Table [dbo].[MustekSupplierMapping]    Script Date: 2013-12-20 11:26:51 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MustekSupplierMapping](
	[SupplierMapID] [int] IDENTITY(1,1) NOT NULL,
	[SupplierCode] [varchar](50) NOT NULL,
	[SupplierName] [varchar](100) NOT NULL,
	[ImportSupplierNo] [int] NOT NULL,
 CONSTRAINT [PK_MustekSupplierMapping] PRIMARY KEY CLUSTERED 
(
	[SupplierMapID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_MustekSupplierMapping]    Script Date: 2013-12-20 11:26:51 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND name = N'IX_MustekSupplierMapping')
CREATE UNIQUE NONCLUSTERED INDEX [IX_MustekSupplierMapping] ON [dbo].[MustekSupplierMapping]
(
	[SupplierCode] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_MustekSupplierMapping_1]    Script Date: 2013-12-20 11:26:51 AM ******/
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]') AND name = N'IX_MustekSupplierMapping_1')
CREATE NONCLUSTERED INDEX [IX_MustekSupplierMapping_1] ON [dbo].[MustekSupplierMapping]
(
	[ImportSupplierNo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MustekSupplierMapping_ImportSupplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]'))
ALTER TABLE [dbo].[MustekSupplierMapping]  WITH NOCHECK ADD  CONSTRAINT [FK_MustekSupplierMapping_ImportSupplier] FOREIGN KEY([ImportSupplierNo])
REFERENCES [dbo].[ImportSupplier] ([ImportSupplierNo])
NOT FOR REPLICATION 
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MustekSupplierMapping_ImportSupplier]') AND parent_object_id = OBJECT_ID(N'[dbo].[MustekSupplierMapping]'))
ALTER TABLE [dbo].[MustekSupplierMapping] CHECK CONSTRAINT [FK_MustekSupplierMapping_ImportSupplier]
GO
