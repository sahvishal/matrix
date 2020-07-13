
USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[DF_TblEventCustomerResult_MoveTopInQueue]') AND type = 'D')
BEGIN
	ALTER TABLE [dbo].[TblEventCustomerResult] DROP CONSTRAINT [DF_TblEventCustomerResult_MoveTopInQueue]	
END
Go
if Exists(select * from sys.columns where Name = N'MoveTopInQueue'  and Object_ID = Object_ID(N'TblEventCustomerResult'))
BEGIN
	ALTER TABLE dbo.TblEventCustomerResult DROP COLUMN MoveTopInQueue
END
GO

Alter Table TblEventCustomerResult Add InQueuePriority bigint null 
GO

