USE [$(dbName)]
Go

ALTER TABLE dbo.TblClinicalTestQualificationCriteria 
ADD	DisqualifierQuestionId bigint NULL,
DisqualifierQuestionAnswer varchar(50) NULL
	
GO

ALTER TABLE [dbo].[TblClinicalTestQualificationCriteria] ADD  CONSTRAINT [FK_TblClinicalTestQualificationCriteria_TblCustomerHealthQuestions_DisqualifierQuestion] 
							FOREIGN KEY([DisqualifierQuestionId]) REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

