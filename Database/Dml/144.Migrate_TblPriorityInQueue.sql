USE [$(dbName)]
Go 
INSERT INTO dbo.[TblPriorityInQueue]
       ([EventCustomerResultId], [InQueuePriority],[DateCreated],[DateModified],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId],[IsActive])    
SELECT  
       EventCustomerResultId
       --,NoteId
       ,InQueuePriority
       ,DateCreated
       ,DateModified
       ,CreatedByOrgRoleUserId
       ,ModifiedByOrgRoleUserId ,1
FROM TblEventCustomerResult
WHERE InQueuePriority is not null 
Go