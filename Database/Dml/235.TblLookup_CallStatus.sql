
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'CallStatus'


Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (242, @lookUpTypeId, 'LeftMessageWithOther', 'Left Message With Other', '', 5, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (243, @lookUpTypeId, 'IncorrectPhoneNumber', 'Incorrect Phone Number', '', 6, getdate(), null, 1, null, 1 )



