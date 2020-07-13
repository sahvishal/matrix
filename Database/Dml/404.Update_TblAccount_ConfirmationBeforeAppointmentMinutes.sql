USE [$(dbname)]
GO

UPDATE TblAccount SET ConfirmationBeforeAppointmentMinutes = 60 WHERE IsHealthPlan = 1
GO
