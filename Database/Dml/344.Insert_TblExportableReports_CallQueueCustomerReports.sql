USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (40, 'Call Queue Customer Report', 'CallQueueCustomerReport', GETDATE())
GO