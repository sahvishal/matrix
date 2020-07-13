USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD EventConfirmationBeforeDays INT NULL	
GO