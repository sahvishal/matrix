USE [$(dbname)]
GO

ALTER TABLE TblCallQueueCustomer
ADD IncorrectPhoneNumberMarkedDate DATETIME NULL, LanguageBarrierMarkedDate DATETIME NULL
go