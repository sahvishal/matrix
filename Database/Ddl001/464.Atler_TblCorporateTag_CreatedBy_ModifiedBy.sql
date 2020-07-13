USE [$(dbName)]
GO

Alter table TblCorporateTag add CreatedBy Bigint null, ModifiedBy bigint null, ModifiedOn Datetime null
GO

ALTER TABLE [dbo].[TblCorporateTag]  WITH CHECK ADD  CONSTRAINT [FK_TblCorporateTag_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY(ModifiedBy)
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblCorporateTag]  WITH CHECK ADD  CONSTRAINT [FK_TblCorporateTag_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO