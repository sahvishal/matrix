USE [$(dbName)]
GO
  
Declare @lookUpTypeId bigint

Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'TestGroup', 'Test Group', '', getdate(), getdate() )

Set @lookUpTypeId = @@IDENTITY

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (187, @lookUpTypeId, 'None', 'None', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (188, @lookUpTypeId, 'Ancillary', 'Ancillary', '', 2, getdate(), null, 1, null, 1 )

Go

ALTER TABLE [dbo].[TblTest]  WITH CHECK ADD  CONSTRAINT [FK_TblTest_TblLookUp_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[TblLookUp] ([LookUpId])
GO

ALTER TABLE [dbo].[TblTest] CHECK CONSTRAINT [FK_TblTest_TblLookUp_GroupId]
GO

ALTER TABLE [dbo].[TblEventTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventTest_TblLookUp_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[TblLookUp] ([LookUpId])
GO

ALTER TABLE [dbo].[TblEventTest] CHECK CONSTRAINT [FK_TblEventTest_TblLookUp_GroupId]
GO



