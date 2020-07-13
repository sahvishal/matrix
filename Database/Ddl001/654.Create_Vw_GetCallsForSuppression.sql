use [$(dbname)]
go

Create View [dbo].[Vw_GetCallsForSuppression]
As

SELECT	c.CallID
		,c.CalledCustomerID
		,c.TimeCreated
		,c.TimeEnd
		,c.CallStatus
		,c.EventID
		,c.DateCreated
		,c.DateModified		
		,Cast (case when c.OutBound is null then 0
			else OutBound 
		end  as bit)as OutBound
		,c.[Status]
		,c.Disposition
		,c.CampaignId
		,c.CreatedByOrgRoleUserId
		,a.AccountId
		,maxDays

		FROM	TblCalls c With(NOLOCK) 

		INNER JOIN TblAccount a With(NOLOCK) on a.AccountID = c.HealthPlanId 

		OUTER APPLY (SELECT MAX(NoOfDays) maxdays from TblAccountCallQueueSetting With(NOLOCK) Where AccountID = a.AccountID ) as maxDays

		WHERE	(CalledCustomerID IS NOT NULL) AND (CalledCustomerID > 0) and a.IsHealthPlan = 1
				And (c.DateCreated > GETDATE() - maxdays and c.HealthPlanId = a.AccountID)
				And C.CalledCustomerID NOT IN 
				(
					SELECT p.CustomerID FROM tblProspectCustomer p with(Nolock) Where ( (p.Tag = 'CallBackLater' or p.Tag = 'LanguageBarrier')
							And p.CallBackRequestedDate < GETDATE())
							And CustomerID IS NOT NULL
				)
				AND C.Status <> 325
				And C.DateCreated > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
				AND C.OutBound = 1
GO


