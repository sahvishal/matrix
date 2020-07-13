USE [$(dbName)]
Go

Alter Table TblEventCustomerResult
 Add RegenerationDate DateTime null,
 RegeneratedBy bigint null constraint FK_TblEventCustomerResult_TblOrganizationRoleUser_RegeneratedBy FOREIGN KEY	(RegeneratedBy) REFERENCES dbo.TblOrganizationRoleUser	(OrganizationRoleUserId)

 go