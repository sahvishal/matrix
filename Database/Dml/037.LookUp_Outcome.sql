USE [$(dbName)]
Go

update TblLookUp set IsActive = 0 where LookupId = 123

Declare @lookUpTypeId bigint
select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerNotScheduledOutcome'

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (147, @lookUpTypeId, 'NotCalled', 'Not Called', '', 13, getdate(), null, 1, null, 1 )