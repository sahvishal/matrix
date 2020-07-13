USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerProfile ADD 
	GroupName varchar(255) CONSTRAINT [DF_TblCustomerProfile_GroupName]  DEFAULT ('') NOT NULL 
GO
 