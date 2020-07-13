
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint
select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerScheduledOutcome'

if Not Exists(select * from TblLookup where Alias='ScheduledWithEmployedPhysician')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (189, @lookUpTypeId, 'ScheduledWithEmployedPhysician', 'Scheduled with Employed Physician', '', 8, getdate(), null, 1, null, 1 )
end


if Not Exists(select * from TblLookup where Alias='ReferredToEmployedPhysician')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (190, @lookUpTypeId, 'ReferredToEmployedPhysician', 'Referred to Employed Physician', '', 9, getdate(), null, 1, null, 1 )
end

if Not Exists(select * from TblLookup where Alias='SelfScheduledWithEmployedPhysician')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (191, @lookUpTypeId, 'SelfScheduledWithEmployedPhysician', 'Self Scheduled with Employed Physician', '', 10, getdate(), null, 1, null, 1 )
end

--Uninsured
Update TblLookup Set RelativeOrder = 11 where LookupId = 156

Update TblLookup Set RelativeOrder = RelativeOrder + 4 where LookupTypeId = 31