
USE [$(dbName)]
GO

ALTER TABLE TblProspectCustomerCall
ADD CONSTRAINT PK_ProspectCustomerCall PRIMARY KEY (ProspectCustomerId,CallId)
GO

ALTER TABLE TblPackageAvailabilityToRoles
ADD CONSTRAINT PK_PackageAvailabilityToRoles PRIMARY KEY (PackageID,RoleID)
GO

ALTER TABLE TblTestAvailabilityToRoles
ADD CONSTRAINT PK_TestAvailabilityToRoles PRIMARY KEY (TestID,RoleID)
GO

ALTER TABLE TblProspectAddress
ADD CONSTRAINT PK_ProspectAddress PRIMARY KEY (ProspectAddressID)
GO

ALTER TABLE TblCategories
ADD CONSTRAINT PK_Categories PRIMARY KEY (CategoryId)
GO