
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='ResultInterpretation'

if Not Exists(select * from TblLookup where Alias='Urgent')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (133, @lookUpTypeId, 'Urgent', 'Urgent', '', 4, getdate(), null, 1, null, 1 )
end

update TblLookup
set RelativeOrder=1
where LookupId=102

update TblLookup
set RelativeOrder=2
where LookupId=102

update TblLookup
set RelativeOrder=3
where LookupId=102
