USE[$(dbname)]
GO

IF NOT EXISTS (SELECT * FROM TblExportableReports WHERE Alias ='CustomerWithNoEventsInAreaReport')
BEGIN
	INSERT INTO TblExportableReports (Id,Name ,Alias,CreatedOn)
	VALUES (41,'Customer With No Events In Area Report','CustomerWithNoEventsInAreaReport', GETDATE())
END