USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD EventLockDaysCount int NULL
		
GO 
 