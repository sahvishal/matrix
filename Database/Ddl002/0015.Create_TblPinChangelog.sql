USE	[$(dbname)]
GO


CREATE TABLE [dbo].[TblPinChangelog](
	[Id] [bigint] IDENTITY(1,1) NOT FOR REPLICATION NOT NULL,
	[TechnicianId] [bigint] NOT NULL,
	[Pin] [varchar](512) NOT NULL,
	[Sequence] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[CreatedByOrgRoleUserId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblPinChangelog] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPinChangelog]  WITH CHECK ADD  CONSTRAINT [FK_TblPinChangelog_OrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblPinChangelog] CHECK CONSTRAINT [FK_TblPinChangelog_OrganizationRoleUser]
GO

ALTER TABLE [dbo].[TblPinChangelog]  WITH CHECK ADD  CONSTRAINT [FK_TblPinChangelog_TblTechnicianProfile] FOREIGN KEY([TechnicianId])
REFERENCES [dbo].[TblTechnicianProfile] ([OrganizationRoleUserId])
GO

ALTER TABLE [dbo].[TblPinChangelog] CHECK CONSTRAINT [FK_TblPinChangelog_TblTechnicianProfile]
GO


