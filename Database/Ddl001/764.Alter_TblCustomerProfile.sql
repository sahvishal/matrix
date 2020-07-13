USE [$(dbname)]
GO

ALTER TABLE TblCustomerProfile
ADD IncorrectPhoneNumberMarkedDate DATETIME NULL, LanguageBarrierMarkedDate DATETIME NULL