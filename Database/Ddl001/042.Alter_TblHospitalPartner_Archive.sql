
USE [$(dbName)]
Go

Alter Table TblHospitalPartner Add NormalResultValidityPeriod int not null CONSTRAINT DF_TblHospitalPartner_NormalResultValidityPeriod DEFAULT 0
Go

Alter Table TblHospitalPartner Add AbnormalResultValidityPeriod int not null CONSTRAINT DF_TblHospitalPartner_AbnormalResultValidityPeriod DEFAULT 0
Go

Alter Table TblHospitalPartner Add CriticalResultValidityPeriod int not null CONSTRAINT DF_TblHospitalPartner_CriticalResultValidityPeriod DEFAULT 0
Go