USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (39, 'Call Queue Excluded Customer Report', 'CallQueueExcludedCustomerReport', GETDATE())
GO