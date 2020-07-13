USE [$(dbname)]
GO

ALTER TABLE TblTest
DROP constraint DF_TblTest_IsBillableToHealthPlan

ALTER TABLE TblTest
ALTER column IsBillableToHealthPlan BIT NULL

Update TblTest set IsBillableToHealthPlan=Null where IsBillableToHealthPlan=0

GO