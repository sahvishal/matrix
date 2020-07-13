
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint
select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerScheduledOutcome'

if Not Exists(select * from TblLookup where Alias='Uninsured')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (156, @lookUpTypeId, 'Uninsured', 'Uninsured', '', 14, getdate(), null, 1, null, 1 )
end