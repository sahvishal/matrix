USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'CancellationReason'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('CancellationReason', 'Cancellation Reason', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DeceasedOrILL' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (234, @lookupTypeId, 'DeceasedOrILL', 'Deceased or ILL', 'Deceased or ILL', 7, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Emergency' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (235, @lookupTypeId, 'Emergency', 'Emergency', 'Emergency', 8, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'AgentMistakeTraining' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (236, @lookupTypeId, 'AgentMistakeTraining', 'Agent Mistake/Training', 'Agent Mistake/Training', 9, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HealthFairReason' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (237, @lookupTypeId, 'HealthFairReason', 'HealthFair Reason', 'HealthFair Reason', 10, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'FieldEventIssue' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (238, @lookupTypeId, 'FieldEventIssue', 'Field/Event Issue', 'Field/Event Issue', 11, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HealthPlanRequested' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (239, @lookupTypeId, 'HealthPlanRequested', 'Health Plan Requested', 'Health Plan Requested', 12, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HomeVisitPreferred' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (240, @lookupTypeId, 'HomeVisitPreferred', 'Home Visit Preferred', 'Home Visit Preferred', 13, getdate(), 1, 1)
END
