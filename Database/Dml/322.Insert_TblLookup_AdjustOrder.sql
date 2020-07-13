USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'AdjustOrderStatus')
BEGIN
	insert into TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
		values ('AdjustOrderStatus','Event Customer Adjust Order' ,'Event Customer Adjust Order',getdate(),getdate())
End

select @lookUpTypeId = LookupTypeID from TblLookupType where Alias = 'AdjustOrderStatus'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'AdjustOrder' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (326, @lookUpTypeId, 'AdjustOrder', 'Adjust Order', 'Adjust Order', 1, getdate(), null, 1, null, 1 )
End
IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Inprogress' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (327, @lookUpTypeId, 'Inprogress', 'Inprogress', 'Inprogress', 1, getdate(), null, 1, null, 1 )
End
IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'OrderAdjusted' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (328, @lookUpTypeId, 'OrderAdjusted', 'Order Adjusted', 'Order Adjusted', 1, getdate(), null, 1, null, 1 )
End
