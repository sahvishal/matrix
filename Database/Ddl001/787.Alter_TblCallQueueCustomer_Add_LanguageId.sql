USE [$(dbname)]
GO

ALTER TABLE TblCallQueueCustomer
ADD LanguageId BIGINT NULL,
	CONSTRAINT FK_TblCallQueueCustomer_TblLanguage FOREIGN KEY([LanguageId]) REFERENCES [TblLanguage]([Id])

GO