use [$(dbname)]
Go

/****** Object:  View [dbo].[Vw_CallQueueCustomerCriteraAssignmentForStats]    Script Date: 03-01-2018 19:06:45 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Vw_GetCalls', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCalls  
GO 

Create VIEW [dbo].[Vw_GetCalls]
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
	, ISNULL(HealthPlanId,0) as HealthPlanId
	, ISNULL(CallQueueId,0) as CallQueueId,
    CustomTags
FROM         TblCalls with(nolock) Where DateCreated is not null and DateCreated >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) 