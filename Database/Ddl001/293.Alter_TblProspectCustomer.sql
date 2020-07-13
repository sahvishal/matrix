USE [$(dbName)]
Go
 
ALTER TABLE dbo.TblProspectCustomer 
	ADD  CallBackRequestedOn  Datetime  Null  ,
	     CallBackRequestedDate  Datetime  Null 
GO
