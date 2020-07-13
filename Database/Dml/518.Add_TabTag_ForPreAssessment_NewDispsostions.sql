USE [$(dbName)]
GO 
 
 ---------------- Update ---------------
 update TblTag set ForPreAssessment=0 


 Declare @CallCenterSource bigint
 Select @CallCenterSource=107
 
 ----------------------------------- Talked to Patient---------------
insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'CHAT completed','CHATCompleted',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Requested CHAT Mailed','RequestedCHATMailed',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Member Doesn''t have time for questions','MemberDoesntHaveTimeForQuestions',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Member Does not feel comfortable answering Questions','MemberDoesNotFeelComfortableAnsweringQuestions',1,0,1,1,34)


insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Follow up - Call Escalated','FollowUpCallEscalated',1,0,1,1,34)



insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Not Interested','NotInterested',1,0,1,1,34)


insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Call Back Later','CallBackLater',1,0,1,1,34)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Reschedule Appointment','RescheduleAppointment',1,0,1,1,34)




--------------- Left Message With Other----------
insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Deceased/Dead','Deceased/Dead',1,0,1,1,242)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'In Long-Term Care / Nursing Home','InLongTermCareNursingHome/Dead',1,0,1,1,242)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Left Message','LeftMessage',1,0,1,1,242)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Mobility Issues','MobilityIssues_LeftMessageWithOther',1,0,1,1,242)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Debilitating Disease','DebilitatingDisease',1,0,1,1,242)


