USE [$(dbName)]
Go 

IF  EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[dbo].[TblFillEventQueueCriteria]') )
	DROP TABLE [dbo].[TblFillEventQueueCriteria] 
Go