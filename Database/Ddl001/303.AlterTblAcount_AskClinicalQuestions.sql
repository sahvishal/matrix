USE [$(dbName)]
Go 

ALTER TABLE dbo.TblAccount ADD
	AskClinicalQuestions bit NOT NULL CONSTRAINT DF_TblAccount_AskClinicalQuestions DEFAULT 0,
	ClinicalQuestionTemplateId bigint NULL
GO

ALTER TABLE dbo.TblAccount ADD CONSTRAINT FK_TblAccount_TblHafTemplate FOREIGN KEY
							(ClinicalQuestionTemplateId) REFERENCES dbo.TblHAFTemplate (HAFTemplateId)
	
GO
