USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForCallQueueWithCustomer]    Script Date: 13-02-2018 12:09:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER  VIEW [dbo].[Vw_GetCustomersForCallQueueWithCustomer]
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
  ,IsNull(cqc.CallCount,0) as CallCount
  ,IsNull(cqc.ZipId,0) as ZipId
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
  ,IsNull(cqc.AppointmentDate,'01/01/1900') as AppointmentDate
  ,IsNull(cqc.AppointmentCancellationDate,'01/01/1900') as AppointmentCancellationDate
  ,IsNull(cqc.LanguageBarrierMarkedDate,'01/01/1900') as LanguageBarrierMarkedDate
  ,IsNull(cqc.IncorrectPhoneNumberMarkedDate,'01/01/1900') as IncorrectPhoneNumberMarkedDate

     from TblCallQueueCustomer cqc with(nolock)
		INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId

	Where  cqc.HealthPlanId is not null 
	AND cqc.CustomerId is not null 
	AND cqc.IsEligble = 1 
	AND (cqc.ActivityId = 332 OR cqc.ActivityId = 333 )
	AND (ISNULL(cqc.PhoneCell, '') <> '' OR ISNULL(cqc.PhoneHome, '') <> '' OR ISNULL(cqc.PhoneOffice, '') <> '')
	And (cqc.IsIncorrectPhoneNumber =  0 or (cqc.IsIncorrectPhoneNumber = 1 and cqc.IncorrectPhoneNumberMarkedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME) ))
	AND cqc.[Status] = 163   
	AND 
	(
		(cqc.DoNotContactTypeId IS NULL OR cqc.DoNotContactTypeId = 289) 
		OR 
		(
			(
				cqc.DoNotContactTypeId = 287 or cqc.DoNotContactTypeId = 288
			) 
			AND 
			(
				cqc.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME)
			)  
			AND
			(
				cqc.DoNotContactUpdateSource IS NULL OR cqc.DoNotContactUpdateSource <> 349
			)

		)
	)
	And 
	( 
		cqc.Disposition is null or cqc.Disposition <> 'Deceased'   
	)
	AND 
	( 
		cqc.ContactedDate is null  
		OR 
		(
			cqc.CallStatus  = 325 and cqc.ContactedDate < CONVERT(date,GETDATE()) 
		)
		or
		(
			cqc.ContactedDate < CONVERT(date,GETDATE()) 
			and
			cqc.ContactedDate > CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
			and
			cqc.Disposition NOT IN ('HomeVisitRequested', 'DoNotCall', 'MobilityIssue', 'InLongTermCareNursingHome','DebilitatingDisease','MobilityIssues_LeftMessageWithOther','NoLongeronInsurancePlan')
		)	 
		or
		( 
			cqc.ContactedDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
		)
		or 
		(	
			cqc.Disposition = 'CallBackLater' and cqc.CallBackRequestedDate < getdate() 
		)          
	)
	And Not 
	(
			cqc.Disposition = 'CallBackLater' and cqc.CallBackRequestedDate > GETDATE()
	)
	And 
	(
		cqc.AppointmentDate is null or cqc.AppointmentDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-' + CONVERT(VARCHAR, 1) + '-' + CONVERT(VARCHAR, 1) AS DATETIME)
	)  
	And Exists 
	(
		select * from TblAccountEventZip where ZipId = cqc.ZipId and AccountId = cqc.HealthPlanId
	)



GO


