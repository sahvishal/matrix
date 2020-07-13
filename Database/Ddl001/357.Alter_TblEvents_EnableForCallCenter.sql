USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblEvents]  
		ADD EnableForCallCenter BIT NOT NULL CONSTRAINT DF_TblEvents_EnableForCallCenter DEFAULT 1,
		 EnableForTechnician BIT NOT NULL CONSTRAINT DF_TblEvents_EnableForTechnician DEFAULT 1
GO 