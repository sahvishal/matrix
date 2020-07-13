USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

SELECT @LookupTypeId = LookupTypeId FROM TblLookupType WHERE Alias = 'OutboundUploadType'

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (329, @LookupTypeId, 'PatientDetail', 'Patient Detail', 'Patient Detail', 3, GETDATE(), 1, 1),
	   (330, @LookupTypeId, 'DiagnosisReport', 'Diagnosis Report', 'Diagnosis Report', 4, GETDATE(), 1, 1)
GO