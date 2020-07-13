
USE [$(dbname)]
GO

DECLARE @LookupTypeId int

IF NOT EXISTS(SELECT 1 FROM TblLookupType Where Alias = 'QuestionnaireType')
	BEGIN
	   INSERT INTO TblLookupType (Alias,DisplayName,[Description],DateCreated)
	   VALUES('QuestionnaireType','Questionnaire Type','Hra and Chat questionnaire type',GETDATE())
	END

    SET @LookupTypeId = (SELECT LookupTypeID FROM TblLookupType Where Alias = 'QuestionnaireType')

If NOT EXISTS (select 1 from TblLookup Where Alias = 'None' and LookupTypeId = @LookupTypeId)
 Begin
	    INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (415,@LookupTypeId,'None','None','None',1,GETDATE(),1,1)	
 End
 
 If Not Exists (select 1 from TblLookup Where Alias = 'HraQuestionnaire' and LookupTypeId = @LookupTypeId)
 Begin
	   INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (416,@LookupTypeId,'HraQuestionnaire','Hra Questionnaire','Hra Questionnaire',2,GETDATE(),1,1)	
 End

 If Not Exists (select 1 from TblLookup Where Alias = 'ChatQuestionnaire' and LookupTypeId = @LookupTypeId)
 Begin
	 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (417,@LookupTypeId,'ChatQuestionnaire','Chat Questionnaire','Chat Questionnaire',3,GETDATE(),1,1)	
 End

 GO


