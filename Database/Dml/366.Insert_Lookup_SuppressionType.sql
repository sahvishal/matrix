USE [$(dbname)]
GO

	DECLARE @LookupTypeId BIGINT

	IF Not Exists ( select * from TblLookupType where Alias = 'SuppressionType')
	BEGIN

		INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
			VALUES ('SuppressionType','Suppression Type','Suppression Type',GETDATE(),GETDATE())
	END

	SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'SuppressionType' 

	IF Not Exists ( select LookupId from TblLookup where Alias = 'LeftVoiceMail' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (344,@LookupTypeId,'LeftVoiceMail','Left Voice Mail',NULL,1,GETDATE(),1,1)
	END

	IF Not Exists ( select LookupId from TblLookup where Alias = 'RefuseCustomer' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (345,@LookupTypeId,'RefuseCustomer','Refused Customer',NULL,2,GETDATE(),1,1)
	END

	IF Not Exists ( select LookupId from TblLookup where Alias = 'Others' and LookupTypeId = @LookupTypeId)
	BEGIN

		INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
				VALUES (346,@LookupTypeId,'Others','Others',NULL,3,GETDATE(),1,1)

	END
	GO
