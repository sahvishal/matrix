USE	[$(dbname)]
GO

Alter TABLE TblCustomerProfile
ADD ProductTypeId BIGINT NULL
GO

ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblLookUp_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblCustomerProfile] CHECK CONSTRAINT [FK_TblCustomerProfile_TblLookUp_ProductTypeId]
GO


Alter TABLE TblCustomerProfileHistory
ADD ProductTypeId BIGINT NULL
GO

ALTER TABLE [dbo].[TblCustomerProfileHistory]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfileHistory_TblLookUp_ProductTypeId] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblCustomerProfileHistory] CHECK CONSTRAINT [FK_TblCustomerProfileHistory_TblLookUp_ProductTypeId]
GO


