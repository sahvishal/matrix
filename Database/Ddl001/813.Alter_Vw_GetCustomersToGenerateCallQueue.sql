USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersToGenerateCallQueue]    Script Date: 3/30/2018 3:08:29 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [dbo].[Vw_GetCustomersToGenerateCallQueue] 
As

	SELECT CP.CustomerID		
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
		,ISNULL(CP.LanguageBarrierMarkedDate,'01/01/1900') as LanguageBarrierMarkedDate
		,ISNULL(CP.IncorrectPhoneNumberMarkedDate,'01/01/1900') as IncorrectPhoneNumberMarkedDate

		FROM TblCustomerProfile AS CP WITH (NOLOCK) INNER JOIN
                         TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
						 INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
						 INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID
						 Left Outer join 
						 (
							select CustomerId, IsEligible as IsEligble from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())
						 )CE on CP.CustomerID = CE.CustomerId

				WHERE 
					((CP.DoNotContactTypeId is null or CP.DoNotContactTypeId = 289) OR 
						(
							(
								CP.DoNotContactTypeId = 287 OR CP.DoNotContactTypeId = 288
							) 
							AND
							(
								CP.DoNotContactUpdateDate IS NOT NULL 
								AND 
								CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
								AND (CP.DoNotContactUpdateSource IS NULL OR CP.DoNotContactUpdateSource <> 349)
							)
						)
					) 
					and (CE.IsEligble is not null and CE.IsEligble = 1 ) 
					and (CP.IsIncorrectPhoneNumber is null or CP.IsIncorrectPhoneNumber = 0 or (CP.IsIncorrectPhoneNumber = 1 and CP.IncorrectPhoneNumberMarkedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) ))
					and CP.CustomerID not in
						(
							SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) 
									WHERE CustomerID is not null and CustomerID > 0 
									and (
											pc.Tag = 'Deceased'  or 
											(
												pc.TagUpdateDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) 
												and pc.Tag in ('HomeVisitRequested','DoNotCall','MobilityIssue','InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan') 
											)
										)

						)
					and CP.CustomerID not in 
					(
						SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
								inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID 
								and ec.AppointmentID is not null and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
					)
					AND (CP.ActivityId = 332 OR CP.ActivityId = 333) 
					AND CP.Tag IS NOT NULL AND CP.Tag <> ''				
					




GO


