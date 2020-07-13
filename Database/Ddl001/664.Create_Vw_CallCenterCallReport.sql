USE [$(dbname)]
GO

CREATE VIEW Vw_CallCenterCallReport
AS
SELECT
		C.CallID AS CallID, 
		C.IsNewCustomer, 
		C.CalledCustomerId, 
		C.TimeCreated, 
		C.TimeEnd, 
		C.CallStatus, 
		C.EventID AS EventId, 
		C.DateCreated AS DateCreated, 
		C.DateModified AS DateModified, 
		C.CallBackNumber, 
		C.IncomingPhoneLine, 
		C.CallersPhoneNumber,
		C.OutBound, 
		C.[Status] AS [Status], 
		C.CreatedByOrgRoleUserId AS CreatedByOrgRoleUserId, 
		C.Disposition, 
		C.ReadAndUnderstoodNotes, 
		C.IsUploaded, 
		C.CampaignId AS CampaignId, 
		C.NotInterestedReasonId, 
		C.CustomTags,
		A.AccountId, 
		A.Tag,
		CQC.CallQueueId

		FROM   TblCalls AS c WITH (nolock)
		LEFT JOIN TblCallQueueCustomerCall AS CQCC WITH (nolock)  ON C.CallID = CQCC.CallId 
		LEFT JOIN TblCallQueueCustomer AS CQC WITH (nolock) ON CQCC.CallQueueCustomerId = CQC.CallQueueCustomerId
		LEFT JOIN TblCallQueue cq WITH (nolock) on cq.CallQueueId = CQC.CallQueueId 
		LEFT JOIN TblAccount as A with (nolock) on C.HealthPlanId = A.AccountID		
	   Where (c.[Status] != 35 and c.[Status] <> 325)

