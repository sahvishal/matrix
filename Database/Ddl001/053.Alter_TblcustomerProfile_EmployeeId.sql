
USE [$(dbName)]
Go

Alter Table TblCustomerProfile Add EmployeeId varchar(100) null
GO

Alter Table TblCustomerProfile add InsuranceId varchar(100) null
Go