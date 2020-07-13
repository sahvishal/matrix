USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfileHistory
ADD IncorrectPhoneNumberMarkedDate DATETIME NULL, LanguageBarrierMarkedDate DATETIME NULL
