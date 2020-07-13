
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'BestTimeToCall', 'Best Time To Call', '', getdate(), getdate() )

Set @lookUpTypeId = @@IDENTITY

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (157, @lookUpTypeId, 'Morning', 'Morning', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (158, @lookUpTypeId, 'Afternoon', 'Morning', '', 2, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (159, @lookUpTypeId, 'EventIng', 'Morning', '', 3, getdate(), null, 1, null, 1 )

