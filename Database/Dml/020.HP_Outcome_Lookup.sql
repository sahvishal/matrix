
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint
select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerScheduledOutcome'

if Not Exists(select * from TblLookup where Alias='ReferredToAffiliatedSpecialist')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (137, @lookUpTypeId, 'ReferredToAffiliatedSpecialist', 'Referred to Affiliated Specialist', '', 9, getdate(), null, 1, null, 1 )
end

if Not Exists(select * from TblLookup where Alias='SelfScheduledWithAffiliatedPhysician')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (138, @lookUpTypeId, 'SelfScheduledWithAffiliatedPhysician', 'Self Scheduled with Affiliated Physician', '', 9, getdate(), null, 1, null, 1 )
end


select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerNotScheduledOutcome'
if Not Exists(select * from TblLookup where Alias='NotReached')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (139, @lookUpTypeId, 'NotReached', 'Not Reached', '', 9, getdate(), null, 1, null, 1 )
end


update TblLookup
set RelativeOrder=3, IsActive=1, Alias='ReferredToAffiliatedPCP', DisplayName='Referred to Affiliated PCP'
where LookupId=121--ReferredToAffiliatedPhysician

update TblLookup
set RelativeOrder=4, IsActive=1
where LookupId=137--ReferredToAffiliatedPhysician

update TblLookup
set RelativeOrder=5, IsActive=1, Alias='SelfScheduledWithNonAffiliatedPhysician', DisplayName='Self Scheduled with Non Affiliated Physician'
where LookupId=122--ScheduledWithNonAffiliatedPhysician

update TblLookup
set RelativeOrder=6, IsActive=1
where LookupId=138--SelfScheduledWithAffiliatedPhysician


update TblLookup
set RelativeOrder=7, IsActive=0
where LookupId=100--Scheduled

update TblLookup
set RelativeOrder=8, IsActive=1
where LookupId=105--NotScheduledSentInformation

update TblLookup
set RelativeOrder=9, IsActive=1
where LookupId=132--NotScheduledNotInterested

update TblLookup
set RelativeOrder=10, IsActive=1
where LookupId=139--NotReached

update TblLookup
set RelativeOrder=11, IsActive=1
where LookupId=123--Other

update TblLookup
set RelativeOrder=12, IsActive=0
where LookupId=101--101