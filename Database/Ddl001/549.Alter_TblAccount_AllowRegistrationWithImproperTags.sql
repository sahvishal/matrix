USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD AllowRegistrationWithImproperTags BIT NOT NULL CONSTRAINT DF_TblAccount_AllowRegistrationWithImproperTags DEFAULT 1
GO