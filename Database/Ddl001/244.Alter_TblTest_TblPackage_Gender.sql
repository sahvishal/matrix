USE [$(dbName)]
Go

ALTER TABLE dbo.TblTest ADD Gender bigint NOT NULL CONSTRAINT DF_TblTest_Gender DEFAULT 184
GO


ALTER TABLE dbo.TblPackage ADD  Gender bigint NOT NULL CONSTRAINT DF_TblPackage_Gender DEFAULT 184
GO


