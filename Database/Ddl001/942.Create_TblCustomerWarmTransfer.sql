USE [$(dbName)]
GO


CREATE TABLE TblCustomerWarmTransfer
(
Id BIGINT NOT NULL IDENTITY(1,1),
CustomerId BIGINT NOT NULL,
WarmTransferYear INT NOT NULL,
IsWarmTransfer BIT NULL,
CreatedBy BIGINT NOT NULL,
DateCreated DATETIME NOT NULL,
ModifiedBy BIGINT NULL,
DateModified DATETIME null,
)

GO

ALTER TABLE TblCustomerWarmTransfer
ADD CONSTRAINT PK_TblCustomerWarmTransfer PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO

ALTER TABLE TblCustomerWarmTransfer
ADD CONSTRAINT FK_TblCustomerWarmTransfer_TblCustomerProfile_CustomerId
FOREIGN KEY (CustomerId)
REFERENCES [TblCustomerProfile](CustomerId)
GO

ALTER TABLE TblCustomerWarmTransfer
ADD CONSTRAINT FK_TblCustomerWarmTransfer_TblOrganizationRoleUser_CreatedBy
FOREIGN KEY ([CreatedBy])
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)
GO

ALTER TABLE TblCustomerWarmTransfer
ADD CONSTRAINT FK_TblCustomerWarmTransfer_TblOrganizationRoleUser_ModifiedBy
FOREIGN KEY (ModifiedBy)
REFERENCES [TblOrganizationRoleUser](OrganizationRoleUserID)
GO