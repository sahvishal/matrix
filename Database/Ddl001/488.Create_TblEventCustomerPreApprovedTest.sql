USE [$(dbName)]
Go

CREATE TABLE [dbo].[TblEventCustomerPreApprovedTest](
	[EventCustomerId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,	
 CONSTRAINT [PK_TblEventCustomerPreApprovedTest] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[TestId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventCustomerPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerPreApprovedTest_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
GO


ALTER TABLE [dbo].[TblEventCustomerPreApprovedTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerPreApprovedTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestID])
GO

