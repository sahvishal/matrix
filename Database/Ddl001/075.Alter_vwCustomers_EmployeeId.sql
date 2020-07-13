
USE [$(dbName)]
Go

Alter VIEW [dbo].[vw_Customers]    
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
  FROM [TblCustomerProfile] TC
Inner join TblOrganizationRoleUser TORU on TC.CustomerId=TORU.OrganizationRoleUserId