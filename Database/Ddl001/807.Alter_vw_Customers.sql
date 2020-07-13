USE [$(dbname)]
GO

/****** Object:  View [dbo].[vw_Customers]    Script Date: 3/30/2018 3:57:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[vw_Customers]    
AS
SELECT TC.[CustomerID]
      ,TC.[DisplayID]
      ,TC.[BillingAddressID]      
      ,TC.[IsActive]
      ,TC.[Height]
      ,TC.[Weight]
      ,TC.[Gender]
      ,TC.[Race]
      ,TC.[Age]
      ,TC.[DateCreated]
      ,TC.[DateModified]     
      ,TC.[TrackingMarketingID]
      ,TC.[AddedByRoleID]
      ,TC.[Employer]
      ,TC.[EmergencyContactName]
      ,TC.[EmergencyContactRelationship]
      ,TC.[EmergencyContactPhoneNumber]
      ,TC.[DoNotContactReasonId]
      ,TC.[DoNotContactReasonNotesId]
      ,TC.[RequestNewsLetter]
      ,TC.EmployeeId
	  ,TORU.UserId 
	  ,TC.Tag
	  ,TC.InsuranceId
	  ,TC.HICN
	  ,TC.MedicareAdvantageNumber
	  ,TC.MedicareAdvantagePlanName
	  ,TC.Copay
	  ,CE.IsEligble	  
	  ,TC.LanguageId
	  ,TC.LabId
	  ,TC.Lpi
	  ,TC.Market
	  ,TC.Mrn
	  ,TC.GroupName
	  ,TC.DoNotContactTypeId
  FROM [TblCustomerProfile] TC
Inner join TblOrganizationRoleUser TORU on TC.CustomerId=TORU.OrganizationRoleUserId
Left Outer join 
(
	select CustomerId, IsEligible as IsEligble from TblCustomerEligibility with(nolock) where ForYear = DATEPART(YEAR, GETDATE())
)CE on TC.CustomerID = CE.CustomerId


GO


