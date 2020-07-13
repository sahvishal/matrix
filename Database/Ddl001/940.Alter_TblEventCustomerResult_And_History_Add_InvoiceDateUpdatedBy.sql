USE [$(dbName)]
GO

ALTER TABLE TblEventCustomerResult
ADD InvoiceDateUpdatedBy BIGINT NULL,
CONSTRAINT FK_TblEventCustomerResult_TblOrganizationRoleUser_InvoiceDateUpdatedBy FOREIGN KEY(InvoiceDateUpdatedBy) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])
GO


ALTER TABLE TblEventCustomerResultHistory
ADD InvoiceDateUpdatedBy BIGINT NULL,
CONSTRAINT FK_TblEventCustomerResultHistory_TblOrganizationRoleUser_InvoiceDateUpdatedBy FOREIGN KEY(InvoiceDateUpdatedBy) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])
GO