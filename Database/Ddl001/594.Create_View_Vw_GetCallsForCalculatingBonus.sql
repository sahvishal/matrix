USE [$(dbname)]
GO

IF OBJECT_ID('Vw_GetCallsForCalculatingBonus', 'view') IS NOT NULL
    DROP VIEW [dbo].[Vw_GetCallsForCalculatingBonus]
GO

CREATE VIEW Vw_GetCallsForCalculatingBonus
As

SELECT        C.CallID, C.CalledCustomerID, C.TimeCreated, C.TimeEnd, C.CallStatus, C.DateCreated, C.[Status], C.OutBound, C.CreatedByOrgRoleUserId
FROM            TblCalls AS C WITH (nolock)  
		WHERE        (	
						c.HealthPlanId IN
							(
								SELECT A.AccountID FROM TblAccount AS a WITH (nolock) WHERE (IsHealthPlan = 1)
							)
					) 
					AND C.IsUploaded = 0
					AND C.[Status] <> 325

