USE [$(dbname)]
GO

INSERT INTO [dbo].[TblTag]
           ([Source],[Name],[Alias],[IsActive],[IsSystemDefined],[IsHealthPlanTag])
     VALUES
           (107, 'Left Message', 'LeftMessage', 1, 0, 1)
GO

UPDATE TblTag SET IsActive = 1 
WHERE IsHealthPlanTag = 1
and Alias in
(
	'Deceased',
	'InLongTermCareNursingHome'
)
GO

DELETE FROM TblTag
WHERE IsHealthPlanTag = 1
and Alias in
(
	'AlreadyAttendedEvent',
	'TalkedToOther'
)
GO