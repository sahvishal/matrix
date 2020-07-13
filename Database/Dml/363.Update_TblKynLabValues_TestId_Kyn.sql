USE [$(dbname)]
GO

DECLARE @testId BIGINT
SET @testId = 23

UPDATE TblKynLabValues SET TestId = @testId
GO

ALTER TABLE TblKynLabValues
ALTER COLUMN TestId BIGINT NOT NULL
GO

ALTER TABLE TblKynLabValues
DROP CONSTRAINT PK_TblKynLabValues
GO

ALTER TABLE TblKynLabValues
ADD CONSTRAINT PK_TblKynLabValues PRIMARY KEY (EventCustomerResultId, TestId)
GO