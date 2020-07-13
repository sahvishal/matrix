

USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='HospitalPartnerCustomerStatus'


if Not Exists(select * from TblLookup where Alias='Voicemail5')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (134, @lookUpTypeId, 'Voicemail5', 'Voicemail 5', '', 7, getdate(), null, 1, null, 1 )
end


if Not Exists(select * from TblLookup where Alias='Voicemail6')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (135, @lookUpTypeId, 'Voicemail6', 'Voicemail 6', '', 8, getdate(), null, 1, null, 1 )
end


if Not Exists(select * from TblLookup where Alias='MailedEmailed')
begin
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (136, @lookUpTypeId, 'MailedEmailed', 'Mailed / Emailed', '', 9, getdate(), null, 1, null, 1 )
end

update TblLookUp
set RelativeOrder=10
where Alias = 'Unreachable'