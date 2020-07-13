USE [$(dbname)]
GO

DECLARE @lookupTypeId BIGINT

INSERT INTO TblLookupType (Alias, DisplayName, Description, DateCreated, DateModified)
	VALUES ('MedicationFrequency', 'MedicationFrequency', 'MedicationFrequency', GETDATE(), NULL)

SELECT
	@lookupTypeId = IDENT_CURRENT('TblLookupType')

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
	VALUES (386, @lookupTypeId, 'QD', 'QD (Once a day)', 'QD (Once a day)', 1, GETDATE(), 1, 1),
	(387, @lookupTypeId, 'BID', 'BID (Twice a day)', 'BID (Twice a day)', 2, GETDATE(), 1, 1),
	(388, @lookupTypeId, 'TID', 'TID (3x a day)', 'TID (3x a day)', 3, GETDATE(), 1, 1),
	(389, @lookupTypeId, 'QID', 'QID (4x a day)', 'QID (4x a day)', 4, GETDATE(), 1, 1),
	(390, @lookupTypeId, 'QOD', 'QOD (Every other day)', 'QOD (Every other day)', 5, GETDATE(), 1, 1),
	(391, @lookupTypeId, 'TIW', 'TIW', 'TIW', 6, GETDATE(), 1, 1),
	(392, @lookupTypeId, 'PRN', 'PRN (As needed)', 'PRN (As needed)', 7, GETDATE(), 1, 1),
	(393, @lookupTypeId, 'QHS', 'QHS (at bedtime)', 'QHS (at bedtime)', 8, GETDATE(), 1, 1),
	(394, @lookupTypeId, 'QAM', 'QAM', 'QAM', 9, GETDATE(), 1, 1),
	(395, @lookupTypeId, 'PC', 'PC (After Meal)', 'PC (After Meal)', 10, GETDATE(), 1, 1),
	(396, @lookupTypeId, 'AC', 'AC (Before Meal)', 'AC (Before Meal)', 11, GETDATE(), 1, 1),
	(397, @lookupTypeId, 'Q2H', 'Q2H (Every 2 hours)', 'Q2H (Every 2 hours)', 12, GETDATE(), 1, 1),
	(398, @lookupTypeId, 'Q3H', 'Q3H (Every 3 hours)', 'Q3H (Every 3 hours)', 13, GETDATE(), 1, 1),
	(399, @lookupTypeId, 'Q4H', 'Q4H (Every 4 hours)', 'Q4H (Every 4 hours)', 14, GETDATE(), 1, 1),
	(400, @lookupTypeId, 'Q8H', 'Q8H (Every 8 hours)', 'Q8H (Every 8 hours)', 15, GETDATE(), 1, 1),
	(401, @lookupTypeId, 'Other', 'Other', 'Other', 16, GETDATE(), 1, 1),
	(402, @lookupTypeId, 'QW', 'QW', 'QW', 17, GETDATE(), 1, 1),
	(403, @lookupTypeId, 'TW', 'TW', 'TW', 18, GETDATE(), 1, 1),
	(404, @lookupTypeId, 'Unknown', 'Unknown', 'Unknown', 19, GETDATE(), 1, 1)

GO
