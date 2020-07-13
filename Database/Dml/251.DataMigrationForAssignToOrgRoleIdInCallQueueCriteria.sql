Declare @CallQueueId bigint 

select @CallQueueId=CallQueueId  from TblCallQueue where Category='NoShows'
Delete TblHealthPlanCriteriaAssignment Where HealthPlanCriteriaId in (select Id  from TblHealthPlanCallQueueCriteria where CallQueueId = @CallQueueId)

CREATE TABLE #TempTable 
	(
		[rowcnt][int] IDENTITY (1,1) NOT NULL, 
		criteriaId [BigInt] Not NULL, 
		CallQueueId [BigInt] Not NULL, 
		HealthPlanId [BigInt] Not NULL
	);

	INSERT INTO #TempTable (criteriaId,CallQueueId,HealthPlanId)
	Select Id,CallQueueId,HealthPlanId from TblHealthPlanCallQueueCriteria where IsDefault = 0 and IsDeleted=0  and CallQueueId = @CallQueueId

DECLARE @intFlag INT,@MaxRow int
SET @intFlag = 1

select @MaxRow = Max(rowcnt) from #TempTable
print @MaxRow
	if(@MaxRow > 0) 
	Begin 				

		While (@intFlag <= @MaxRow)
		Begin
			Begin Try
				Begin Tran
					Declare @HealthPlanId BigInt,@criteriaId BigInt		

					Select @HealthPlanId=HealthPlanId,@criteriaId=criteriaId from #TempTable where rowcnt=@intFlag
					If exists (select * from TblHealthPlanCallQueueCriteria where Id = @criteriaId and IsDeleted=0 and IsDefault = 0)
					Begin			

						Declare @StartDate DateTime,@EndDate DateTime

						Select @StartDate=StartDate,@EndDate=EndDate from TblHealthPlanCallQueueCriteria where Id=@criteriaId and IsDeleted=0 and IsDefault=0				

						Insert Into TblHealthPlanCriteriaAssignment (HealthPlanCriteriaId,AssignedToOrgRoleUserId)

						select @criteriaId,AssignedToOrgRoleUserId  from TblHealthPlanCallQueueCriteria  where StartDate = @StartDate and EndDate = @EndDate And HealthPlanId = @HealthPlanId and CallQueueId = @CallQueueId 		

						Update TblHealthPlanCallQueueCriteria Set CreatedByOrgRoleUserId = 1,DateCreated = GETDATE(),DateModified = null,ModifiedByOrgRoleUserId = 1,IsDeleted = 0 where Id = @criteriaId 				

						Update TblHealthPlanCallQueueCriteria Set IsDeleted=1 where StartDate = @StartDate and EndDate = @EndDate And HealthPlanId = @HealthPlanId and CallQueueId = @CallQueueId and Id <> @criteriaId
						
						Delete TblHealthPlanCallQueueCriteriaAssignment where CriteriaId in (select Id From TblHealthPlanCallQueueCriteria where IsDeleted=1)
						
						Delete TblHealthPlanCallQueueCriteria where IsDeleted = 1
					End
				Commit Tran
			End Try
			Begin Catch
			print 'Error Raise'
					IF @@TRANCOUNT > 0
						ROLLBACK TRAN
					DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
					SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()	
					print @ErrMsg
			End Catch
			Set	@intFlag = @intFlag + 1		
	End
End	

Drop table #TempTable