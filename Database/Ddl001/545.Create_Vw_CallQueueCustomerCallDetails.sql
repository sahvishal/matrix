use [$(dbName)]
go

Create View Vw_CallQueueCustomerCallDetails
As

SELECT        
		C.CallID, 		
		C.CalledCustomerID, 
		C.TimeCreated, 
		C.TimeEnd, 
		C.CallStatus, 
		C.EventID AS EventId, 
		C.DateCreated AS DateCreated, 
		C.DateModified AS DateModified,		 
		C.CallBackNumber, 
		C.IncomingPhoneLine, 
        C.CallersPhoneNumber, 
		C.CallerName, 
		C.PromoCodeID, 
		C.AffiliateID, 
		C.OutBound, 
		C.[Status] AS [Status], 
		C.CreatedByOrgRoleUserId AS CreatedByOrgRoleUserId, 
		C.Disposition, 
		C.ReadAndUnderstoodNotes, 
		C.IsUploaded, 
		C.CampaignId, 
        C.NotInterestedReasonId,
		CQC.CallQueueCustomerId,
		CQC.CallQueueId,
		A.AccountId as HealthPlanId

FROM            TblCalls AS C WITH (NOLOCK) 

				INNER JOIN	TblCallQueueCustomerCall AS CQCC WITH (NOLOCK) ON C.CallID = CQCC.CallId 
				INNER JOIN	TblCallQueueCustomer AS CQC WITH (NOLOCK) ON CQCC.CallQueueCustomerId = CQC.CallQueueCustomerId
				INNER JOIN	TblAccount as A with (nolock) on CQC.HealthPlanId = A.AccountID
				Inner Join	TblCallQueue as CQ WITH (NOLOCK) on CQC.CallQueueId = cq.CallQueueId
WHERE	        (C.EventID IS NOT NULL) AND (C.EventID > 0) AND (CQC.HealthPlanId IS NOT NULL) AND (C.Disposition = 'BookedAppointment')
				AND (A.IsHealthPlan = 1) and CQ.IsActive = 1