USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_GetAllTestForCustomers]    Script Date: 04/14/2014 14:56:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE View [dbo].[vw_GetKynTestCustomers]
As

SELECT TEC.EventCustomerID, TOD.OrderID FROM tbleventcustomers TEC
Inner Join[TblEventCustomerOrderDetail] TECOD on TEC.EventCustomerId =  TECOD.EventCustomerId 
INNER JOIN [TblOrderDetail] TOD ON TECOD.[OrderDetailID] = TOD.[OrderDetailID] and TECOD.IsActive = 1
Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] 
		INNER JOIN [TblOrderItem] ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageOrderItem] ON [TblEventPackageOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventPackageDetails] ON [TblEventPackageDetails].[EventPackageID] = [TblEventPackageOrderItem].[EventPackageID]
		INNER JOIN TblEventPackageTest on [TblEventPackageDetails].[EventPackageID] = TblEventPackageTest.EventPackageId
		INNER JOIN [TblEventTest] ON [TblEventTest].[EventTestID] = TblEventPackageTest.[EventTestID]					
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID]=23
) PackageOrder on TOD.OrderId = PackageOrder.OrderID

Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] 
		INNER JOIN [TblOrderItem] ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTestOrderItem] ON [TblEventTestOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTest] ON [TblEventTest].[EventTestID] = [TblEventTestOrderItem].[EventTestID]		
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID]=23
)TestOrder on TOD.OrderId = TestOrder.OrderID
where appointmentid is not null and noshow = 0
and (PackageOrder.TestID is not null or TestOrder.TestID is not null)


GO


