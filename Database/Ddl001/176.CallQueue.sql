USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueue_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueue]'))
ALTER TABLE [dbo].[TblCallQueue] DROP CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_CreatedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueue_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueue]'))
ALTER TABLE [dbo].[TblCallQueue] DROP CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_ModifiedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCriteria_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCriteria]'))
ALTER TABLE [dbo].[TblCallQueueCriteria] DROP CONSTRAINT [FK_TblCallQueueCriteria_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCriteria_TblCriteria]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCriteria]'))
ALTER TABLE [dbo].[TblCallQueueCriteria] DROP CONSTRAINT [FK_TblCallQueueCriteria_TblCriteria]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueAssignment_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]'))
ALTER TABLE [dbo].[TblCallQueueAssignment] DROP CONSTRAINT [FK_TblCallQueueAssignment_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueAssignment_TblOrganizationRoleUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]'))
ALTER TABLE [dbo].[TblCallQueueAssignment] DROP CONSTRAINT [FK_TblCallQueueAssignment_TblOrganizationRoleUser]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblProspectCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblProspectCustomer]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblNotesDetails]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblNotesDetails]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblOrganizationRoleUser_CreatedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_CreatedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomer_TblOrganizationRoleUser_ModifiedBy]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]'))
ALTER TABLE [dbo].[TblCallQueueCustomer] DROP CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_ModifiedBy]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomerCall_TblCallQueueCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomerCall]'))
ALTER TABLE [dbo].[TblCallQueueCustomerCall] DROP CONSTRAINT [FK_TblCallQueueCustomerCall_TblCallQueueCustomer]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCallQueueCustomerCall_TblCalls]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomerCall]'))
ALTER TABLE [dbo].[TblCallQueueCustomerCall] DROP CONSTRAINT [FK_TblCallQueueCustomerCall_TblCalls]
GO

----------------------TblCriteria

