USE [$(dbname)]
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_getEventWizardDetails] 
	-- Add the parameters for the stored procedure here
	(@EventID BIGINT)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
    Declare @TerritoryId bigint
	Select Distinct @TerritoryId = IsNull(TerritoryId,0) from TblEventPod where EventID=@EventID
	SELECT TE.EventID
			,THED.HostID
			,TE.CosttoUseHostSite
			,1 as PaymentTypeID
			,TE.ScheduleMethodID
			,TE.CommunicationModeID
			,THED.bConfirmMinRequirements
			,THED.bConfirmedVisually
			,ISNULL(THED.ConfirmedVisuallyComments,'') ConfirmedVisuallyComments
			,ISNull(TEST.ScheduleTemplateID,0) ScheduleTemplateID
			,TE.EventTypeID
			,TE.IsActive
			,TE.EventDate
			,TE.TimeZone
			,TE.InvitationCode
			,TE.EventStartTime
			,TE.EventEndTime
			,ISNULL(TE.TeamArrivalTime,'1900-01-01 08:00:00.000')TeamArrivalTime
			,ISNULL(TE.TeamDepartureTime,'1900-01-01 17:00:00.000')TeamDepartureTime
			,TORU.OrganizationId FranchiseeID
			,TE.AssignedToOrgRoleUserId SalesRepID
			,ISNULL(TE.EventActivityTemplateID,0)EventActivityTemplateID
			,ISNULL(TE.EventActivityOrgRoleUserId,0)EventActivitySalesRep
			,ISNULL(TE.EventStatus,1)EventStatus
			,ISNULL(TE.EventNotes,'')EventNotes
			,ISNULL(THED.InstructionForCallCenter,'') InstructionForCallCenter 
			,ISNULL(TEA.AccountID,0)AccountID
			,ISNULL(TEHP.HospitalPartnerID,0)HospitalPartnerID
			,ISNULL(TEHP.AttachHospitalMaterial,1)AttachHospitalMaterial
			,@TerritoryId as TerritoryId
			,TE.EnableAlaCarteOnline
			,TE.EnableAlaCarteCallCenter
			,TE.EnableAlaCarteTechnician
			,TE.IsDynamicScheduling
			,ISNULL(TE.SlotInterval, 0) as SlotInterval
			,ISNULL(TE.ServerRooms, 0) as ServerRooms
			,TE.LunchStartTime
			,ISNULL(TE.LunchDuration, 0) as LunchDuration
			,ISNULL(TE.HAFTemplateId,0) as HAFTemplateId
			,CaptureInsuranceId
			,InsuranceIdRequired
			,Case When TEPE.EventId is Null Then 1 Else 0 End As EnableProduct
			,ISNULL(TEHP.CaptureSsn,1)CaptureSsn
			,TE.IsFemaleOnly
			,TE.RecommendPackage
			,TE.AskPreQualifierQuestion
			,ISNULL(TE.FixedGroupScreeningTime,0)as FixedGroupScreeningTime
			,ISNULL(TEHP.RestrictEvaluation,1)RestrictEvaluation
			,TE.EventCancellationReasonId
			,TE.EnableForCallCenter
			,TE.EnableForTechnician
			,TE.IsPackageTimeOnly
	FROM dbo.TblEvents TE
	INNER JOIN TblOrganizationRoleUser TORU on TE.AssignedToOrgRoleUserId = TORU.OrganizationRoleUserId
	INNER JOIN dbo.TblHostEventDetails THED ON TE.EventID = THED.EventID
	LEFT OUTER JOIN dbo.TblEventScheduleTemplate TEST ON THED.EventID = TEST.EventID
	LEFT OUTER JOIN TblEventAccount TEA ON TE.EventID = TEA.EventID
	LEFT OUTER JOIN TblEventHospitalPartner TEHP ON TE.EventID = TEHP.EventID
	Left OUTER JOIN TblEventProductExclusion TEPE on TE.EventId = TEPE.EventId
	WHERE TE.EventID=@EventID


	SELECT THED.EventID 
			,ISNULL(CAST(PaymentDueDate AS VARCHAR(30)),'') PaymentDueDate
			,ISNULL(CAST(DepositDueDate AS VARCHAR(30)),'') DepositDueDate
			,ISNULL(THED.[PayByCheck],0) PayByCheck
			,ISNULL(THED.[PayByCreditCard],0) PayByCreditCard
			,ISNULL(THED.[DepositAmount],0) DepositAmount
	FROM [TblHostEventDetails] THED
	WHERE THED.EventID=@EventID

	SELECT 
	tp.[PackageName],
	TE.EventID
			,TEPD.PackageID
			,TEPD.PackagePrice
			,IsNull(TEPD.ScreeningTime, 0) as ScreeningTime 
			,TEPD.Gender
			,TEPD.IsRecommended
			,TEPD.MostPopular
			,TEPD.BestValue
			,TEPD.PodRoomID
	FROM dbo.TblEvents TE
	INNER JOIN dbo.TblEventPackageDetails TEPD ON TE.EventID = TEPD.EventID
	INNER JOIN [TblPackage] tp ON TEPD.[PackageID] = tp.[PackageID]
	WHERE TE.EventID=@EventID

	SELECT [EventPodID]
			,[EventID]
			,[TblEventPod].[PodID]
			,[TblEventPod].[IsActive]
			,[TblEventPod].[DateCreated]
			,[TblEventPod].[DateModified]
			,TblPodDetails.[Name]
			,TblPodDetails.Description
			,TVD.[Name] as VanName
			,TVD.RegistrationNumber
			,TVD.Make
	FROM [TblEventPod] 
	inner join TblPodDetails on TblPodDetails.PodiD = TblEventPod.PodID
	inner join TblVanDetails TVD on TVD.VanID = TblPodDetails.VanID
	where eventid = @EventID and [TblEventPod].[IsActive] = 1	
	
	-- Get Test Details For Events
	SELECT TT.[Name],TE.EventID,TET.TestId,TET.Price,isnull(TT.Description,'') [Description], TET.ShowInAlaCarte
	,IsNull(TET.ScreeningTime, 0) as ScreeningTime, TET.WithPackagePrice
	FROM dbo.TblEvents TE
	INNER JOIN dbo.TblEventTest TET ON TE.EventID = TET.EventID
	INNER JOIN [TblTest] TT ON TET.[TestId] = TT.[TestId]
	WHERE TE.EventID=@EventID

END