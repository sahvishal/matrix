USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetOutboundCalls]    Script Date: 05-06-2017 19:19:30 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID('Vw_GetCallCenterAgentsForConversionReport', 'view') IS NOT NULL
    DROP VIEW [dbo].[Vw_GetCallCenterAgentsForConversionReport]
GO
CREATE VIEW [dbo].[Vw_GetCallCenterAgentsForConversionReport]
AS
	SELECT C.[CreatedByOrgRoleUserId]
	  ,C.[DateCreated]
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


