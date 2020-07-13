USE [$(dbName)]
GO

ALTER VIEW [dbo].[Vw_GetCustomersForCallQueueWithCustomerVici]
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
  ,'' as EventIds
  ,cqc.FirstName
  ,cqc.MiddleName
  ,cqc.LastName
  ,cqc.ZipCode
  ,cqc.IsLanguageBarrier
  ,IsNull(cqc.CallStatus,0) as CallStatus
  ,IsNull(cqc.ContactedDate,cast('01/01/1900' as datetime)) as ContactedDate
  ,cqc.Disposition   
  ,IsNull(cqc.AppointmentDate,cast('01/01/1900' as datetime)) as AppointmentDate
  ,IsNull(cqc.AppointmentCancellationDate,cast('01/01/1900' as datetime)) as AppointmentCancellationDate
  ,IsNull(cqc.LanguageBarrierMarkedDate,cast('01/01/1900' as datetime)) as LanguageBarrierMarkedDate
  ,IsNull(cqc.IncorrectPhoneNumberMarkedDate,cast('01/01/1900' as datetime)) as IncorrectPhoneNumberMarkedDate
  ,IsNull(cqc.NoShowDate,cast('01/01/1900' as datetime)) as NoShowDate
  ,ISNULL(cqc.ProductTypeId, 0) ProductTypeId
     from TblCallQueueCustomer cqc with(nolock)
		INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId

	Where  cqc.HealthPlanId is not null 
	AND cqc.CustomerId is not null 
	AND cqc.IsEligble = 1 
	AND (cqc.TargetedYear IS NOT null AND cqc.IsTargeted IS NOT	null AND cqc.TargetedYear = DATEPART(YEAR, GETDATE()) AND cqc.IsTargeted = 1)
	AND (cqc.ActivityId = 2 OR cqc.ActivityId = 3 )
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
				cqc.ContactedDate > CONVERT(date,GETDATE()) and 
				(
					(cqc.CallStatus = 33 ) 
					or 
					(cqc.CallStatus = 32) 
					or 
					(cqc.CallStatus = 242 and cqc.Disposition = 'LeftMessage')
				) 
		)
		OR 
		(
			(cqc.CallStatus  = 325 OR cqc.CallStatus = 35) and cqc.ContactedDate < CONVERT(date,GETDATE()) 
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
	And 
	(
		Exists 
		(
			select AccountId from TblAccountEventZip WITH(NOLOCK) where ZipId = cqc.ZipId and AccountId = cqc.HealthPlanId
		) 
		OR
		Exists
		(
			select AccountId from TblAccountEventZipSubstitute WITH(NOLOCK) where ZipId = cqc.ZipId and AccountId = cqc.HealthPlanId
		)
	)
	AND
	(
		cqc.CallQueueId = 151
		OR
		cqc.CustomerId IN
		(
			SELECT CustomerId FROM TblCustomerTag WITH(NOLOCK) WHERE Tag in
			(
				SELECT Tag FROM TblCorporateTag WITH(NOLOCK) WHERE StartDate >= cast('11/01/2017' as datetime) and EndDate >= CONVERT(DATE, GETDATE()) AND IsActive = 1
			) and IsActive = 1
		)
	)
	AND cqc.CustomerId NOT IN
	(
		SELECT CustomerId FROM TblCallQueueCustomerLock WITH(NOLOCK)
	)
	AND
	( 
		exists
			(
				select zrd.DestinationZipId from TblEventZipProductType tt 
				inner join TblZipRadiusDistance zrd on zrd.SourceZipId = tt.zipId and Radius <=  60 
				where tt.ProductTypeId = cqc.ProductTypeId
			)
		or exists 
				(
				select zrd.DestinationZipId from TblEventZipProductTypeSubstitute tt 
				inner join TblZipRadiusDistance zrd on zrd.SourceZipId = tt.zipId and Radius <=  60 
				where tt.ProductTypeId = cqc.ProductTypeId
				)
	)
	--AND
	--(
	--	cqc.HealthPlanId NOT IN
	--	(
	--		SELECT HealthPlanId FROM TblCallQueueCustomTag CQCT WITH(NOLOCK) WHERE CQCT.IsActive = 1
	--	)
	--	OR
	--	(
	--		cqc.CustomerId IN
	--		(
	--			SELECT CustomerId FROM TblCustomerTag CT WITH(NOLOCK) WHERE CT.Tag in
	--			(
	--				SELECT CustomTag FROM TblCallQueueCustomTag CQCT WITH(NOLOCK) WHERE CQCT.IsActive = 1 AND CQCT.HealthPlanId = cqc.HealthPlanId
	--			) AND IsActive = 1
	--		)
	--		and cqc.CustomerID not IN
	--		(
	--			SELECT CustomerId FROM TblCustomerTag WITH(NOLOCK)
	--			WHERE Tag IN 
	--			(
	--				'Optum-UT_GMS_2018_List-1', 'UHC-TX_GMS_2018_List-1', 'Excellus_GMS_2018_List-1',
	--				'UHC-CT_Assessments_2018_List-1_GMS',
	--				'UHC-AZ_Assessments_2018_List-1_GMS',
	--				'Optum-NV_Assessments_2018_List-2_GMS',
	--				'Optum-NV_Mammo_2018_List-2_GMS',
	--				'Optum-NV_Assessments_2018_List-1_GMS',
	--				'Optum-NV_Assessments_2018_List-4_GMS',
	--				'Optum-NV_Assessments_2018_List-3_GMS'
	--			)
	--		)
	--	)
	--)

GO


