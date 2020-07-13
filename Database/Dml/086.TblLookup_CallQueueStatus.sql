
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'CallQueueStatus', 'Call Queue Status', '', getdate(), getdate() )

Set @lookUpTypeId = @@IDENTITY

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (163, @lookUpTypeId, 'Initial', 'Cancellation', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (164, @lookUpTypeId, 'InProcess', 'In Process', '', 2, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (165, @lookUpTypeId, 'Completed', 'Completed', '', 3, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (166, @lookUpTypeId, 'Removed', 'Removed', '', 4, getdate(), null, 1, null, 1 )

