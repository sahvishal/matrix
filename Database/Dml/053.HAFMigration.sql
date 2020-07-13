USE [$(dbName)]
Go

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]'))
ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] DROP CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers]
GO



/****** Object:  Table [dbo].[TblCustomerHealthInfoArchiveTemp]    Script Date: 01/21/2013 19:01:34 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfoArchiveTemp]') AND type in (N'U'))
DROP TABLE [dbo].[TblCustomerHealthInfoArchiveTemp]
GO



/****** Object:  Table [dbo].[TblCustomerHealthInfoArchiveTemp]    Script Date: 01/21/2013 19:01:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerHealthInfoArchiveTemp](
	[CustomerHealthInfoArchiveID] [bigint] NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[CustomerHealthQuestionID] [bigint] NOT NULL,
	[HealthQuestionAnswer] [nvarchar](4000) NULL,
	[ArchiveDate] [datetime] NULL,
	[Version] [bigint] NOT NULL,
	[EventCustomerId] [bigint] NULL,
 CONSTRAINT [PK_TblCustomerHealthInfoArchiveTemp] PRIMARY KEY CLUSTERED 
(
	[CustomerHealthInfoArchiveID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions] FOREIGN KEY([CustomerHealthQuestionID])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerHealthQuestions]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblCustomerProfile]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblCustomerHealthInfoArchiveTemp] CHECK CONSTRAINT [FK_TblCustomerHealthInfoArchiveTemp_TblEventCustomers]
GO

Insert Into [TblCustomerHealthInfoArchiveTemp]
	([CustomerHealthInfoArchiveID] ,[CustomerID] ,[CustomerHealthQuestionID] ,[HealthQuestionAnswer] ,[ArchiveDate] ,[Version] ,[EventCustomerId])
	
SELECT [CustomerHealthInfoArchiveID] ,[CustomerID] ,[CustomerHealthQuestionID] ,[HealthQuestionAnswer] ,[ArchiveDate] ,[Version] ,[EventCustomerId]
FROM [TblCustomerHealthInfoArchive]
GO

delete from TblCustomerHealthInfoArchiveTemp where CustomerHealthInfoArchiveId in
(
Select CustomerHealthInfoArchiveId from TblCustomerHealthInfoArchiveTemp A
inner join (
select CustomerId, CustomerHealthQuestionId, [version], max(ArchiveDate) ADate
from TblCustomerHealthInfoArchiveTemp 
group by CustomerId, CustomerHealthQuestionId, [version]
having count(*)>1) B
on A.CustomerId = B.CustomerId and A.CustomerHealthQuestionId = B.CustomerHealthQuestionId 
and A.[version] = B.[Version] And A.ArchiveDate <> B.ADate
)