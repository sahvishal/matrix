USE [$(dbName)]
Go

--/****** Object:  Table [dbo].[TblResultContent]    Script Date: 10/15/2012 17:30:19 ******/
--SET ANSI_NULLS ON
--GO

--SET QUOTED_IDENTIFIER ON
--GO

--SET ANSI_PADDING ON
--GO

--CREATE TABLE [dbo].[TblResultContent](
--	[ResultContentId] [bigint] IDENTITY(1,1) NOT NULL,
--	[Title] [varchar](250) NOT NULL,
--	[Summary] [varchar](2000) NOT NULL,
--	[Content] [varchar](max) NOT NULL,
--	[IsActive] [bit] NOT NULL,
--	[DateCreated] [datetime] NOT NULL,
--	[DateModified] [datetime] NULL,
--	[CreatedBy] [bigint] NOT NULL,
--	[ModifiedBy] [bigint] NULL
-- CONSTRAINT [PK_TblResultContent] PRIMARY KEY CLUSTERED 
--(
--	[ResultContentId] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
-- CONSTRAINT [UK_TblResultContent_Title] UNIQUE NONCLUSTERED 
--(
--	[Title] ASC
--)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
--) ON [PRIMARY]

--GO

--SET ANSI_PADDING OFF
--GO

--ALTER TABLE dbo.TblResultContent ADD CONSTRAINT FK_TblResultContent_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) 
--	REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserId) 
	
--GO

--ALTER TABLE dbo.TblResultContent ADD CONSTRAINT FK_TblResultContent_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) 
--	REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserId) 
	
--GO


/****** Object:  Table [dbo].[TblContent]    Script Date: 10/15/2012 17:30:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblContent](
	[ContentId] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](250) NOT NULL,
	[Summary] [varchar](2000) NOT NULL,
	[Content] [varchar](max) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedBy] [bigint] NOT NULL,
	[ModifiedBy] [bigint] NULL
 CONSTRAINT [PK_TblContent] PRIMARY KEY CLUSTERED 
(
	[ContentId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_TblContent_Title] UNIQUE NONCLUSTERED 
(
	[Title] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE dbo.TblContent ADD CONSTRAINT FK_TblContent_TblOrganizationRoleUser_CreatedBy FOREIGN KEY (CreatedBy) 
	REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserId) 
	
GO

ALTER TABLE dbo.TblContent ADD CONSTRAINT FK_TblContent_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY (ModifiedBy) 
	REFERENCES dbo.TblOrganizationRoleUser (OrganizationRoleUserId) 
	
GO

-------------------


IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblResultContent_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblResultContent]'))
ALTER TABLE [dbo].[TblResultContent] DROP CONSTRAINT [FK_TblResultContent_TblOrganizationRoleUser_CreatedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblResultContent_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblResultContent]'))
ALTER TABLE [dbo].[TblResultContent] DROP CONSTRAINT [FK_TblResultContent_TblOrganizationRoleUser_ModifiedBy]
GO

/****** Object:  Table [dbo].[TblResultContent]    Script Date: 10/22/2012 15:41:56 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblResultContent]') AND type in (N'U'))
DROP TABLE [dbo].[TblResultContent]
GO