USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_EventCustomerPayment]    Script Date: 12/07/2013 16:29:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




ALTER View [dbo].[vw_EventCustomerPayment]
AS
Select EventCustomerId, ECOrder.OrderId, OrderCost, OrderTotal, isnull(NetPayment, 0) NetPayment, DiscountAmount, IsShipping, (Case When OrderTotal > isnull(NetPayment, 0) then 0 else 1 end) IsPaid, CouponCode from (
			Select distinct EC.EventCustomerId, OrderId from TblEventcustomers EC 
				Inner Join  TblEventCustomerOrderDetail ECOD on EC.EventCustomerId = ECOD.EventCustomerId 
				Inner Join TblOrderDetail OD ON ECOD.OrderDetailId = OD.OrderDetailId 
			where ECOD.IsActive = 1) ECOrder
	left outer join(
		Select OrderId, Sum(isnull(vSouCd.Amount, 0)) DiscountAmount, Sum(vOD.Amount) OrderCost,  (Sum(vOD.Amount) + Sum(isnull(vShiOd.Amount, 0)) - Sum(isnull(vSouCd.Amount, 0))) OrderTotal, (Case When Sum(vShiOd.Amount) is null then 0 else 1 end) IsShipping from 
			(
				Select OrderId, OrderDetailId, (case when TOI.[Type] =3 then (-1) * Price else Price end) as Amount 
				from TblOrderDetail TOD
				inner join TblOrderItem TOI on TOD.OrderItemId = TOI.OrderItemId
				where [Status] = 1 
			) vOD 
			Left Outer JOIN
			(Select OrderDetailId, Amount from TblSourceCodeOrderDetail where isActive = 1 ) vSouCd On vOD.OrderDetailId = vSouCd.OrderDetailId	
			Left outer JOIN
			(Select OrderDetailId, sum(isnull(ActualPrice,0)) Amount from TblShippingDetailOrderDetail SDOD 
				inner join TblShippingDetail SD on SDOD.ShippingDetailId = SD.ShippingDetailId 
				Where IsActive = 1
				group by OrderDetailId
			) vShiOd
				On vOD.OrderDetailId = vShiOd.OrderDetailId
		group By OrderId
	) oCost on oCost.OrderId = ECOrder.OrderId
	left outer Join
		(Select OrderId, Sum(Amount) NetPayment from (
			Select PaymentId, Amount from TblEcheckPayment ECP inner join TblCheck C on ECP.ECheckId = C.CheckId
			Union
			Select PaymentId, Amount from TblCheckPayment CP inner join TblCheck C on CP.CheckId = C.CheckId
			Union
			Select PaymentId, Amount from TblChargeCardPayment
			Union
			Select PaymentId, Amount from TblCashPayment
			Union
			Select PaymentId, Amount from TblGiftCertificatePayment
			Union
			Select PaymentId, Amount from TblInsurancePayment
		) vw_PaymentGroup inner join TblPaymentOrder PO on PO.PaymentId = vw_PaymentGroup.PaymentId group by OrderId) pOrder
	on pOrder.OrderId = ECOrder.OrderId
	left Outer join
	(Select OrderId, Amount, CouponCode from TblSourceCodeOrderDetail SCOD inner join TblOrderDetail OD on SCOD.OrderDetailId = OD.OrderDetailId
		inner join TblCoupons SC on SC.CouponId = SCOD.SourceCodeId where SCOD.isActive = 1) oSCodes on oSCodes.OrderId = ECOrder.Orderid



GO


