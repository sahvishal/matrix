USE [$(dbname)]
GO

update TblAccount set FolderName = 'North Carolina' where AccountID = 1046
update TblAccount set FolderName = 'Texas' where AccountID = 1035