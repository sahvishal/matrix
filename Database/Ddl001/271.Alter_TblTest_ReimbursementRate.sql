USE [$(dbName)]
Go
ALTER TABLE dbo.TblTest ADD
	ReimbursementRate decimal(10, 0) NOT NULL CONSTRAINT DF_TblTest_ReimbursementRate DEFAULT 0
GO


ALTER TABLE dbo.TblEventTest ADD
	ReimbursementRate decimal(10, 0) NOT NULL CONSTRAINT DF_TblEventTest_ReimbursementRate DEFAULT 0
GO
