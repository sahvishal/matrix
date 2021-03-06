USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_getKPISummaryforFranchisorDashboard]    Script Date: 07/04/2012 16:41:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
    
-- =============================================  
-- Author:  Sandeep Raheja  
-- Create date: 10th Jan, 2009  
-- Description: Mode 0 = Today, 1 = Last 7Days, 2 = Last 30Days, 3 = All Time   
-- =============================================  
ALTER PROCEDURE [dbo].[usp_getKPISummaryforFranchisorDashboard](@mode tinyint)  
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
 DECLARE @TotalCustomers BIGINT  
   ,@TotalMaleCustomers BIGINT  
   ,@TotalFemaleCustomers BIGINT  
   ,@TotalEvents BIGINT  
   ,@TotalCalls BIGINT  
   ,@TotalRevenue DECIMAL(18,2)  
  
 IF(@mode = 0)  
 BEGIN  
  
  /*********TotalCustomers**************/  
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and CONVERT(VARCHAR,EventDate,101) = CONVERT(VARCHAR,GETDATE(),101)  
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE CONVERT(VARCHAR,DateCreated,101)=CONVERT(VARCHAR,GETDATE(),101)   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
	(Select TOP 100 PERCENT EventCustomerId, TP.DateCreated, TCCP.Amount as CardAmount,vw_CheckPayment.Amount as CheckAmount,  
			vw_ECheckPayment.Amount as EcheckAmount, [TblCashPayment].Amount as CashAmount, 
			(isnull(TCCP.Amount, 0) + isnull(vw_CheckPayment.Amount, 0) + isnull(vw_ECheckPayment.Amount, 0) + isnull([TblCashPayment].Amount, 0)) as TotalAmount
		from 
		(  
			SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD  INNER JOIN [TblOrderDetail] TOD 
				ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]  
		)vw_EventCustomer
		INNER JOIN [TblPaymentOrder] ON vw_EventCustomer.OrderID = [TblPaymentOrder].[OrderID]  
		INNER JOIN [TblPayment] TP ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]  
		LEFT OUTER JOIN [TblChargeCardPayment] TCCP ON  TP.[PaymentID] = TCCP.[PaymentID]  
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblCheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblCheckPayment].[CheckID]) vw_CheckPayment
		ON vw_CheckPayment.[PaymentID]=TP.[PaymentID]  	
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblECheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblECheckPayment].[ECheckID]) vw_ECheckPayment
		ON vw_ECheckPayment.[PaymentID]=TP.[PaymentID]
		LEFT OUTER JOIN	[TblCashPayment] ON [TblCashPayment].[PaymentID]=TP.[PaymentID]  
		Order By EventCustomerId) a
	WHERE 
		CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
  
 END  
 ELSE IF(@mode = 1)  
 BEGIN  
  
    
  /*********TotalCustomers**************/  
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 7    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 7    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 7    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= getdate() - 7    
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 7    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
	(Select TOP 100 PERCENT EventCustomerId, TP.DateCreated, TCCP.Amount as CardAmount,vw_CheckPayment.Amount as CheckAmount,  
			vw_ECheckPayment.Amount as EcheckAmount, [TblCashPayment].Amount as CashAmount, 
			(isnull(TCCP.Amount, 0) + isnull(vw_CheckPayment.Amount, 0) + isnull(vw_ECheckPayment.Amount, 0) + isnull([TblCashPayment].Amount, 0)) as TotalAmount
		from 
		(  
			SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD  INNER JOIN [TblOrderDetail] TOD 
				ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]  
		)vw_EventCustomer
		INNER JOIN [TblPaymentOrder] ON vw_EventCustomer.OrderID = [TblPaymentOrder].[OrderID]  
		INNER JOIN [TblPayment] TP ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]  
		LEFT OUTER JOIN [TblChargeCardPayment] TCCP ON  TP.[PaymentID] = TCCP.[PaymentID]  
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblCheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblCheckPayment].[CheckID]) vw_CheckPayment
		ON vw_CheckPayment.[PaymentID]=TP.[PaymentID]  	
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblECheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblECheckPayment].[ECheckID]) vw_ECheckPayment
		ON vw_ECheckPayment.[PaymentID]=TP.[PaymentID]
		LEFT OUTER JOIN	[TblCashPayment] ON [TblCashPayment].[PaymentID]=TP.[PaymentID]  
		Order By EventCustomerId)	a
	WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 7  
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
  
  
 END  
 ELSE IF(@mode = 2)  
 BEGIN  
  
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 30    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 30    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 30    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= getdate() - 30    
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 30    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM  
	(Select TOP 100 PERCENT EventCustomerId, TP.DateCreated, TCCP.Amount as CardAmount,vw_CheckPayment.Amount as CheckAmount,  
			vw_ECheckPayment.Amount as EcheckAmount, [TblCashPayment].Amount as CashAmount, 
			(isnull(TCCP.Amount, 0) + isnull(vw_CheckPayment.Amount, 0) + isnull(vw_ECheckPayment.Amount, 0) + isnull([TblCashPayment].Amount, 0)) as TotalAmount
		from 
		(  
			SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD  INNER JOIN [TblOrderDetail] TOD 
				ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]  
		)vw_EventCustomer
		INNER JOIN [TblPaymentOrder] ON vw_EventCustomer.OrderID = [TblPaymentOrder].[OrderID]  
		INNER JOIN [TblPayment] TP ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]  
		LEFT OUTER JOIN [TblChargeCardPayment] TCCP ON  TP.[PaymentID] = TCCP.[PaymentID]  
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblCheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblCheckPayment].[CheckID]) vw_CheckPayment
		ON vw_CheckPayment.[PaymentID]=TP.[PaymentID]  	
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblECheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblECheckPayment].[ECheckID]) vw_ECheckPayment
		ON vw_ECheckPayment.[PaymentID]=TP.[PaymentID]
		LEFT OUTER JOIN	[TblCashPayment] ON [TblCashPayment].[PaymentID]=TP.[PaymentID]  
		Order By EventCustomerId)	a	
	WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= getdate() - 30  
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) < Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
  
  
 END  
 ELSE IF(@mode = 3)  
 BEGIN  
    
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null    
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null   
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null   
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1   
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
	(Select TOP 100 PERCENT EventCustomerId, TP.DateCreated, TCCP.Amount as CardAmount,vw_CheckPayment.Amount as CheckAmount,  
			vw_ECheckPayment.Amount as EcheckAmount, [TblCashPayment].Amount as CashAmount, 
			(isnull(TCCP.Amount, 0) + isnull(vw_CheckPayment.Amount, 0) + isnull(vw_ECheckPayment.Amount, 0) + isnull([TblCashPayment].Amount, 0)) as TotalAmount
		from 
		(  
			SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD  INNER JOIN [TblOrderDetail] TOD 
				ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]  
		)vw_EventCustomer
		INNER JOIN [TblPaymentOrder] ON vw_EventCustomer.OrderID = [TblPaymentOrder].[OrderID]  
		INNER JOIN [TblPayment] TP ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]  
		LEFT OUTER JOIN [TblChargeCardPayment] TCCP ON  TP.[PaymentID] = TCCP.[PaymentID]  
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblCheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblCheckPayment].[CheckID]) vw_CheckPayment
		ON vw_CheckPayment.[PaymentID]=TP.[PaymentID]  	
		LEFT OUTER JOIN
			(Select PaymentId, [TblCheck].* from [TblECheckPayment] INNER JOIN [TblCheck] ON [TblCheck].[CheckID] = [TblECheckPayment].[ECheckID]) vw_ECheckPayment
		ON vw_ECheckPayment.[PaymentID]=TP.[PaymentID]
		LEFT OUTER JOIN	[TblCashPayment] ON [TblCashPayment].[PaymentID]=TP.[PaymentID]  
		Order By EventCustomerId)a
  
   
  
 END  
  
   
 SELECT @TotalCustomers AS TotalCustomers, @TotalMaleCustomers AS TotalMaleCustomers, @TotalFemaleCustomers AS TotalFemaleCustomers,  
  @TotalEvents AS TotalEvents, @TotalCalls AS TotalCalls , isnull(@TotalRevenue, 0.00) AS TotalRevenue  
  
      
END  
          
  