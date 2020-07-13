
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerStatus'

if Not Exists(select * from TblLookup where Alias='LeftVoiceMail2')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (129, @lookUpTypeId, 'LeftVoiceMail2', 'Left Voice Mail 2', '', 5, getdate(), null, 1, null, 1 )
end

if Not Exists(select * from TblLookup where Alias='LeftVoiceMail3')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (130, @lookUpTypeId, 'LeftVoiceMail3', 'Left Voice Mail 3', '', 5, getdate(), null, 1, null, 1 )
end

if Not Exists(select * from TblLookup where Alias='LeftVoiceMail4')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (131, @lookUpTypeId, 'LeftVoiceMail4', 'Left Voice Mail 4', '', 5, getdate(), null, 1, null, 1 )
end

update TblLookUp
set RelativeOrder=1
where Alias = 'NotCalled'

update TblLookUp
set RelativeOrder=2
where Alias = 'TalkedToPerson'

update TblLookUp
set RelativeOrder=3
where Alias = 'LeftVoiceMail'

update TblLookUp
set RelativeOrder=4
where Alias = 'LeftVoiceMail2'

update TblLookUp
set RelativeOrder=5
where Alias = 'LeftVoiceMail3'

update TblLookUp
set RelativeOrder=6
where Alias = 'LeftVoiceMail4'

update TblLookUp
set RelativeOrder=7
where Alias = 'Unreachable'