USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_CallQueueCustomerCriteraAssignmentWithCustomer]    Script Date: 4/18/2018 1:13:59 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



ALTER VIEW [dbo].[Vw_CallQueueCustomerCriteraAssignmentWithCustomer]
As

--Declare @CallQueueStatus bigint
--set @CallQueueStatus = 163 --Initial

SELECT	cqc.CallQueueCustomerId
		,hpcqca.CriteriaId
		,hpcqca.CallQueueId
		,cqc.CustomerId
		,cqc.[Status]
		,cqc.Attempts
		,cqc.IsActive
		,cqc.DateCreated
		,CASE 
			WHEN  cqc.DateModified is null THEN cqc.DateCreated 
			ELSE cqc.DateModified 
		END AS DateModified
		,cqc.CreatedByOrgRoleUserId
		,cqc.ModifiedByOrgRoleUserId
		,cqc.AssignedToOrgRoleUserId
		,cqc.CallQueueCriteriaId
		,cqc.CallDate
		,cqc.HealthPlanId
		,cqc.CampaignId
		,'' as EventIds
		,CASE 
			WHEN calls.CallCount is null THEN 0
			ELSE calls.CallCount 
		END AS  [CallCount],	
		A.ZipID,
		CP.IsLanguageBarrier

FROM            TblCallQueueCustomer AS cqc WITH (NOLOCK) 
				INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId
				inner join 	TblCustomerProfile AS CP WITH (NOLOCK) on cqc.customerId = cp.customerId
				INNER JOIN 	TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
				INNER JOIN	TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
				INNER JOIN	TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID	
				inner JOIN	TblHealthPlanEventZip  Z ON CP.Tag = Z.AccountTag
				inner join 
				(
					select CustomerId, IsEligible from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())
				)CE on CP.CustomerID = CE.CustomerId
				Left Outer Join (
								select CalledCustomerID,COUNT(CalledCustomerID) as [CallCount] 
								from TblCalls c WITH (NOLOCK)
								join TblCallQueueCustomerCall cqcc WITH (NOLOCK) on c.CallID = cqcc.CallId
								Where	(
											c.CalledCustomerID is not null and c.CalledCustomerID > 0
										) and  
										c.TimeCreated > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
										and c.[Status] != 325
										group by CalledCustomerID
							) calls
				on calls.CalledCustomerID = cqc.CustomerId
				WHERE cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL 
					and cqc.HealthPlanId > 0 
					and cqc.[Status] = 163 					
					and cqc.CustomerId not in
					(
						SELECT ccqca.CustomerID from TblCustomerCallQueueCallAttempt as ccqca where ccqca.DateCreated > GETDATE() and ccqca.IsCallSkipped = 1
					)
					and (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 			
				AND (CE.IsEligible = 1) 
				AND ((CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
					OR 
					(
						(CP.DoNotContactTypeId = 287 or CP.DoNotContactTypeId = 288) AND (CP.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))  
					)
				)			
				AND (CP.ActivityId = 332 OR CP.ActivityId = 333) 
				AND (CP.IsIncorrectPhoneNumber = 0) 
				AND CP.Tag IS NOT NULL AND CP.Tag <> ''
				and CP.CustomerID not in
				(
					SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) 
						WHERE CustomerID > 0 
						AND (
								pc.Tag = 'Deceased'  OR 
								(
									pc.ContactedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME) 
									AND pc.Tag IN ('HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan') 
								)
								or 
								(
									pc.Tag = 'CALLBACKLATER' and CallBackRequestedDate > GETDATE()
								)
							)
				)
				AND CP.CustomerID NOT IN 
				(
					SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
					INNER JOIN TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID AND ec.AppointmentID IS NOT NULL 
					AND e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
				)
				AND CHARINDEX(',' + convert(varchar(5), a.ZipID) +',', ',' + z.EventZipID +',') > 0
				And CP.CustomerID Not in 
				(
					select  C.CalledCustomerID from tblCalls C with(nolock) where C.DateCreated > CONVERT(date,GETDATE()) AND C.CalledCustomerID > 0 
					and C.CalledCustomerID Not in 
					(
						SELECT pc.CustomerID FROM TblProspectCustomer pc WITH(NOLOCK) WHERE  CustomerID > 0 AND pc.Tag = 'CALLBACKLATER' and CallBackRequestedDate < GETDATE()								
					)
				)				
				
				


GO


