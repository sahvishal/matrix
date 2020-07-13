USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCallsForCalculatingBonus]    Script Date: 21-07-2017 22:12:19 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_GetCallsForCalculatingBonus]
As

SELECT        C.CallID, C.CalledCustomerID, C.TimeCreated, C.TimeEnd, C.CallStatus, C.DateCreated, C.[Status], C.OutBound, C.CreatedByOrgRoleUserId
FROM            TblCalls AS C WITH (nolock)  
		WHERE       
		 --(	
			--			c.HealthPlanId IN
			--				(
			--					SELECT A.AccountID FROM TblAccount AS a WITH (nolock) WHERE (IsHealthPlan = 1)
			--				)
			--		) AND
					 C.IsUploaded = 0
					AND C.[Status] <> 325
GO


