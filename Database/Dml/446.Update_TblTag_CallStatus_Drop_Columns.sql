USE [$(dbname)]
GO

--Attended
UPDATE TblTag SET CallStatus = 34 WHERE IsHealthPlanTag = 1
GO

--Talked To Others
UPDATE TblTag SET CallStatus = 408 WHERE IsHealthPlanTag = 1 AND ForTalkedToOthers = 1
GO

--Left Message With Others
UPDATE TblTag SET CallStatus = 242 WHERE IsHealthPlanTag = 1 AND ForLeftMessageWithOthers = 1
GO

--No event in area
INSERT INTO TblTag ([Source], [Name], [Alias], IsActive, IsSystemDefined, IsHealthPlanTag, ForTalkedToOthers, ForAppointmentConfirmation, ForLeftMessageWithOthers, CallStatus)
VALUES (107, 'No convenient in area', 'NoConvenientInArea', 1, 0, 1, 0, 0, 0, 280),
		(107, 'No Events in list', 'NoEventsInList', 1, 0, 1, 0, 0, 0, 280)

GO

--Drop columns
ALTER TABLE TblTag
DROP CONSTRAINT DF_TblTag_ForTalkedToOthers
GO

ALTER TABLE TblTag
DROP COLUMN ForTalkedToOthers
GO


ALTER TABLE TblTag
DROP CONSTRAINT DF_TblTag_ForLeftMessageWithOthers
GO

ALTER TABLE TblTag
DROP COLUMN ForLeftMessageWithOthers
GO