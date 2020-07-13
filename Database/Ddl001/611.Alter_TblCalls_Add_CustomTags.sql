USE [$(dbname)]
GO

ALTER TABLE TblCalls
ADD [CustomTags] VARCHAR(MAX) NULL
GO