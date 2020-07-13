USE [$(dbName)]
GO

Alter TABLE TblCustomerProfile
ADD  MemberUploadSourceId BIGINT NULL

GO

ALTER TABLE [dbo].[TblCustomerProfile]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerProfile_TblLookUp_MemberUploadSourceId] FOREIGN KEY([MemberUploadSourceId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblCustomerProfile] CHECK CONSTRAINT [FK_TblCustomerProfile_TblLookUp_MemberUploadSourceId]
GO
