
USE [$(dbName)]
Go
--select * from TblLookup where LookupTypeId = 12

insert Into TblLookup
	(LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorID, DataRecorderModifierID, IsActive)
Values
	(182, 12, 'Pdf', 'Pdf', 'File Type: Pdf', 1, GETDATE(), GETDATE(), 1, null, 1)

GO

Update TblFile set [Type] = 182 where Path like '%.pdf'
GO