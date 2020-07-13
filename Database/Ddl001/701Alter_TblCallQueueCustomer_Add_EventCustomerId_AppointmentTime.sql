USE [$(dbname)]
GO

ALTER TABLE TblCallQueueCustomer
ADD EventCustomerId BIGINT NULL,
	AppointmentDateTimeWithTimeZone DATETIME NULL,
	CONSTRAINT FK_TblCallQueueCustomers_TblEventCustomers FOREIGN KEY ([EventCustomerId]) REFERENCES [TblEventCustomers]([EventCustomerId])
GO