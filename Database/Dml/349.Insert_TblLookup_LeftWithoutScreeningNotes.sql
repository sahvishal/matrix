USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT
SELECT @LookupTypeId = LookupTypeId FROM TblLookupType WHERE Alias = 'CustomerRegistrationNoteType'

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (337, @LookupTypeId, 'LeftWithoutScreeningNotes', 'Left Without Screening Notes', 'Left Without Screening Notes', 5, GETDATE(), 1, 1)