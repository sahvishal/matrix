USE [$(dbname)]
GO

UPDATE TblCalls SET HealthPlanId = cqc.HealthPlanId, CallQueueId = cqc.CallQueueId
FROM TblCalls c
INNER JOIN TblCallQueueCustomerCall cqcc ON c.CallID = cqcc.CallId
INNER JOIN TblCallQueueCustomer cqc ON cqcc.CallQueueCustomerId = cqc.CallQueueCustomerId
WHERE cqc.HealthPlanId IS NOT NULL
GO

--DROP TABLE [TblSystemGeneratedCallQueueAssignment]
--DROP TABLE [TblHealthPlanCallQueueCriteriaAssignment]
--DROP TABLE [TblCallQueueCustomerLock]
--DROP TABLE [TblCallQueueCustomerCall]
--DROP TABLE [TblCallQueueCustomer]