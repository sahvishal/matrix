USE [$(dbName)]
Go 

CREATE TABLE dbo.TblMolinaAttestation (
	Id [bigint] NOT NULL PRIMARY KEY IDENTITY(1,1),
	EventCustomerResultId [bigint] NOT NULL,
	Icd9Code [varchar] (256) NULL,
	Icd9CodeDescription [varchar] (5120) NULL,
	Icd10Code [varchar] (256) NULL,
	Icd10CodeDescription [varchar] (5120) NULL,
	Condition [varchar] (5120) NULL, 
	StatusId [bigint] NULL, 
	WhyNoDiagnosis [varchar] (5120) NULL,
	DateResolved [datetime] NULL
)

ALTER TABLE [dbo].[TblMolinaAttestation]  WITH CHECK ADD  CONSTRAINT [FK_TblMolinaAttestation_TblEventCustomerResult] FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO

ALTER TABLE [dbo].[TblMolinaAttestation]  WITH CHECK ADD  CONSTRAINT [FK_TblMolinaAttestation_TblLookup] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

--drop table TblMolinaAttestation