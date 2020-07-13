USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerProfile ADD 
	Copay varchar(50) CONSTRAINT [DF_TblCustomerProfile_Copay]  DEFAULT ('') NOT NULL 
GO
 
