
USE [$(dbName)]
GO 

Alter Table  TblAccount DROP CONSTRAINT DF_TblAccount_GenerateFluPneuConsentForm

Alter Table TblAccount Drop Column GenerateFluPneuConsentForm

ALTER TABLE [dbo].[TblAccount]  
		ADD GenerateFluPneuConsentForm BIT NOT NULL CONSTRAINT DF_TblAccount_GenerateFluPneuConsentForm DEFAULT 0
		
GO