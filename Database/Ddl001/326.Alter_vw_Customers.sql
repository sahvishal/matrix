USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_Customers]    Script Date: 04/15/2014 18:18:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vw_Customers]    
AS
SELECT TC.[CustomerID]
      ,TC.[DisplayID]
      ,TC.[BillingAddressID]
      ,TC.[ContactMethod]
      ,TC.[IsActive]
      ,TC.[Height]
      ,TC.[Weight]
      ,TC.[Gender]
      ,TC.[Race]
      ,TC.[Age]
      ,TC.[DateCreated]
      ,TC.[DateModified]
      ,TC.[CollectionMode]
      ,TC.[IsMailingList]
      ,TC.[IsDirectMail]
      ,TC.[IsSpecialOffer]
      ,TC.[TrackingMarketingID]
      ,TC.[AddedByRoleID]
      ,TC.[SignInSource]
      ,TC.[AdvocateID]
      ,TC.[Employer]
      ,TC.[EmergencyContactName]
      ,TC.[EmergencyContactRelationship]
      ,TC.[EmergencyContactPhoneNumber]
      ,TC.[DoNotContactReasonId]
      ,TC.[DoNotContactReasonNotesId]
      ,TC.[RequestNewsLetter]
      ,TC.UserDefined1
      ,TC.EmployeeId
	  ,TORU.UserId 
	  ,TC.Tag
	  ,TC.InsuranceId
	  ,TC.HICN
	  ,TC.MedicareAdvantageNumber
	  ,TC.MedicareAdvantagePlanName
	  ,TC.Copay
	  ,TC.IsEligble	  
	  ,TC.LanguageId
	  ,TC.LabId
	  
  FROM [TblCustomerProfile] TC
Inner join TblOrganizationRoleUser TORU on TC.CustomerId=TORU.OrganizationRoleUserId
GO


