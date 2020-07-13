USE [$(dbname)]
GO

INSERT INTO [TblTag] (Source, Name, Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers) 
VALUES (107,'Patient Confirmed','PatientConfirmed',1,0,1,0)

INSERT INTO [TblTag] (Source, Name, Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers) 
VALUES (107,'Cancel Appointment','CancelAppointment',1,0,1,0)

INSERT INTO [TblTag] (Source, Name, Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers) 
VALUES (107,'Reschedule Appointment','RescheduleAppointment',1,0,1,0)

GO
