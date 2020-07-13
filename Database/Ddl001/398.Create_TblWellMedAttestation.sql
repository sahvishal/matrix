USE [$(dbName)]
Go 

CREATE TABLE dbo.TblWellMedAttestation (
	Id [bigint] NOT NULL PRIMARY KEY IDENTITY(1,1),
	EventCustomerResultId [bigint] NOT NULL,
	DiagnosisCode [varchar] (512) NULL,
	ReferenceDate [datetime] NULL,
	StatusId [bigint] NULL,
	ProviderSignatureFileID [bigint] NULL,
	FullPrintedName [varchar] (512) NULL,
	DiagnosisDate [datetime] NULL
)

ALTER TABLE [dbo].[TblWellMedAttestation]  WITH CHECK ADD  CONSTRAINT [FK_TblWellMedAttestation_TblEventCustomerResult] FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO

ALTER TABLE [dbo].[TblWellMedAttestation]  WITH CHECK ADD  CONSTRAINT [FK_TblWellMedAttestation_TblFile] FOREIGN KEY([ProviderSignatureFileID])
REFERENCES [dbo].[TblFile] ([FileId])
GO

ALTER TABLE [dbo].[TblWellMedAttestation]  WITH CHECK ADD  CONSTRAINT [FK_TblWellMedAttestation_TblLookup] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
--drop table TblWellMedAttestation