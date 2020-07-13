USE [$(dbname)]
GO

UPDATE TblAccount SET IsMaxAttemptPerHealthPlan = 1, MaxAttempt = 10 WHERE IsHealthPlan = 1
GO