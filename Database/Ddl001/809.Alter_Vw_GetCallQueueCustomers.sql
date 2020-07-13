USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCallQueueCustomers]    Script Date: 3/30/2018 4:05:20 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[Vw_GetCallQueueCustomers]
AS
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
		,cqc.HealthPlanId
		,cqc.CallQueueId
		,hpcqca.CriteriaId
		,cqc.CampaignId

FROM            TblCustomerProfile AS CP WITH (NOLOCK) INNER JOIN
                         TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
						 INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
						 INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID	
						 JOIN TblHealthPlanEventZip  Z  WITH (NOLOCK) ON CP.Tag = Z.AccountTag
						 INNER JOIN TblCallQueueCustomer AS cqc WITH (NOLOCK) on cqc.CustomerId = cp.CustomerID
						INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId
						Left Outer join 
						(
							select CustomerId, IsEligible as IsEligble from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())
						)CE on CP.CustomerID = CE.CustomerId
						Left Outer Join (
										select CalledCustomerID,COUNT(CalledCustomerID) as [CallCount] 
										from tblCalls c WITH (NOLOCK)
										Where	(
													c.CalledCustomerID is not null and c.CalledCustomerID > 0
												) and  
												c.TimeCreated > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
												and c.[Status] != 325
												group by CalledCustomerID
									) calls
						on calls.CalledCustomerID = cqc.CustomerId
				
					Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL 
					and cqc.HealthPlanId > 0 
					and cqc.[Status] = 163 

						 AND (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
						 AND (CE.IsEligble IS NOT NULL) 
						 AND (CE.IsEligble = 1) 
						 AND ((CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
								OR 
								(
									(CP.DoNotContactTypeId = 287 or CP.DoNotContactTypeId = 288) AND (CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))
									AND (CP.DoNotContactUpdateSource IS NULL OR CP.DoNotContactUpdateSource <> 349)
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
						 AND CHARINDEX(',' + convert(varchar(5), a.ZipID) +',', ',' + z.EventZipID +',') > 0

GO


