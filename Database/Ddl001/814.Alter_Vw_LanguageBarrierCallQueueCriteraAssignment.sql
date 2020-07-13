USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_LanguageBarrierCallQueueCriteraAssignment]    Script Date: 3/30/2018 4:21:50 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_LanguageBarrierCallQueueCriteraAssignment]
As

--Declare @CallQueueStatus bigint
--set @CallQueueStatus = 163 --Initial

SELECT	lbcq.Id
		,lbcqca.CriteriaId		
		,lbcq.CustomerId
		,lbcq.[Status]
		,cca.Attempt		
		,lbcq.DateCreated
		,CASE 
			WHEN  lbcq.DateModified is null THEN lbcq.DateCreated 
			ELSE lbcq.DateModified 
		END AS DateModified		
		,lbcq.ModifiedBy				
		,lbcq.CallDate
		,lbcq.HealthPlanId
		,CASE 
			WHEN calls.CallCount is null THEN 0
			ELSE calls.CallCount 
		END AS  [CallCount]
		,CASE 
			WHEN cttag.CustomerId is null THEN 0
			ELSE cttag.TagCount 
		END AS  [TagCount]
		,CASE 
			WHEN cttag.CustomerId is null THEN cttag.Tag
			ELSE cttag.Tag 
		END AS  [Tags]
		,A.ZipID
	FROM        
		TblLanguageBarrierCallQueue AS lbcq WITH (NOLOCK) 
		INNER JOIN  TblLanguageBarrierCallQueueCriteriaAssignment AS lbcqca WITH (NOLOCK) ON lbcq.Id = lbcqca.LanguageBarrierCallQueueId
		INNER JOIN TblCustomerCallAttempts as cca WITH(NOLOCK) on cca.CustomerId = lbcq.CustomerId
		INNER JOIN  TblCustomerProfile AS CP WITH (NOLOCK) 	ON CP.CustomerID = lbcq.CustomerId
		INNER JOIN TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
		INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
		INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID
		Left Outer join 
		(
			select CustomerId, IsEligible from TblCustomerEligibility WITH (NOLOCK) where ForYear = DATEPART(YEAR, GETDATE())
		)CE on CP.CustomerID = CE.CustomerId
		Left Outer Join 
			(
						select CalledCustomerID,COUNT(CalledCustomerID) as [CallCount] 
						from tblCalls c WITH (NOLOCK)
						Where	(
									c.CalledCustomerID is not null and c.CalledCustomerID > 0
								) and  
								c.TimeCreated > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
								and c.[Status] != 325
								group by CalledCustomerID
			) calls on calls.CalledCustomerID = lbcq.CustomerId

		Left Outer Join
			(
				select ct.CustomerId,count(ct.CustomerId) TagCount
				,STUFF(
						(
							SELECT DISTINCT ',' + ct1.Tag
									from TblCustomerTag ct1 With(NOLOCK)
									where ct1.CustomerId = ct.CustomerId for XML Path(''), TYPE
						).value('.','NVARCHAR(MAX)'),1,1,''
					) Tag  from TblCustomerTag ct With(NOLOCK) group by ct.CustomerId
		
			) cttag on cttag.CustomerId = lbcq.CustomerId
			

		Where	lbcq.CustomerId is not null 
				AND lbcq.HealthPlanId IS NOT NULL 
				AND lbcq.HealthPlanId > 0 and lbcq.[Status] = 163 
				AND (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
				AND (CE.IsEligible IS NOT NULL) 
				AND (CE.IsEligible = 1) 
				AND (CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
				AND (CP.ActivityId IS NOT NULL) 
				AND (CP.ActivityId = 332 OR CP.ActivityId = 333)
				AND CP.IsLanguageBarrier = 1 
				AND (CP.IsIncorrectPhoneNumber = 0) 				
				and lbcq.CustomerId not in 
				(
					select CustomerId from TblCustomerLockForCall clfc with (nolock)
				)
				and Not 
					(
						(
							lbcq.CallDate > CONVERT(DATE, (GETDATE() + 1)) 	and lbcq.CustomerId in 
								(
									SELECT CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
										WHERE c.CalledCustomerID is not null 
												and c.TimeCreated is not null 
												and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] <> 35 
								)
						) 
						or lbcq.CustomerId in 
						(
								SELECT	CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
								WHERE	c.CalledCustomerID is not null 
										and c.TimeCreated is not null 
										and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] = 35 
						)
					)
				AND CP.CustomerID NOT IN 
					(
						SELECT EC.CustomerID FROM tbleventcustomers ec WITH (NOLOCK) 
								inner join TblEvents e WITH(NOLOCK) on ec.EventID = e.EventID 
						WHERE	ec.AppointmentID is not null 
								and e.EventDate >= CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)

					)


GO


