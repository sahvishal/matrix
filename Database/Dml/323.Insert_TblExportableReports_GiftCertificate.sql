USE [$(dbname)]
GO

INSERT INTO TblExportableReports (Id, Name, Alias, CreatedOn)
VALUES (36, 'Gift Certificate', 'GiftCertificate', GETDATE())
GO