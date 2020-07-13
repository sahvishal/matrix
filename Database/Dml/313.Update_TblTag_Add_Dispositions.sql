USE [$(dbname)]
GO

--Remove Tag "Booked Appointment", "Deceased/Dead", "Moved/Relocated", "In Long-Term Care / Nursing Home"
UPDATE TblTag SET IsActive = 0 
WHERE IsHealthPlanTag = 1
and Alias in
(
	'BookedAppointment',
	'Deceased',
	'MovedRelocated',
	'InLongTermCareNursingHome'
)
GO

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Already Attended Event', 'AlreadyAttendedEvent', 1, 0, 1),
		   (107, 'Talked to Other', 'TalkedToOther', 1, 0, 1)
GO