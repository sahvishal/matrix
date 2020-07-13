USE [$(dbname)]
GO

-- (for live database) before running this script, run below select script and see if there is any record in table or not, if reocrd exists, then don't run the script.
-- SELECT * FROM TblStaffEventScheduleUploadLog

TRUNCATE TABLE TblStaffEventScheduleUploadLog
GO

ALTER TABLE TblStaffEventScheduleUploadLog
DROP COLUMN StaffEmail
GO

ALTER TABLE TblStaffEventScheduleUploadLog
ADD EmployeeId VARCHAR(64)
GO