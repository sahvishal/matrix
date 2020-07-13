
USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblTag]  
		ADD IsHealthPlanTag BIT NOT NULL CONSTRAINT DF_TblTag_IsHealthPlanTag DEFAULT 0
		
GO