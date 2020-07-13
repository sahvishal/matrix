USE [$(dbname)]
GO

ALTER TABLE TblKynLabValues
ADD TestId BIGINT NULL,
	CONSTRAINT FK_TblKynLabValues_TblTest FOREIGN KEY(TestId) REFERENCES [TblTest](TestId)
GO