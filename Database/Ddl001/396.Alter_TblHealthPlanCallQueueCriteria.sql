
USE [$(dbName)]
Go 

ALTER TABLE dbo.TblHealthPlanCallQueueCriteria ADD
	ZipCode varchar(55) NULL, 
	Radius int null
GO
