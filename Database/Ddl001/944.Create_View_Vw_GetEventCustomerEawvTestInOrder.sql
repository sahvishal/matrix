USE [$(dbName)]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

Create View [dbo].[Vw_GetEventCustomerEawvTestInOrder]
As

SELECT TEC.EventCustomerID,tec.CustomerID,tec.EventID, TOD.OrderID FROM tbleventcustomers TEC
Inner Join [TblEventCustomerOrderDetail] TECOD with(nolock) on TEC.EventCustomerId =  TECOD.EventCustomerId 
INNER JOIN [TblOrderDetail] TOD with(nolock)  ON TECOD.[OrderDetailID] = TOD.[OrderDetailID] and TECOD.IsActive = 1

Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] with(nolock) 
		INNER JOIN [TblOrderItem] with(nolock) ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageOrderItem] with(nolock) ON [TblEventPackageOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageDetails] with(nolock) ON [TblEventPackageDetails].[EventPackageID] = [TblEventPackageOrderItem].[EventPackageID]
		INNER JOIN TblEventPackageTest with(nolock) on [TblEventPackageDetails].[EventPackageID] = TblEventPackageTest.EventPackageId
		INNER JOIN [TblEventTest] with(nolock) ON [TblEventTest].[EventTestID] = TblEventPackageTest.[EventTestID]					
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 81
) PackageOrder on TOD.OrderId = PackageOrder.OrderID
Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] with(nolock) 
		INNER JOIN [TblOrderItem] with(nolock) ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTestOrderItem] with(nolock) ON [TblEventTestOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTest] with(nolock) ON [TblEventTest].[EventTestID] = [TblEventTestOrderItem].[EventTestID]		
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 81
)TestOrder on TOD.OrderId = TestOrder.OrderID
where (PackageOrder.TestID is not null or TestOrder.TestID is not null) 
and appointmentid is not null and noshow = 0 and LeftWithoutScreeningReasonId is null



