USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD GenerateFluPneuConsentForm BIT NOT NULL CONSTRAINT DF_TblAccount_GenerateFluPneuConsentForm DEFAULT 1
		
GO
