USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblCallQueue]  
		ADD IsHealthPlan BIT NOT NULL CONSTRAINT DF_TblCallQueue_IsHealthPlan DEFAULT 0
		
GO