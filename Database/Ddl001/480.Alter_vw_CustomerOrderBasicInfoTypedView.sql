USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_CustomerOrderBasicInfo]    Script Date: 12/07/2013 17:55:37 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vw_CustomerOrderBasicInfo]    
AS
SELECT EventCustomerDetail.EventCustomerID
		,TOD.[OrderID]
		,TOD.[OrderDetailID]
		,EventCustomerDetail.[CustomerID]
		,EventCustomerDetail.[FirstName] 
		,EventCustomerDetail.MiddleName
		,EventCustomerDetail.[LastName] 
		,EventCustomerDetail.Email1
		,EventCustomerDetail.Phone
		,EventCustomerDetail.DateCreated AS [EventSignupDate]
		,ISNULL(EventCustomerDetail.RoleID,9) AS [EventSignupRoleId]
		,EventCustomerDetail.AppointmentID
		,EventCustomerDetail.StartTime AS [AppointmentStartTime]
		,EventCustomerDetail.EndTime AS [AppointmentEndTime]
		,EventCustomerDetail.Noshow
		,EventCustomerDetail.LeftWithoutScreeningReasonId
		,EventCustomerDetail.HIPAAStatus
		,OrderPackage.EventPackageID
		,EventCustomerDetail.EventName
		,EventCustomerDetail.EventDate
		,EventCustomerDetail.[EventID] 
		,EventCustomerDetail.[FranchiseeName]
		,EventCustomerDetail.OrganizationName
		,EventCustomerDetail.[HostAddress]
		,EventCustomerDetail.[HostState]
		,EventCustomerDetail.[HostCity]
		,EventCustomerDetail.[HostZip]
		,EventCustomerDetail.Latitude
		,EventCustomerDetail.Longitude
		,EventCustomerDetail.IsManuallyVerified
		,EventCustomerDetail.UseLatLogForMapping
		,EventCustomerDetail.CheckinTime
		,EventCustomerDetail.CheckoutTime

		,vwOrderDetail.ScreeningCost AS [PackagePrice]
		,vwOrderDetail.[EffectiveCost] AS [EffectiveCost]
		,OrderPackage.[PackageName]
		,OrderPackage.PackageID
		,ISNULL(dbo.fn_getCustomerEventAdditionalTest( EventCustomerDetail.[EventCustomerID] ),'') AdditionalTest  
   
		,EventCustomerDetail.MarketingSource AS [EventSignupMarketingSource]
		,EventCustomerDetail.EventStatus
		,vwOrderDetail.SourceCodeID
		,vwOrderDetail.CouponCode [SourceCode]
		,ISNULL(vwOrderDetail.DiscountAmount,0)[SourceCodeAmount]
		,ISNULL(vwOrderDetail.ShippingPrice,0)ShippingCost
		,ISNULL(vwOrderDetail.NewCCPayment,0)CreditCard
		,ISNULL(vwOrderDetail.NewCheckPayment,0)[Check]
		,ISNULL(vwOrderDetail.NewECheckPayment,0)[ECheck]
		,ISNULL(vwOrderDetail.NewCashPayment,0)[Cash]
		,ISNULL(vwOrderDetail.NewGCPayment,0)[GC]
		,CASE WHEN EXISTS (SELECT EventCustomerID FROM [TblScreeningAuthorization] WHERE [EventCustomerID] = TECOD.[EventCustomerID]) THEN 1 ELSE 0 END AS IsAuthorized
		
		,ISNULL(TblEventCustomerResult.EventCustomerResultId,0)CustomerEventTestID
		
		,ISNULL(TblEventCustomerResult.IsResultPDFGenerated, 0) AS IsResultPDFGenerated
		
		,ISNULL(TblEventCustomerResult.IsClinicalFormGenerated, 0) AS IsPDFGenerated		
		, Case When isnull(TblEventCustomerResult.ResultState, 0) = 7 Then 1 Else 0	 End AS IsResultReady
		,0 as IsColoractelResultReady
		,isnull(TblEventCustomerResult.ResultState, 1) as TestStatus,
		   -------------------------------------------
			   0 as AAATestEvaluation,
			   0 as ASITestEvaluation,
			   0 as CarotidTestEvaluation,
			   0 as OsteoTestEvaluation,
			   0 as PADTestEvaluation,
			   0 as EKGTestEvaluation,
			   0 as LipidTestEvaluation, 
			   0 as LiverTestEvaluation,
			   0 as FraminghamTestEvaluation, 
			   0 as AAAPartialState,
			   0 as ASIPartialState,
			   0 as CarotidPartialState,
			   0 as OsteoPartialState,
			   0 as PADPartialState,
			   0 as EKGPartialState,
			   0 as LipidPartialState, 
			   0 as LiverPartialState,
			   0 as FraminghamPartialState,    
		   -------------------------------------------
			ISNULL(vw_CustEventCount.EventCount, 0) EventCount,ScheduledByOrgRoleUserId,
			isnull(Reason,'') AppointBlockReason,UserCreatedOn,
			Case when vw_customermedhistory.CustomerID is null then 0 else 1 end CustomerHealthInfo,
			case when EventCustomerDetail.AppointmentID is not null then 1 else 0 end IsRegistered,
			case when (IsTestConducted=1 and AppointmentID is not null) then 1 else 0 end IsTestAttended,
			vwOrderDetail.IsPaid		
			,vwOrderDetail.isShipping isShippingApplied
			,EventCustomerDetail.PartnerRelease
			,ISNULL(vwOrderDetail.NewInsurancePayment,0)[InsurancePayment]
			,ISNULL(EventCustomerDetail.AwvVisitId,0)[AwvVisitId]
FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
INNER JOIN 
(
	SELECT TEC.[CustomerID],TEC.[EventID],TEC.[EventCustomerID],TEC.MarketingSource
		,TEC.DateCreated ,EventRegTORU.[RoleID] ,TEC.[AppointmentID],TEC.IsTestConducted,
		isnull(TEA.ScheduledByOrgRoleUserId,0) ScheduledByOrgRoleUserId
		,'' as Reason
		,TEC.Noshow ,ISNULL(TEC.HIPAAStatus, 1) HIPAAStatus
		,ISNULL(TEC.LeftWithoutScreeningReasonId, 0) LeftWithoutScreeningReasonId
		,TE.EventName ,TE.EventDate ,isnull(TE.EventStatus,1) EventStatus
		,[TblProspects].[OrganizationName]
		,TEA.StartTime
		,TEA.[EndTime]
		,ISNULL(TEA.CheckinTime,'')AS CheckinTime
		,ISNULL(TEA.CheckoutTime,'') AS CheckoutTime
		,TU.FirstName ,TU.MiddleName ,TU.LastName,ISNULL(TU.DateCreated, '') AS UserCreatedOn
		,ISNULL(TU.Email1, '') Email1
		,ISNULL(IsNull(IsNull(TU.PhoneHome,TU.PhoneCell),TU.PhoneOffice) , '') Phone
		,TA.Address1 AS [HostAddress]
		,TblState.[Name] AS [HostState]
		,TblCity.[Name] AS [HostCity]
		,TblZip.ZipCode AS [HostZip]
		,ISNULL(TA.Latitude,'') Latitude
		,ISNULL(TA.Longitude,'') Longitude
		,TA.IsManuallyVerified IsManuallyVerified
		,ISNULL(TA.UseLatLogForMapping,0) UseLatLogForMapping
		,TblOrganization.[Name] AS [FranchiseeName]
		,ISNULL(TEC.PartnerRelease, 1) PartnerRelease
		,TEC.AwvVisitId
	FROM TblEventCustomers TEC WITH (NOLOCK)
	INNER JOIN TblOrganizationRoleUser EventRegTORU WITH (NOLOCK) on TEC.CreatedByOrgRoleUserId = EventRegTORU.OrganizationRoleUserId
	INNER JOIN [TblCustomerProfile] TC WITH (NOLOCK) ON TEC.[CustomerID]=TC.[CustomerID]
	INNER JOIN TblOrganizationRoleUser TORU WITH (NOLOCK) ON TORU.OrganizationRoleUserId = TC.[CustomerID]
	INNER JOIN [TblUser] TU WITH (NOLOCK) ON TORU.[UserID] = TU.[UserID]
	INNER JOIN [TblEventAppointment] TEA WITH (NOLOCK) ON TEC.[AppointmentID]=TEA.[AppointmentID]
	INNER JOIN [TblEvents] TE WITH (NOLOCK) ON TEC.[EventID] = TE.[EventID]
	INNER JOIN TblOrganizationRoleUser EventTORU WITH (NOLOCK) ON TE.AssignedToOrgRoleUserId = EventTORU.OrganizationRoleUserId
	INNER JOIN TblOrganization WITH (NOLOCK) ON TblOrganization.OrganizationId = EventTORU.OrganizationId
	INNER JOIN [TblHostEventDetails] THED WITH (NOLOCK) ON TE.[EventID] = THED.[EventID]
	INNER JOIN [TblProspects] WITH (NOLOCK) ON THED.[HostID] = [TblProspects].[ProspectID]
	INNER JOIN [TblAddress] TA WITH (NOLOCK) ON [TblProspects].[AddressID] = TA.[AddressID]
	INNER JOIN [TblState] WITH (NOLOCK) ON TA.[StateID] = [TblState].[StateID]
	INNER JOIN [TblCity] WITH (NOLOCK) ON TA.[CityID] = [TblCity].[CityID]
	INNER JOIN [TblZip] WITH (NOLOCK) ON TA.[ZipID]=[TblZip].[ZipID]
)EventCustomerDetail ON EventCustomerDetail.EventCustomerID=TECOD.[EventCustomerId]
INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
LEFT OUTER JOIN 
(
	SELECT TOD.[OrderID], TP.[PackageID], TP.[PackageName], TEPD.[EventPackageID]
	FROM [TblOrderDetail] TOD WITH (NOLOCK)
	INNER JOIN [TblOrderItem] TOI WITH (NOLOCK) ON TOD.[OrderItemID] = TOI.[OrderItemID]
	INNER JOIN [TblEventPackageOrderItem] TEPOI WITH (NOLOCK) ON TOI.[OrderItemID] = TEPOI.[OrderItemID]
	INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID] = TEPD.[EventPackageID]
	INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]
	WHERE [Status]=1
)OrderPackage ON OrderPackage.OrderId=TOD.OrderId
LEFT OUTER JOIN TblEventCustomerResult on TblEventCustomerResult.EventCustomerResultId = TECOD.[EventCustomerId]

