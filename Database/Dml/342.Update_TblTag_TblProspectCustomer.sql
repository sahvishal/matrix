USE [$(dbname)]
GO

update TblTag set Alias='DoNotCall' Where Alias='DoNotContact' and IsHealthPlanTag = 1

update TblProspectCustomer Set Tag='DoNotCall' Where Tag = 'DoNotContact'

update TblCalls set Disposition='DoNotCall' where Disposition='DoNotContact' 