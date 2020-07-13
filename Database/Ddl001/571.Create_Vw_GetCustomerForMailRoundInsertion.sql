USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersToGenerateCallQueue]    Script Date: 02-06-2017 10:23:21 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Vw_GetCustomerForMailRoundInsertion] 
As

	SELECT CP.CustomerID		
		,CP.DoNotContactReasonId
		,CP.DoNotContactReasonNotesId		
		,CP.IsEligble
		,CP.IsIncorrectPhoneNumber
		,CP.IsLanguageBarrier
		,CP.ActivityId
		,CP.DoNotContactTypeId
		,CP.Tag
		, 0 as ZipID
		--,A.ZipID

		FROM TblCustomerProfile AS CP WITH (NOLOCK) 
		--INNER JOIN TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
		--INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
		--INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID

		WHERE CP.Tag IS NOT NULL AND CP.Tag <> ''
			--(CP.DoNotContactTypeId is null or CP.DoNotContactTypeId = 289) 
			--and (CP.IsEligble is not null and CP.IsEligble = 1 ) 
			--and (CP.IsIncorrectPhoneNumber is null or CP.IsIncorrectPhoneNumber = 0 )
			--and CP.CustomerID not in
			--	(
			--		SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) 
			--				WHERE CustomerID is not null and CustomerID > 0 
			--				and (
			--						pc.Tag = 'Deceased'  or 
			--						(
			--							pc.ContactedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME) 
			--							and pc.Tag in ('HomeVisitRequested','DoNotContact','MobilityIssue','InLongTermCareNursingHome') 
			--						)
			--					)

			--	)
			--and CP.CustomerID not in 
			--(
			--	SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
			--			inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID 
			--			and ec.AppointmentID is not null and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
			--)
			--AND (CP.ActivityId = 332 OR CP.ActivityId = 333) 
			--AND CP.Tag IS NOT NULL AND CP.Tag <> ''

GO


