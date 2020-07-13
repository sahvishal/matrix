USE [$(dbname)]
GO

ALTER TABLE TblResultArchiveUpload
ALTER COLUMN UploadEndTime DATETIME NULL
GO