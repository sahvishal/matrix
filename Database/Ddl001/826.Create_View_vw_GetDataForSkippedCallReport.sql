USE[$(dbName)]
GO

CREATE VIEW vw_GetDataForSkippedCallReport AS

SELECT
	ccqca.CallID AS CallId
   ,ccqca.CustomerID AS CustomerId
   ,ccqca.CreatedBy AS AgentId
   ,ccqca.CallQueueCustomerID AS CallQueueCustomerId
   ,ccqca.CallAttemptID AS CallAttemptId
   ,ccqca.SkipCallNote AS SkipCallNote
   ,cqc.HealthPlanId AS HealthPlanId
   ,cqc.CallQueueId AS CallQueueId
   ,ccqca.DateCreated AS SkipCallDate

FROM TblCustomerCallQueueCallAttempt ccqca WITH (NOLOCK)
JOIN TblCallQueueCustomer cqc WITH (NOLOCK)
	ON ccqca.CallQueueCustomerID = cqc.CallQueueCustomerId
WHERE ccqca.IsCallSkipped = 1

GO