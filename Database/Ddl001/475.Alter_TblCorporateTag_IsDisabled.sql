USE [$(dbName)]
Go

Alter Table TblCorporateTag Add IsDisabled BIT NOT NULL CONSTRAINT DF_TblCorporateTag_IsDisabled DEFAULT 0