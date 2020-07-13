
USE [$(dbName)]
GO

/****** Object:  Index [NIDX_PhysicianMaster_NPI]    Script Date: 07/14/2014 13:59:58 ******/
IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblPhysicianMaster]') AND name = N'NIDX_PhysicianMaster_NPI')
DROP INDEX [NIDX_PhysicianMaster_NPI] ON [dbo].[TblPhysicianMaster] WITH ( ONLINE = OFF )
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerPrimaryCarePhysician_TblPhysicianMaster]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerPrimaryCarePhysician]'))
ALTER TABLE [dbo].[TblCustomerPrimaryCarePhysician] DROP CONSTRAINT [FK_TblCustomerPrimaryCarePhysician_TblPhysicianMaster]
GO

/****** Object:  Table [dbo].[TblPhysicianMaster]    Script Date: 07/11/2014 19:30:35 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblPhysicianMaster]') AND type in (N'U'))
DROP TABLE [dbo].[TblPhysicianMaster]
GO

/****** Object:  Table [dbo].[TblPhysicianMaster]    Script Date: 07/11/2014 19:46:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblPhysicianMaster](
	[PhysicianMasterID] [bigint] IDENTITY(1,1) NOT NULL,
	[NPI] [varchar](50) NOT NULL,
	[LastName] [varchar](255) NOT NULL,
	[FirstName] [varchar](255) NOT NULL,
	[MiddleName] [varchar](255) NULL,
	[PrefixText] [varchar](255) NULL,
	[SuffixText] [varchar](255) NULL,
	[CredentialText] [varchar](255) NULL,
	[PracticeAddress1] [varchar](500) NULL,
	[PracticeAddress2] [varchar](500) NULL,
	[PracticeCity] [varchar](255) NULL,
	[PracticeState] [varchar](255) NULL,
	[PracticeZip] [varchar](10) NULL,
	[PracticePhone] [varchar](10) NULL,
	[PracticeFax] [varchar](10) NULL,
	[DateCreated] [DateTime] not null,
	[DateModified] [DateTime] NULL,
	[IsImported] [bit] not null,
	[IsActive] [bit] not NULL
 CONSTRAINT [PK_TblPhysicianMaster] PRIMARY KEY CLUSTERED 
(
	[PhysicianMasterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Index [NIDX_PhysicianMaster_NPI]    Script Date: 07/14/2014 13:59:12 ******/
CREATE NONCLUSTERED INDEX [NIDX_PhysicianMaster_NPI] ON [dbo].[TblPhysicianMaster] 
(
	[NPI] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO