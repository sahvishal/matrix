USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD ForLeftMessageWithOthers bit NOT NULL Constraint DF_TblTag_ForLeftMessageWithOthers DEFAULT(0)






