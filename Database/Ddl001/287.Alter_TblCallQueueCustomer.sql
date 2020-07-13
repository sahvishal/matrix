USE [$(dbName)]
Go

ALTER TABLE TblCallQueueCustomer ALTER COLUMN AssignedToOrgRoleUserId Bigint NULL
Go
ALTER TABLE TblCallQueueCustomer ALTER COLUMN CallQueueCriteriaId Bigint NULL
Go