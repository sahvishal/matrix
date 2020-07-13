USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD ShowHafFooter BIT NOT NULL CONSTRAINT DF_TblAccount_ShowHafFooter DEFAULT 1 
		
GO

 
 
 