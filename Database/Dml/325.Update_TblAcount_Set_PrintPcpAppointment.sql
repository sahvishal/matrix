USE [$(dbname)]
GO

UPDATE TblAccount SET PrintPcpAppointmentForBulkHaf = 1, PrintPcpAppointmentForResult = 1
WHERE BookPcpAppointment = 1
GO