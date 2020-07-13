USE [$(dbName)]
Go

Declare @callQueueId bigint

Select @callQueueId = CallQueueId from TblCallQueue where Category  = 'LanguageBarrier'

Update TblHealthPlanCallQueueCriteria set isDeleted=1 where HealthPlanId in (select AccountId from tblAccount where isHealthPlan = 1) and CallQueueId=@callQueueId

INSERT INTO [dbo].[TblHealthPlanCallQueueCriteria]
           ([CallQueueId],[Percentage],[NoOfDays],[RoundOfCalls],[StartDate],[EndDate],[HealthPlanId],[CustomTags],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate]
           ,[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     
          select @callQueueId,0,0,0,null,null, AccountId,Null,0,0,null
		  ,GETDATE(),null,1,null from tblAccount where isHealthPlan = 1

