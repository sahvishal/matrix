USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerProfile ADD 
	Lpi varchar(50) CONSTRAINT [DF_TblCustomerProfile_Lpi]  DEFAULT ('') NOT NULL 
GO
 
