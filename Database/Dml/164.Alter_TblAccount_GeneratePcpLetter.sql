USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD GeneratePcpLetter BIT NOT NULL CONSTRAINT DF_TblAccount_GeneratePcpLetter DEFAULT 1 
		
GO
