USE [$(dbname)]
GO

DELETE FROM TblHealthPlanCriteriaAssignment WHERE StartDate IS NULL
GO