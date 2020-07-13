USE [$(dbname)]
GO


INSERT INTO TblGlobalConfiguration([Name], [Description], [Value], SettingGroupName, DataType, IsActive, DateCreated, DateModified)
VALUES('PreviousPinNonRepetitionCount', 'PreviousPinNonRepetitionCount', '3', 'Admin', 'interger', 1, GETDATE(), GETDATE()),
	  ('PinExpirationDays', 'PinExpirationDays', '90', 'Admin', 'interger', 1, GETDATE(), GETDATE()),
	  ('AlertBeforePinExpirationInDays', 'AlertBeforePinExpirationInDays', '30', 'Admin', 'interger', 1, GETDATE(), GETDATE())