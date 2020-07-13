USE [$(dbName)]
GO

Alter TABLE TblCustomerProfileHistory
ADD  MemberUploadSourceId BIGINT NULL

GO

ALTER TABLE [dbo].[TblCustomerProfileHistory]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfileHistory_TblLookUp_MemberUploadSourceId] FOREIGN KEY([MemberUploadSourceId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblCustomerProfileHistory] CHECK CONSTRAINT [FK_TblCustomerProfileHistory_TblLookUp_MemberUploadSourceId]
GO
