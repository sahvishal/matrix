USE[$(dbname)]
GO

IF NOT EXISTS (SELECT * FROM TblExportableReports WHERE Alias ='ConfirmationReport')
BEGIN
	INSERT INTO TblExportableReports (Id,Name ,Alias,CreatedOn)
	VALUES (43,'Confirmation Report','ConfirmationReport',GETDATE())
END