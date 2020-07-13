
USE [$(dbName)]
Go

ALTER TABLE dbo.TblStandardFinding ADD PathwayRecommendation bigint NULL
GO

ALTER TABLE dbo.TblStandardFinding ADD CONSTRAINT FK_TblStandardFinding_TblLookup_PathwayRecommendation FOREIGN KEY (PathwayRecommendation) 
	REFERENCES dbo.TblLookup (LookupId) 
	
GO

