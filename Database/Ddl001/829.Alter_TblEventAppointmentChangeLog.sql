USE[$(dbName)]
GO

ALTER TABLE TblEventAppointmentChangeLog
ADD SubReasonId BIGINT NULL

GO

ALTER TABLE TblEventAppointmentChangeLog
ADD CONSTRAINT [FK_TblEventAppointmentChangeLog_TblRescheduleCancelDisposition] FOREIGN KEY([SubReasonId])
REFERENCES [TblRescheduleCancelDisposition] ([Id])
GO
