
USE [$(dbName)]
Go

---------------------------Scheduled Outcome--------------------------------------

Update TblLookupType set alias ='HospitalPartnerCustomerScheduledOutcome', DisplayName ='Hospital Partner Customer Scheduled Outcome'
where LookupTypeId=24--HospitalPartnerCustomerOutcome

update TblLookup
set Alias='ScheduledWithAffiliatedPCP', DisplayName = 'Scheduled with Affiliated PCP', RelativeOrder=1
where LookupId=119--ScheduledWithPCP

update TblLookup
set Alias='ScheduledWithAffiliatedSpecialist', DisplayName = 'Scheduled with Affiliated Specialist', RelativeOrder=2
where LookupId=120--ScheduledWithSpecialist

update TblHospitalPartnerCustomer Set Outcome=121 where Outcome=122

update TblLookup
set Alias='ReferredToAffiliatedPhysician', DisplayName= 'Referred to Affiliated Physician', RelativeOrder=3
where LookupId=121--ReferredToPCP

update TblLookup
set Alias='ScheduledWithNonAffiliatedPhysician', DisplayName = 'Scheduled with Non Affiliated Physician', RelativeOrder=4
where LookupId=122--ReferredToSpecialist

update TblLookup
set RelativeOrder=5,IsActive=0
where LookupId=100--Scheduled

-----------------------------------------------Not Scheduled outcome-----------------------------------------------------------------------------------
Declare @lookUpTypeId bigint

--set @lookUpTypeId=24
If Not Exists(select * from TblLookupType where Alias='HospitalPartnerCustomerNotScheduledOutcome')
begin
	Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
	values ( 'HospitalPartnerCustomerNotScheduledOutcome', 'Hospital Partner Customer Not Scheduled Outcome', '', getdate(), getdate() )

	Set @lookUpTypeId = @@IDENTITY
end
else
begin
	select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerNotScheduledOutcome'
end

update TblLookup
set Alias='NotScheduledSentInformation', DisplayName = 'Not Scheduled / Sent Information', LookupTypeId=@lookUpTypeId, RelativeOrder=6
where LookupId=105--SentInformation

if Not Exists(select * from TblLookup where Alias='NotScheduledNotInterested')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (132, @lookUpTypeId, 'NotScheduledNotInterested', 'Not Scheduled / Not Interested', '', 7, getdate(), null, 1, null, 1 )
end
else
begin
	update TblLookup
	set Alias='NotScheduledNotInterested', DisplayName = 'Not Scheduled / Not Interested', LookupTypeId=@lookUpTypeId, RelativeOrder=7
	where LookupId=132--NotScheduledNot Interested
end

update TblLookup
set LookupTypeId=@lookUpTypeId, RelativeOrder=8, IsActive=0
where LookupId=101--NotScheduled

update TblLookup
set LookupTypeId=@lookUpTypeId, RelativeOrder=9, IsActive=0
where LookupId=123--Other