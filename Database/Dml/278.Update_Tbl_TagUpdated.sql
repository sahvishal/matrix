USE [$(dbName)]
GO

update TblTag set Name='Do Not Call' where Alias='DoNotContact' and isHealthPlanTag=1 

