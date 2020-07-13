USE[$(dbName)]

GO

INSERT INTO TblExportableReports
(Id,[Name],Alias,CreatedOn)
VALUES (44,'CallSkippedReport','CallSkippedReport',GETDATE())

GO