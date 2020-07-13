USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblEventCustomerRequiredTest](
	[EventCustomerId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventCustomerRequiredTest] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblEventCustomerRequiredTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerRequiredTest_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO


ALTER TABLE [dbo].[TblEventCustomerRequiredTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerRequiredTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestID])
GO

GO


