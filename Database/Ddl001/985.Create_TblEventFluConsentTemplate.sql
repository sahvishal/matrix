USE [$(dbName)]
GO

CREATE TABLE TblEventFluConsentTemplate
(
	[EventId] BIGINT NOT NULL,
	[TemplateId] BIGINT NOT NULL,
	CONSTRAINT PK_TblEventFluConsentTemplate PRIMARY KEY ([EventId], [TemplateId]),
	CONSTRAINT FK_TblEventFluConsentTemplate_TblEvents FOREIGN KEY ([EventId]) REFERENCES [TblEvents]([EventId]),
	CONSTRAINT FK_TblEventFluConsentTemplate_TblFluConsentTemplate FOREIGN KEY ([TemplateId]) REFERENCES [TblFluConsentTemplate]([Id])
)

GO