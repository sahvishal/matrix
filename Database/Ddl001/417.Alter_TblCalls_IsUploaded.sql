USE [$(dbName)]
Go

Alter Table TblCalls Add IsUploaded bit NOT NULL CONSTRAINT DF_TblCalls_IsUploaded DEFAULT 0