USE [$(dbName)]

GO

ALTER Table TblCallQueueCustomer
ADD NoShowDate datetime null
GO

ALTER Table TblEventCustomers
ADD NoShowDate datetime null
GO