USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalPartnerHospitalFacility_TblHospitalFacility]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalPartnerHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility] DROP CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalFacility]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHospitalPartnerHospitalFacility_TblHospitalPartner]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHospitalPartnerHospitalFacility]'))
ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility] DROP CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalPartner]
GO

/****** Object:  Table [dbo].[TblHospitalPartnerHospitalFacility]    Script Date: 01/02/2014 20:11:20 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblHospitalPartnerHospitalFacility]') AND type in (N'U'))
DROP TABLE [dbo].[TblHospitalPartnerHospitalFacility]
GO

/****** Object:  Table [dbo].[TblHospitalPartnerHospitalFacility]    Script Date: 01/02/2014 20:11:20 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblHospitalPartnerHospitalFacility](
	[HospitalPartnerId] [bigint] NOT NULL,
	[HospitalFacilityId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblHospitalPartnerHospitalFacility] PRIMARY KEY CLUSTERED 
(
	[HospitalPartnerId] ASC,
	[HospitalFacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalFacility] FOREIGN KEY([HospitalFacilityId])
REFERENCES [dbo].[TblHospitalFacility] ([HospitalFacilityId])
GO

ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility] CHECK CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalFacility]
GO

ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalPartner] FOREIGN KEY([HospitalPartnerId])
REFERENCES [dbo].[TblHospitalPartner] ([HospitalPartnerID])
GO

ALTER TABLE [dbo].[TblHospitalPartnerHospitalFacility] CHECK CONSTRAINT [FK_TblHospitalPartnerHospitalFacility_TblHospitalPartner]
GO


