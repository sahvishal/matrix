USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD ScreeningInfo BIT NOT NULL CONSTRAINT DF_TblAccount_PrintScreeningInfo DEFAULT 0, 
		PatientWorkSheet BIT NOT NULL CONSTRAINT DF_TblAccount_PatientWorkSheet DEFAULT 0 
		
GO

 
 
 