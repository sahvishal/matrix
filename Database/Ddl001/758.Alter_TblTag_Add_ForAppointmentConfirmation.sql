USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD ForAppointmentConfirmation BIT NOT NULL CONSTRAINT DF_TblTag_ForAppointmentConfirmation DEFAULT 0
GO