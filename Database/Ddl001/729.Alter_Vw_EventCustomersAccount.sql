USE [$(dbname)]
GO

ALTER VIEW [dbo].[Vw_EventCustomersAccount]
As

SELECT [EventCustomerID]
      ,ec.[EventID]
      ,[CustomerID]
      ,[IsPaymentOnline]
      ,CASE
	   WHEN [AppointmentID] IS NOT NULL
	   THEN [AppointmentID] ELSE 0
	   END AS [AppointmentId]
      ,[IsTestConducted]
      ,[bMailReports]
      ,[Notes]
      ,[NoShow]
      ,ec.[DateCreated]
      ,[OfflineCustomerID]
      ,[AffiliateCampaignID]
      ,[SignInSource]
      ,[AdvocateID]
      ,[HIPAAStatus]
      ,[MarketingSource]
      ,[ClickID]
      ,ec.[CreatedByOrgRoleUserId]
      ,[PartnerRelease]
      ,[HospitalFacilityId]
      ,[ABNStatus]
      ,[PCPConsentStatus]
      ,[InsuranceReleaseStatus]
      ,[CampaignId]
      ,[LeftWithoutScreeningReasonId]
      ,[AwvVisitId]
      ,[EnableTexting]
      ,[IsGiftCertificateDelivered]
      ,[GiftCode]
      ,[PatientDetailId]
	  ,[EventDate]
	  ,[EventStatus]
	  ,[EventTypeID]
	  ,CASE
	   WHEN [AccountID] IS NOT NULL
	   THEN [AccountID] ELSE 0 END
	   AS AccountID
	  ,[IsAppointmentConfirmed]
	  ,[ConfirmedBy]
FROM [TblEventCustomers] AS ec WITH (NOLOCK)
INNER JOIN TblEvents AS e WITH (NOLOCK) ON ec.EventID = e.EventID
LEFT OUTER JOIN TblEventAccount ea WITH (NOLOCK) ON e.EventID = ea.EventID 



GO


