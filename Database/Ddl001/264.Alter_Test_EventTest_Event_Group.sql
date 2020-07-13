USE [$(dbName)]
Go

Alter Table TblTest Add GroupId bigint NOT NULL CONSTRAINT DF_TblTest_GroupId DEFAULT 187
GO

Alter Table TblEventTest Add GroupId bigint NOT NULL CONSTRAINT DF_TblEventTest_GroupId DEFAULT 187
GO

Alter Table TblEvents Add FixedGroupScreeningTime int NULL 
GO