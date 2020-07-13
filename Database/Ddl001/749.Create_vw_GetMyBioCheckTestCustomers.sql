USE [$(dbname)]
GO

/****** Object:  View [dbo].[vw_GetKynTestCustomers]    Script Date: 30-10-2017 16:45:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[vw_GetMyBioCheckTestCustomers]
As

SELECT TEC.EventCustomerID, TOD.OrderID FROM tbleventcustomers TEC with(nolock)
Inner Join[TblEventCustomerOrderDetail] TECOD with(nolock) on TEC.EventCustomerId =  TECOD.EventCustomerId 
INNER JOIN [TblOrderDetail] TOD ON TECOD.[OrderDetailID] = TOD.[OrderDetailID] and TECOD.IsActive = 1
Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] with(nolock) 
		INNER JOIN [TblOrderItem] with(nolock) ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageOrderItem] with(nolock) ON [TblEventPackageOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageDetails] with(nolock) ON [TblEventPackageDetails].[EventPackageID] = [TblEventPackageOrderItem].[EventPackageID]
		INNER JOIN TblEventPackageTest with(nolock) on [TblEventPackageDetails].[EventPackageID] = TblEventPackageTest.EventPackageId
		INNER JOIN [TblEventTest] with(nolock) ON [TblEventTest].[EventTestID] = TblEventPackageTest.[EventTestID]					
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 99
) PackageOrder on TOD.OrderId = PackageOrder.OrderID

Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] with(nolock) 
		INNER JOIN [TblOrderItem] with(nolock) ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTestOrderItem] with(nolock) ON [TblEventTestOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTest] with(nolock) ON [TblEventTest].[EventTestID] = [TblEventTestOrderItem].[EventTestID]		
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 99
)TestOrder on TOD.OrderId = TestOrder.OrderID
where TEC.AppointmentID is not null and TEC.NoShow = 0 and TEC.LeftWithoutScreeningReasonId is null
and (PackageOrder.TestID is not null or TestOrder.TestID is not null)

GO
