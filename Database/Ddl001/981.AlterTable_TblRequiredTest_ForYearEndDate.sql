USE [$(dbName)]
GO

ALTER TABLE TblRequiredTest
Add ForYear int NOT NULL
,EndDate Datetime NULL