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
Alter PROCEDURE usp_GetDailerPatientList 
	-- Add the parameters for the stored procedure here
	 @HealthPlanName varchar(512), @CallQueueName varchar(2000), @CriteriaId BIGINT
AS
BEGIN
	
	SET NOCOUNT ON;

    DECLARE  @IsMaxAttemptPerHealthPlan BIT, @MaxAttemptPerHealthPlan INT, @OthersFilterDays INT, 
	 @LeftVoiceMailDays INT, @RefusalDays INT, @MaxAttemptPerCallQueue INT, @StartOfYear DATETIME,
	 @MinDate DATETIME, @CheckoutPhoneNumber nvarchar(100), @HealthPlanId bigint, @CallQueueId bigint
	 

	select @HealthPlanId = OrganizationID, @CheckoutPhoneNumber = a.CheckoutPhoneNumber,  @IsMaxAttemptPerHealthPlan =  a.IsMaxAttemptPerHealthPlan, @MaxAttemptPerHealthPlan = a.MaxAttempt  
		from TblOrganization o With(nolock)
		inner join TblAccount a With(nolock) on a.AccountID = o.OrganizationID 
		where [Name] = @HealthPlanName and [OrganizationTypeID] = 5 and a.IsHealthPlan = 1

	
	SELECT @StartOfYear = CAST(CONVERT(VARCHAR, DATEPART(yyyy,GETDATE())) + '-1-1' AS DATETIME), @MinDate = '01/01/1900'

	Select @CallQueueId = CallQueueId from TblCallQueue With(nolock) Where [Name]= @CallQueueName and IsActive = 1 and IsHealthPlan = 1

	SELECT * INTO #CallQueueSettings FROM TblAccountCallQueueSetting With(nolock) WHERE AccountID = @HealthPlanId AND CallQueueID = @CallQueueId AND IsActive = 1

	SELECT @MaxAttemptPerCallQueue = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 347 --Suppression Type for Max Attempt
	SELECT @LeftVoiceMailDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 344 --Suppression Type for Left Voice Mail
	SELECT @RefusalDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 345 --Suppression Type for Refused Customers

	SELECT @OthersFilterDays = NoOfDays FROM #CallQueueSettings WHERE SuppressionTypeID = 346 --Suppression Type for Other Dispositions


	SELECT CQC.CustomerId AS [Customer ID],
			CP.InsuranceId AS [Member ID],			
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
			@HealthPlanName AS [Health Plan],
			
			@CallQueueName as [Call Queue],
			@CallQueueId as [Call Queue Id]	--,
			
			FROM Vw_GetCustomersForCallQueueWithCustomer CQC 
				
				INNER JOIN TblCustomerProfile CP WITH(NOLOCK) ON CQC.CustomerId = CP.CustomerID  
				INNER JOIN TblOrganizationRoleUser ORU WITH(NOLOCK) ON CQC.CustomerId = ORU.OrganizationRoleUserID
				INNER JOIN TblUser U WITH(NOLOCK) ON ORU.UserID = U.UserID
				INNER JOIN TblAddress A WITH(NOLOCK) ON U.HomeAddressID = A.AddressID
				INNER JOIN TblCity C WITH(NOLOCK) ON A.CityID = C.CityID
				INNER JOIN TblState S WITH(NOLOCK) ON A.StateID = S.StateID
				INNER JOIN TblZip Z With(NOLOCK) ON A.ZipID = Z.ZipID
				
				WHERE	
					cqc.CriteriaId = @CriteriaId and cqc.CallQueueId = @CallQueueId and cqc.HealthPlanId = @HealthPlanId 
					and
						(	
							(@IsMaxAttemptPerHealthPlan = 1 AND CQC.CallCount < @MaxAttemptPerHealthPlan) 
							OR (@IsMaxAttemptPerHealthPlan = 0 AND CQC.Attempts < @MaxAttemptPerCallQueue)
						)	
					AND (CQC.IsLanguageBarrier = 0 OR (CQC.IsLanguageBarrier = 1 AND CQC.LanguageBarrierMarkedDate < @StartOfYear)) 
					AND (CQC.AppointmentCancellationDate = @MinDate OR CQC.AppointmentCancellationDate <= CONVERT(DATE, (GETDATE() - @OthersFilterDays + 1)))					
					AND (CQC.NoShowDate = @MinDate OR CQC.NoShowDate <= CONVERT(DATE, (GETDATE() - @OthersFilterDays + 1)))					
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
					)
		
	
	DROP TABLE #CallQueueSettings
	
END
GO
