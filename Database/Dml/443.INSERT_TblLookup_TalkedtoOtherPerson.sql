USE [$(dbname)]
GO

DECLARE @LookUptypeId int
SET @LookUptypeId=(SELECT LookupTypeID FROM TblLookupType WHERE Alias='CallStatus')

IF NOT Exists (SELECT * FROM TblLookup WHERE Alias='TalkedtoOtherPerson' AND LookupTypeId = @LookUptypeId)
BEGIN
	INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,	DisplayName,[Description],RelativeOrder,DateCreated,DateModified,DataRecorderCreatorID,	DataRecorderModifierID,	IsActive)
	VALUES(408,@LookUptypeId,'TalkedtoOtherPerson',	'Talked to Other Person','Talked to Other Person',8,GETDATE(),NULL,1,NULL,1)
END



