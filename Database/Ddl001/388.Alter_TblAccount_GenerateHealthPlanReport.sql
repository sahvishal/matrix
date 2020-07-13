USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD GenerateHealthPlanReport BIT NOT NULL CONSTRAINT DF_TblAccount_GenerateHealthPlanReport DEFAULT 0
		
GO