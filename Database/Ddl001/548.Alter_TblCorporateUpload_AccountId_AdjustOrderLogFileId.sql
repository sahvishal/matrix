USE [$(dbname)]
GO

Drop Table TblEventCustomerAdjustOrderLog


ALTER TABLE TblCorporateUpload ADD AccountId BIGINT NULL
GO

ALTER TABLE TblCorporateUpload
ADD CONSTRAINT FK_TblCorporateUpload_TblAccount_AccountId FOREIGN KEY(AccountId) REFERENCES TblAccount(AccountId)
GO

ALTER TABLE TblCorporateUpload ADD AdjustOrderLogFileId BIGINT NULL
GO

ALTER TABLE TblCorporateUpload
ADD CONSTRAINT FK_TblCorporateUpload_TblFile_AdjustOrderLogFileId FOREIGN KEY(AdjustOrderLogFileId) REFERENCES TblFile(FileId)
GO