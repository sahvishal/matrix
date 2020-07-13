USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

IF NOT EXISTS (Select LookupTypeID from TblLookupType where Alias = 'ExportableReports')
BEGIN
	Insert into TblLookupType (Alias,DisplayName,Description,DateCreated) values('ExportableReports','Exportable Reports','Exportable Reports',GETDATE())
END

SELECT @lookupTypeId= LookupTypeID from TblLookupType where Alias='ExportableReports'

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Pending' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (274, @lookUpTypeId, 'Pending', 'Pending', 'Pending', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'InProgress' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (275, @lookUpTypeId, 'InProgress', 'InProgress', 'InProgress', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Completed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (276, @lookUpTypeId, 'Completed', 'Completed', 'Completed', 1, getdate(), null, 1, null, 1 )
End


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Failed' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
	values (277, @lookUpTypeId, 'Failed', 'Failed', 'Failed', 1, getdate(), null, 1, null, 1 )
End



