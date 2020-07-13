
USE [$(dbName)]
GO

Alter Table TblUser Alter Column SSN varchar(255) NULL
Go

Alter Table TblHospitalPartner Add CaptureSsn bit not null Constraint DF_TblHospitalPartner_CaptureSsn default 0
GO

Alter Table TblEventHospitalPartner Add CaptureSsn bit not null Constraint DF_TblEventHospitalPartner_CaptureSsn default 0
GO