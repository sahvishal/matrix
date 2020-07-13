USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerProfile ADD 
	Market varchar(255) CONSTRAINT [DF_TblCustomerProfile_Market]  DEFAULT ('') NOT NULL 
GO
 