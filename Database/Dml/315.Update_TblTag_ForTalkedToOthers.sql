USE [$(dbname)]
GO

UPDATE TblTag set ForTalkedToOthers = 1
WHERE IsHealthPlanTag = 1
and Alias in
(
	'Deceased',
	'InLongTermCareNursingHome',
	'LeftMessage'
)
GO