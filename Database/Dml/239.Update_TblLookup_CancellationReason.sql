USE [$(dbName)]
Go

Declare @lookUpTypeId bigint

select @lookUpTypeId = LookUpTypeId from TblLookUpType where Alias ='CancellationReason'

if Exists(select * from TblLookup where Alias='HealthPlanRequested')
begin
	update TblLookup set DisplayName='Requested By Plan',Description='Requested By Plan' where LookupId=239
end

