USE [$(dbName)]
GO

ALTER TABLE TblCustomerHealthInfoArchive Add DateCreated DateTime null
GO

UPDATE TblCustomerHealthInfoArchive set DateCreated=ArchiveDate WHERE CustomerHealthInfoArchiveID>1
GO

ALTER TABLE TblCustomerHealthInfoArchive ALTER COLUMN DateCreated DateTime not null
GO
