USE[$(dbName)]

GO

INSERT INTO TblExportableReports(Id, [Name], Alias, CreatedOn)
VALUES (45, 'PcpTrackingReport', 'PcpTrackingReport', GETDATE())

GO