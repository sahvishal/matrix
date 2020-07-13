USE[$(dbname)]
GO

IF NOT EXISTS (SELECT * FROM TblExportableReports WHERE Alias ='CallCenterCallReport')
BEGIN
	INSERT INTO TblExportableReports (Id,Name ,Alias,CreatedOn)
	VALUES (42,'Call Center Call Report','CallCenterCallReport',GETDATE())
END