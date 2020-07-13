USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'AppointmentStatus'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('AppointmentStatus', 'Appointment Status', 'Free, Booked, TemporarilyBooked, Blocked', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Free' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (148, @lookupTypeId, 'Free', 'Free', 'Free', 1, getdate(), 1, 1)
	
	
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'TemporarilyBooked' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (149, @lookupTypeId, 'TemporarilyBooked', 'Temporarily Booked', 'Temporarily Booked', 2, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Booked' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (150, @lookupTypeId, 'Booked', 'Booked', 'Booked', 3, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'Blocked' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (151, @lookupTypeId, 'Blocked', 'Blocked', 'Blocked', 4, getdate(), 1, 1)
END


Update TblEventAppointment Set scheduledbyorgroleuserid = EC.CreatedByOrgRoleUserId, [Status] = 2
from TblEventAppointment EA Inner Join TblEventCustomers EC on EC.AppointmentId = EA.AppointmentId Where 
EA.Status <> 2


Update TblEventAppointment Set Status = 3 where Status = 0 and scheduledbyorgroleuserid is not null and len(isnull(subject, '')) > 0 

Update TblEventAppointment Set Status = isnull(Status, 0) + 148