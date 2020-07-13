USE [$(dbName)]
Go

Insert into TblGlobalConfiguration (Name, [Description], Value, SettingGroupName, DataType, IsActive, Delimiter, DateCreated, DateModified)
values('EventBookingThreshold', 'Event Booking Threshold', '87', 'Admin', 'decimal', 1, '', getdate(), getdate()) 
