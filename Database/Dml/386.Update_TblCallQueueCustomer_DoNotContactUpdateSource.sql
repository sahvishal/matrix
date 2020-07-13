USE [$(dbname)]
GO

UPDATE TblCallQueueCustomer SET DoNotContactUpdateSource = 348
WHERE CustomerId IN
(
	SELECT CustomerId from TblCustomerProfile
	WHERE DoNotContactUpdateSource = 348
)
GO


UPDATE TblCallQueueCustomer SET DoNotContactUpdateSource = 349
WHERE CustomerId IN
(
	SELECT CustomerId from TblCustomerProfile
	WHERE DoNotContactUpdateSource = 349
)
GO