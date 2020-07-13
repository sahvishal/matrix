USE [$(dbname)]
GO

UPDATE TblPayPeriod SET NumberOfWeeks = DATEDIFF(WEEK, StartDate, EndDate)
GO

ALTER TABLE TblPayPeriod
ALTER COLUMN NumberOfWeeks INT NOT NULL
GO

ALTER TABLE TblPayPeriod
DROP COLUMN EndDate
GO