USE [$(dbname)]
GO

-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE usp_GetDailerPatientList 
	-- Add the parameters for the stored procedure here
	 @HealthPlanName varchar(512), @CallQueueName varchar(2000)
AS
BEGIN
	
	SET NOCOUNT ON;

    
	DECLARE @HealthPlanId BIGINT, @CriteriaId BIGINT, @CallQueueId BIGINT, @CampaignId BIGINT,
	 @IsMaxAttemptPerHealthPlan BIT, @MaxAttemptPerHealthPlan INT, @OthersFilterDays INT, 
	 @LeftVoiceMailDays INT, @RefusalDays INT, @MaxAttemptPerCallQueue INT, @StartOfYear DATETIME, @MinDate DATETIME	 


	select @HealthPlanId = OrganizationID  from TblOrganization o
	inner join TblAccount a on a.AccountID = o.OrganizationID where [Name] = @HealthPlanName and [OrganizationTypeID] = 5 and a.IsHealthPlan = 1

	SELECT @StartOfYear = CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME), @MinDate = '01/01/1900'

	SELECT @IsMaxAttemptPerHealthPlan = IsMaxAttemptPerHealthPlan, @MaxAttemptPerHealthPlan = MaxAttempt FROM TblAccount WITH(NOLOCK) WHERE AccountID = @HealthPlanId

	Select @CallQueueId = CallQueueId from TblCallQueue Where [Name]= @CallQueueName and IsActive = 1 and IsHealthPlan = 1

	SELECT * INTO #CallQueueSettings FROM TblAccountCallQueueSetting WHERE AccountID = @HealthPlanId AND CallQueueID = @CallQueueId AND IsActive = 1

	SELECT @MaxAttemptPerCallQueue = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 347 --Suppression Type for Max Attempt
	SELECT @LeftVoiceMailDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 344 --Suppression Type for Left Voice Mail
	SELECT @RefusalDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 345 --Suppression Type for Refused Customers
	SELECT @OthersFilterDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 346 --Suppression Type for Other Dispositions

	SELECT CQC.CustomerId,MAX(cqc.CallCount) CallCount, MAX(cqc.Attempts) Attempts,Max(cqc.HealthPlanId) HealthPlanId INTO #CustomerInCallQueue FROM Vw_GetCustomersForCallQueueWithCustomer CQC 

	WHERE	
		cqc.CallQueueId = @CallQueueId and cqc.HealthPlanId = @HealthPlanId
		and
			(	
				(@IsMaxAttemptPerHealthPlan = 1 AND CQC.CallCount < @MaxAttemptPerHealthPlan) 
				OR (@IsMaxAttemptPerHealthPlan = 0 AND CQC.Attempts < @MaxAttemptPerCallQueue)
			)	
		AND (CQC.IsLanguageBarrier = 0 OR (CQC.IsLanguageBarrier = 1 AND CQC.LanguageBarrierMarkedDate < @StartOfYear)) 
		AND (CQC.AppointmentCancellationDate = @MinDate OR CQC.AppointmentCancellationDate <= CONVERT(DATE, (GETDATE() - @OthersFilterDays + 1)))
		AND 
		(
			CQC.ContactedDate = @MinDate OR CQC.Disposition = 'CallBackLater'
			OR NOT
			(
				(CQC.ContactedDate >= CONVERT(DATE, (GETDATE() - @LeftVoiceMailDays + 1)) AND CQC.CallStatus = 33)
				OR
				(
					CQC.ContactedDate >= CONVERT(DATE, (GETDATE() - @RefusalDays + 1))
					AND (CQC.CallStatus <> 325 AND CQC.CallStatus <> 33)
					AND (CQC.Disposition = 'NotInterested' OR CQC.Disposition = 'RecentlySawDoc' OR CQC.Disposition = 'TransportationIssue')
				)
				OR (CQC.ContactedDate >= CONVERT(DATE, (GETDATE() - @OthersFilterDays + 1)))
			)
		) group by cqc.CustomerId
		
	
	select CQC.CustomerId AS [Customer ID],
			u.FirstName AS [First Name],
			ISNULL(u.MiddleName, '') AS [Middle Name],
			u.LastName AS [Last Name],
			U.EMail1 AS Email,
			U.PhoneHome AS [Phone Home],
			U.PhoneOffice AS [Phone Office],
			U.PhoneCell AS [Phone Cell],
			A.Address1 AS [Address Line1],
			ISNULL(A.Address2, '') AS [Address Line2],
			C.[Name] AS City,
			S.[Name] AS [State],
			Z.ZipCode AS [Zip],
			CP.InsuranceId AS [Member ID],
			O.[Name] AS [Health Plan],
			CASE WHEN ACPN.CheckoutPhoneNumber IS NOT NULL THEN ACPN.CheckoutPhoneNumber ELSE 
					(
						SELECT CheckoutPhoneNumber FROM TblAccount WITH(NOLOCK) WHERE AccountID = @HealthPlanId
					) END AS [Caller ID] 

			from #CustomerInCallQueue cqc

			INNER JOIN TblOrganization O WITH(NOLOCK) ON CQC.HealthPlanId = O.OrganizationID
	INNER JOIN TblCustomerProfile CP WITH(NOLOCK) ON CQC.CustomerId = CP.CustomerID
	INNER JOIN TblOrganizationRoleUser ORU WITH(NOLOCK) ON CQC.CustomerId = ORU.OrganizationRoleUserID
	INNER JOIN TblUser U WITH(NOLOCK) ON ORU.UserID = U.UserID
	INNER JOIN TblAddress A WITH(NOLOCK) ON U.HomeAddressID = A.AddressID
	INNER JOIN TblCity C WITH(NOLOCK) ON A.CityID = C.CityID
	INNER JOIN TblState S WITH(NOLOCK) ON A.StateID = S.StateID
	INNER JOIN TblZip Z With(NOLOCK) ON A.ZipID = Z.ZipID
	LEFT OUTER JOIN 
	(
		SELECT TOP 1 AccountID, StateID, CheckoutPhoneNumber FROM TblAccountCheckoutPhoneNumber WITH(NOLOCK) WHERE AccountID = @HealthPlanId
	)
	ACPN ON A.StateID = ACPN.StateID
	order by cqc.CallCount

	DROP TABLE #CallQueueSettings
	Drop table #CustomerInCallQueue
END
GO
