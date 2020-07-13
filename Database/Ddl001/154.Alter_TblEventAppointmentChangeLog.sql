
USE [$(dbName)]
GO

Alter Table TblEventAppointmentChangeLog Alter Column OldAppointmentTime DateTime null
GO

Alter Table TblEventAppointmentChangeLog Add ReasonId bigint null
GO

Alter Table TblEventAppointmentChangeLog Add Notes varchar(max) null
GO

ALTER TABLE TblEventAppointmentChangeLog  WITH CHECK ADD  CONSTRAINT [FK_TblEventAppointmentChangeLog_TblLookup] FOREIGN KEY(ReasonId)
REFERENCES TblLookup (LookupId)
GO
