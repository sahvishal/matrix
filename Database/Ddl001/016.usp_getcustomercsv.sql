USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_getcustomercsv]    Script Date: 03/27/2012 15:42:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================    
-- Author:  Abhinav Goel    
-- Create date: 23-08-2008    
-- Description: to fetch customer data    
-- Parameters:     
-- Modified (25-Aug-09) - [Virnajay] Added SalesRep Column  
-- =============================================    
ALTER PROCEDURE [dbo].[usp_getcustomercsv](     
@customerid BIGINT=null,     
@customername varchar(200) = null,     
@cityname varchar(200) = null,     
@statename varchar(200) = null,     
@zipcode varchar(100) = null,     
@fromdate datetime = null,     
@todate datetime = null,     
@franchiseeid bigint = null,     
@datetype bigint = null,    
@mode tinyint)     
 -- Add the parameters for the stored procedure here    
AS
BEGIN    
 -- SET NOCOUNT ON added to prevent extra result sets from    
 -- interfering with SELECT statements.    
 SET NOCOUNT ON;    
    
    -- Insert statements for procedure here   
  
IF(@customerid=0 AND (@customername IS NULL) AND (@statename IS NULL) AND (@cityname IS NULL) AND (@zipcode IS NULL) AND (@fromdate IS NULL) AND (@todate IS NULL) AND @franchiseeid=0 AND @datetype=0 AND @mode=0)  
BEGIN  
 --SELECT * FROM (  
 select TOP 10 TEC.EventCustomerID, TEC.CustomerID,   
       TEC.DateCreated,   
       TU.FirstName,   
       TU.LastName,   
       TU.EMail1, TU.DOB,    
       ISNULL(ECTORU.RoleID,0) AS RoleID,   
       TE.EventName,   
       TE.EventDate,   
       TH.OrganizationName,    
       TEA.StartTime,   
       ISNULL(vwPaymentDetails.ScreeningCost,0) PackagePrice,   
      ISNULL(Package.[PackageName],'') PackageName,  
      ISNULL(Test.AdditionalTest,'') AdditionalTest,  
      --- TC.TrackingMarketingID,  
      TEC.marketingsource TrackingMarketingID,   
        ISNULL(TC.Race,'') AS Race,   
       ISNULL(vwPaymentDetails.Discount,0) DiscountAmount,  
       ISNULL(vwPaymentDetails.CouponCode,'') CouponCode,  
       ISNULL(TC.Height,0) AS Height,    
       ISNULL(TC.[Weight],0) AS WEIGHT,   
       ISNULL(TC.Gender,'') AS Gender, 
       TC.RequestNewsLetter,  
       vwPaymentDetails.isPaid,  ---TPDEC.IsPaid,    
       vwPaymentDetails.PaidAmount, ---   vwpaidamount.PaidAmount,   
       Ta.Address1,   
       TCity.[Name] City,   
       TS.[Name] State,   
       TZ.ZipCode,    
       Ta1.Address1 AS EventAddress,   
       TCity1.[Name] EventCity,   
       TS1.[Name] EventState,    
       TZ1.ZipCode AS EventCode,   
       IsNull(vwcalls.IncomingPhoneLine,'') as IncomingPhoneLine,    
       IsNull(vwcalls.CallersPhoneNumber,'') as CallersPhoneNumber,   
       TU.DateCreated as CustRegDate  
       ,TEC.EventID,  
    TE.AssignedToOrgRoleUserId SalesRepID,  
  TU1.FirstName + ' ' + TU1.LastName as 'SalesRep'  
  ,vwPaymentDetails.CreditCardPayment, vwPaymentDetails.CashPayment,vwPaymentDetails.CheckPayment, vwPaymentDetails.ECheckPayment, vwPaymentDetails.GCPayment  
  ,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
       FROM TblEventCustomers TEC (NOLOCK)
       INNER JOIN TblOrganizationRoleuser ECTORU (NOLOCK) on TEC.CreatedByOrgRoleUserId =  ECTORU.OrganizationRoleUserId  
       INNER JOIN dbo.TblEvents TE (NOLOCK) ON  TE.EventID=TEC.EventID   
       INNER JOIN dbo.TblHostEventDetails THED (NOLOCK) ON THED.EventID=TE.EventID    
       INNER JOIN dbo.TblProspects TH (NOLOCK) ON TH.ProspectID=THED.HostID    
       INNER JOIN dbo.TblEventAppointment TEA (NOLOCK) ON TEA.AppointmentID=TEC.AppointmentID    
  
    INNER JOIN TblEventCustomerOrderDetail TECOD (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID  
    INNER JOIN TblOrderDetail TOD (NOLOCK) on TOD.OrderDetailId=TECOD.OrderDetailId  
    INNER JOIN dbo.vw_Customers TC (NOLOCK) ON TC.CustomerID=TEC.CustomerID    
       INNER JOIN dbo.TblUser TU (NOLOCK) ON TU.UserID=tc.UserID    
       INNER JOIN dbo.TblAddress TA (NOLOCK) ON TA.AddressID=TU.HomeAddressID    
       INNER JOIN dbo.TblCity TCity (NOLOCK) ON TA.CityID=TCity.CityID    
       INNER JOIN dbo.TblState TS (NOLOCK) ON Ts.StateID=TA.StateID    
       INNER JOIN dbo.TblZip TZ (NOLOCK) ON ta.ZipID=tz.ZipID    
       INNER JOIN dbo.TblAddress TA1 (NOLOCK) ON TA1.AddressID=Th.AddressID    
       INNER JOIN dbo.TblCity TCity1 (NOLOCK) ON TA1.CityID=TCity1.CityID    
       INNER JOIN dbo.TblState TS1 (NOLOCK) ON Ts1.StateID=TA1.StateID    
       INNER JOIN dbo.TblZip TZ1 (NOLOCK) ON ta1.ZipID=tz1.ZipID   
    -- Added for salesRep     
    INNER JOIN TblOrganizationRoleUser TORU (NOLOCK) ON TORU.OrganizationRoleUserID=TE.AssignedToOrgRoleUserId
    INNER JOIN (select userid,firstname,lastname from TblUser (NOLOCK)) TU1 ON TU1.[UserID]=TORU.[UserID]  
  LEFT OUTER JOIN  
  (  
   SELECT TOD.OrderID, ISNULL(TP.PackageName,'') PackageName, TOD.Price AS PackagePrice  
   FROM [TblOrderDetail] TOD WITH (NOLOCK)  
   INNER JOIN TblOrderItem TPI WITH (NOLOCK) ON TPI.OrderItemId = TOD.OrderItemId   
   INNER JOIN TblEventPackageOrderItem TEPOI WITH (NOLOCK) On TEPOI.OrderItemId = TPI.OrderItemId  
   INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID]=TEPD.[EventPackageID]  
   INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]  
   WHERE TOD.Status=1  
  )Package ON Package.OrderID=TOD.OrderID   
    
  LEFT OUTER JOIN   
  (  
   SELECT TOP 100 PERCENT b.EventCustomerID,  
   STUFF  
   (  
    (SELECT  TOP 100 PERCENT ', ' + [Name] FROM   
     (       
      SELECT   [Name],[EventCustomerId]  
      FROM tblOrderDetail od (NOLOCK) INNER join  tblOrderItem oi (NOLOCK) on od.OrderItemId = oi.OrderItemId  
      INNER join  tblEventTestOrderItem etoi (NOLOCK) on oi.OrderItemId = etoi.OrderItemId  
      INNER join  tblEventTest et (NOLOCK) on etoi.EventTestId = et.EventTestId  
      INNER JOIN [TblTest] (NOLOCK) ON et.[TestID] = [TblTest].[TestID]   
      INNER JOIN (   
      SELECT [OrderID],[EventCustomerId]  from  tblEventCustomerOrderDetail ecod (NOLOCK)    
      INNER JOIN tblOrderDetail od (NOLOCK) on ecod.OrderDetailId = od.OrderDetailId  
      WHERE ecod.[IsActive]=1  ) ec ON ec.OrderID=od.[OrderID]  
      AND  od.Status =1 AND  oi.Type = 4  
     )   
     vw_Test  
    WHERE b.eventcustomerid = vw_Test.eventcustomerid  
    ORDER BY ',' + vw_Test.Name FOR XML PATH('')  
   ), 1, 1, '') AS AdditionalTest  
   FROM  tbleventcustomers AS b (NOLOCK)  
   ORDER BY b.[EventCustomerID]  
  )Test ON Test.EventCustomerID=TEC.EventCustomerID  
       left outer join     
       (  
  
         SELECT CASE WHEN [EffectiveCost] >isnull( totalpayment,0) THEN 0    ELSE 1 END AS IsPaid, lastPayDate AS DateModified,  
   [vw_EventCustomerRevenue].[EventCustomerId],CouponCode,Discount,isnull(totalpayment,0) AS PaidAmount,  
   ISNULL (CreditCardPayment,0) AS CreditCardPayment, ISNULL (CashPayment,0) AS CashPayment,  
   ISNULL (CheckPayment,0) AS CheckPayment, ISNULL (ECheckPayment,0) AS ECheckPayment,  
   ISNULL (GCPayment,0) AS GCPayment,ScreeningCost        
    FROM [vw_EventCustomerRevenue] (NOLOCK) LEFT OUTER JOIN [vw_EventCustomerPaymentNewOrderSystem] (NOLOCK) ON   
    [vw_EventCustomerPaymentNewOrderSystem].[EventCustomerId] = [vw_EventCustomerRevenue].[EventCustomerId]  
       )vwPaymentDetails on vwPaymentDetails.EventCustomerID=TEC.EventCustomerID  
    
       LEFT OUTER JOIN     
       (    
   SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID   
   FROM Tblcalls (NOLOCK)  
   WHERE (CallStatus='Register New Customer' OR CallStatus='Existing Customer') AND EventID IS NOT NULL  
   GROUP BY CalledCustomerID    
       )vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID   
       INNER JOIN     
  (    
   Select vw1.CustomerID, EventDate from    
   (    
    select TEC.CustomerID, EventDate,     
    ROW_NUMBER() OVER(PARTITION BY TEC.CustomerID ORDER BY ABS(DATEDIFF(DAY, EventDate, GETDATE()))) RowNumber    
    from TblEventCustomers TEC (NOLOCK)    
    inner join TblEvents TE (NOLOCK) on TEC.EventID=TE.EventID    
    WHERE TEC.AppointmentID IS NOT NULL    
   ) vw1    
   where RowNumber=1    
  ) tbl1 ON TEC.CustomerID = tbl1.CustomerID AND TE.EventDate = tbl1.EventDate   
  
       WHERE TEC.AppointmentID IS NOT NULL AND TU.IsActive=1    
    AND TECOD.IsActive=1 AND TEC.datecreated >  DATEADD(d,-90,GETDATE())   
     
  ORDER BY CustRegDate DESC  
  
          
        SELECT EP.EventID,TblPodDetails.[Name] AS PodName  
        FROM TblEventPod EP (NOLOCK)  
        INNER JOIN TblPodDetails (NOLOCK) ON TblPodDetails.PodID=EP.PodID  
  WHERE EP.IsActive=1  
