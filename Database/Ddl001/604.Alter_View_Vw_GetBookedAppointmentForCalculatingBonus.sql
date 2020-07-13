USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetBookedAppointmentForCalculatingBonus]    Script Date: 21-07-2017 21:53:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_GetBookedAppointmentForCalculatingBonus]
As

--CallCenterRep = 10,

SELECT        EC.CustomerID, EC.DateCreated, EC.CreatedByOrgRoleUserId

FROM                     TblEventCustomers AS EC (nolock)   INNER JOIN
                         TblOrganizationRoleUser AS ORU  (nolock) ON ORU.OrganizationRoleUserID = EC.CreatedByOrgRoleUserId 
						 --INNER JOIN  TblEventAccount As EA on ec.EventID = ea.EventID                          
						 
				WHERE (ORU.IsActive = 1) -- EC.AppointmentID is not null AND  
				--And	ea.AccountId IN (SELECT  AccountID  FROM   TblAccount AS a WITH (nolock) WHERE   (IsHealthPlan = 1))
GO


