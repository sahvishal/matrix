use [$(dbName)]
go

IF OBJECT_ID ('Vw_MailRoundCallQueueCriteraAssignment', 'view') IS NOT NULL  
	DROP VIEW Vw_MailRoundCallQueueCriteraAssignment ;  
GO 

CREATE VIEW [dbo].[Vw_MailRoundCallQueueCriteraAssignment]
As

--Declare @CallQueueStatus bigint
--set @CallQueueStatus = 163 --Initial

SELECT	mrcq.Id
		,mrcqca.CriteriaId		
		,mrcq.CustomerId
		,mrcq.[Status]
		,cca.Attempt		
		,mrcq.DateCreated
		,CASE 
			WHEN  mrcq.DateModified is null THEN mrcq.DateCreated 
			ELSE mrcq.DateModified 
		END AS DateModified		
		,mrcq.ModifiedBy				
		,mrcq.CallDate
		,mrcq.HealthPlanId
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
		TblMailRoundCallQueue AS mrcq WITH (NOLOCK) 
		INNER JOIN  TblMailRoundCallQueueCriteriaAssignment AS mrcqca WITH (NOLOCK) ON mrcq.Id = mrcqca.MailRoundCallQueueId
		INNER JOIN TblCustomerCallAttempts as cca WITH(NOLOCK) on cca.CustomerId = mrcq.CustomerId
		INNER JOIN  TblCustomerProfile AS CP WITH (NOLOCK) 	ON CP.CustomerID = mrcq.CustomerId
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
			) calls on calls.CalledCustomerID = mrcq.CustomerId

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
		
			) cttag on cttag.CustomerId = mrcq.CustomerId
			

		Where	mrcq.CustomerId is not null 
				AND mrcq.HealthPlanId IS NOT NULL 
				AND mrcq.HealthPlanId > 0 and mrcq.[Status] = 163 
				AND (ISNULL(U.PhoneCell, '') <> '' OR ISNULL(U.PhoneHome, '') <> '' OR ISNULL(U.PhoneOffice, '') <> '') 
				AND (CP.IsEligble IS NOT NULL) 
				AND (CP.IsEligble = 1) 
				AND (CP.DoNotContactTypeId IS NULL OR CP.DoNotContactTypeId = 289) 
				AND (CP.ActivityId IS NOT NULL) 
				AND (CP.ActivityId = 332 OR CP.ActivityId = 333)
				AND CP.IsLanguageBarrier = 0 
				AND (CP.IsIncorrectPhoneNumber = 0) 				
				and mrcq.CustomerId not in 
				(
					select CustomerId from TblCustomerLockForCall clfc with (nolock)
				)
				and Not 
					(
						(
							mrcq.CallDate > CONVERT(DATE, (GETDATE() + 1)) 	and mrcq.CustomerId in 
								(
									SELECT CalledCustomerID FROM TblCalls c WITH(NOLOCK)  
										WHERE c.CalledCustomerID is not null 
												and c.TimeCreated is not null 
												and CONVERT(DATE, c.TimeCreated)  = CONVERT(DATE, (GETDATE())) and c.[Status] <> 35 
								)
						) 
						or mrcq.CustomerId in 
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
