USE [$(dbName)]
Go

Declare @lookUpTypeId bigint


IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'CampaignMode')
BEGIN
	Insert into TblLookupType (Alias,DisplayName,Description,DateCreated) values('CampaignMode','Campaign Mode','Campaign Mode',GETDATE())
END

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='CampaignMode'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Inbound' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (268, @lookUpTypeId, 'Inbound', 'Inbound', 'Inbound', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Outbound' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (269, @lookUpTypeId, 'Outbound', 'Outbound', 'Outbound', 1, getdate(), null, 1, null, 1 )
End