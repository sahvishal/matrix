USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT

 
SELECT @LookupTypeId = LookupTypeID FROM TblLookupType WHERE Alias = 'RapsUploadStatus' 

IF Not Exists ( select LookupId from TblLookup where Alias = 'UploadStarted' and LookupTypeId = @LookupTypeId)
BEGIN

	INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
			VALUES (350, @LookupTypeId, 'UploadStarted', 'Upload Started', NULL, 1, GETDATE(), 1, 1)
END
 
