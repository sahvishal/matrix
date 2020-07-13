USE [$(dbName)]
GO 

Update tblTag  
Set IsActive=0 , ForAppointmentConfirmation=1
where   Alias  in ('PatientConfirmed', 'ConfirmedHRANotComplete','ConfirmLanguageBarrier')
