USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (37, 'Event Archive Stats', 'EventArchiveStats', GETDATE())
GO