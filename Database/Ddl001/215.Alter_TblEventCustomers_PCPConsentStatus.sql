
USE [$(dbName)]
GO

Alter Table TblEventCustomers Add PCPConsentStatus [smallint] NOT NULL Constraint DF_TblEventCustomers_PCPConsentStatus default 0