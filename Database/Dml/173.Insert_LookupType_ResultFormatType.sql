USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'ResultFormatType'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('ResultFormatType', 'Result Format Type', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'PDF' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (222, @lookupTypeId, 'PDF', 'PDF', 'PDF', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'TIFF' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (223, @lookupTypeId, 'TIFF', 'TIFF', 'TIFF', 2, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Both' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (224, @lookupTypeId, 'Both', 'Both', 'Both', 3, getdate(), 1, 1)
END

Go

Update TblAccount set ResultFormatTypeId=222 where AccountID > 0

Alter TABLE TblAccount ALTER COLUMN ResultFormatTypeId bigint NOT NULL

Go