LEFT OUTER JOIN 
(
		SELECT  CASE WHEN [EffectiveCost] >isnull( totalpayment,0) THEN 0    ELSE 1 END AS IsPaid, 
				[Shipping] ShippingPrice ,[vw_EventCustomerRevenue].[Discount]   DiscountAmount,
		[SourceCodeId], [CouponCode],
		ISNULL( [CreditCardPayment],0) NewCCPayment,
		ISNULL( [CheckPayment],0) NewCheckPayment,
		ISNULL( [ECheckPayment],0) NewECheckPayment,
		ISNULL( [CashPayment],0) NewCashPayment,
		ISNULL( [GCPayment],0) NewGCPayment, 
		ISNULL( [InsurancePayment],0) NewInsurancePayment,[vw_EventCustomerRevenue].[EventCustomerId],isShipping
		,[vw_EventCustomerRevenue].ScreeningCost,[EffectiveCost]
		FROM  [vw_EventCustomerRevenue] Left Outer JOIN [vw_EventCustomerPaymentNewOrderSystem] ON 
				[vw_EventCustomerPaymentNewOrderSystem].[EventCustomerId] = [vw_EventCustomerRevenue].[EventCustomerId]
) vwOrderDetail
ON EventCustomerDetail.EventCustomerID=vwOrderDetail.[EventCustomerId]
LEFT OUTER JOIN 
(
	Select count(*) EventCount, CustomerID from TblEventCustomers WITH (NOLOCK) where AppointmentID IS NOT NULL group by customerid
)
vw_CustEventCount on EventCustomerDetail.CustomerID=vw_CustEventCount.CustomerID
LEFT OUTER JOIN  (SELECT distinct Customerid FROM dbo.TblCustomerHealthInfo WITH (NOLOCK) ) vw_customermedhistory on	vw_customermedhistory.CustomerID = EventCustomerDetail.CustomerID
WHERE TECOD.IsActive=1



GO


