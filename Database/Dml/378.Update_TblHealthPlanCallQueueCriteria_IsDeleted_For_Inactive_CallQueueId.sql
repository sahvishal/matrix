USE [$(dbname)]
GO

SELECT * FROM TblHealthPlanCallQueueCriteria 
WHERE CallQueueId IN
(
	SELECT CallQueueId FROM TblCallQueue WHERE IsHealthPlan = 1 AND IsActive = 0
)
AND IsDeleted = 0

--UPDATE TblHealthPlanCallQueueCriteria SET IsDeleted = 1
--WHERE CallQueueId IN
--(
--	SELECT CallQueueId FROM TblCallQueue WHERE IsHealthPlan = 1 AND IsActive = 0
--)
--AND IsDeleted = 0