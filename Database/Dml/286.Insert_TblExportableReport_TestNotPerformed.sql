USE [$(dbName)]
Go

Insert Into TblExportableReports (Id,Name,Alias,CreatedOn) 
	values(33,'Test Not Performed','TestNotPerformed',GETDATE())