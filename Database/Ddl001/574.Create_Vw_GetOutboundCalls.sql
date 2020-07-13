USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetOutboundCalls]    Script Date: 05-06-2017 19:19:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('Vw_GetOutboundCalls', 'view') IS NOT NULL
    DROP VIEW [dbo].[Vw_GetOutboundCalls]
GO
CREATE VIEW [dbo].[Vw_GetOutboundCalls]
AS
	SELECT C.[CallID]
      ,C.[IsNewCustomer]
      ,C.[CalledCustomerID]
      ,C.[TimeCreated]
      ,C.[TimeEnd]
      ,C.[CallStatus]
      ,C.[EventID]
      ,C.[DateCreated]
      ,C.[DateModified]
      ,C.[CallBackNumber]
      ,C.[IncomingPhoneLine]
      ,C.[CallersPhoneNumber]
      ,C.[CallerName]
      ,C.[PromoCodeID]
      ,C.[AffiliateID]
      ,C.[OutBound]
      ,C.[Status]
      ,C.[CreatedByOrgRoleUserId]
      ,C.[Disposition]
      ,C.[ReadAndUnderstoodNotes]
      ,C.[IsUploaded]
      ,C.[CampaignId]
      ,C.[NotInterestedReasonId]
	  ,CQC.[HealthPlanId]
	  ,CQC.[CallQueueId]
  FROM [dbo].[TblCalls] C WITH(NOLOCK)
  INNER JOIN [dbo].[TblCallQueueCustomerCall] CQCC WITH(NOLOCK) ON C.[CallID] = CQCC.[CallId]
  INNER JOIN [dbo].[TblCallQueueCustomer] CQC WITH(NOLOCK) ON CQCC.[CallQueueCustomerId] = CQC.[CallQueueCustomerId]
  WHERE C.[Outbound] = 1
  AND C.[Status] <> 325
  AND C.[IsUploaded] = 0
  AND CQC.[HealthPlanId] IS NOT NULL
GO


