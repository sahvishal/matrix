USE [$(dbName)]
GO

Alter Table TblCustomerHealthInfo Add CreatedByOrgRoleUserId bigint null
GO

ALTER TABLE [dbo].[TblCustomerHealthInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfo_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO

Alter Table TblCustomerHealthInfoArchive Add CreatedByOrgRoleUserId bigint null
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchive]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoArchive_TblOrganizationRoleUser] FOREIGN KEY([CreatedByOrgRoleUserId])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserId])
GO