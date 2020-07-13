USE [$(dbName)]
Go

Alter Table [TblTempCart] Add EligibilityId bigint null
GO

ALTER TABLE [dbo].[TblTempCart]  WITH CHECK ADD  CONSTRAINT [FK_TblTempCart_TblEligibility] FOREIGN KEY([EligibilityId])
REFERENCES [dbo].[TblEligibility] ([EligibilityId])
GO

Alter Table TblTempCart Add ChargeCardId bigint null
GO

ALTER TABLE [dbo].[TblTempCart]  WITH CHECK ADD  CONSTRAINT [FK_TblTempCart_TblChargeCard] FOREIGN KEY([ChargeCardId])
REFERENCES [dbo].[TblChargeCard] ([ChargeCardId])
GO

