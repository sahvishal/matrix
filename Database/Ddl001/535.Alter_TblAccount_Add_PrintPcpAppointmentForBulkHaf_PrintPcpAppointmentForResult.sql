USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD PrintPcpAppointmentForBulkHaf BIT NOT NULL CONSTRAINT DF_TblAccount_PrintPcpAppointmentForBulkHaf DEFAULT 0,
	PrintPcpAppointmentForResult BIT NOT NULL CONSTRAINT DF_TblAccount_PrintPcpAppointmentForResult DEFAULT 0
GO