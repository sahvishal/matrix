USE [$(dbname)]
GO

/****** Object:  View [dbo].[vw_GetKynTestCustomers]    Script Date: 30-10-2017 16:45:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



Create View [dbo].[vw_GetHkynTestCustomers]
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
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 98
) PackageOrder on TOD.OrderId = PackageOrder.OrderID

Left Outer Join 
(
		select OrderId, TestId from  [TblOrderDetail] 
		INNER JOIN [TblOrderItem] ON [TblOrderDetail].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTestOrderItem] ON [TblEventTestOrderItem].[OrderItemID] = [TblOrderItem].[OrderItemID]
		INNER JOIN [TblEventTest] ON [TblEventTest].[EventTestID] = [TblEventTestOrderItem].[EventTestID]		
		WHERE [TblOrderDetail].[Status] = 1 And [TblEventTest].[TestID] = 98
)TestOrder on TOD.OrderId = TestOrder.OrderID
where appointmentid is not null and noshow = 0
and (PackageOrder.TestID is not null or TestOrder.TestID is not null)



GO
