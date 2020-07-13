USE [$(dbName)]
Go


Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'CallUploadStatus'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('CallUploadStatus', 'Call Upload Status', 'Call Upload Status', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Uploaded' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (259, @lookupTypeId, 'Uploaded', 'Upload - Succeeded', 'Upload - Succeeded', 1, getdate(), 1, 1)
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Parsing' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (260, @lookupTypeId, 'Parsing', 'Parse - In Progress', 'Parse - In Progress', 2, getdate(), 1, 1)
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'ParseFailed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (261, @lookupTypeId, 'ParseFailed', 'Parse - Failed', 'Parse - Failed', 3, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Parsed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (262, @lookupTypeId, 'Parsed', 'Parse - Succeeded', 'Parse - Succeeded', 4, getdate(), 1, 1)
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'InvalidFileFormat' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (263, @lookupTypeId, 'InvalidFileFormat', 'Parse - Invalid File Format', 'Parse - Invalid File Format', 5, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'FileNotFound' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (264, @lookupTypeId, 'FileNotFound', 'Parse - File Not Found', 'Parse - File Not Found', 6, getdate(), 1, 1)
END
