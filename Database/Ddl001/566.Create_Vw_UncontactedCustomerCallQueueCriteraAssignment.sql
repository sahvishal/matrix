use [$(dbName)]
go

IF OBJECT_ID ('Vw_UncontactedCustomerCallQueueCriteraAssignment', 'view') IS NOT NULL  
	DROP VIEW Vw_UncontactedCustomerCallQueueCriteraAssignment ;  
GO 

CREATE VIEW [dbo].[Vw_UncontactedCustomerCallQueueCriteraAssignment]
As

--Declare @CallQueueStatus bigint
--set @CallQueueStatus = 163 --Initial

SELECT	uccq.Id
		,uccqca.CriteriaId		
		,uccq.CustomerId
		,uccq.[Status]
		,cca.Attempt		
		,uccq.DateCreated
		,CASE 
			WHEN  uccq.DateModified is null THEN uccq.DateCreated 
			ELSE uccq.DateModified 
		END AS DateModified		
		,uccq.ModifiedBy				
		,uccq.CallDate
		,uccq.HealthPlanId
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
		TblUncontactedCustomerCallQueue AS uccq WITH (NOLOCK) 
		INNER JOIN  TblUncontactedCustomerCallQueueCriteriaAssignment AS uccqca WITH (NOLOCK) ON uccq.Id = uccqca.UncontactedCustomerId
		INNER JOIN TblCustomerCallAttempts as cca WITH(NOLOCK) on cca.CustomerId = uccq.CustomerId
		INNER JOIN  TblCustomerProfile AS CP WITH (NOLOCK) 	ON CP.CustomerID = uccq.CustomerId
		INNER JOIN TblOrganizationRoleUser AS oru WITH (NOLOCK) ON CP.CustomerID = oru.OrganizationRoleUserID 
		INNER JOIN TblUser AS U WITH (NOLOCK) ON oru.UserID = U.UserID
		INNER JOIN TblAddress AS A WITH (NOLOCK) ON A.AddressID = U.HomeAddressID
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
			) calls on calls.CalledCustomerID = uccq.CustomerId

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
		
			) cttag on cttag.CustomerId = uccq.CustomerId
			

		Where	uccq.CustomerId is not null 
				AND uccq.HealthPlanId IS NOT NULL 
				AND uccq.HealthPlanId > 0 and uccq.[Status] = 163 
				AND (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
				AND (CP.IsEligble IS NOT NULL) 
				AND (CP.IsEligble = 1) 
				AND (CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
				AND (CP.ActivityId IS NOT NULL) 
				AND (CP.ActivityId = 332 OR CP.ActivityId = 333)
				AND CP.IsLanguageBarrier = 0 
				AND (CP.IsIncorrectPhoneNumber = 0) 				
				and uccq.CustomerId not in 
				(
					select CustomerId from TblCustomerLockForCall clfc with (nolock)
				)
				and Not 
					(
						(
							uccq.CallDate > CONVERT(DATE, (GETDATE() + 1)) 	and uccq.CustomerId in 
								(
									SELECT CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
										WHERE c.CalledCustomerID is not null 
												and c.TimeCreated is not null 
												and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] <> 35 
								)
						) 
						or uccq.CustomerId in 
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
