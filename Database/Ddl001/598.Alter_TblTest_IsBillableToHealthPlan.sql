USE [$(dbname)]
GO

ALTER TABLE TblTest
ADD IsBillableToHealthPlan BIT NOT NULL CONSTRAINT DF_TblTest_IsBillableToHealthPlan DEFAULT(0)
	
GO