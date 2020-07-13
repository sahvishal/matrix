USE [$(dbname)]
GO

ALTER TABLE TblHealthPlanCallQueueCriteria
ADD LanguageId BIGINT NULL,
	CONSTRAINT FK_TblHealthPlanCallQueueCriteria_TblLanguage FOREIGN KEY([LanguageId]) REFERENCES [TblLanguage]([Id])

GO