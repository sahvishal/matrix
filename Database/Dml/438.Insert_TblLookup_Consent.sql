USE [$(dbName)]

GO
DECLARE @lookupTypeId BIGINT
INSERT INTO TblLookupType (Alias, DisplayName, [Description], DateCreated, DateModified)
	VALUES ('PatientConsent', 'PatientConsent', 'Patient Consent', GETDATE(), NULL)

SELECT @lookupTypeId=SCOPE_IDENTITY()

INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
	VALUES (405, @lookupTypeId, 'Unknown',  'Unknown',  'Unknown', 1, GETDATE(), 1, 1),
		   (406, @lookupTypeId, 'Granted',  'Granted',  'Granted', 2, GETDATE(), 1, 1),
		   (407, @lookupTypeId, 'Rejected', 'Rejected', 'Rejected',3, GETDATE(), 1, 1)

GO