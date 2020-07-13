USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD ForTalkedToOthers BIT NOT NULL CONSTRAINT DF_TblTag_ForTalkedToOthers DEFAULT 0
GO