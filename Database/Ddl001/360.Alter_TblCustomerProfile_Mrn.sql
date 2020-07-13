USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerProfile ADD 
	Mrn varchar(255) CONSTRAINT [DF_TblCustomerProfile_Mrn]  DEFAULT ('') NOT NULL 
GO
 