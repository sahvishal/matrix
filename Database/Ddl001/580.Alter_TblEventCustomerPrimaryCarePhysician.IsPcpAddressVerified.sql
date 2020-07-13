USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerPrimaryCarePhysician
ADD IsPcpAddressVerified BIT NUll,
PcpAddressVerifiedBy BigInt NUll,
PcpAddressVerifiedOn datetime NULL,	
CONSTRAINT FK_TblEventCustomerPrimaryCarePhysician_TblOrganizationRoleUser_PcpAddressVerifiedBy FOREIGN KEY ([PcpAddressVerifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO


ALTER TABLE TblCustomerPrimaryCarePhysician
ADD IsPcpAddressVerified BIT NUll,
PcpAddressVerifiedBy BigInt NUll,
PcpAddressVerifiedOn datetime NULL,	
CONSTRAINT FK_TblCustomerPrimaryCarePhysician_TblOrganizationRoleUser_PcpAddressVerifiedBy FOREIGN KEY ([PcpAddressVerifiedBy]) REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO
