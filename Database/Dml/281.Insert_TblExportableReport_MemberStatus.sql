USE [$(dbName)]
Go

Insert Into TblExportableReports (Id,Name,Alias,CreatedOn) 
	values(32,'Member Status Report','MemberStatusReport',GETDATE())