USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForNotInCallQueue]    Script Date: 07-12-2017 17:30:43 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER  VIEW [dbo].[Vw_GetCustomersForNotInCallQueue]
AS

SELECT	CP.CustomerID		
		,CP.Gender
		,CP.Race
		,CP.DoNotContactReasonId
		,CP.DoNotContactReasonNotesId
		,CP.RequestNewsLetter
		,CP.IsEligble
		,CP.IsIncorrectPhoneNumber
		,CP.IsLanguageBarrier
		,CP.ActivityId
		,CP.DoNotContactTypeId
		,CP.BillingAddressID
		,CP.InsuranceId
		,CP.Tag
		,A.ZipID
		,ac.AccountID
		,Z.ZipCode

FROM            TblCustomerProfile AS CP WITH (NOLOCK) INNER JOIN
                         TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
						 INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
						 INNER JOIN TblAccount ac WITH (NOLOCK)  ON ac.Tag = CP.Tag
						 INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID
						 LEFT JOIN TblZip Z WITH(NOLOCK) ON A.ZipID = Z.ZipID
						 LEFT JOIN TblHealthPlanEventZip HPEZ WITH (NOLOCK)  ON ac.AccountID = HPEZ.AccountID
						 WHERE (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
						 AND (CP.IsEligble IS NOT NULL) 
						 AND (CP.IsEligble = 1) 
						 AND ((CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
								OR 
								(
									(CP.DoNotContactTypeId = 287 or CP.DoNotContactTypeId = 288) AND (CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))  
								)
							)
						 AND (CP.ActivityId IS NOT NULL) 
						 AND (CP.ActivityId = 332 OR CP.ActivityId = 333) 
						 AND (CP.IsIncorrectPhoneNumber = 0) 
						 AND CP.Tag IS NOT NULL AND CP.Tag <> ''
						 and CP.CustomerID not in
						 (
							SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) 
							WHERE CustomerID IS NOT NULL AND CustomerID > 0 
							AND 
							(
								pc.Tag = 'Deceased'  OR 
								(
									pc.ContactedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME) 
									AND pc.Tag IN ('HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan') 
								)
							)
						 )
						 AND CP.CustomerID NOT IN 
						 (
							SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
							INNER JOIN TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID AND ec.AppointmentID IS NOT NULL AND e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
						 )
						 AND CHARINDEX(',' + convert(varchar(5), a.ZipID) +',', ',' + HPEZ.EventZipID +',') = 0
						 


GO


