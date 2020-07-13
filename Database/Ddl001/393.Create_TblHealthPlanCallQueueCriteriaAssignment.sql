USE [$(dbName)]
Go 

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueue]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHealthPlanCallQueueCriteriaAssignment]'))
ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] DROP CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueue]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueueCustomer]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHealthPlanCallQueueCriteriaAssignment]'))
ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] DROP CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueueCustomer]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHealthPlanCallQueueCriteriaAssignment_TblSystemGeneratedCallQueueCriteria]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHealthPlanCallQueueCriteriaAssignment]'))
ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] DROP CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblSystemGeneratedCallQueueCriteria]
GO
 
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblHealthPlanCallQueueCriteriaAssignment]') AND type in (N'U'))
DROP TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment]
GO


SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

 CREATE TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment]( 
	 [CallQueueCustomerId] [bigint] NOT NULL,
	 [CallQueueId] [bigint] NOT NULL,
	 [CriteriaId] [bigint] NOT NULL
 )

ALTER TABLE dbo.TblHealthPlanCallQueueCriteriaAssignment ADD CONSTRAINT
	PK_TblHealthPlanCallQueueCriteriaAssignment PRIMARY KEY CLUSTERED 
	(
	[CallQueueCustomerId] ,[CallQueueId],[CriteriaId]
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueueCustomer] FOREIGN KEY([CallQueueCustomerId])
REFERENCES [dbo].[TblCallQueueCustomer] ([CallQueueCustomerId])
GO   

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblCallQueue] FOREIGN KEY([CallQueueId])
REFERENCES [dbo].[TblCallQueue] ([CallQueueId])
GO 

ALTER TABLE [dbo].[TblHealthPlanCallQueueCriteriaAssignment] ADD  CONSTRAINT [FK_TblHealthPlanCallQueueCriteriaAssignment_TblHealthPlanCallQueueCriteria] FOREIGN KEY([CriteriaId])
REFERENCES [dbo].[TblHealthPlanCallQueueCriteria] ([Id])
GO  
  

 
  --drop table [TblHealthPlanCallQueueCriteriaAssignment]
  