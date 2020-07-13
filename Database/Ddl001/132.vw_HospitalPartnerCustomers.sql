USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_HospitalPartnerCustomers]    Script Date: 05/14/2013 19:42:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create VIEW [dbo].[vw_HospitalPartnerCustomers]    
AS
SELECT THPC.[HospitalPartnerCustomerId]
      ,[EventId]
      ,[CustomerId]
      ,[Status]
      ,[Outcome]
      ,[CareCoordinatorOrgRoleUserId]
      ,[Notes]
      ,[DateCreated]
      ,[CreatedByOrgRoleUserId]
      ,[DateModified]
      ,[ModifiedByOrgRoleUserId]
  FROM [TblHospitalPartnerCustomer] THPC with (nolock)
  INNER JOIN 
  (
	Select Max(HospitalPartnerCustomerId)as HospitalPartnerCustomerId
	from TblHospitalPartnerCustomer with (nolock)
	Group By CustomerId, EventId
  )Temp on THPC.[HospitalPartnerCustomerId] = Temp.HospitalPartnerCustomerId


GO


