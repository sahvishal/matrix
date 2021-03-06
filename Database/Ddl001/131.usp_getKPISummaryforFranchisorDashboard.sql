USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getKPISummaryforFranchisorDashboard]    Script Date: 05/07/2013 15:18:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
  
    
-- =============================================  
-- Author:  Sandeep Raheja  
-- Create date: 10th Jan, 2009  
-- Description: Mode 0 = Today, 1 = Last 7Days, 2 = Last 30Days, 3 = All Time   
-- =============================================  
ALTER PROCEDURE [dbo].[usp_getKPISummaryforFranchisorDashboard](@mode tinyint, @signupmode tinyint)  
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
   
   ,@TotalOnlineCustomers BIGINT    
   ,@TotalOnlineRevenue DECIMAL(18,2) 
   ,@TotalOnlineMaleCustomers BIGINT 
   ,@TotalOnlineFemaleCustomers BIGINT 
   
   ,@TotalCallCenterCustomers BIGINT  
   ,@TotalCallCenterRevenue DECIMAL(18,2) 
   ,@TotalCallCenterMaleCustomers BIGINT 
   ,@TotalCallCenterFemaleCustomers BIGINT     
  
 IF(@mode = 0)  
 BEGIN  
  
  /*********TotalCustomers**************/ 
	if(@signupmode = 0)
	Begin
		SELECT @TotalCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
		and EventId not in (select EventId from TblEventAccount with(nolock)) 

		SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
		and  customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')
		and EventId not in (select EventId from TblEventAccount with(nolock))

		SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId 
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  
		and  customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female') 
		and EventId not in (select EventId from TblEventAccount with(nolock))  
		  
		SELECT @TotalRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with (nolock)
			inner join vw_EventCustomerPayment ECP with (nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
			and EventId not in (select EventId from TblEventAccount with(nolock)) 
		)a
	End
	Else if(@signupmode = 1)
	Begin
		SELECT @TotalOnlineCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)

		SELECT @TotalOnlineMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)  

		SELECT @TotalOnlineFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)
		
		SELECT @TotalOnlineRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount -- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TEC.CustomerId = TEC.CreatedByOrgRoleUserId
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
		)a 
	End
	Else if(@signupmode = 2)
	Begin
		SELECT @TotalCallCenterCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)

		SELECT @TotalCallCenterMaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)

		SELECT @TotalCallCenterFemaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101)
		
		SELECT @TotalCallCenterRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0 
			and TORU.RoleId = 10
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and CONVERT(VARCHAR,DateCreated,101) = CONVERT(VARCHAR,GETDATE(),101) 
		)a
	End  
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and CONVERT(VARCHAR,EventDate,101) = CONVERT(VARCHAR,GETDATE(),101) 
  and EventId not in (select EventId from TblEventAccount with(nolock))  
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE CONVERT(VARCHAR,DateCreated,101)=CONVERT(VARCHAR,GETDATE(),101) 
  
 END  
 ELSE IF(@mode = 1)  
 BEGIN  
	if(@signupmode = 0)
	Begin
		SELECT @TotalCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
		and customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male')
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
		and customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalRevenue=SUM(TotalAmount) FROM 
		(
			select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
			and EventId not in (select EventId from TblEventAccount with(nolock)) 
		)a  
	End
	Else if(@signupmode = 1)
	Begin
		SELECT @TotalOnlineCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalOnlineMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalOnlineFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		
		SELECT @TotalOnlineRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null
			and ECP.OrderTotal > 0 
			and TEC.CustomerId = TEC.CreatedByOrgRoleUserId
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		)a   
	End
	Else if(@signupmode = 2)
	Begin
		SELECT @TotalCallCenterCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		
		SELECT @TotalCallCenterMaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		
		SELECT @TotalCallCenterFemaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalCallCenterRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TORU.RoleId = 10
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		)a
	End 
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))   
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
   and EventId not in (select EventId from TblEventAccount with(nolock))  
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 6),101))    
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
  

 END  
 ELSE IF(@mode = 2)  
 BEGIN  
	if(@signupmode = 0)
	Begin
		SELECT @TotalCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		and EventId not in (select EventId from TblEventAccount with(nolock)) 
		
		SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
		and customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male') 
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))  
		and customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female') 
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalRevenue=SUM(TotalAmount) FROM 
		( 
			select (ECP.OrderTotal)as TotalAmount -- + ECP.DiscountAmount
			FROM TblEventCustomers TEC
			inner join vw_EventCustomerPayment ECP on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
			and EventId not in (select EventId from TblEventAccount with(nolock)) 
		)a     
	End
	Else if(@signupmode = 1)
	Begin
		SELECT @TotalOnlineCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		
		SELECT @TotalOnlineMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		
		SELECT @TotalOnlineFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalOnlineRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TEC.CustomerId = TEC.CreatedByOrgRoleUserId
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		)a
	End
	Else if(@signupmode = 2)
	Begin
		SELECT @TotalCallCenterCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalCallCenterMaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalCallCenterFemaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))    
		and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
		
		SELECT @TotalCallCenterRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TORU.RoleId = 10
			and EventId not in (select EventId from TblEventAccount with (nolock)) 
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
			and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101)) 
		)a
	End
    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1 and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))   
   and Convert(DateTime, CONVERT(VARCHAR,EventDate,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))
   and EventId not in (select EventId from TblEventAccount with(nolock))    
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls WHERE Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) >= Convert(DateTime, CONVERT(VARCHAR,(getdate() - 29),101))  
   and Convert(DateTime, CONVERT(VARCHAR,DateCreated,101)) <= Convert(DateTime, CONVERT(VARCHAR,getdate(),101))   
   
 END  
 ELSE IF(@mode = 3)  
 BEGIN  
	if(@signupmode = 0)
	Begin
		SELECT @TotalCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and customerid in  (Select CustomerID from TBlCustomerProfile where isnull(Gender, 'male') =  'male') 
		and EventId not in (select EventId from TblEventAccount with(nolock)) 
		
		SELECT @TotalFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and customerid in  (Select CustomerID from TBlCustomerProfile where Gender =  'female')  
		and EventId not in (select EventId from TblEventAccount with(nolock))
		
		SELECT @TotalRevenue=SUM(TotalAmount) FROM 
		(
			select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null
			and ECP.OrderTotal > 0
			and EventId not in (select EventId from TblEventAccount with(nolock)) 
		)a
	End
	Else if(@signupmode = 1)
	Begin
		SELECT @TotalOnlineCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		
		SELECT @TotalOnlineMaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		
		SELECT @TotalOnlineFemaleCustomers=COUNT(*) from TblEventCustomers TEC with(nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		where appointmentid is not null 
		and ECP.OrderTotal > 0
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and CustomerId = CreatedByOrgRoleUserId
		and  customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		
		SELECT @TotalOnlineRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TEC.CustomerId = TEC.CreatedByOrgRoleUserId
			and EventId not in (select EventId from TblEventAccount with (nolock))
		)a
	End
	Else if(@signupmode = 2)
	Begin
		SELECT @TotalCallCenterCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		
		SELECT @TotalCallCenterMaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where isnull(Gender, 'male') =  'male')
		
		SELECT @TotalCallCenterFemaleCustomers=COUNT(*) from TblEventCustomers TEC with (nolock)
		inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
		inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
		where appointmentid is not null
		and ECP.OrderTotal > 0 
		and EventId not in (select EventId from TblEventAccount with (nolock))
		and TORU.RoleId = 10
		and customerid in  (Select CustomerID from TBlCustomerProfile with (nolock) where Gender =  'female')
		
		SELECT @TotalCallCenterRevenue=SUM(TotalAmount) FROM 
		(	select (ECP.OrderTotal)as TotalAmount-- + ECP.DiscountAmount
			FROM TblEventCustomers TEC with(nolock)
			inner join vw_EventCustomerPayment ECP with(nolock) on TEC.EventCustomerId = ECP.EventCustomerId
			inner join TblOrganizationroleUser TORU with (nolock) on TEC.CreatedByOrgRoleUserId = TORU.OrganizationRoleUserId
			WHERE appointmentid is not null 
			and ECP.OrderTotal > 0
			and TORU.RoleId = 10
			and EventId not in (select EventId from TblEventAccount with (nolock))
		)a
	End

    
  /*********TotalEvents  **************/  
  SELECT @TotalEvents=COUNT(*) FROM TblEvents WHERE IsActive = 1 and EventStatus=1
  and EventId not in (select EventId from TblEventAccount with(nolock))    
  
  /*********TotalCalls  **************/  
  SELECT @TotalCalls=COUNT(*) FROM dbo.TblCalls
  
 END  
  
   
 SELECT isnull(@TotalCustomers,0) AS TotalCustomers, isnull(@TotalMaleCustomers,0) AS TotalMaleCustomers, isnull(@TotalFemaleCustomers,0) AS TotalFemaleCustomers,  
  @TotalEvents AS TotalEvents, @TotalCalls AS TotalCalls , isnull(@TotalRevenue, 0.00) AS TotalRevenue 
  ,isnull(@TotalOnlineCustomers,0) as TotalOnlineCustomers ,isnull(@TotalCallCenterCustomers,0) as TotalCallCenterCustomers
  ,isnull(@TotalOnlineMaleCustomers,0) AS TotalOnlineMaleCustomers, isnull(@TotalOnlineFemaleCustomers,0) AS TotalOnlineFemaleCustomers
  ,isnull(@TotalCallCenterMaleCustomers,0) AS TotalCallCenterMaleCustomers, isnull(@TotalCallCenterFemaleCustomers,0) AS TotalCallCenterFemaleCustomers
  ,isnull(@TotalOnlineRevenue,0.00) as TotalOnlineRevenue ,isnull(@TotalCallCenterRevenue,0.00) as TotalCallCenterRevenue
  
      
END  
          
  