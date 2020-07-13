USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfileHistory
ADD TargetedYear INT NULL,
	IsTargeted BIT NULL

