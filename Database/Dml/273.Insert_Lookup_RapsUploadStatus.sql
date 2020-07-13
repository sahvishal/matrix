USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'RapsUploadStatus', 'Raps Upload Status', '', getdate(), getdate() )

Set @lookUpTypeId = @@IDENTITY

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (281, @lookUpTypeId, 'Uploaded', 'Upload - Succeeded', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (282, @lookUpTypeId, 'Parsing', 'Parse - In Progress', '', 2, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (283, @lookUpTypeId, 'ParseFailed', 'Parse - Failed', '', 3, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (284, @lookUpTypeId, 'Parsed', 'Parse - Succeeded', '', 4, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (285, @lookUpTypeId, 'InvalidFileFormat', 'Parse - Invalid File Format', '', 5, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (286, @lookUpTypeId, 'FileNotFound', 'Parse - File Not Found', '', 6, getdate(), null, 1, null, 1 )

