USE [$(dbname)]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCustomerAccountGlocomNumber](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[CallID] [bigint] NOT NULL,
	[GlocomNumber] [nvarchar](50) NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblCustomerAccountGlocomNumber] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblCustomerAccountGlocomNumber]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerAccountGlocomNumber_CallID] FOREIGN KEY([CallID])
REFERENCES [dbo].[TblCalls] ([CallID])
GO

ALTER TABLE [dbo].[TblCustomerAccountGlocomNumber] CHECK CONSTRAINT [FK_TblCustomerAccountGlocomNumber_CallID]
GO

ALTER TABLE [dbo].[TblCustomerAccountGlocomNumber]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerAccountGlocomNumber_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerAccountGlocomNumber] CHECK CONSTRAINT [FK_TblCustomerAccountGlocomNumber_CustomerID]
GO


