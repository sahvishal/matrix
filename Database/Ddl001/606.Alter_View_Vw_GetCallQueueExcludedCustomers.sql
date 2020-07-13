USE [$(dbname)]
GO

ALTER VIEW [dbo].[Vw_GetCallQueueExcludedCustomers]
AS
	SELECT [CustomerID]
      ,[Tag]
	  ,[ActivityId]
	  ,[IsEligble]
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
	WHERE (U.PhoneCell IS NULL AND U.PhoneHome IS NULL AND U.PhoneOffice IS NULL)
	OR (CP.IsEligble IS NULL OR CP.IsEligble = 0)
	OR (CP.DoNotContactTypeId IS NOT NULL AND CP.DoNotContactTypeId <> 289 AND CP.DoNotContactUpdateDate >= CONVERT(DATE,DATEADD(YEAR,DATEDIFF(YEAR,0,GETDATE()),0)))
	OR (CP.ActivityId IS NULL OR CP.ActivityId = 331)
	OR (CP.IsIncorrectPhoneNumber = 1)
	OR (CP.CustomerID IN 
			(
				SELECT CustomerID FROM TblEventCustomers EC WITH (NOLOCK)
				INNER JOIN TblEvents E WITH (NOLOCK) ON EC.EventID = E.EventID
				WHERE EC.AppointmentID IS NOT NULL AND E.EventDate >= CONVERT(DATE,DATEADD(YEAR,DATEDIFF(YEAR,0,GETDATE()),0))
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
								'HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther'
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