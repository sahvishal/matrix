USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD CaptureSurvey BIT NOT NULL CONSTRAINT DF_TblAccount_CaptureSurvey DEFAULT 0,
		SurveyPdfFileId bigint NULL
		
GO