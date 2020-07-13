USE [$(dbname)]
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

	FROM TblCallQueueCustomer AS cqc WITH (NOLOCK) 
	
	INNER JOIN TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH (NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId				
	Where cqc.CustomerId is not null AND cqc.HealthPlanId IS NOT NULL and cqc.HealthPlanId > 0
	AND cqc.CustomerId IN
	(
		SELECT CustomerId FROM TblCustomerTag WITH(NOLOCK) WHERE Tag in
		(
			SELECT Tag FROM TblCorporateTag WITH(NOLOCK) WHERE StartDate >= '11/01/2017' and EndDate >= CONVERT(DATE, GETDATE()) AND IsActive = 1
		)
	)
GO