USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD AttachEawvPreventionPlan BIT NOT NULL CONSTRAINT DF_TblAccount_AttachEawvPreventionPlan DEFAULT 1
		
GO

ALTER TABLE [dbo].[TblAccount]  
		ADD GenerateEawvPreventionPlanReport BIT NOT NULL CONSTRAINT DF_TblAccount_GenerateEawvPreventionPlanReport DEFAULT 0
		
GO
