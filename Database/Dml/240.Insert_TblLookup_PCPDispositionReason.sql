USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'PCPAppointmentDisposition'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('PCPAppointmentDisposition', 'PCP appointment tracking', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'ScheduledHealthFairBooked' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (251, @lookupTypeId, 'ScheduledHealthFairBooked', 'Scheduled  - HealthFair Booked PCP Appointment', 'Scheduled  - HealthFair Booked PCP Appointment', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'ScheduledPatientBooked' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (252, @lookupTypeId, 'ScheduledPatientBooked', 'Scheduled - Patient Booked PCP Appointment', 'Scheduled - Patient Booked PCP Appointment', 2, getdate(), 1, 1)
END


IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'NoAnswer' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (253, @lookupTypeId, 'NoAnswer', 'No Answer', 'No Answer', 3, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'LeftVoiceMail' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (254, @lookupTypeId, 'LeftVoiceMail', 'Left Voice Mail', 'Left Voice Mail', 4, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'WrongPhoneNumber' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (255, @lookupTypeId, 'WrongPhoneNumber', 'Wrong Phone Number', 'Wrong Phone Number', 5, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DeniedNotCurrentPatient' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (256, @lookupTypeId, 'DeniedNotCurrentPatient', 'Denied - Not a Current Patient', 'Denied - Not a Current Patient', 6, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DeniedRequiresPatientCallDirectly' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (257, @lookupTypeId, 'DeniedRequiresPatientCallDirectly', 'Denied - Requires Patient to Call Directly', 'Denied - Requires Patient to Call Directly', 7, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'DeniedRefusesToReviewHealthFairResults' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (258, @lookupTypeId, 'DeniedRefusesToReviewHealthFairResults', 'Denied - PCP Refuses To Review HealthFair Results', 'Denied - PCP Refuses To Review HealthFair Results', 8, getdate(), 1, 1)
END