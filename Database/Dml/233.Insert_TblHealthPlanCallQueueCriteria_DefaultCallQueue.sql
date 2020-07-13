USE [$(dbName)]
Go

Declare @callQueueId bigint

Select @callQueueId=CallQueueId from TblCallQueue where Category='CallRound'

if not Exists (select Id from TblHealthPlanCallQueueCriteria where CallQueueId = @callQueueId)
begin
INSERT INTO [dbo].[TblHealthPlanCallQueueCriteria]
           ([CallQueueId],[Percentage],[NoOfDays],[RoundOfCalls],[StartDate],[EndDate],[HealthPlanId],[CustomTags],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId]
           ,[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
           (@callQueueId,0,7,0,null,null,null,Null,1,1,null,Null
		   ,GETDATE(),null,1,null)
End

set @callQueueId=0

Select @callQueueId=CallQueueId from TblCallQueue where Category='FillEventsHealthPlan'

if not Exists (select Id from TblHealthPlanCallQueueCriteria where CallQueueId = @callQueueId)
Begin
INSERT INTO [dbo].[TblHealthPlanCallQueueCriteria]
           ([CallQueueId],[Percentage],[NoOfDays],[RoundOfCalls],[StartDate],[EndDate],[HealthPlanId],[CustomTags],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId]
           ,[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
           (@callQueueId,50,15,0,null,null,null,Null,1,1,null,Null
		   ,GETDATE(),null,1,null)

End

set @callQueueId=0

Select @callQueueId=CallQueueId from TblCallQueue where Category='NoShows'

if not Exists (select Id from TblHealthPlanCallQueueCriteria where CallQueueId = @callQueueId)
Begin
INSERT INTO [dbo].[TblHealthPlanCallQueueCriteria]
           ([CallQueueId],[Percentage],[NoOfDays],[RoundOfCalls],[StartDate],[EndDate],[HealthPlanId],[CustomTags],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId]
           ,[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
           (@callQueueId,0,0,0,null,null,null,Null,1,1,null,Null
		   ,GETDATE(),null,1,null)

End
