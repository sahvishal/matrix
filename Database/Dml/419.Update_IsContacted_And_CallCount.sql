USE [$(dbname)]
GO

UPDATE TblCalls SET IsContacted = 1 
WHERE [Status] IN (33, 34, 242) 
AND DateCreated >= '01/01/2018' 
AND CallQueueId IS NOT NULL AND CallQueueId IN (147, 151, 152)
GO

UPDATE TblCalls SET IsContacted = 0 
WHERE [Status] NOT IN (33, 34, 242) 
AND DateCreated >= '01/01/2018' 
AND CallQueueId IS NOT NULL AND CallQueueId IN (147, 151, 152)
GO