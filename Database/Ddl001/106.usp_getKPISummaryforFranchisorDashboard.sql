USE [$(dbName)]
GO

/****** Object:  StoredProcedure [dbo].[usp_getKPISummaryforFranchisorDashboard]    Script Date: 01/08/2013 11:30:59 ******/
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
  and EventId not in (select EventId from TblEventAccount) 
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')
  and EventId not in (select EventId from TblEventAccount)   
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female') 
  and EventId not in (select EventId from TblEventAccount)  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and CONVERT(VARCHAR,EventDate,101) = CONVERT(VARCHAR,GETDATE(),101) 
  and EventId not in (select EventId from TblEventAccount)  
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE CONVERT(VARCHAR,DateCreated,101)=CONVERT(VARCHAR,GETDATE(),101)   
     
  /*********TotalRevenue  **************/  
	SELECT @TotalRevenue=SUM(TotalAmount) FROM 
	(	select (ECP.OrderTotal + ECP.DiscountAmount)as TotalAmount
		FROM TblEventCustomers TEC
		inner join vw_EventCustomerPayment ECP on TEC.EventCustomerId = ECP.EventCustomerId
		WHERE appointmentid is not null and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
		and EventId not in (select EventId from TblEventAccount) 
	)a
  
 END  
 ELSE IF(@mode = 1)  
 BEGIN  
  
    
  /*********TotalCustomers**************/  
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
   and EventId not in (select EventId from TblEventAccount) 
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')
  and EventId not in (select EventId from TblEventAccount)   
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
  and EventId not in (select EventId from TblEventAccount) 
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))   
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
   and EventId not in (select EventId from TblEventAccount)  
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
  (
	select (ECP.OrderTotal + ECP.DiscountAmount)as TotalAmount
	FROM TblEventCustomers TEC
	inner join vw_EventCustomerPayment ECP on TEC.EventCustomerId = ECP.EventCustomerId
	WHERE appointmentid is not null and 
	Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
	and EventId not in (select EventId from TblEventAccount) 
  )a
  
 END  
 ELSE IF(@mode = 2)  
 BEGIN  
  
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
   and EventId not in (select EventId from TblEventAccount)   
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male') 
  and EventId not in (select EventId from TblEventAccount)  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null and   
   Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female') 
  and EventId not in (select EventId from TblEventAccount)  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
   and EventId not in (select EventId from TblEventAccount)    
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
  ( 
	select (ECP.OrderTotal + ECP.DiscountAmount)as TotalAmount
	FROM TblEventCustomers TEC
	inner join vw_EventCustomerPayment ECP on TEC.EventCustomerId = ECP.EventCustomerId
	WHERE appointmentid is not null and 
	Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
	and EventId not in (select EventId from TblEventAccount) 
  )a
  
 END  
 ELSE IF(@mode = 3)  
 BEGIN  
    
  SELECT @TotalCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null  
  and EventId not in (select EventId from TblEventAccount)   
    
  /*********MaleCustomers **************/    
  SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null   
  and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male') 
  and EventId not in (select EventId from TblEventAccount)  
  
  /*********FemaleCustomers  **************/  
  SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers where appointmentid is not null   
  and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
  and EventId not in (select EventId from TblEventAccount) 
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1
  and EventId not in (select EventId from TblEventAccount)    
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls   
     
  /*********TotalRevenue  **************/  
  SELECT @TotalRevenue=SUM(TotalAmount) FROM 
  (
	select (ECP.OrderTotal + ECP.DiscountAmount)as TotalAmount
	FROM TblEventCustomers TEC
	inner join vw_EventCustomerPayment ECP on TEC.EventCustomerId = ECP.EventCustomerId
	WHERE appointmentid is not null
	and EventId not in (select EventId from TblEventAccount) 
	)a
  
   
  
 END  
  
   
 SELECT @TotalCustomers AS TotalCustomers, @TotalMaleCustomers AS TotalMaleCustomers, @TotalFemaleCustomers AS TotalFemaleCustomers,  
  @TotalEvents AS TotalEvents, @TotalCalls AS TotalCalls , isnull(@TotalRevenue, 0.00) AS TotalRevenue  
  
      
END  
          
  