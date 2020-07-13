USE [$(dbname)]
GO

IF OBJECT_ID('Vw_GetBookedAppointmentForCalculatingBonus', 'view') IS NOT NULL
    DROP VIEW [dbo].[Vw_GetBookedAppointmentForCalculatingBonus]
GO

CREATE VIEW Vw_GetBookedAppointmentForCalculatingBonus
As

--CallCenterRep = 10,

SELECT        EC.CustomerID, EC.DateCreated, EC.CreatedByOrgRoleUserId

FROM                     TblEventCustomers AS EC (nolock)   INNER JOIN
                         TblOrganizationRoleUser AS ORU  (nolock) ON ORU.OrganizationRoleUserID = EC.CreatedByOrgRoleUserId INNER JOIN
						 TblEventAccount As EA on ec.EventID = ea.EventID                          
						 
				WHERE  EC.AppointmentID is not null AND (ORU.IsActive = 1) And
						ea.AccountId IN (SELECT  AccountID  FROM   TblAccount AS a WITH (nolock) WHERE   (IsHealthPlan = 1))

                         