USE [$(dbName)]
Go

DECLARE @FillEventCallQueueId BIGINT ,
		@UpsellCallQueueId BIGINT ,
		@ConfirmationCallQueueId BIGINT ,
		@date datetime
		 
SELECT @date = GETDATE()
SELECT @FillEventCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'FillEvents'
SELECT @UpsellCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'Upsell'
SELECT @ConfirmationCallQueueId = CallQueueId FROM TblCallQueue WHERE Category= 'Confirmation'

IF NOT EXISTS(SELECT 1 from [TblSystemGeneratedCallQueueCriteria] WHERE [CallQueueId] = @FillEventCallQueueId and IsDefault = 1)
INSERT INTO [dbo].[TblSystemGeneratedCallQueueCriteria]
([CallQueueId],[Amount],[Percentage],[NoOfDays],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId],[DateCreated],[DateModified],
 [CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
(@FillEventCallQueueId,null,50.0,10,1,0,null,null,@date,@date
,1,1)


IF NOT EXISTS(SELECT 1 from [TblSystemGeneratedCallQueueCriteria] WHERE [CallQueueId] = @UpsellCallQueueId and IsDefault = 1)
INSERT INTO [dbo].[TblSystemGeneratedCallQueueCriteria]
([CallQueueId],[Amount],[Percentage],[NoOfDays],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId],[DateCreated],[DateModified],
 [CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
(@UpsellCallQueueId,164,null,15,1,0,null,null,@date,@date
,1,1)

IF NOT EXISTS(SELECT 1 from [TblSystemGeneratedCallQueueCriteria] WHERE [CallQueueId] = @ConfirmationCallQueueId and IsDefault = 1)
INSERT INTO [dbo].[TblSystemGeneratedCallQueueCriteria]
([CallQueueId],[Amount],[Percentage],[NoOfDays],[IsDefault],[IsQueueGenerated],[LastQueueGeneratedDate],[AssignedToOrgRoleUserId],[DateCreated],[DateModified],
 [CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])
     VALUES
(@ConfirmationCallQueueId,null,null,1,1,0,null,null,@date,@date
,1,1)
GO

