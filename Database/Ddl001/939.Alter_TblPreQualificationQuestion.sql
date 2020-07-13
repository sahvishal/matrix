USE [$(dbName)]
GO

ALTER TABLE TblPreQualificationQuestion
ADD DisqualifiedReason VARCHAR(1024)