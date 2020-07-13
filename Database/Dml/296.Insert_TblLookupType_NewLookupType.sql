USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'HealthPlanRevenue'

IF (isnull(@lookupTypeId, 0) = 0)
	Begin
		Insert into [dbo].[TblLookupType](Alias,DisplayName,[Description],DateCreated,DateModified)
		values('HealthPlanRevenue','Health Plan Revenue','Health Plan Revenue',GETDATE(),getdate())

		set @lookupTypeId = Scope_Identity()
	End
if not exists (select LookupId from TblLookup where Alias = 'PerCustomer' and LookupTypeId = @lookupTypeId)
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (299,@lookupTypeId,'PerCustomer','Per Customer','Per Customer',1,getdate(),1,1)
	End
if not exists(select LookupId from TblLookup where Alias ='PerPackage' and LookupTypeId = @lookupTypeId )
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (300,@lookupTypeId,'PerPackage','Per Package','Per Package',2,getdate(),1,1)		
	End

	if not exists(select LookupId from TblLookup where Alias ='PerTest' and LookupTypeId = @lookupTypeId )
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (301,@lookupTypeId,'PerTest','Per Test','Per Test',3,getdate(),1,1)		
	End
