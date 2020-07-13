USE [$(dbname)]
GO

ALTER TABLE TblPhysicianProfile
ADD UpdateResultEntry BIT NOT NULL CONSTRAINT DF_TblPhysicianProfile_UpdateResultEntry DEFAULT 0
GO