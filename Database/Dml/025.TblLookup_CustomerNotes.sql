
USE [$(dbName)]
Go

Insert Into TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
values (143, 21, 'PostScreeningFollowUpNote', 'Post Screening FollowUp Note', '', 4, getdate(), null, 1, null, 1 )

