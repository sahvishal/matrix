USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForNotInCallQueue]    Script Date: 24-05-2018 16:43:31 ******/
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
		,CE.IsEligble
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
						 Left Outer join 
						 (
							select CustomerId, IsEligible as IsEligble from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())
						 )CE on CP.CustomerID = CE.CustomerId
						 LEFT JOIN TblZip Z WITH(NOLOCK) ON A.ZipID = Z.ZipID
						 LEFT JOIN TblHealthPlanEventZip HPEZ WITH (NOLOCK)  ON ac.AccountID = HPEZ.AccountID
						 WHERE (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
						 AND (CE.IsEligble IS NOT NULL) 
						 AND (CE.IsEligble = 1) 
						 AND (
								(CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
								OR 
								(
									(
										CP.DoNotContactTypeId = 287 or CP.DoNotContactTypeId = 288
									) 
									AND 
									(
										CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
									)  
									AND
									(
										CP.DoNotContactUpdateSource IS NULL OR CP.DoNotContactUpdateSource <> 349
									)
								)
							)
						 AND (CP.ActivityId IS NOT NULL) 
						 AND (CP.ActivityId = 2 OR CP.ActivityId = 3) 
						 And (CP.IsIncorrectPhoneNumber =  0 or (CP.IsIncorrectPhoneNumber = 1 and CP.IncorrectPhoneNumberMarkedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) ))
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
							INNER JOIN TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID AND ec.AppointmentID IS NOT NULL AND e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) and ec.NoShow = 0
						 )
						  And Not Exists
						  (
							select * from TblAccountEventZip aez where aez.ZipId = a.ZipID and aez.AccountID = ac.AccountID
						  )
						 --AND CHARINDEX(',' + convert(varchar(5), a.ZipID) +',', ',' + HPEZ.EventZipID +',') = 0


GO


