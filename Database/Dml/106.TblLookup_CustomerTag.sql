
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'CustomerTag'


Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (177, @lookUpTypeId, 'ArchivedPhysicianPartner', 'Archived Physician Partner', '', 1, getdate(), null, 1, null, 1 )



