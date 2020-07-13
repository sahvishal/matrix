USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (35, 'Event Report', 'EventReport', GETDATE())
GO