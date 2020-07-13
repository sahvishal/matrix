USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'EventType'

if not exists (select LookupId from TblLookup where Alias = 'HealthPlan' and LookupTypeId = @lookupTypeId)
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (317,@lookupTypeId,'HealthPlan','Health Plan','Health Plan',2,getdate(),1,1)
	End