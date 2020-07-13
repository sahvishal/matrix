USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD UseHeaderImage BIT NOT NULL CONSTRAINT DF_TblAccount_UseHeaderImage DEFAULT 1 
		
GO

 
 
 