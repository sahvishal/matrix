use [$(dbName)]
go

IF OBJECT_ID ('Vw_GetCallsForCallQueue', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCallsForCallQueue 
GO 

Create View Vw_GetCallsForCallQueue
As

SELECT	CallID
		,CalledCustomerID
		,TimeCreated
		,TimeEnd
		,CallStatus
		,EventID
		,DateCreated
		,DateModified		
		,Cast (case when OutBound is null then 0
			else OutBound 
		end  as bit)as OutBound
		,[Status]
		,Disposition
		,CampaignId
		,CreatedByOrgRoleUserId
		FROM	TblCalls With(NOLOCK)	WHERE	(CalledCustomerID IS NOT NULL) AND (CalledCustomerID > 0)