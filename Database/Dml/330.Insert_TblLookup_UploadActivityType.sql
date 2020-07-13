USE [$(dbName)]
Go

DECLARE @lookUpTypeId BIGINT

INSERT INTO TblLookupType (Alias,DisplayName, [Description],DateCreated,DateModified ) 
VALUES ('UploadActivityType', 'Upload Activity Type', 'Upload Activity Type', GETDATE(), GETDATE())

SET @lookUpTypeId = SCOPE_IDENTITY()

INSERT INTO TblLookUp (LookUpId, LookUpTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DateModified, DataRecorderCreatorId, DataRecorderModifierId, IsActive)
VALUES (331, @lookUpTypeId, 'OnlyMail', 'Only Mail', 'Only Mail', 1, GETDATE(), null, 1, null, 1 ),
	   (332, @lookUpTypeId, 'OnlyCall', 'Only Call', 'Only Call', 2, GETDATE(), null, 1, null, 1 ),
	   (333, @lookUpTypeId, 'BothMailAndCall', 'Both Mail And Call', 'Both Mail And Call', 3, GETDATE(), null, 1, null, 1 )
GO
