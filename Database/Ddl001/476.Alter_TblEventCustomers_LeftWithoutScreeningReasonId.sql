USE [$(dbName)]
Go

ALTER TABLE [dbo].[TblEventCustomers] ADD LeftWithoutScreeningReasonId bigint null  CONSTRAINT [FK_TblEventCustomers_TblLookup] FOREIGN KEY(LeftWithoutScreeningReasonId)
REFERENCES [dbo].[TblLookup] (LookupId)

GO