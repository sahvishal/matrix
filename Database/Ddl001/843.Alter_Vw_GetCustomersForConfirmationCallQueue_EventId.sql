USE [$(dbname)]
GO

/****** Object:  View [dbo].[Vw_GetCustomersForConfirmationCallQueue]    Script Date: 4/19/2018 7:05:54 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[Vw_GetCustomersForConfirmationCallQueue]
AS
SELECT cqc.CallQueueCustomerId
  ,hpcqca.CriteriaId
  ,hpcqca.CallQueueId
  ,cqc.CustomerId
  ,cqc.FirstName
  ,cqc.MiddleName
  ,cqc.LastName
  ,cqc.[Status]
  ,cqc.Attempts
  ,cqc.IsActive
  ,cqc.DateCreated
  ,ISNULL(cqc.CallDate,'01/01/1900') as CallDate
  ,ISNULL(cqc.CallCount,0) as CallCount
  ,CASE 
   WHEN  cqc.DateModified is null THEN cqc.DateCreated 
	ELSE cqc.DateModified 
	END AS DateModified
  ,cqc.HealthPlanId
  ,ISNULL(cqc.EventId, 0) as EventId
  ,ISNULL(cqc.EventCustomerId, 0) as EventCustomerId
  ,ISNULL(cqc.AppointmentDate,'01/01/1900') as AppointmentDate
  ,ISNULL(cqc.AppointmentDateTimeWithTimeZone,'01/01/1900') as AppointmentDateTimeWithTimeZone
  ,cqc.LanguageId

   from TblCallQueueCustomer cqc WITH(NOLOCK)
		INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH(NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId

		Where  cqc.HealthPlanId IS NOT NULL
		AND cqc.CustomerId IS NOT NULL
		AND (ISNULL(cqc.PhoneCell, '') <> '' OR ISNULL(cqc.PhoneHome, '') <> '' OR ISNULL(cqc.PhoneOffice, '') <> '')
		AND cqc.[Status] = 163
		AND (
				(cqc.DoNotContactTypeId IS NULL OR cqc.DoNotContactTypeId = 289) 
				OR 
				(
					(cqc.DoNotContactTypeId = 287 OR cqc.DoNotContactTypeId = 288) 
					AND 
					(cqc.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))
					AND
					(cqc.DoNotContactUpdateSource IS NULL OR cqc.DoNotContactUpdateSource <> 349)
				)
			)
		AND
		( 
			cqc.Disposition IS NULL OR cqc.Disposition not in ('Deceased', 'PatientConfirmed', 'CancelAppointment')
		)
		AND
		( 
			cqc.ContactedDate is null
			or 
			(	
				cqc.Disposition = 'CallBackLater' and cqc.CallBackRequestedDate < getdate()
			)
			or
			(
				cqc.ContactedDate < CONVERT(date,GETDATE())
			)
		)
		AND
		(
			cqc.AppointmentDate IS NOT NULL AND cqc.AppointmentDate > GETDATE() AND AppointmentCancellationDate IS NULL
		)
		AND cqc.CustomerId NOT IN
		(
			SELECT CustomerId FROM TblCallQueueCustomerLock WITH(NOLOCK)
		)

GO


