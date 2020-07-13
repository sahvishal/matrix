
USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  ADD GenerateBmiReport BIT NOT NULL CONSTRAINT DF_TblAccount_GenerateBmiReport DEFAULT 0
		
GO