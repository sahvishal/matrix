USE [$(dbname)]
GO

DECLARE @LookupTypeId BIGINT
SELECT @LookupTypeId = LookupTypeID from TblLookupType where Alias ='MemberUploadSource'

INSERT INTO TblLookup  (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DataRecorderCreatorID, IsActive)
VALUES (428, @LookupTypeId, 'CorporateUplaod', 'Corporate Uplaod', 'Corporate Uplaod', 2, GETDATE(), 1, 1)
GO


