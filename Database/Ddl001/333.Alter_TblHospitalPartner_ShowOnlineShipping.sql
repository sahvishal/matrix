
USE [$(dbName)]
GO 

ALTER TABLE dbo.TblHospitalPartner ADD	ShowOnlineShipping bit NOT NULL CONSTRAINT DF_TblHospitalPartner_ShowOnlineShipping DEFAULT 1
Go