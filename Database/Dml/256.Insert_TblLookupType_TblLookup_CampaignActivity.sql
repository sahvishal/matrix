USE [$(dbName)]
Go

Declare @lookUpTypeId bigint


IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'CampaignActivity')
BEGIN
	Insert into TblLookupType (Alias,DisplayName,Description,DateCreated) values('CampaignActivity','Campaign Activity','Campaign Activity',GETDATE())
END

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='CampaignActivity'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'OutboundCall' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (270, @lookUpTypeId, 'OutboundCall', 'Outbound Call', 'Outbound Call', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DirectMail' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (271, @lookUpTypeId, 'DirectMail', 'Direct Mail', 'Direc tMail', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Email' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (272, @lookUpTypeId, 'Email', 'Email', 'Email', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Text' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (273, @lookUpTypeId, 'Text', 'Text', 'Text', 1, getdate(), null, 1, null, 1 )
End
