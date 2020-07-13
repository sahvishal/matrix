USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (38, 'Call Queue Scheduling Report', 'CallQueueSchedulingReport', GETDATE())
GO