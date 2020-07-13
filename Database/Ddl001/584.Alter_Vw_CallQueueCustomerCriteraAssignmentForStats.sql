USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_CallQueueCustomerCriteraAssignmentForStats]    Script Date: 19-06-2017 14:03:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_CallQueueCustomerCriteraAssignmentForStats]
As

SELECT	cqc.CallQueueCustomerId
		,hpcqca.CriteriaId
		,hpcqca.CallQueueId
		,cqc.CustomerId
		,cqc.[Status]
		,cqc.Attempts
		,cqc.IsActive
		,cqc.DateCreated
		,CASE 
			WHEN  cqc.DateModified is null THEN cqc.DateCreated 
			ELSE cqc.DateModified 
		END AS DateModified
		,cqc.CreatedByOrgRoleUserId
		,cqc.ModifiedByOrgRoleUserId
		,cqc.AssignedToOrgRoleUserId
		,cqc.CallQueueCriteriaId
		,cqc.CallDate
		,cqc.HealthPlanId
		,cqc.CampaignId
		,cqc.EventIds		
		,a.ZipID

FROM            TblCallQueueCustomer AS cqc WITH (NOLOCK) 
				INNER JOIN TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId
				INNER JOIN TblOrganizationRoleUser AS oru WITH (NOLOCK) ON cqc.CustomerID = oru.OrganizationRoleUserID
				INNER JOIN TblUser AS u WITH (NOLOCK) ON oru.UserID = u.UserID
				INNER JOIN TblAddress AS a WITH (NOLOCK) ON a.AddressID = u.HomeAddressID
				Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL and cqc.HealthPlanId > 0
GO