/****** Object:  Table [dbo].[TblCriteria]    Script Date: 02/11/2014 18:38:58 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCriteria]') AND type in (N'U'))
DROP TABLE [dbo].[TblCriteria]
GO

/****** Object:  Table [dbo].[TblCriteria]    Script Date: 02/11/2014 18:38:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblCriteria](
	[CriteriaId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[IsActive] [bit] NOT NULL
 CONSTRAINT [PK_TblCriteria] PRIMARY KEY CLUSTERED 
(
	[CriteriaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

--------------------------------------------------TblCallQueue

/****** Object:  Table [dbo].[TblCallQueue]    Script Date: 02/11/2014 18:40:43 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueue]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueue]
GO


/****** Object:  Table [dbo].[TblCallQueue]    Script Date: 02/11/2014 18:40:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblCallQueue](
	[CallQueueId] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](2000) NOT NULL,
	[Description] [varchar](max) NULL,
	[Attempts] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblCallQueue] PRIMARY KEY CLUSTERED 
(
	[CallQueueId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblCallQueue]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblCallQueue] CHECK CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_CreatedBy]
GO


ALTER TABLE [dbo].[TblCallQueue]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblCallQueue] CHECK CONSTRAINT [FK_TblCallQueue_TblOrganizationRoleUser_ModifiedBy]
GO

--------------------------------TblCallQueueCriteria

/****** Object:  Table [dbo].[TblCallQueueCriteria]    Script Date: 02/11/2014 20:01:14 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueCriteria]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueCriteria]
GO


/****** Object:  Table [dbo].[TblCallQueueCriteria]    Script Date: 02/11/2014 20:01:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblCallQueueCriteria](
	[CallQueueCriteriaId] [bigint] IDENTITY(1,1) NOT NULL,
	[CallQueueId] [bigint] NOT NULL,
	[CriteriaId] [bigint] NOT NULL,
	[Zipcode] [varchar](10) NOT NULL,
	[Radius] [int] NOT NULL,
	[Condition] [bit] NOT NULL,
	[IsActive] [bit] NOT NULL
 CONSTRAINT [PK_TblCallQueueCriteria] PRIMARY KEY CLUSTERED 
(
	[CallQueueCriteriaId]
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblCallQueueCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCriteria_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO

ALTER TABLE [dbo].[TblCallQueueCriteria] CHECK CONSTRAINT [FK_TblCallQueueCriteria_TblCallQueue]
GO

ALTER TABLE [dbo].[TblCallQueueCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCriteria_TblCriteria] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[TblCriteria] ([CriteriaId])
GO

ALTER TABLE [dbo].[TblCallQueueCriteria] CHECK CONSTRAINT [FK_TblCallQueueCriteria_TblCriteria]
GO

----------------------TblCallQueueAssignment

/****** Object:  Table [dbo].[TblCallQueueAssignment]    Script Date: 02/11/2014 20:03:19 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueAssignment]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueAssignment]
GO

/****** Object:  Table [dbo].[TblCallQueueAssignment]    Script Date: 02/11/2014 20:03:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCallQueueAssignment](
	[CallQueueId] [bigint] NOT NULL,
	[AssignedOrgRoleUserId] [bigint] NOT NULL,
	[Percentage] [int] NOT NULL,
 CONSTRAINT [PK_TblCallQueueAssignment] PRIMARY KEY CLUSTERED 
(
	[CallQueueId] ASC,
	[AssignedOrgRoleUserId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCallQueueAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueAssignment_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO

ALTER TABLE [dbo].[TblCallQueueAssignment] CHECK CONSTRAINT [FK_TblCallQueueAssignment_TblCallQueue]
GO

ALTER TABLE [dbo].[TblCallQueueAssignment]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueAssignment_TblOrganizationRoleUser] FOREIGN KEY([AssignedOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblCallQueueAssignment] CHECK CONSTRAINT [FK_TblCallQueueAssignment_TblOrganizationRoleUser]
GO

---------------------------------------TblCallQueueCustomer

/****** Object:  Table [dbo].[TblCallQueueCustomer]    Script Date: 02/11/2014 20:10:03 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomer]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueCustomer]
GO


/****** Object:  Table [dbo].[TblCallQueueCustomer]    Script Date: 02/11/2014 20:10:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCallQueueCustomer](
	[CallQueueCustomerId] [bigint] IDENTITY(1,1) NOT NULL,
	[CallQueueId] [bigint] NOT NULL,
	[CustomerId] [bigint] NULL,
	[ProspectCustomerId] [bigint] NULL,
	[Status] [bigint] NOT NULL,
	[Attempts] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[NotesId] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[DateModified] [datetime] NULL,
	[CreatedByOrgRoleUserId] [bigint] NULL,
	[ModifiedByOrgRoleUserId] [bigint] NULL,
 CONSTRAINT [PK_TblCallQueueCustomer] PRIMARY KEY CLUSTERED 
(
	[CallQueueCustomerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblCallQueue]
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblProspectCustomer] FOREIGN KEY([ProspectCustomerId])
REFERENCES [dbo].[TblProspectCustomer] ([ProspectCustomerId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblProspectCustomer]
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblNotesDetails] FOREIGN KEY([NotesId])
REFERENCES [dbo].[TblNotesDetails] ([NoteId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblNotesDetails]
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_CreatedBy]
GO

ALTER TABLE [dbo].[TblCallQueueCustomer]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY([ModifiedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomer] CHECK CONSTRAINT [FK_TblCallQueueCustomer_TblOrganizationRoleUser_ModifiedBy]
GO

----------------------TblCallQueueCustomerCall

/****** Object:  Table [dbo].[TblCallQueueCustomerCall]    Script Date: 02/11/2014 20:22:17 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCallQueueCustomerCall]') AND type in (N'U'))
DROP TABLE [dbo].[TblCallQueueCustomerCall]
GO

/****** Object:  Table [dbo].[TblCallQueueCustomerCall]    Script Date: 02/11/2014 20:22:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCallQueueCustomerCall](
	[CallQueueCustomerId] [bigint] NOT NULL,
	[CallId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblCallQueueCustomerCall] PRIMARY KEY CLUSTERED 
(
	[CallQueueCustomerId] ASC,
	[CallId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCallQueueCustomerCall]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomerCall_TblCallQueueCustomer] FOREIGN KEY([CallQueueCustomerId])
REFERENCES [dbo].[TblCallQueueCustomer] ([CallQueueCustomerId])
GO

ALTER TABLE [dbo].[TblCallQueueCustomerCall] CHECK CONSTRAINT [FK_TblCallQueueCustomerCall_TblCallQueueCustomer]
GO

ALTER TABLE [dbo].[TblCallQueueCustomerCall]  WITH CHECK ADD  CONSTRAINT [FK_TblCallQueueCustomerCall_TblCalls] FOREIGN KEY([CallId])
REFERENCES [dbo].[TblCalls] ([CallID])
GO

ALTER TABLE [dbo].[TblCallQueueCustomerCall] CHECK CONSTRAINT [FK_TblCallQueueCustomerCall_TblCalls]
GO