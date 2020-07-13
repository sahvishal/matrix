USE[$(dbName)]
GO

Alter table TblStaffEventScheduleUploadLog
ALTER COLUMN StaffName varchar(255) null;
GO

Alter table TblStaffEventScheduleUploadLog
ALTER COLUMN StaffEmail varchar(100) null;
GO

Alter table TblStaffEventScheduleUploadLog
ALTER COLUMN Pod varchar(500) null;

GO
Alter table TblStaffEventScheduleUploadLog
ALTER COLUMN [Role] varchar(255) null;

GO