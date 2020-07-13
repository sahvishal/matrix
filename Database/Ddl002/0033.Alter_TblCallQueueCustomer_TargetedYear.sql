USE [$(dbname)]
GO

ALTER TABLE TblCallQueueCustomer
ADD TargetedYear INT NULL,
	IsTargeted BIT NULL

