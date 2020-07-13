USE [$(dbName)]
GO 

------- Update -----------

 Declare @CallCenterSource bigint
 Select @CallCenterSource=107
 
 --------------------------------- Talked to Patient---------------
insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag],ForPreAssessment,CallStatus)
Values(@CallCenterSource,'Cancelled Appointment','CancelledAppointment',1,0,1,1,34)