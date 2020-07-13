USE [$(dbName)]
GO

ALTER TABLE [TblShippingDetail]
Add ShippedByOrgRoleUserId bigint NULL, ModifiedBy bigint NULL, DateModified DateTime NULL;

GO

ALTER TABLE [TblShippingDetail] ADD  CONSTRAINT [FK_TblShippingDetail_TblOrganizationRoleUser_ShippedByOrgRoleUserId] FOREIGN KEY(ShippedByOrgRoleUserId)
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)

Go

ALTER TABLE [TblShippingDetail] ADD  CONSTRAINT [FK_TblShippingDetail_TblOrganizationRoleUser_ModifiedBy] FOREIGN KEY(ModifiedBy)
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)

GO