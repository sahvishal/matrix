USE [$(dbName)]
GO

/****** Object:  View [dbo].[Vw_OutreachCallReport]    Script Date: 3/16/2018 1:05:26 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





ALTER View [dbo].[Vw_OutreachCallReport]
As

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
		INNer JOIN TblCallQueueCustomerCall AS CQCC WITH (nolock)  ON C.CallID = CQCC.CallId and C.DateCreated > '01/01/2016'
		INNER JOIN TblCallQueueCustomer AS CQC WITH (nolock) ON CQCC.CallQueueCustomerId = CQC.CallQueueCustomerId AND CQC.HealthPlanId IS NOT NULL AND C.CallQueueId = CQC.CallQueueId
		INNER JOIN TblCallQueue cq WITH (nolock) on cq.CallQueueId = CQC.CallQueueId 
		INNER JOIN TblAccount as A with (nolock) on CQC.HealthPlanId = A.AccountID
		Where A.IsHealthPlan = 1 and (c.OutBound is not null and c.OutBound = 1) and (c.[Status] != 35 and c.[Status] <> 325) --and cq.IsActive = 1
		


GO


