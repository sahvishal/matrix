
USE [$(dbName)]
Go
Alter Table TblCustomerEventCriticalTestData Add IsDefaultFollowup bit NOT NULL CONSTRAINT DF_TblCustomerEventCriticalTestData_IsDefaultFollowup DEFAULT 1
GO

Alter Table TblCustomerEventCriticalTestData Add IsPatientReceivedImages bit NOT NULL CONSTRAINT DF_TblCustomerEventCriticalTestData_IsPatientReceivedImages DEFAULT 0
Go

Alter Table TblCustomerEventCriticalTestData Add Symptoms nvarchar(max) null
GO