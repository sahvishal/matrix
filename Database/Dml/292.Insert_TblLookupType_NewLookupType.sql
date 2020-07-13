USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'LeftWithoutScreeningReason'

IF (isnull(@lookupTypeId, 0) = 0)
	Begin
		Insert into [dbo].[TblLookupType](Alias,DisplayName,[Description],DateCreated,DateModified)
		values('LeftWithoutScreeningReason','Left Without Screening Reason','Left Without Screening Reason',GETDATE(),getdate())

		set @lookupTypeId = Scope_Identity()
	End
if not exists (select LookupId from TblLookup where Alias = 'DueToWait' and LookupTypeId = @lookupTypeId)
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (296,@lookupTypeId,'DueToWait','Due To Wait','Patient left due to wait',1,getdate(),1,1)
	End
if not exists(select LookupId from TblLookup where Alias ='ChangedMind' and LookupTypeId = @lookupTypeId )
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (297,@lookupTypeId,'ChangedMind','Changed Mind','Changed Mind',2,getdate(),1,1)		
	End

	if not exists(select LookupId from TblLookup where Alias ='UpsetWithService' and LookupTypeId = @lookupTypeId )
	Begin
		Insert into  [dbo].[TblLookup](LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		values (298,@lookupTypeId,'UpsetWithService','Upset With Service','Upset with service',3,getdate(),1,1)		
	End
