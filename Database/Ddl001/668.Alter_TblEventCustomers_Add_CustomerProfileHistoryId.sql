use [$(dbname)]
Go

ALTER TABLE TblEventCustomers
	ADD CustomerProfileHistoryId bigInt Null
GO

ALTER TABLE [dbo].[TblEventCustomers]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomers_TblCustomerProfileHistory_Id] FOREIGN KEY([CustomerProfileHistoryId])
REFERENCES [dbo].[TblCustomerProfileHistory] ([Id])
GO

ALTER TABLE [dbo].[TblEventCustomers] CHECK CONSTRAINT [FK_TblEventCustomers_TblCustomerProfileHistory_Id]
GO