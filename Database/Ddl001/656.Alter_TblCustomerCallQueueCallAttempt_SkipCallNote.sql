USE [$(dbname)]
GO

Alter table TblCustomerCallQueueCallAttempt
add SkipCallNote varchar(5000);