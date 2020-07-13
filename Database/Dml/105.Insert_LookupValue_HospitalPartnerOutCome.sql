USE [$(dbName)]
Go

Declare @lookUpTypeIdNotScheduled bigint

select @lookUpTypeIdNotScheduled = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerNotScheduledOutcome'

Update TblLookup Set IsActive=1 where Alias='Other' and LookupTypeId in(@lookUpTypeIdNotScheduled) 	

if Not Exists(select * from TblLookup where Alias='RequiresCallBack')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (176, @lookUpTypeIdNotScheduled, 'RequiresCallBack', 'Requires CallBack', '', 15, getdate(), null, 1, null, 1 )
end