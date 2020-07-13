USE [$(dbname)]
GO

ALTER VIEW [dbo].[Vw_GetTestPerformedReport]
As

	SELECT      ec.EventId, ec.CustomerId, e.EventDate, p.Name AS Pod, accountTemp.AccountId, accountTemp.IsHealthPlan, 
				cets.CustomerEventTestStateId, cets.CustomerEventScreeningTestId, cets.EvaluationState, 
                cets.IsPartial, cets.IsCritical, cets.SelfPresent, cets.CreatedByOrgRoleUserId, 
				cets.CreatedOn, cets.IsTestNotPerformed, cets.ConductedByOrgRoleUserId,
				cets.EvaluatedByOrgRoleUserId, cets.TechnicianNotes, 
                cets.UpdatedByOrgRoleUserId, cets.UpdatedOn, cets.IsNoteManualEntered, cets.TestSummary, 
				cets.PathwayRecommendation, cets.IsPriorityInQueue,
				ces.TestId
				,CONVERT(BIT,CASE WHEN (EventCustomerResult.ResultState >= 6 AND EventCustomerResult.IsResultPDFGenerated=1) THEN 1 ELSE 0 END) AS  IsPdfGenerated

		FROM    TblEventCustomers AS ec WITH (nolock) 
		INNER JOIN TblCustomerEventScreeningTests AS ces WITH (nolock) ON ec.EventCustomerId = ces.EventCustomerResultId 
		INNER JOIN TblCustomerEventTestState AS cets WITH (nolock) ON ces.CustomerEventScreeningTestID = cets.CustomerEventScreeningTestId 
		--INNER JOIN TblEventCustomers AS ec WITH (nolock) ON ecr.EventCustomerResultId = ec.EventCustomerID 
		INNER JOIN TblEventAppointment AS ea WITH (nolock) ON ec.AppointmentID = ea.AppointmentID 
		INNER JOIN TblEvents AS e WITH (nolock) ON ec.EventID = e.EventID 
		INNER JOIN TblEventPod AS ep WITH (nolock) ON e.EventID = ep.EventID AND ep.IsActive = 1 
		INNER JOIN TblPodDetails AS p WITH (nolock) ON p.PodID = ep.PodID 
		LEFT OUTER JOIN
        (
			SELECT  eAccount.EventID, a.AccountID, a.IsHealthPlan
			FROM	TblEventAccount AS eAccount WITH (nolock) 
			INNER JOIN TblAccount AS a WITH (nolock) ON eAccount.AccountID = a.AccountID
		) AS accountTemp ON e.EventID = accountTemp.EventID
		
		OUTER APPLY(
			SELECT top 1 * FROM TblEventCustomerResult ecr WITH (nolock) WHERE ecr.CustomerID = ec.CustomerID ORDER BY ecr.EventCustomerResultId DESC
		) EventCustomerResult
		
		WHERE        (cets.ConductedByOrgRoleUserId IS NOT NULL) 
					AND (ec.NoShow = 0) 
					AND (ec.LeftWithoutScreeningReasonId IS NULL) 
					AND (ea.CheckinTime IS NOT NULL) 
					AND (ea.CheckoutTime IS NOT NULL) 
					AND (e.EventDate < GETDATE() + 1) 
					AND (ces.CustomerEventScreeningTestID NOT IN 
								(
									SELECT CustomerEventScreeningTestId FROM TblTestNotPerformed AS tnp WITH (nolock)
								)
						)