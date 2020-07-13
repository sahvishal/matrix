
USE [$(dbName)]
Go
--select * from TblLookup where LookupTypeId = 12

insert Into TblLookup
	(LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DateModified, DataRecorderCreatorID, DataRecorderModifierID, IsActive)
Values
	(183, 30, 'DateTypeTextBox', 'DateType', 'Display Control Type: DateType TextBox', 1, GETDATE(), GETDATE(), 1, null, 1)

GO
