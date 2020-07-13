use [$(dbName)]
Go

CREATE TABLE TblSurveyTemplateQuestion
(
	TemplateId BIGINT NOT NULL,
	QuestionId BIGINT NOT NULL,
	CONSTRAINT PK_TblSurveyTemplateQuestion PRIMARY KEY (TemplateId, QuestionId),
	CONSTRAINT FK_TblSurveyTemplateQuestion_TblSurveyTemplate FOREIGN KEY(TemplateId) REFERENCES TblSurveyTemplate(Id),
	CONSTRAINT FK_TblSurveyTemplateQuestion_TblSurveyQuestion FOREIGN KEY(QuestionId) REFERENCES TblSurveyQuestion(Id)
)
GO