USE [$(dbName)]
Go

Alter Table TblAccount Add RecommendPackage bit NOT NULL CONSTRAINT DF_TblAccount_RecommendPackage DEFAULT 0
GO

Alter Table TblAccount Add AskPreQualificationQuestion bit NOT NULL CONSTRAINT DF_TblAccount_AskPreQualificationQuestion DEFAULT 0
GO

Alter Table TblHospitalPartner Add AskPreQualificationQuestion bit NOT NULL CONSTRAINT DF_TblHospitalPartner_AskPreQualificationQuestion DEFAULT 0
GO