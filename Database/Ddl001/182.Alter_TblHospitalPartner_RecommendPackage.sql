
USE [$(dbName)]
GO

Alter Table TblHospitalPartner Add RecommendPackage bit not null Constraint DF_TblHospitalPartner_RecommendPackage default 1
GO

Alter Table TblEventHospitalPartner Add RecommendPackage bit not null Constraint DF_TblEventHospitalPartner_RecommendPackage default 1
GO