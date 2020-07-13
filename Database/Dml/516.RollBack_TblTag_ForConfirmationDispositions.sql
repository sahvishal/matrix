USE [$(dbName)]
GO 

Update  TblTag Set IsActive=0 where Alias in ('CHATCompleted',
'RequestedCHATMailed',
'MemberDoesntHaveTimeForQuestions',
'MemberDoesNotFeelComfortableAnsweringQuestions',
'FollowUpCallEscalated',
'MemberConfirmedChange'
)


 Update  TblTag Set ForAppointmentConfirmation =1  , IsActive=1 where Alias in ('PatientConfirmed',
'ConfirmedHRANotComplete',
'ConfirmLanguageBarrier'
)



 Update  TblTag Set ForAppointmentConfirmation =0,IsActive=1 where Alias in ('NotInterested'
)