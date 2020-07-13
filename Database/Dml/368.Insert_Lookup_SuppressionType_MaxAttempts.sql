USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT
SELECT @LookupTypeId = LookupTypeId FROM TblLookupType WHERE Alias = 'SuppressionType'

IF Not Exists ( select LookupId from TblLookup where Alias = 'MaxAttempts' and LookupTypeId = @LookupTypeId)
BEGIN

	INSERT INTO TblLookup (LookupId, LookupTypeId, Alias, DisplayName, [Description], RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
			VALUES (347, @LookupTypeId, 'MaxAttempts', 'Max Attempts', NULL, 1, GETDATE(), 1, 1)
END
GO