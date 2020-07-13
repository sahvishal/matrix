USE [$(dbname)]
GO


ALTER VIEW [dbo].[Vw_CallQueueCustomerCriteraAssignment]
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
		--,pc.Tag
		--,pc.CallBackRequestedDate
		--,pc.ContactedDate As LastContactedDate
		, '' As Tag
		, GETDATE() As CallBackRequestedDate
		,GETDATE() As LastContactedDate
		,0 As CallStatus
		

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
				
				Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL 
					and cqc.HealthPlanId > 0 
					and cqc.[Status] = 163 
					and cqc.CustomerId not in 
					(
						SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK)  Where Tag = 'CallBackLater' and pc.CallBackRequestedDate > getdate() and pc.CustomerID > 0
					)