USE [$(dbName)]
GO 
 
 Declare @CallCenterSource bigint
 Select @CallCenterSource=107

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Booked Appointment','BookedAppointment',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Will Speak with Physician','SpeakWithPhysician',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Call Back Later','CallBackLater',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Recently Saw Doc or Future Doc Appt','RecentlySawDoc',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Not Interested','NotInterested',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'No Events in Area','NoEventsinArea',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Date/Time Conflict','DateTimeConflict',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Home Visit Requested','HomeVisitRequested',1,0,1)


insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Mobility Issue: No Home Visit Requested','MobilityIssue',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Transportation Issue: No Home Visit Requested','TransportationIssue',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Do Not Contact','DoNotContact',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Deceased/Dead','Deceased',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Moved/Relocated','MovedRelocated',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'No Longer on Insurance Plan','NoLongeronInsurancePlan',1,0,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined], [IsHealthPlanTag])
Values(@CallCenterSource,'Language Barrier','LanguageBarrier',1,0,1)