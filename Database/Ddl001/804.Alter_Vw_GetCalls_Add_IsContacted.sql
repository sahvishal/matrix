USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCalls]    Script Date: 3/29/2018 7:15:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_GetCalls]
As

SELECT   
	  CallID
	,IsNewCustomer
	,isNull(CalledCustomerID,0) as CalledCustomerID
	,ISNULL(TimeCreated,'01/01/1900') as TimeCreated
	,TimeEnd
	,CallStatus
	,EventID
	,DateCreated
	,DateModified
	,CallBackNumber
	,IncomingPhoneLine
	,CallersPhoneNumber
	,CallerName
	,PromoCodeID
	,AffiliateID
	,OutBound
	,Status
	,CreatedByOrgRoleUserId
	,Disposition
	,ReadAndUnderstoodNotes
	,IsUploaded, CampaignId
	,ISNULL(NotInterestedReasonId,0) as NotInterestedReasonId
	,ISNULL(HealthPlanId,0) as HealthPlanId
	,ISNULL(CallQueueId,0) as CallQueueId
    ,CustomTags
	,ISNULL(IsContacted,1) as IsContacted
FROM         TblCalls with(nolock) Where DateCreated is not null and DateCreated >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) 
GO


