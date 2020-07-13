USE [$(dbName)]
GO

ALTER TABLE TblFluConsentQuestion
ADD FluConsentQuestionType  bigint  NULL 


ALTER TABLE TblFluConsentQuestion
	ADD CONSTRAINT FK_TblFluConsentQuestion_TblLookup_FluConsentQuestionType FOREIGN KEY (FluConsentQuestionType) REFERENCES TblLookup(LookupId)


GO