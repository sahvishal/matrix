
USE [$(dbName)]
GO


Alter Table TblCustomerPrimaryCarePhysician Add NPI varchar(50) NULL
GO

Alter Table TblCustomerPrimaryCarePhysician Add Fax varchar(50) NULL
GO


