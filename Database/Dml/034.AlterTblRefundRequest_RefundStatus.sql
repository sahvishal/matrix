
USE [$(dbName)]
Go

Alter Table TblRefundRequest Add RequestStatus bigint null
Go

Update TblRefundRequest
set RequestStatus = 144
where IsResolved = 0

Update TblRefundRequest
set RequestStatus = 145
where IsResolved = 1

Alter Table TblRefundRequest Alter column RequestStatus bigint Not null
Go

ALTER TABLE [dbo].[TblRefundRequest]  WITH CHECK ADD  CONSTRAINT [FK_TblRefundRequest_TblLookUp] FOREIGN KEY([RequestStatus])
REFERENCES [dbo].[TblLookUp] ([LookUpId])
GO

