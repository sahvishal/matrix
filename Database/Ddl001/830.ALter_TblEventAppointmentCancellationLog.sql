USE[$(dbName)]
GO

ALTER TABLE TblEventAppointmentCancellationLog
ADD SubReasonId BIGINT NULL

GO

ALTER TABLE TblEventAppointmentCancellationLog
ADD CONSTRAINT [FK_TblEventAppointmentCancellationLog_TblRescheduleCancelDisposition] FOREIGN KEY([SubReasonId])
REFERENCES [TblRescheduleCancelDisposition] ([Id])
GO