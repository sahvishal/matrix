use [$(dbName)]
go

IF OBJECT_ID ('Vw_CallQueueCustomerCriteraAssignmentForStats', 'view') IS NOT NULL  
	DROP VIEW Vw_CallQueueCustomerCriteraAssignmentForStats ;  
GO 

CREATE VIEW Vw_CallQueueCustomerCriteraAssignmentForStats
As

--Declare @CallQueueStatus bigint
--set @CallQueueStatus = 163 --Initial

SELECT	cqc.CallQueueCustomerId
		,hpcqca.CriteriaId
		,hpcqca.CallQueueId
		,cqc.CustomerId
		,cqc.[Status]
		,cqc.Attempts
		,cqc.IsActive
		,cqc.DateCreated
		,CASE 
			WHEN  cqc.DateModified is null THEN cqc.DateCreated 
			ELSE cqc.DateModified 
		END AS DateModified
		,cqc.CreatedByOrgRoleUserId
		,cqc.ModifiedByOrgRoleUserId
		,cqc.AssignedToOrgRoleUserId
		,cqc.CallQueueCriteriaId
		,cqc.CallDate
		,cqc.HealthPlanId
		,cqc.CampaignId
		,cqc.EventIds		
		
		

FROM            TblCallQueueCustomer AS cqc WITH (NOLOCK) 
				INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId				
				Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL and cqc.HealthPlanId > 0