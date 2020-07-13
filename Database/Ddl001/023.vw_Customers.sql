USE [$(dbName)]
Go

/****** Object:  View [dbo].[vw_Customers]    Script Date: 04/04/2012 18:36:21 ******/
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
	  ,TORU.UserId 
  FROM [TblCustomerProfile] TC
Inner join TblOrganizationRoleUser TORU on TC.CustomerId=TORU.OrganizationRoleUserId



GO


