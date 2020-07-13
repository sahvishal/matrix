
 USE [$(dbname)]
 GO

DECLARE @HraStartDate Datetime, @HraLookupId bigint, @NoneLookupId bigint 
SET @HraLookupId = 416
SET @NoneLookupId = 415 
SET @HraStartDate = '01/01/2015'

	--INSERT INTO TblAccountHraChatQuestionnaire (AccountId, QuestionnaireType, StartDate, EndDate, CreatedOn, CreatedBy)
	--SELECT AccountID, @HraLookupId, @HraStartDate, NULL, GETDATE(), 1  FROM tblAccount where ShowHraQuestionnaire=

	--* Please comment below 2 lines before execute this on Live Server *--
	ALTER TABLE TblAccount
	DROP CONSTRAINT [DF_TblAccount_ShowHRAQuestionnaire], COLUMN ShowHraQuestionnaire
		
GO
