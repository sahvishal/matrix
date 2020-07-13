USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'CampaignType')
BEGIN
	Insert into TblLookupType (Alias,DisplayName,Description,DateCreated) values('CampaignType','Campaign Type','Campaign Type',GETDATE())
END

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='CampaignType'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Reatil' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (266, @lookUpTypeId, 'Reatil', 'Reatil', 'Reatil', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Corporate' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (267, @lookUpTypeId, 'Corporate', 'Corporate', 'Corporate', 1, getdate(), null, 1, null, 1 )
End




