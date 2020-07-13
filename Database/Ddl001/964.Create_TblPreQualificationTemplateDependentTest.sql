USE [$(dbname)]
GO

CREATE TABLE TblPreQualificationTemplateDependentTest
(
	TemplateId BIGINT NOT NULL,
	TestId BIGINT NOT NULL,
	IsActive BIT NOT NULL CONSTRAINT DF_TblPreQualificationTemplateDependentTest_IsActive DEFAULT (0),
	CONSTRAINT PK_TblPreQualificationTemplateDependentTest PRIMARY KEY (TemplateId, TestId),
	CONSTRAINT FK_TblPreQualificationTemplateDependentTest_TblPreQualificationTestTemplate FOREIGN KEY (TemplateId) REFERENCES [TblPreQualificationTestTemplate]([Id]),
	CONSTRAINT FK_TblPreQualificationTemplateDependentTest_TblTest FOREIGN KEY (TestId) REFERENCES [TblTest]([TestId])
)

GO