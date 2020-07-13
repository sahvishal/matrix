USE [$(dbname)]
GO

ALTER View Vw_GetCallsForCallQueue
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
		,cp.Tag
		FROM	TblCalls c With(NOLOCK) 
		INNER JOIN TblCustomerProfile cp With(NOLOCK) on cp.CustomerID = c.CalledCustomerID 
		WHERE	(CalledCustomerID IS NOT NULL) AND (CalledCustomerID > 0) And cp.Tag is not null and cp.Tag !=''

