USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (47,'Disqualified Test Report','DisqualifiedTestReport',GETDATE())
GO