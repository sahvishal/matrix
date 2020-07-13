USE [$(dbName)]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventHospitalFacility_TblEvents]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventHospitalFacility]'))
ALTER TABLE [dbo].[TblEventHospitalFacility] DROP CONSTRAINT [FK_TblEventHospitalFacility_TblEvents]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblEventHospitalFacility_TblHospitalFacility]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblEventHospitalFacility]'))
ALTER TABLE [dbo].[TblEventHospitalFacility] DROP CONSTRAINT [FK_TblEventHospitalFacility_TblHospitalFacility]
GO

/****** Object:  Table [dbo].[TblEventHospitalFacility]    Script Date: 01/02/2014 20:19:01 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblEventHospitalFacility]') AND type in (N'U'))
DROP TABLE [dbo].[TblEventHospitalFacility]
GO


/****** Object:  Table [dbo].[TblEventHospitalFacility]    Script Date: 01/02/2014 20:19:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblEventHospitalFacility](
	[EventId] [bigint] NOT NULL,
	[HospitalFacilityId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventHospitalFacility] PRIMARY KEY CLUSTERED 
(
	[EventId] ASC,
	[HospitalFacilityId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblEventHospitalFacility_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblEventHospitalFacility] CHECK CONSTRAINT [FK_TblEventHospitalFacility_TblEvents]
GO

ALTER TABLE [dbo].[TblEventHospitalFacility]  WITH CHECK ADD  CONSTRAINT [FK_TblEventHospitalFacility_TblHospitalFacility] FOREIGN KEY([HospitalFacilityId])
REFERENCES [dbo].[TblHospitalFacility] ([HospitalFacilityId])
GO

ALTER TABLE [dbo].[TblEventHospitalFacility] CHECK CONSTRAINT [FK_TblEventHospitalFacility_TblHospitalFacility]
GO


