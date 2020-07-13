
USE [$(dbName)]
Go

Delete from TblCustomerHealthInfoArchive 
Go

Delete from TblCustomerHealthInfo
GO

DBCC CHECKIDENT (TblCustomerHealthInfoArchive, reseed, 1)
go

Alter Table TblCustomerHealthInfoArchive Alter Column EventCustomerId bigint not null
GO

Alter Table TblCustomerHealthInfo Alter Column EventCustomerId bigint not null
GO

IF  EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[dbo].[TblCustomerHealthInfo]') AND name = N'PK_TblCustomerHealthInfo')
ALTER TABLE [dbo].[TblCustomerHealthInfo] DROP CONSTRAINT [PK_TblCustomerHealthInfo]
GO

ALTER TABLE [dbo].[TblCustomerHealthInfo] ADD  CONSTRAINT [PK_TblCustomerHealthInfo] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[CustomerHealthQuestionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

