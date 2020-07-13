USE [$(dbName)]
Go

ALTER TABLE dbo.TblAccountPackage ADD
	IsRecommended bit NOT NULL CONSTRAINT DF_TblAccountPackage_IsRecommended DEFAULT 0
GO

ALTER TABLE dbo.TblHospitalPartnerPackage ADD 
			IsRecommended bit NOT NULL CONSTRAINT DF_TblHospitalPartnerPackage_IsRecommended DEFAULT 0
GO


