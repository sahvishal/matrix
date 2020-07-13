USE [$(dbName)]
go

Insert into TblExportableReports (Id,[Name],alias,[CreatedOn])
values (46,'Excluded Customer Report','ExcludedCustomerReport',getdate())