END  
ELSE   
 BEGIN    
  Declare @sel_events_query nvarchar(max)  
  Declare @sel_payment_query nvarchar(4000)    
  DECLARE @sel_pod_query NVARCHAR(1000)  
  Declare @sel_temp varchar(4000)  
  set @sel_temp=''  
  SET @sel_events_query=''  
    
   
       
    
  Set @sel_events_query = 'select  TEC.EventCustomerID,TEC.CustomerID,     TEC.DateCreated, TU.FirstName, TU.LastName, TU.EMail1, TU.DOB,    
       ISNULL(ECTORU.RoleID,0) AS RoleID, TE.EventName, TE.EventDate, TH.OrganizationName,    
       TEA.StartTime,  ISNULL(vwPaymentDetails.ScreeningCost,0) PackagePrice,    
      ISNULL(Package.[PackageName],'''') PackageName,  
      ISNULL(Test.AdditionalTest,'''') AdditionalTest,     
       ISNULL(vwPaymentDetails.Discount,0) AS DiscountAmount, vwPaymentDetails.CouponCode, ---ISNULL(TCD.CouponCode,'''') AS CouponCode,    
       --TC.TrackingMarketingID,  
        TEC.marketingsource TrackingMarketingID, ISNULL(TC.Race,'''') AS Race, ISNULL(TC.Height,0) AS Height,    
       ISNULL(TC.[Weight],0) AS WEIGHT, ISNULL(TC.Gender,'''') AS Gender, TC.RequestNewsLetter, vwPaymentDetails.IsPaid, ---TPDEC.IsPaid,    
          vwPaymentDetails.PaidAmount, Ta.Address1, TCity.[Name] City, TS.[Name] State, TZ.ZipCode,    
       Ta1.Address1 AS EventAddress, TCity1.[Name] EventCity, TS1.[Name] EventState,    
       TZ1.ZipCode AS EventCode, IsNull(vwcalls.IncomingPhoneLine,'''') as IncomingPhoneLine,    
       IsNull(vwcalls.CallersPhoneNumber,'''') as CallersPhoneNumber, TU.DateCreated as CustRegDate ,TEC.EventID,  
    TE.AssignedToOrgRoleUserId SalesRepID,TU1.FirstName + '' '' + TU1.LastName as SalesRep  
     ,vwPaymentDetails.CreditCardPayment, vwPaymentDetails.CashPayment,vwPaymentDetails.CheckPayment,  
     vwPaymentDetails.ECheckPayment,    vwPaymentDetails.GCPayment  
     ,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
          FROM TblEventCustomers TEC (NOLOCK) 
       INNER JOIN TblOrganizationRoleuser ECTORU (NOLOCK) on TEC.CreatedByOrgRoleUserId =  ECTORU.OrganizationRoleUserId     
       INNER JOIN dbo.TblEvents TE (NOLOCK) ON  TE.EventID=TEC.EventID    
       INNER JOIN dbo.TblHostEventDetails THED (NOLOCK) ON THED.EventID=TE.EventID    
       INNER JOIN dbo.TblProspects TH (NOLOCK) ON TH.ProspectID=THED.HostID    
       INNER JOIN dbo.TblEventAppointment TEA (NOLOCK) ON TEA.AppointmentID=TEC.AppointmentID    
       INNER JOIN TblEventCustomerOrderDetail TECOD (NOLOCK) on TECOD.EventCustomerId = TEC.EventCustomerID  
    INNER JOIN TblOrderDetail TOD (NOLOCK) on TOD.OrderDetailId=TECOD.OrderDetailId  
    INNER JOIN dbo.vw_Customers TC (NOLOCK) ON TC.CustomerID=TEC.CustomerID    
       INNER JOIN dbo.TblUser TU (NOLOCK) ON TU.UserID=tc.UserID   
       INNER JOIN dbo.TblAddress TA (NOLOCK) ON TA.AddressID=TU.HomeAddressID    
       INNER JOIN dbo.TblCity TCity (NOLOCK) ON TA.CityID=TCity.CityID    
       INNER JOIN dbo.TblState TS (NOLOCK) ON Ts.StateID=TA.StateID    
       INNER JOIN dbo.TblZip TZ (NOLOCK) ON ta.ZipID=tz.ZipID    
       INNER JOIN dbo.TblAddress TA1 (NOLOCK) ON TA1.AddressID=Th.AddressID    
       INNER JOIN dbo.TblCity TCity1 (NOLOCK) ON TA1.CityID=TCity1.CityID    
       INNER JOIN dbo.TblState TS1 (NOLOCK) ON Ts1.StateID=TA1.StateID    
       INNER JOIN dbo.TblZip TZ1 (NOLOCK) ON ta1.ZipID=tz1.ZipID  
  -- Added for salesRep       
    INNER JOIN TblOrganizationRoleUser TORU (NOLOCK) ON TORU.OrganizationRoleUserID=TE.AssignedToOrgRoleUserId  
    INNER JOIN (select userid,firstname,lastname from TblUser (NOLOCK)) TU1 ON TU1.[UserID]=TORU.[UserID]    
       LEFT OUTER JOIN  
  (  
   SELECT TOD.OrderID, ISNULL(TP.PackageName,'''') PackageName, TOD.Price AS PackagePrice  
   FROM [TblOrderDetail] TOD WITH (NOLOCK)  
   INNER JOIN TblOrderItem TPI WITH (NOLOCK) ON TPI.OrderItemId = TOD.OrderItemId   
   INNER JOIN TblEventPackageOrderItem TEPOI WITH (NOLOCK) On TEPOI.OrderItemId = TPI.OrderItemId  
   INNER JOIN [TblEventPackageDetails] TEPD WITH (NOLOCK) ON TEPOI.[EventPackageID]=TEPD.[EventPackageID]  
   INNER JOIN [TblPackage] TP WITH (NOLOCK) ON TEPD.[PackageID] = TP.[PackageID]  
   WHERE TOD.Status=1  
  )Package ON Package.OrderID=TOD.OrderID   
    
  LEFT OUTER JOIN   
  (  
   SELECT TOP 100 PERCENT b.EventCustomerID,  
   STUFF  
   (  
    (SELECT  TOP 100 PERCENT '', '' + [Name] FROM   
     (       
      SELECT   [Name],[EventCustomerId]  
      FROM tblOrderDetail od (NOLOCK) INNER join  tblOrderItem oi (NOLOCK) on od.OrderItemId = oi.OrderItemId  
      INNER join  tblEventTestOrderItem etoi (NOLOCK) on oi.OrderItemId = etoi.OrderItemId  
      INNER join  tblEventTest et (NOLOCK) on etoi.EventTestId = et.EventTestId  
      INNER JOIN [TblTest] (NOLOCK) ON et.[TestID] = [TblTest].[TestID]   
      INNER JOIN (   
      SELECT [OrderID],[EventCustomerId]  from  tblEventCustomerOrderDetail ecod (NOLOCK)   
      INNER JOIN tblOrderDetail od (NOLOCK) on ecod.OrderDetailId = od.OrderDetailId  
      WHERE ecod.[IsActive]=1  ) ec ON ec.OrderID=od.[OrderID]  
      AND  od.Status =1 AND  oi.Type = 4  
     )   
     vw_Test  
    WHERE b.eventcustomerid = vw_Test.eventcustomerid  
    ORDER BY '','' + vw_Test.Name FOR XML PATH('''')  
   ), 1, 1, '''') AS AdditionalTest  
   FROM  tbleventcustomers AS b (NOLOCK) 
   ORDER BY b.[EventCustomerID]  
  )Test ON Test.EventCustomerID=TEC.EventCustomerID  
       left outer join     
       (  
   SELECT CASE WHEN [EffectiveCost] >isnull(totalpayment,0) THEN 0    ELSE 1 END AS IsPaid, lastPayDate AS DateModified,  
   [vw_EventCustomerRevenue].[EventCustomerId],CouponCode,Discount,  
   isnull(totalpayment,0) AS PaidAmount,  
   ISNULL (CreditCardPayment,0) AS CreditCardPayment, ISNULL (CashPayment,0) AS CashPayment,  
   ISNULL (CheckPayment,0) AS CheckPayment, ISNULL (ECheckPayment,0) AS ECheckPayment,  
   ISNULL (GCPayment,0) AS GCPayment, ScreeningCost             
    FROM [vw_EventCustomerRevenue] (NOLOCK) Left Outer JOIN  [vw_EventCustomerPaymentNewOrderSystem] (NOLOCK) ON   
    [vw_EventCustomerPaymentNewOrderSystem].[EventCustomerId] = [vw_EventCustomerRevenue].[EventCustomerId]    
       )vwPaymentDetails on vwPaymentDetails.EventCustomerID=TEC.EventCustomerID  '  
          
  set @sel_temp='INNER JOIN     
  (    
   Select vw1.CustomerID, EventDate from    
   (    
    select TEC.CustomerID, EventDate,     
    ROW_NUMBER() OVER(PARTITION BY TEC.CustomerID ORDER BY ABS(DATEDIFF(DAY, EventDate, GETDATE()))) RowNumber    
    from TblEventCustomers TEC (NOLOCK)   
    inner join TblEvents TE (NOLOCK) on TEC.EventID=TE.EventID    
    WHERE TEC.AppointmentID IS NOT NULL    
   ) vw1    
   where RowNumber=1    
  ) tbl1 ON TEC.CustomerID = tbl1.CustomerID AND TE.EventDate = tbl1.EventDate '  
--  IF(@datetype=2)  
--  BEGIN  
  SET @sel_events_query= @sel_events_query + @sel_temp  
--  END  
    
  SET @sel_events_query = @sel_events_query +   
       '  
       
       LEFT OUTER JOIN     
       (    
        SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID   
  FROM Tblcalls (NOLOCK)  
  WHERE (CallStatus=''Register New Customer'' OR CallStatus=''Existing Customer'') AND EventID IS NOT NULL  
  GROUP BY CalledCustomerID     
       )vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID    
       WHERE TEC.AppointmentID IS NOT NULL AND TU.IsActive=1 AND TECOD.IsActive=1 '     
      
  if(@franchiseeid > 0)    
  BEGIN    
   Set @sel_events_query = @sel_events_query + ' AND TE.FranchiseeID =' + Convert(varchar(10), @franchiseeid )     
  END    
    
  if(@customerid > 0)    
  BEGIN    
   Set @sel_events_query = @sel_events_query + ' AND TC.CustomerID = ' + Convert(varchar(10), @customerid )      
  END    
    
  if(@customername is not NULL)    
  BEGIN    
 set @customername=replace(@customername,'%','')    
   set @customername = '%' + @customername +'%'  
   Set @sel_events_query = @sel_events_query + ' and ((rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(TU.middlename,'''')))) > 0 then '' '' + TU.middlename + '' '' else '' '' end) +  rtrim(ltrim(TU.LastName)))like ''' + @customername + '''
 )'                   
   --Set @sel_events_query = @sel_events_query + ' and (TU.FirstName like ''%' + @customername + '%'' '+ ' or TU.LastName like ''%' + @customername + '%'' '+ ' or TU.MiddleName  like ''%' + @customername + '%'' )'                
  END    
    
  if(@cityname is not null)    
  BEGIN    
   Set @sel_events_query = @sel_events_query + ' AND TA.CityID in (Select CityID from tblcity (NOLOCK) where [name] like ''%' + @cityname + '%'' ) '     
  END    
    
  if(@statename is not null)    
  BEGIN    
   Set @sel_events_query = @sel_events_query + ' AND TA.StateID in (Select StateID from tblstate (NOLOCK) where [name] like ''%' + @statename + '%'' ) '     
  END    
        
  if(@zipcode is not null)    
  BEGIN    
   Set @sel_events_query = @sel_events_query + ' AND TA.ZipID in (Select ZipID from TblZip (NOLOCK) where ZipCode like ''%' + @zipcode + '%'' ) '    
  END    
      
  if(@datetype=0)    
  Begin    
   if(@fromdate is not null and @todate is not null)    
   BEGIN     
    
    Set @sel_events_query = @sel_events_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DateTime) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME)'    
   END    
   else if(@fromdate is not null )    
   BEGIN    
    Set @sel_events_query = @sel_events_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '    
   END    
   else if(@todate is not null)    
   BEGIN    
    Set @sel_events_query = @sel_events_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '    
   END    
   --Set @sel_events_query = @sel_events_query + ' ORDER BY TU.DateCreated desc '    
       
  END    
  Else if(@datetype=1)    
  Begin    
   if(@fromdate is not null and @todate is not null)    
   BEGIN    
    Set @sel_events_query = @sel_events_query + ' AND CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TE.EventDate,101) as DATETIME)<= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME)'    
   END    
   else if(@fromdate is not null )    
   BEGIN    
    Set @sel_events_query = @sel_events_query + ' and TE.EventDate >= ''' + Cast(@fromdate as varchar(50)) + ''' '    
   END    
   else if(@todate is not null)    
   BEGIN    
    Set @sel_events_query = @sel_events_query + ' and TE.EventDate <= ''' + Cast(@todate as varchar(50)) + ''' '    
   END    
   --set @sel_events_query= @sel_events_query + ' and ((TEA.CheckinTime IS NOT NULL) or (TEA.CheckoutTime IS NOT null))' 
   set @sel_events_query= @sel_events_query + ' and TEC.NoShow = 0'   
   Set @sel_events_query = @sel_events_query + ' ORDER BY TE.EventDate desc '       
  END    
  Else if(@datetype=2)      
  Begin      
   if(@fromdate is not null and @todate is not null)      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' AND TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1 '      
   END      
   else if(@fromdate is not null )      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' and TEC.DateCreated >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '      
   END      
   else if(@todate is not null)      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' and TEC.DateCreated <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1 '      
   END      
   Set @sel_events_query = @sel_events_query + ' ORDER BY TEC.DateCreated desc '      
  END      
  Else if(@datetype=3)      
  Begin      
   if(@fromdate is not null and @todate is not null)      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' AND vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + ''' as datetime) and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + ''' as datetime) + 1'      
   END      
   else if(@fromdate is not null )      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' and vwPaymentDetails.DateModified >= CAST(''' + convert(varchar, @fromdate,101) + '''as datetime) '      
   END      
   else if(@todate is not null)      
   BEGIN      
    Set @sel_events_query = @sel_events_query + ' and vwPaymentDetails.DateModified <= CAST(''' + convert(varchar,@todate,101) + '''as datetime) + 1 '      
   END      
   Set @sel_events_query = @sel_events_query + ' AND vwPaymentDetails.IsPaid=1 '    
   Set @sel_events_query = @sel_events_query + ' ORDER BY vwPaymentDetails.DateModified desc '      
  END    
      
         
  SET @sel_pod_query='SELECT EP.EventID,TblPodDetails.[Name] AS PodName FROM TblEventPod EP (NOLOCK) INNER JOIN TblPodDetails (NOLOCK) ON TblPodDetails.PodID=EP.PodID WHERE EP.IsActive=1'  
     
-- IF(@datetype = 0)      
-- BEGIN      
--  Declare @sel_ACevents_query nvarchar(4000)      
      
--  /* *************************************************** */      
--  /* Preparing string query for fetching TblEvents record */      
--  Set @sel_ACevents_query = ' Select distinct      
--     0 AS EventCustomerID, TC.CustomerID, NULL AS DateCreated, ISNULL(TU.FirstName, '''') FirstName,    
--     ISNULL(TU.LastName, '''') LastName, TU.EMail1, TU.DOB, ISNULL(TC.AddedByRoleID, 0) RoleID,    
--     '''' as EventName, Null as EventDate, '''' as OrganizationName, '''' AS StartTime,    
--     0 AS PackagePrice, '''' as PackageName,'''' as AdditionalTest,   0 AS DiscountAmount, '''' AS CouponCode,    
--     TC.TrackingMarketingID,   
--     ISNULL(TC.Race,'''') AS Race, ISNULL(TC.Height,0) AS Height,    
--     ISNULL(TC.[Weight],0) AS WEIGHT, ISNULL(TC.Gender,'''') AS Gender, 0 AS IsPaid, 0 AS PaidAmount,    
--     Ta.Address1, TCity.[Name] City, TS.[Name] State, TZ.ZipCode, '''' AS EventAddress,     
--     '''' AS  EventCity, '''' AS EventState, '''' AS EventCode,     
--     IsNull(vwcalls.IncomingPhoneLine,'''') as IncomingPhoneLine,    
--     IsNull(vwcalls.CallersPhoneNumber,'''') as CallersPhoneNumber,    
--     TU.DateCreated as CustRegDate, 0 AS EventID,  
--  0 as SalesRepID,'''' as SalesRep  
--  ,0 AS CreditCardPayment, 0 AS CashPayment,0 AS CheckPayment,  
--     0 AS ECheckPayment,    0 AS GCPayment  
--     ,ISNULL(TC.DoNotContactReasonId,0) as DoNotContactReasonId
--     from  vw_Customers TC (NOLOCK)     
--     Inner Join TblUser TU (NOLOCK) on TU.UserID=TC.UserID      
--     INNER JOIN TblAddress TA (NOLOCK) ON TA.AddressID=TU.HomeAddressID    
--     INNER JOIN dbo.TblCity TCity (NOLOCK) ON TA.CityID=TCity.CityID    
--     INNER JOIN dbo.TblState TS (NOLOCK) ON Ts.StateID=TA.StateID    
--     INNER JOIN dbo.TblZip TZ (NOLOCK) ON TA.ZipID=TZ.ZipID    
--     LEFT OUTER JOIN     
--     (    
--     SELECT MAX(IncomingPhoneLine) AS IncomingPhoneLine,MAX(CallersPhoneNumber) AS CallersPhoneNumber,CalledCustomerID   
--  FROM Tblcalls (NOLOCK)  
--  WHERE (CallStatus=''Register New Customer'' OR CallStatus=''Existing Customer'') AND EventID IS NOT NULL  
--  GROUP BY CalledCustomerID   
--     )vwcalls ON vwcalls.CalledCustomerID=TC.CustomerID      
--     WHERE CustomerID NOT IN (SELECT DISTINCT customerid FROM dbo.TblEventCustomers (NOLOCK) WHERE AppointmentID IS NOT null) '      
    
--   if(@franchiseeid > 0)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND TE.FranchiseeID =' + Convert(varchar(10), @franchiseeid )       
--   END      
    
--   if(@customerid > 0)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND TC.CustomerID = ' + Convert(varchar(10), @customerid )        
--   END      
    
--   if(@customername is not NULL)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' and ((rtrim(ltrim(TU.FirstName)) + (case when len(rtrim(ltrim(isnull(middlename,'''')))) > 0 then '' '' + middlename + '' '' else '' '' end) +  rtrim(ltrim(TU.LastName)))like ''%' + @customername + '%
--'' )'                  
--   END      
    
--   if(@cityname is not null)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND TA.CityID in (Select CityID from tblcity (NOLOCK) where [name] like ''%' + @cityname + '%'' ) '       
--   END      
    
--   if(@statename is not null)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND TA.StateID in (Select StateID from tblstate (NOLOCK) where [name] like ''%' + @statename + '%'' ) '       
--   END      
    
--   if(@zipcode is not null)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND TA.ZipID in (Select ZipID from TblZip (NOLOCK) where ZipCode like ''%' + @zipcode + '%'' ) '      
--   END      
    
--   if(@fromdate is not null and @todate is not null)      
--   BEGIN       
--    Set @sel_ACevents_query = @sel_ACevents_query + ' AND CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) >= CAST(''' + convert(varchar, @fromdate,101) + ''' as DATETIME) and CAST(CONVERT(VARCHAR,TU.DateCreated,101) as DATETIME) <= CAST(''' + convert(varchar,@todate,101) + ''' as DATETIME) '      
--   END      
--   else if(@fromdate is not null )      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' and TU.DateCreated >= ''' + Cast(@fromdate as varchar(50)) + ''' '      
--   END      
--   else if(@todate is not null)      
--   BEGIN      
--    Set @sel_ACevents_query = @sel_ACevents_query + ' and TU.DateCreated <= ''' + Cast(@todate as varchar(50)) + ''' '      
--   END      
--   --Set @sel_ACevents_query = @sel_ACevents_query + ' ORDER by TU.DateCreated '    
     
--   SET @sel_events_query= 'SELECT * FROM ('+ @sel_events_query + ' UNION '  + @sel_ACevents_query + ') vw ORDER BY vw.CustRegDate desc'    
    
       
       
        
-- END    
  PRINT @sel_events_query  
  
 Exec sp_executesql @sel_events_query    
 Exec sp_executesql @sel_payment_query    
 EXEC sp_executesql @sel_pod_query  
 END    
     
END
