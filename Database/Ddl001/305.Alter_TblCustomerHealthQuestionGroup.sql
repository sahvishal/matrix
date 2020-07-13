USE [$(dbName)]
Go 

ALTER TABLE dbo.TblCustomerHealthQuestionGroup ADD
	IsClinicalQuestions bit NOT NULL CONSTRAINT DF_TblCustomerHealthQuestionGroup_IsClinicalQuestions DEFAULT 0,
	TestId bigint NULL
GO
ALTER TABLE dbo.TblCustomerHealthQuestionGroup ADD CONSTRAINT
	FK_TblCustomerHealthQuestionGroup_TblTest FOREIGN KEY 	(TestId) REFERENCES dbo.TblTest	(TestID)
	
