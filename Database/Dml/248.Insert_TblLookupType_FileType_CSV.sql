
USE [$(dbName)]
Go


DECLARE @lookupTypeId BIGINT

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='FileType'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Csv' and LookupTypeId = @lookupTypeId)
BEGIN	
		Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
		values (265, @lookupTypeId, 'Csv', 'Csv', 'File Type: Csv', 1, getdate(), null, 1, null, 1 )
END

