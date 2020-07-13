USE [$(dbName)]
GO

update TblTag set IsActive=0 where Alias='NoEventsinArea' and isHealthPlanTag=1 and IsActive=1
update TblTag set IsActive=0 where Alias='TransportationIssue' and isHealthPlanTag=1 and IsActive=1
update TblTag set IsActive=0 where Alias='IncorrectPhoneNumber' and isHealthPlanTag=1 and IsActive=1

