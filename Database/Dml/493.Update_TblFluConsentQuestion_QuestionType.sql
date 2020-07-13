USE [$(dbName)]
GO

update TblFluConsentQuestion 
set  FluConsentQuestionType=423
Where Id in (1,2,3,4,5,6,7,8,9,10,11)


update TblFluConsentQuestion 
set  FluConsentQuestionType=424
Where Id in (12,13,14,15,16,17,18,19,20,21)


ALTER TABLE TblFluConsentQuestion
 Alter Column  FluConsentQuestionType  bigint Not  NULL 



GO

