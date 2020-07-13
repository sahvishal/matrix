USE [$(dbName)]
GO

/****** Object:  View [dbo].[Vw_GetCallQueueExcludedCustomers]    Script Date: 17-05-2018 15:02:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER VIEW [dbo].[Vw_GetCallQueueExcludedCustomers]  
AS  
 SELECT CP.[CustomerID]  
      ,[Tag]  
   ,[ActivityId]  
   ,CE.[IsEligble]  
   ,[IsIncorrectPhoneNumber]  
   ,[InsuranceId]  
      ,[DoNotContactTypeId]  
      ,[DoNotContactUpdateDate]  
   ,Z.[ZipCode]  
 FROM TblCustomerProfile CP WITH (NOLOCK)  
 INNER JOIN TblOrganizationRoleUser ORU WITH (NOLOCK) ON CP.CustomerID = ORU.OrganizationRoleUserID  
 INNER JOIN TblUser U WITH (NOLOCK) ON ORU.UserID = U.UserID  
 INNER JOIN TblAddress A WITH (NOLOCK) ON U.HomeAddressID = A.AddressID  
 INNER JOIN TblZip Z WITH (NOLOCK) ON A.ZipID = Z.ZipID  
 Left Outer join   
 (  
  select CustomerId, IsEligible as IsEligble from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())  
 )CE on CP.CustomerID = CE.CustomerId  
 WHERE (U.PhoneCell IS NULL AND U.PhoneHome IS NULL AND U.PhoneOffice IS NULL)  
 OR (CE.IsEligble IS NULL OR CE.IsEligble = 0)  
 OR (CP.DoNotContactTypeId IS NOT NULL AND CP.DoNotContactTypeId <> 289 AND CP.DoNotContactUpdateDate >= CONVERT(DATE,DATEADD(YEAR,DATEDIFF(YEAR,0,GETDATE()),0)))  
 OR (CP.ActivityId IS NULL OR CP.ActivityId = 331)  
 OR (cp.IsIncorrectPhoneNumber = 1 and cp.IncorrectPhoneNumberMarkedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) )
 OR (CP.CustomerID IN   
   (  
    SELECT CustomerID FROM TblEventCustomers EC WITH (NOLOCK)  
    INNER JOIN TblEvents E WITH (NOLOCK) ON EC.EventID = E.EventID  
    WHERE EC.AppointmentID IS NOT NULL AND E.EventDate >= CONVERT(DATE,DATEADD(YEAR,DATEDIFF(YEAR,0,GETDATE()),0)) and EC.NoShow =0
   )  
  )  
 OR (CP.CustomerID IN   
   (  
    SELECT CustomerID FROM TblProspectCustomer PC WITH (NOLOCK)  
    WHERE PC.Tag = 'Deceased'  
    OR (  
      PC.TagUpdateDate IS NOT NULL AND PC.TagUpdateDate >= CONVERT(DATE,DATEADD(YEAR,DATEDIFF(YEAR,0,GETDATE()),0))  
      AND PC.Tag IN   
       (  
        'HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan'  
       )  
     )  
   )  
  )  
  or   
  (cp.CustomerID in   
   (  
    select CustomerId from TblProspectCustomer pc with(nolock) where pc.CustomerID > 0 and pc.Tag = 'CallBackLater' and pc.CallBackRequestedDate > CONVERT(DATE, (GETDATE() + 1))       
   )  
  )  
  
GO
