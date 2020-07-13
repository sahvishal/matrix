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


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Personal Reasons' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (205, @lookupTypeId, 'PersonalReasons', 'Personal Reasons', 'Personal Reasons', 3, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'ScheduleConflict' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (206, @lookupTypeId, 'ScheduleConflict', 'Schedule Conflict', 'Schedule Conflict', 4, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'EventMove' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (207, @lookupTypeId, 'EventMove', 'Event Move', 'Event Move', 5, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'PhysicianRecommendation' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (208, @lookupTypeId, 'PhysicianRecommendation', 'Physician Recommendation', 'Physician Recommendation', 6, getdate(), 1, 1)
END

IF EXISTS (Select LookUpId from TblLookup where Alias = 'Other' and LookupTypeId = @lookupTypeId)
BEGIN
	Update TblLookUp set RelativeOrder=7 where Alias = 'Other' and LookupTypeId = @lookupTypeId	
END
