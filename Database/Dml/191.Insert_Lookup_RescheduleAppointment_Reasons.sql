USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'RescheduleReason'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('RescheduleReason', 'Reschedule Reason', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DeceasedOrILL' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (229, @lookupTypeId, 'DeceasedOrILL', 'Deceased or ILL', 'DeceasedOrILL', 7, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Emergency' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (230, @lookupTypeId, 'Emergency', 'Emergency', 'Emergency', 8, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'AgentMistakeTraining' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (231, @lookupTypeId, 'AgentMistakeTraining', 'Agent Mistake/Training', 'Agent Mistake/Training', 9, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HealthFairReason' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (232, @lookupTypeId, 'HealthFairReason', 'HealthFair Reason', 'HealthFair Reason', 10, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'FieldEventIssue' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (233, @lookupTypeId, 'FieldEventIssue', 'Field/Event Issue', 'Field/Event Issue', 11, getdate(), 1, 1)
END

IF EXISTS (Select LookUpId from TblLookup where Alias = 'Other' and LookupTypeId = @lookupTypeId)
BEGIN
	Update TblLookUp set RelativeOrder=12 where Alias = 'Other' and LookupTypeId = @lookupTypeId	
END
