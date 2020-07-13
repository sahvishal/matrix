USE [$(dbname)]
GO

IF EXISTS (SELECT * FROM sys.views WHERE name = 'Vw_GetCustomersForConfirmationCallQueue')
DROP VIEW [Vw_GetCustomersForConfirmationCallQueue]
GO

CREATE VIEW [dbo].[Vw_GetCustomersForConfirmationCallQueue]
AS
SELECT cqc.CallQueueCustomerId
  ,hpcqca.CriteriaId
  ,hpcqca.CallQueueId
  ,cqc.CustomerId
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
  ,ISNULL(cqc.AppointmentDate,'01/01/1900') as AppointmentDate
  ,ISNULL(cqc.AppointmentDateTimeWithTimeZone,'01/01/1900') as AppointmentDateTimeWithTimeZone

   from TblCallQueueCustomer cqc WITH(NOLOCK)
		INNER JOIN  TblHealthPlanCallQueueCriteriaAssignment AS hpcqca WITH(NOLOCK) ON cqc.CallQueueCustomerId = hpcqca.CallQueueCustomerId

		Where  cqc.HealthPlanId IS NOT NULL
		AND cqc.CustomerId IS NOT NULL
		--AND cqc.IsEligble = 1 
		--AND (cqc.ActivityId = 332 OR cqc.ActivityId = 333 )
		AND (ISNULL(cqc.PhoneCell, '') <> '' OR ISNULL(cqc.PhoneHome, '') <> '' OR ISNULL(cqc.PhoneOffice, '') <> '')
		--AND (ISNULL(cqc.FirstName, '') <> '' OR ISNULL(cqc.MiddleName, '') <> '' OR ISNULL(cqc.LastName, '') <> '')
		AND cqc.[Status] = 163
		AND (
				(cqc.DoNotContactTypeId IS NULL OR cqc.DoNotContactTypeId = 289) 
				OR 
				(
					(cqc.DoNotContactTypeId = 287 OR cqc.DoNotContactTypeId = 288) 
					AND 
					(cqc.DoNotContactUpdateDate < CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME))
				)
			)
		AND
		( 
			cqc.Disposition IS NULL OR cqc.Disposition not in ('Deceased', 'PatientConfirmed', 'CancelAppointment')
		)
		AND
		( 	
			cqc.ContactedDate IS NULL
			OR
			(cqc.CallStatus = 325 AND cqc.ContactedDate < CONVERT(DATE,GETDATE()) )			
			OR
			(
				cqc.Disposition = 'CallBackLater' AND cqc.CallBackRequestedDate < GETDATE() 
			)								
		)
		AND
		(
			cqc.ContactedDate IS NULL
			OR
			cqc.ContactedDate < CONVERT(DATE,GETDATE()) 
			OR 
			(cqc.Disposition = 'CallBackLater' AND cqc.ContactedDate > CONVERT(DATE,GETDATE()) AND cqc.CallStatus != 325)
		)
		AND
		(
			cqc.AppointmentDate IS NOT NULL AND cqc.AppointmentDate > GETDATE() AND AppointmentCancellationDate IS NULL
		)


GO