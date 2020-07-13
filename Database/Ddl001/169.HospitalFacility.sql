USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalFacility_TblHospitalPartner]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalFacility] DROP CONSTRAINT [FK_TblHospitalFacility_TblHospitalPartner]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalFacility_TblOrganizationRoleUser]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalFacility] DROP CONSTRAINT [FK_TblHospitalFacility_TblOrganizationRoleUser]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalFacility_TblTerritory]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalFacility] DROP CONSTRAINT [FK_TblHospitalFacility_TblTerritory]
GO

/****** Object:  Table [dbo].[TblHospitalFacility]    Script Date: 01/02/2014 13:59:16 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]') AND type in (N'U'))
DROP TABLE [dbo].[TblHospitalFacility]
GO

--------------New Hospital facility
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalFacility_TblContract]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalFacility] DROP CONSTRAINT [FK_TblHospitalFacility_TblContract]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalFacility_TblOrganization]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalFacility] DROP CONSTRAINT [FK_TblHospitalFacility_TblOrganization]
GO

/****** Object:  Table [dbo].[TblHospitalFacility]    Script Date: 12/31/2013 16:38:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblHospitalFacility]') AND type in (N'U'))
DROP TABLE [dbo].[TblHospitalFacility]
GO

/****** Object:  Table [dbo].[TblHospitalFacility]    Script Date: 12/31/2013 16:38:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblHospitalFacility](
	[HospitalFacilityId] [bigint] NOT NULL,
	[ContractId] [bigint] NOT NULL,
	[ResultLetterFileId] [bigint] NULL,
	[CannedMessage] varchar(max) NULL
 CONSTRAINT [PK_TblHospitalFacility] PRIMARY KEY CLUSTERED 
(
	[HospitalFacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalFacility_TblOrganization] FOREIGN KEY([HospitalFacilityId])
REFERENCES [dbo].[TblOrganization] ([OrganizationID])
GO

ALTER TABLE [dbo].[TblHospitalFacility] CHECK CONSTRAINT [FK_TblHospitalFacility_TblOrganization]
GO

ALTER TABLE [dbo].[TblHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalFacility_TblContract] FOREIGN KEY([ContractId])
REFERENCES [dbo].[TblContract] ([ContractId])
GO

ALTER TABLE [dbo].[TblHospitalFacility] CHECK CONSTRAINT [FK_TblHospitalFacility_TblContract]
GO

