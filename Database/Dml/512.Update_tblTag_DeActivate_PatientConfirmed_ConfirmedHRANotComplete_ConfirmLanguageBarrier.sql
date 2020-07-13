USE [$(dbName)]
GO 

Update tblTag  
Set IsActive=1 , ForAppointmentConfirmation=0
where   Alias  in ('PatientConfirmed', 'ConfirmedHRANotComplete','ConfirmLanguageBarrier')
				And Source=107 And CallStatus=34 And  ForAppointmentConfirmation=1



Update tblTag  
Set IsActive=1 , ForAppointmentConfirmation=1
where   Alias ='NotInterested'
				And Source=107 And CallStatus=34 
				