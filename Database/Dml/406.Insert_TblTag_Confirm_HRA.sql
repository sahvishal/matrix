USE [$(dbname)]
GO

INSERT INTO [TblTag] (Source, Name, Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers,ForAppointmentConfirmation) 
VALUES (107,'Confirmed, HRA not complete','ConfirmedHRANotComplete',1,0,1,0, 1)

INSERT INTO [TblTag] (Source, Name, Alias, IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers,ForAppointmentConfirmation) 
VALUES (107,'Language barrier','ConfirmLanguageBarrier',1,0,1,0, 1)


GO
