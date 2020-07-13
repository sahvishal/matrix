USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD LockEvent BIT NOT NULL CONSTRAINT DF_TblAccount_LockEvent DEFAULT 0
		
GO

ALTER TABLE [dbo].[TblEvents]  
		ADD IsLocked BIT NOT NULL CONSTRAINT DF_TblEvents_IsLocked DEFAULT 0
		
GO