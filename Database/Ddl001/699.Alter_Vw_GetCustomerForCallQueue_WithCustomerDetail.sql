USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForCallQueue]    Script Date: 28-12-2017 20:45:29 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF OBJECT_ID ('Vw_GetCustomersForCallQueue', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCustomersForCallQueue  
GO 

IF OBJECT_ID ('Vw_GetCustomersForCallQueueWithCustomer', 'view') IS NOT NULL  
	DROP VIEW Vw_GetCustomersForCallQueueWithCustomer  
GO 

Create  VIEW [dbo].[Vw_GetCustomersForCallQueueWithCustomer]
AS
select cqc.CallQueueCustomerId
  ,hpcqca.CriteriaId
  ,hpcqca.CallQueueId
  ,cqc.CustomerId
  ,cqc.[Status]
  ,cqc.Attempts
  ,cqc.IsActive
  ,cqc.DateCreated
  ,isNull(cqc.CallDate,'01/01/1900') as CallDate
  ,IsNull(cqc.CallCount,0) As CallCount
 ,cqc.ZipId
  ,CASE 
   WHEN  cqc.DateModified is null THEN cqc.DateCreated 
	ELSE cqc.DateModified 
	END AS DateModified
  ,cqc.HealthPlanId
  ,cqc.CampaignId
  ,cqc.EventIds
  ,cqc.FirstName
  ,cqc.MiddleName
  ,cqc.LastName
  ,cqc.ZipCode
  ,cqc.IsLanguageBarrier
  ,IsNull(cqc.CallStatus,0) as CallStatus
  ,IsNull(cqc.ContactedDate,'01/01/1900') as ContactedDate
  ,cqc.Disposition  
  ,cqc.HasFutureAppointment
  , IsNull(cqc.AppointmentDate,'01/01/1900') as AppointmentDate
  ,IsNull(cqc.AppointmentCancellationDate,'01/01/1900') as AppointmentCancellationDate

   from TblCallQueueCustomer cqc with(nolock)
		INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId

		Where  cqc.HealthPlanId is not null 
		AND cqc.CustomerId is not null 
		AND cqc.IsEligble = 1 
		AND (cqc.ActivityId = 332 OR cqc.ActivityId = 333 )
		AND (ISNULL(cqc.PhoneCell, '') <> '' OR ISNULL(cqc.PhoneHome, '') <> '' OR ISNULL(cqc.PhoneOffice, '') <> '')
		AND (ISNULL(cqc.FirstName, '') <> '' OR ISNULL(cqc.MiddleName, '') <> '' OR ISNULL(cqc.LastName, '') <> '')
		AND cqc.[Status] = 163 
		AND cqc.IsCallSkipped = 0

		AND (
				(cqc.DoNotContactTypeId IS NULL OR cqc.DoNotContactTypeId = 289) 
				OR 
				(
					(cqc.DoNotContactTypeId = 287 or cqc.DoNotContactTypeId = 288) 
					AND 
					(cqc.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))  
				)
			)
		And 
		( 
			cqc.Disposition is null or cqc.Disposition <> 'Deceased'	
		)
		AND
		( 		
			( 
				cqc.ContactedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
					and
				cqc.Disposition  IN ('HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan')
			)
			or 
			(
				cqc.Disposition = 'CallBackLater' and cqc.CallBackRequestedDate < getdate() 
			)
			or 
			(
				cqc.Disposition Not IN ('HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan')
			)								
		)
		AND
		(
			cqc.ContactedDate is null 
			or 
			cqc.ContactedDate < CONVERT(date,GETDATE()) 
			OR 
			(cqc.Disposition = 'CallBackLater' and cqc.ContactedDate > CONVERT(date,GETDATE()) and cqc.CallStatus != 325)
		)
		And 
		(
			cqc.AppointmentDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
		)

GO


