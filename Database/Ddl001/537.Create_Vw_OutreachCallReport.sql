USE [$(dbName)]
Go

Create View Vw_OutreachCallReport
As

SELECT   C.CallID AS CallID, 
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
    C.IsUploaded, C.CampaignId AS CampaignId, C.NotInterestedReasonId, A.AccountId, A.Tag

FROM   TblCalls AS c WITH (nolock)
INNer JOIN TblCallQueueCustomerCall AS CQCC WITH (nolock)  ON C.CallID = CQCC.CallId and C.DateCreated > '01/01/2016'
INNER JOIN TblCallQueueCustomer AS CQC WITH (nolock) ON CQCC.CallQueueCustomerId = CQC.CallQueueCustomerId AND CQC.HealthPlanId IS NOT NULL
--INNER JOIN TblCalls AS c WITH (nolock) ON C.CallID = CQCC.CallId --and C.DateCreated > '01/01/2016'
INNER JOIN TblAccount as A with (nolock) on CQC.HealthPlanId = A.AccountID
Where A.IsHealthPlan = 1 
		

