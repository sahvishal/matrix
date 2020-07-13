USE [$(dbname)]
GO

Alter Table TblCustomerProfile Add DoNotContactUpdateDate DateTime NULL
Go

ALTER TABLE TblCustomerProfile
ADD IsDuplicate BIT NOT NULL CONSTRAINT DF_TblCustomerProfile_IsDuplicate DEFAULT 0
GO
