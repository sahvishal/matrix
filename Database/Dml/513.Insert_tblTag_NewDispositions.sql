USE [$(dbName)]
GO 
 
 Declare @CallCenterSource bigint
 Select @CallCenterSource=107
 

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'CHAT completed','CHATCompleted',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'Requested CHAT Mailed','RequestedCHATMailed',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'Member Doesn''t have time for questions','MemberDoesntHaveTimeForQuestions',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'Member Does not feel comfortable answering Questions','MemberDoesNotFeelComfortableAnsweringQuestions',1,0,1,1,34)


insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'Follow up - Call Escalated','FollowUpCallEscalated',1,0,1,1,34)



insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForAppointmentConfirmation,CallStatus)
Values(@CallCenterSource,'Member Confirmed Change','MemberConfirmedChange',1,0,1,1,34)


