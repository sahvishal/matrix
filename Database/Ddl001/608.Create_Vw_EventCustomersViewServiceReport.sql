USE [$(dbname)]
GO

IF OBJECT_ID('Vw_EventCustomersViewServiceReport', 'view') IS NOT NULL
    DROP VIEW [dbo].[Vw_EventCustomersViewServiceReport]
GO

CREATE VIEW Vw_EventCustomersViewServiceReport
As

SELECT	ec.EventCustomerId, 
		ec.CustomerID as CustomerId, 
		ec.EventID as EventId, 
		ec.DateCreated, 		
		eAccount.AccountID as AccountId,
		e.EventDate

				FROM TblEventCustomers AS ec WITH (nolock) INNER JOIN
                     TblEventAppointment AS ea WITH (nolock) ON ec.AppointmentID = ea.AppointmentID INNER JOIN
                     TblEvents AS e WITH (nolock) ON ec.EventID = e.EventID INNER JOIN
                     TblEventAccount AS eAccount WITH (NOLOCK) ON ec.EventID = eAccount.EventID
WHERE		(ec.NoShow = 0) 
		AND (ec.LeftWithoutScreeningReasonId IS NULL) 
		AND (ea.CheckinTime IS NOT NULL) 
		AND (ea.CheckoutTime IS NOT NULL) 
		AND (e.EventDate < GETDATE() + 1) 
		AND (
				ec.EventCustomerID IN
                             (
								SELECT	ces.EventCustomerResultId
									FROM	TblCustomerEventScreeningTests AS ces WITH (nolock) INNER JOIN
                                            TblCustomerEventTestState AS cets WITH (nolock) ON ces.CustomerEventScreeningTestID = cets.CustomerEventScreeningTestId
									WHERE	ces.CustomerEventScreeningTestID NOT IN
                                                (	
													SELECT CustomerEventScreeningTestId FROM TblTestNotPerformed AS tnp WITH (nolock)
												)									
							)
			)