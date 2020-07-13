USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'NotInterestedReason')
BEGIN
	Insert into TblLookupType (Alias,DisplayName,Description,DateCreated) values('NotInterestedReason','Not Interested Reason','Not Interested Reason',GETDATE())
END

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='NotInterestedReason'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'CustomerRefused' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (278, @lookUpTypeId, 'CustomerRefused', 'Customer Refused', 'Customer Refused', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DontHaveInsurance' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (279, @lookUpTypeId, 'DontHaveInsurance', 'Don''t have insurance', 'Don''t have insurance', 2, getdate(), null, 1, null, 1 )
End