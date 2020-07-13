USE [$(dbName)]
Go

Alter Table TblAccount Add AttachCongitiveClockForm bit NOT NULL CONSTRAINT DF_TblAccount_AttachCongitiveClockForm DEFAULT 0
GO

Alter Table TblAccount Add AttachChronicEvaluationForm bit NOT NULL CONSTRAINT DF_TblAccount_AttachChronicEvaluationForm DEFAULT 0
GO

Alter Table TblAccount Add AttachParicipantConsentForm bit NOT NULL CONSTRAINT DF_TblAccount_AttachParicipantConsentForm DEFAULT 0
GO