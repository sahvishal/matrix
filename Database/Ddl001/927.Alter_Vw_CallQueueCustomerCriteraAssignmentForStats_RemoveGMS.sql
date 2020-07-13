USE [$(dbName)]
GO

/****** Object:  View [dbo].[Vw_CallQueueCustomerCriteraAssignmentForStats]    Script Date: 7/30/2018 3:14:17 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER VIEW [dbo].[Vw_CallQueueCustomerCriteraAssignmentForStats]
AS

SELECT cqc.CallQueueCustomerId
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
  ,IsNull(cqc.ContactedDate,'01/01/1900') as ContactedDate
  ,cqc.Disposition   
  ,IsNull(cqc.AppointmentDate,'01/01/1900') as AppointmentDate
  ,IsNull(cqc.AppointmentCancellationDate,'01/01/1900') as AppointmentCancellationDate
  ,ISNULL(cqc.IsEligble,0) as IsEligble
  ,ISNULL(cqc.ActivityId,331) as ActivityId
  ,ISNULL(cqc.PhoneCell,'') as PhoneCell
  ,ISNULL(cqc.PhoneHome,'') as PhoneHome
  ,ISNULL(cqc.PhoneOffice,'') as PhoneOffice  
  ,ISNULL(cqc.IsIncorrectPhoneNumber,0) as IsIncorrectPhoneNumber
  ,ISNULL(cqc.DoNotContactTypeId,0) as DoNotContactTypeId  
  ,ISNULL(cqc.CallBackRequestedDate,'01/01/1900') as CallBackRequestedDate    
  ,ISNULL(cqc.DoNotContactUpdateDate,'01/01/1900') as DoNotContactUpdateDate
  ,ISNULL(cqc.DoNotContactUpdateSource,0) as DoNotContactUpdateSource
  ,ISNULL(cqc.LanguageBarrierMarkedDate,'01/01/1900') as LanguageBarrierMarkedDate
  ,ISNULL(cqc.IncorrectPhoneNumberMarkedDate,'01/01/1900') as IncorrectPhoneNumberMarkedDate
  ,IsNull(cqc.NoShowDate,'01/01/1900') as NoShowDate

	FROM TblCallQueueCustomer AS cqc WITH (NOLOCK) 
	
	INNER JOIN TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId				
	Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL and cqc.HealthPlanId > 0
	AND
	(
		cqc.CallQueueId = 151
		OR
		cqc.CustomerId IN
		(
			SELECT CustomerId FROM TblCustomerTag WITH(NOLOCK) WHERE Tag in
			(
				SELECT Tag FROM TblCorporateTag WITH(NOLOCK) WHERE StartDate >= '11/01/2017' and EndDate >= CONVERT(DATE, GETDATE()) AND IsActive = 1
			) and IsActive = 1
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


