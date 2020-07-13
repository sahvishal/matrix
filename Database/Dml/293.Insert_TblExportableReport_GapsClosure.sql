USE [$(dbName)]
Go

Insert Into TblExportableReports (Id,Name,Alias,CreatedOn) 
	values(34,'Gaps Closure','GapsClosure',GETDATE())