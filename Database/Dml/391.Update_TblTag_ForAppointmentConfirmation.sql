USE [$(dbname)]
GO

UPDATE TblTag SET ForAppointmentConfirmation = 1
WHERE Alias IN
(
	'CallBackLater',
	'PatientConfirmed',
	'CancelAppointment',
	'RescheduleAppointment'
)