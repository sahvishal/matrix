USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_CustomerAggregateResultSummary]    Script Date: 03/05/2013 19:29:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



/*
Thyroid - 5
Colorectal - 15
CRP - 17
PSA - 20
KYN - 23
A1C - 25
-- Date is hard coded in order hide old customers who have purchased only kyn, crp, psa, Colorectal, A1C and thyroid
*/
ALTER View [dbo].[vw_CustomerAggregateResultSummary]
As
select TEC.EventCustomerId, TEC.NoShow, TEC.HiPAAStatus, TEC.PartnerRelease, TEC.CustomerId, TEC.AppointmentId
,TECR.ResultState, IsNull(TECR.ResultSummary,0) as ResultSummary, TECR.DateModified as ResultStatusUpdatedDate, TECR.ResultSummaryOrder
,TE.EventId, TE.EventDate, TE.EventTypeId
,TU.FirstName, TU.MiddleName, TU.LastName, TU.DOB, TU.PhoneHome, TU.PhoneCell, TU.PhoneOffice
,IsNull(TblEventAccount.AccountId,0)  as CorporateAccountId
,IsNull(TblEventHospitalPartner.HospitalPartnerId,0) as HospitalPartnerId
,IsNull(HospitalPartnerCustomer.HospitalPartnerStatus,97) as HospitalPartnerStatus, IsNull(HospitalPartnerCustomer.HospitalPartnerStatusOrder,1) as HospitalPartnerStatusOrder
,IsNull(HospitalPartnerCustomer.HospitalPartnerLastModifiedDate, '01/01/1901') as HospitalPartnerLastModifiedDate
,IsNull(Shipping.ShippingStatus,0) ShippingStatus
,Shipping.ShipmentDate
,(Case When IsNull(HospitalPartnerCustomer.HospitalPartnerStatus, 97) > 97 or TECR.ResultState <> 7 or isnull(Shipping.ShippingStatus, 2) < 2 Then null 
	When TECR.ResultState = 7 and Shipping.ShippingStatus is null Then DateAdd(d, 1, TECR.DateModified)
	When TECR.ResultState = 7 and Shipping.ShippingStatus is Not null Then DateAdd(d, (1 + isnull(MailTransitDays, 0)), IsNull(ShipmentDate, TECR.DateModified))
	Else Null End) as InitialCallDate
from TblEventCustomers TEC
inner join
( 
	select TECR.EventCustomerResultId, TECR.ResultState, TECR.ResultSummary, TECR.DateModified, Isnull(TblLookUp.RelativeOrder,0) as ResultSummaryOrder
	from TblEventCustomerResult TECR 
	left outer join TblLookUp on TECR.ResultSummary = TblLookUp.LookupId
	where TECR.EventCustomerResultId in 
	(
		select EventCustomerResultId from TblCustomerEventScreeningTests where TestId not in (5, 15, 17, 20, 23, 25)
	)
	OR TECR.EventCustomerResultId in
	(
		select EventCustomerResultId from TblEventCustomerResult where EventCustomerResultId in
		(
			select EventCustomerResultId from TblCustomerEventScreeningTests where TestId in (23, 25)
		)		
		and IsNull(DateModified,DateCreated) >= cast('01/27/2013' as Datetime)
	)
)TECR on TEC.EventCustomerId = TECR.EventCustomerResultId
inner join TblEvents TE on TEC.EventId = TE.EventId
inner join TblOrganizationRoleUser TORU on TEC.CustomerId = TORU.OrganizationRoleUserId
inner join TblUser TU on TORU.UserId = TU.UserId
left outer join TblEventAccount on TE.EventId = TblEventAccount.EventId
left outer join TblEventHospitalPartner on TE.EventId = TblEventHospitalPartner.EventId
left outer join TblHospitalPartner on TblEventHospitalPartner.HospitalPartnerId = TblHospitalPartner.HospitalPartnerId
left outer join 
(
	select THPC.[Status] as HospitalPartnerStatus, THPC.DateModified as HospitalPartnerLastModifiedDate, THPC.EventId, THPC.CustomerId, TblLookUp.RelaTiveOrder as HospitalPartnerStatusOrder
	from TblHospitalPartnerCustomer THPC
	inner join 
	(
		select Max(HospitalPartnerCustomerId) as HospitalPartnerCustomerId from TblHospitalPartnerCustomer
		group by EventId, CustomerId
	)HPC on THPC.HospitalPartnerCustomerId = HPC.HospitalPartnerCustomerId
	inner join TblLookup on THPC.[Status] = TblLookUp.LookUpId
)HospitalPartnerCustomer on TEC.EventId = HospitalPartnerCustomer.EventId and TEC.CustomerId = HospitalPartnerCustomer.CustomerId
left outer join 
(
	select TECOD.EventCustomerId, SD.[Status] as ShippingStatus, SD.ShipmentDate
	from TblEventCustomerOrderDetail TECOD 
	inner join 
		(Select OrderDetailId, Min(TSD.ShippingDetailId) ShippingDetailId
			from 
				TblShippingDetailOrderDetail TSDOD 
				inner join 
				TblShippingDetail TSD on TSDOD.ShippingDetailId = TSD.ShippingDetailId
			where TSDOD.IsActive=1 and (ShippingOptionId=1 or ShippingOptionId=2)
			group by OrderDetailId) Min_SDOD 
	on TECOD.OrderDetailId = Min_SDOD.OrderDetailId
	inner join TblShippingDetail SD on Min_SDOD.ShippingDetailId = SD.ShippingDetailId		
	where TECOD.IsActive=1
)Shipping on TEC.EventCustomerId = Shipping.EventCustomerId




GO


