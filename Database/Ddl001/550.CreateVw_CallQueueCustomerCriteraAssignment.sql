use [$(dbName)]
go

IF OBJECT_ID ('Vw_CallQueueCustomerCriteraAssignment', 'view') IS NOT NULL  
	DROP VIEW Vw_CallQueueCustomerCriteraAssignment ;  
GO 

CREATE VIEW [dbo].[Vw_CallQueueCustomerCriteraAssignment]
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
		,CASE 
			WHEN calls.CallCount is null THEN 0
			ELSE calls.CallCount 
		END AS  [CallCount]
		

FROM            TblCallQueueCustomer AS cqc WITH (NOLOCK) 
				INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId
				Left Outer Join (
								select CalledCustomerID,COUNT(CalledCustomerID) as [CallCount] 
								from tblCalls c WITH (NOLOCK)
								Where	(
											c.CalledCustomerID is not null and c.CalledCustomerID > 0
										) and  
										c.TimeCreated > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
										and c.[Status] != 325
										group by CalledCustomerID
							) calls
				on calls.CalledCustomerID = cqc.CustomerId
				Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL and cqc.HealthPlanId > 0 and cqc.[Status] = 163 
					and Not (
								(
									cqc.CallDate > CONVERT(DATE, (GETDATE() + 1)) 
										and CustomerId in 
									(
										SELECT CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
											WHERE c.CalledCustomerID is not null 
													and c.TimeCreated is not null 
													and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] <> 35 
									)
								) 
								or CustomerId in 
								(
									SELECT CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
										WHERE c.CalledCustomerID is not null 
												and c.TimeCreated is not null 
												and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] = 35 
								)
							) 



GO