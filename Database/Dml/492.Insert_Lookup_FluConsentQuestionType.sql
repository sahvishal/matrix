USE [$(dbname)]
GO

DECLARE @LookupTypeId int

IF NOT EXISTS(SELECT 1 FROM TblLookupType Where Alias = 'FluConsentQuestionType')
	BEGIN
	   INSERT INTO TblLookupType (Alias,DisplayName,[Description],DateCreated)
	   VALUES('FluConsentQuestionType','FluConsentQuestionType','Flu Consent Question Type',GETDATE())
	END

    SET @LookupTypeId = (SELECT LookupTypeID FROM TblLookupType Where Alias = 'FluConsentQuestionType')
	
If NOT EXISTS (select 1 from TblLookup Where Alias = 'CustomerQuestion' and LookupTypeId = @LookupTypeId)
 Begin
	    INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (423,@LookupTypeId,'CustomerQuestion','CustomerQuestion','CustomerQuestion',1,GETDATE(),1,1)	
 End
 
 If Not Exists (select 1 from TblLookup Where Alias = 'ClinicalQuestion' and LookupTypeId = @LookupTypeId)
 Begin
	   INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (424,@LookupTypeId,'ClinicalQuestion','ClinicalQuestion','ClinicalQuestion',2,GETDATE(),1,1)	
 End
 
 GO
 