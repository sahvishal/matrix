USE [$(dbName)]
GO
  
Declare @lookUpTypeId bigint

Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'GenerateKynXmlStatus', 'Generate Kyn Xml Status', '', getdate(), getdate() )

Set @lookUpTypeId = @@IDENTITY

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (171, @lookUpTypeId, 'Generate', 'Generate', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (172, @lookUpTypeId, 'InProcess', 'InProcess', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (173, @lookUpTypeId, 'Generated', 'Generated', '', 1, getdate(), null, 1, null, 1 )

