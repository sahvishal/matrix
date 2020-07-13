USE [$(dbName)]
Go

Alter View Vw_CustomerAggregateResultSummary
As
select TEC.EventCustomerId, TEC.NoShow, TEC.HiPAAStatus, TEC.PartnerRelease, TEC.CustomerId, TEC.AppointmentId
,TECR.ResultState, TECR.ResultSummary, TECR.DateModified as ResultStatusUpdatedDate, TECR.ResultSummaryOrder
,TE.EventId, TE.EventDate, TE.EventTypeId
,TU.FirstName, TU.MiddleName, TU.LastName, TU.DOB, TU.PhoneHome, TU.PhoneCell, TU.PhoneOffice
,IsNull(TblEventAccount.AccountId,0)  as CorporateAccountId
,IsNull(TblEventHospitalPartner.HospitalPartnerId,0) as HospitalPartnerId
,IsNull(HospitalPartnerCustomer.HospitalPartnerStatus,97) as HospitalPartnerStatus, IsNull(HospitalPartnerCustomer.HospitalPartnerStatusOrder,1) as HospitalPartnerStatusOrder
,HospitalPartnerCustomer.HospitalPartnerLastModifiedDate
,IsNull(Shipping.ShippingStatus,0) ShippingStatus,
Shipping.ShipmentDate
from TblEventCustomers TEC
inner join
( 
	select TECR.EventCustomerResultId, TECR.ResultState, TECR.ResultSummary, TECR.DateModified, Isnull(TblLookUp.RelativeOrder,0) as ResultSummaryOrder
	from TblEventCustomerResult TECR 
	left outer join TblLookUp on TECR.ResultSummary = TblLookUp.LookupId
)TECR on TEC.EventCustomerId = TECR.EventCustomerResultId
inner join TblEvents TE on TEC.EventId = TE.EventId
inner join TblOrganizationRoleUser TORU on TEC.CustomerId = TORU.OrganizationRoleUserId
inner join TblUser TU on TORU.UserId = TU.UserId
left outer join TblEventAccount on TE.EventId = TblEventAccount.EventId
left outer join TblEventHospitalPartner on TE.EventId = TblEventHospitalPartner.EventId
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

