USE [$(dbName)]
Go 

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblSystemGeneratedCallQueueAssignment_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblSystemGeneratedCallQueueAssignment]'))
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] DROP CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblSystemGeneratedCallQueueAssignment_TblCallQueueCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblSystemGeneratedCallQueueAssignment]'))
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] DROP CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblCallQueueCustomer]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblSystemGeneratedCallQueueAssignment_TblSystemGeneratedCallQueueCriteria]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblSystemGeneratedCallQueueAssignment]'))
ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] DROP CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblSystemGeneratedCallQueueCriteria]
GO
 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblSystemGeneratedCallQueueAssignment]') AND type in (N'U'))
DROP TABLE [dbo].[TblSystemGeneratedCallQueueAssignment]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE TABLE [dbo].[TblSystemGeneratedCallQueueAssignment]( 
	 [CallQueueCustomerId] [bigint] NOT NULL,
	 [CallQueueId] [bigint] NOT NULL,
	 [CriteriaId] [bigint] NOT NULL
 )

ALTER TABLE dbo.TblSystemGeneratedCallQueueAssignment ADD CONSTRAINT
	PK_TblSystemGeneratedCallQueueAssignment PRIMARY KEY CLUSTERED 
	(
	[CallQueueCustomerId] ,[CallQueueId],[CriteriaId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblCallQueueCustomer] FOREIGN KEY([CallQueueCustomerId])
REFERENCES [dbo].[TblCallQueueCustomer] ([CallQueueCustomerId])
GO   

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO 

ALTER TABLE [dbo].[TblSystemGeneratedCallQueueAssignment] ADD  CONSTRAINT [FK_TblSystemGeneratedCallQueueAssignment_TblSystemGeneratedCallQueueCriteria] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[TblSystemGeneratedCallQueueCriteria] ([Id])
GO  
  

 
  --drop table [TblSystemGeneratedCallQueueAssignment]
  