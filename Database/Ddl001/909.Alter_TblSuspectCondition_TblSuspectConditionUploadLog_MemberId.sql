USE [$(dbname)]
GO

ALTER TABLE TblSuspectCondition
ADD MemberId VARCHAR(100)

GO

ALTER TABLE TblSuspectConditionUploadLog
ADD MemberId VARCHAR(100)

GO