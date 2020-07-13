USE [$(dbname)]
GO

ALTER TABLE TblEventCustomerResult
ADD IsRevertedToEvaluation BIT NOT NULL CONSTRAINT DF_TblEventCustomerResult_IsRevertedToEvaluation DEFAULT 0,
	IsPennedBack BIT NOT NULL CONSTRAINT DF_TblEventCustomerResult_IsPennedBack DEFAULT 0
GO