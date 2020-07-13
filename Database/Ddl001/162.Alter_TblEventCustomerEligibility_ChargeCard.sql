
USE [$(dbName)]
GO

Alter Table [TblEventCustomerEligibility] add ChargeCardId bigint null
GO

ALTER TABLE [dbo].[TblEventCustomerEligibility]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerEligibility_TblChargeCard] FOREIGN KEY([ChargeCardId])
REFERENCES [dbo].[TblChargeCard] ([ChargeCardId])
GO
