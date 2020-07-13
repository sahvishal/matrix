USE [$(dbName)]
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog] DROP CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblNotesDetails]
GO

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblCustomerRegistrationNotes] FOREIGN KEY([NoteId])
REFERENCES [dbo].[TblCustomerRegistrationNotes] ([CustomerRegistrationNotesID])
GO

Alter Table TblEventAppointmentCancellationLog Add RefundRequestId BigInt Null
Go

ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblRefundRequest] FOREIGN KEY([RefundRequestId])
REFERENCES [dbo].[TblRefundRequest] ([RefundRequestId])
GO


--ALTER TABLE [dbo].[TblEventAppointmentCancellationLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblNotesDetails] FOREIGN KEY([NoteId])
--REFERENCES [dbo].[TblNotesDetails] ([NoteID])
--GO

--ALTER TABLE [dbo].[TblEventAppointmentCancellationLog] CHECK CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblNotesDetails]
--GO


