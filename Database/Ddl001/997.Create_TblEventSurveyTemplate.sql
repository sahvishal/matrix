USE [$(dbname)]
GO

CREATE TABLE TblEventSurveyTemplate
(
	[EventId] BIGINT NOT NULL,
	[SurveyTemplateId] BIGINT NOT NULL,
	CONSTRAINT PK_TblEventSurveyTemplate PRIMARY KEY([EventId], [SurveyTemplateId]),
	CONSTRAINT FK_TblEventSurveyTemplate_TblEvents FOREIGN KEY([EventId]) REFERENCES [TblEvents](EventID),
	CONSTRAINT FK_TblEventSurveyTemplate_TblSurveyTemplate FOREIGN KEY([SurveyTemplateId]) REFERENCES [TblSurveyTemplate](Id)
)
GO