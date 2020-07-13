USE [$(dbName)]
GO

Alter Table TblCustomerProfile Add IsLanguageBarrier bit NOT NULL Constraint DF_TblCustomerProfile_IsLanguageBarrier default 0
GO
