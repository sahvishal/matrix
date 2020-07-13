USE [$(dbname)]
GO

UPDATE TblAccount SET EnableSms = 1, MaximumSms = 1
GO

UPDATE TblAccount SET MaximumSms = 3 WHERE IsHealthPlan = 1
GO