USE [$(dbname)]
GO

UPDATE TblCalls SET CallQueueId = CQC.CallQueueId
FROM TblCalls C WITH(NOLOCK)
JOIN TblCallQueueCustomerCall CQCC WITH(NOLOCK) ON C.CallID = CQCC.CallId
JOIN TblCallQueueCustomer CQC WITH(NOLOCK) ON CQCC.CallQueueCustomerId = CQC.CallQueueCustomerId
GO