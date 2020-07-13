USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoTemp_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblEventCustomers]
GO



/****** Object:  Table [dbo].[TblCustomerHealthInfoTemp]    Script Date: 01/21/2013 18:58:02 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoTemp]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerHealthInfoTemp]
GO



/****** Object:  Table [dbo].[TblCustomerHealthInfoTemp]    Script Date: 01/21/2013 18:58:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerHealthInfoTemp](
	[CustomerID] [bigint] NOT NULL,
	[CustomerHealthQuestionID] [bigint] NOT NULL,
	[HealthQuestionAnswer] [nvarchar](4000) NULL,
	[DateCreated] [datetime] NULL,
	[DateModified] [datetime] NULL,
	[EventCustomerId] [bigint] NULL,
 CONSTRAINT [PK_TblCustomerHealthInfoTemp] PRIMARY KEY CLUSTERED 
(
	[CustomerID] ASC,
	[CustomerHealthQuestionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions] FOREIGN KEY([CustomerHealthQuestionID])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerHealthQuestions]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerProfile] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoTemp_TblEventCustomers]
GO

Insert Into [TblCustomerHealthInfoTemp]
	([CustomerID] ,[CustomerHealthQuestionID] ,[HealthQuestionAnswer] ,[DateCreated] ,[DateModified] ,[EventCustomerId])
	
SELECT [CustomerID] ,[CustomerHealthQuestionID] ,[HealthQuestionAnswer] ,[DateCreated] ,[DateModified] ,[EventCustomerId]
FROM [TblCustomerHealthInfo]


