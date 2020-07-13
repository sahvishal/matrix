USE [$(dbname)]
GO

DECLARE @startOfYear DATETIME
SELECT @startOfYear = DATEADD(yy, DATEDIFF(yy, 0, GETDATE()), 0)

UPDATE TblCallQueueCustomer 
SET Attempts = (
					SELECT COUNT(*) FROM TblCallQueueCustomerCall WITH(NOLOCK) WHERE CallQueueCustomerId = CQC.CallQueueCustomerId 
					AND CallId IN 
					(
						SELECT CallID FROM TblCalls WITH(NOLOCK)
						WHERE DateCreated >= @startOfYear
						AND [Status] <> 325
					)
				)
FROM TblCallQueueCustomer CQC WITH(NOLOCK)
GO