USE [$(dbname)]
GO

DECLARE @Aces BIGINT = 413,
		@CorporateUplaod BIGINT = 428

update TblCorporateUpload SET sourceId = @Aces where id in (
SELECT DISTINCT CorporateUploadId FROM TblMemberUploadLog)

update TblCorporateUpload SET sourceId = @CorporateUplaod where id NOT IN (
SELECT DISTINCT CorporateUploadId FROM TblMemberUploadLog)


ALTER TABLE TblCorporateUpload
ALTER COLUMN sourceId BIGINT NOT NULL
GO

