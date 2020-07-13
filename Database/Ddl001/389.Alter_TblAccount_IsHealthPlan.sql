USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD IsHealthPlan BIT NOT NULL CONSTRAINT DF_TblAccount_IsHealthPlan DEFAULT 0
		
GO