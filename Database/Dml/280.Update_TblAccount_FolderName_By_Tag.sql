USE [$(dbName)]
GO

update TblAccount set FolderName=Tag where Tag is not null and tag <> ''
