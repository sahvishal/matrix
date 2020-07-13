USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('RestrictAvailableTimeSlotForCorporate', 'Restrict Available Time Slot For Corporate', 'False', 'Admin', 'Varchar', 1, '', getdate(), getdate())
