use [$(dbName)]
go


Alter View Vw_GetCustomersForCallQueue
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
								inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID and ec.AppointmentID is not null and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)

						 )

WHERE        (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
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

GO