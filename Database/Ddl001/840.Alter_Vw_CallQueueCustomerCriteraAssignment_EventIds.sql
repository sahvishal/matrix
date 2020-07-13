USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_CallQueueCustomerCriteraAssignment]    Script Date: 4/18/2018 1:15:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
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
		,'' as EventIds
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
								from TblCalls c WITH (NOLOCK)
								join TblCallQueueCustomerCall cqcc WITH (NOLOCK) on c.CallID = cqcc.CallId
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
						SELECT ccqca.CustomerID from TblCustomerCallQueueCallAttempt as ccqca where ccqca.DateCreated > GETDATE() and ccqca.IsCallSkipped = 1
					)

GO


