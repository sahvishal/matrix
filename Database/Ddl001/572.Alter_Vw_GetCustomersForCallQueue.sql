USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForCallQueue]    Script Date: 02-06-2017 11:37:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER View [dbo].[Vw_GetCustomersForCallQueue]
As

--DoNotContactType DoNotMail = 289 
-- UploadActivityType OnlyCall = 332, BothMailAndCall = 333
--CallStatus Initiated = 35

SELECT	CP.CustomerID
		,CP.ContactMethod
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

FROM            TblCustomerProfile AS CP WITH (NOLOCK) INNER JOIN
                         TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
						 INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
						 INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID	

						 AND CP.CustomerID NOT IN 
						 (
							SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
								inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID and ec.AppointmentID is not null and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)

						 )

WHERE        (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
			AND (CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
			AND (CP.IsEligble = 1) 
			and (CP.IsIncorrectPhoneNumber is null or CP.IsIncorrectPhoneNumber = 0 )			 
			and CP.CustomerID not in
			(
				SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) 
						WHERE CustomerID is not null and CustomerID > 0 
						and (
								pc.Tag = 'Deceased'  or 
								(
									pc.ContactedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME) 
									and pc.Tag in ('HomeVisitRequested','DoNotContact','MobilityIssue','InLongTermCareNursingHome') 
								)
							)

			)
			
			AND (CP.ActivityId = 332 OR CP.ActivityId = 333)
			AND CP.Tag IS NOT NULL AND CP.Tag <> '' 

GO


