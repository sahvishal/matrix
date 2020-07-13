
USE [$(dbName)]
GO

Alter Table TblAccount Add SendAppointmentMail bit NOT NULL Constraint DF_TblAccount_SendAppointmentMail default 0