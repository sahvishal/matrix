USE [$(dbName)]
GO

ALTER TABLE TblAccount 
ADD SurveyTemplateId BIGINT null,
	CONSTRAINT FK_TblAccount_TblSurveyTemplate_SurveyTemplateId FOREIGN KEY (SurveyTemplateId) REFERENCES TblSurveyTemplate(Id)
	
GO