
USE [$(dbName)]
Go

Declare @lookUpTypeId bigint


Insert Into TblLookUpType (Alias, DisplayName, Description, DateCreated, DateModified)
values ( 'OnlineScreeningQuestionAnswers', 'Online Screening Question Answers', '', getdate(), getdate() )

SELECT @lookUpTypeId =  SCOPE_IDENTITY();

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (178, @lookUpTypeId, 'Yes', 'Yes', '', 1, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (179, @lookUpTypeId, 'No', 'No', '', 2, getdate(), null, 1, null, 1 )

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (180, @lookUpTypeId, 'DONOTKNOW', 'Don''t know', '', 3, getdate(), null, 1, null, 1 )

