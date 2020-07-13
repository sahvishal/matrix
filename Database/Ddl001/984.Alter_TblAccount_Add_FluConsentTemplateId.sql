USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD FluConsentTemplateId BIGINT NULL,
	CONSTRAINT FK_TblAccount_TblFluConsentTemplate FOREIGN KEY ([FluConsentTemplateId]) REFERENCES [TblFluConsentTemplate]([Id])

GO