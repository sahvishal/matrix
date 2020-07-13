USE [$(dbName)]
Go

Declare @CallQueueId bigint 

select @CallQueueId=CallQueueId  from TblCallQueue where Category='FillEventsHealthPlan'

--select * from TblHealthPlanCallQueueCriteria where CallQueueId = @CallQueueId and Percentage = 99.00 and NoOfDays = 30 and IsDefault = 0

Delete from TblHealthPlanCallQueueCriteriaAssignment where CriteriaId in (select Id from TblHealthPlanCallQueueCriteria where CallQueueId = @CallQueueId and Percentage = 99.00 and NoOfDays = 30 and IsDefault = 0)

delete from TblHealthPlanCriteriaAssignment where HealthPlanCriteriaId in (select Id from TblHealthPlanCallQueueCriteria where CallQueueId = @CallQueueId and Percentage = 99.00 and NoOfDays = 30 and IsDefault = 0)
						
Delete from TblHealthPlanCallQueueCriteria where CallQueueId = @CallQueueId and Percentage = 99.00 and NoOfDays = 30 and IsDefault = 0

update TblHealthPlanCallQueueCriteria set Percentage = 99.00, NoOfDays = 30 where CallQueueId = @CallQueueId and IsDefault = 1