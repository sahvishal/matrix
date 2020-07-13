USE [$(dbName)]
GO 
 

ALTER TABLE [dbo].[TblUserLogin] DROP CONSTRAINT DF_TblUserLogin_Salt

GO