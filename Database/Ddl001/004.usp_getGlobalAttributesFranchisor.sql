USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_getGlobalAttributesFranchisor]    Script Date: 03/12/2012 15:40:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================      
-- Author:  Nitin Tikkha      
-- Create date: 02-12-2007      
-- Description: To get the detail of the GlobalAttributes      
-- Name: usp_getcity      
-- Parameter: Input (mode "0->All rows,1->Rows for Franchisor")      
--=============================================        
ALTER PROCEDURE [dbo].[usp_getGlobalAttributesFranchisor]( @mode tinyint )       
       
AS
BEGIN       
 if(@mode = 1)      
 BEGIN      
  select  DaysToChangePassword=(select value from TblGlobalConfiguration where name='DaysToChangePassword')       
  ,NumberOfPictures=(select value from TblGlobalConfiguration where name='NumberOfPictures')       
  ,  AppointmentSlot=(select value from TblGlobalConfiguration where name='AppointmentSlot')      
  ,  ScheduleTemplateID=(select value from TblGlobalConfiguration where name='DefaultScheduleTemplate')       
  ,  GlobalCutOffDate=(select value from TblGlobalConfiguration where name='GlobalCutOffDate')      
  ,  MVAccessIPs=(select value from TblGlobalConfiguration where name='MVAccessIPs')    
  ,  ShowOrderCatalog=(select value from TblGlobalConfiguration where name='ShowOrderCatalog')    
  ,  MVPermittedKey=(select value from TblGlobalConfiguration where name='MVPermittedKey')    
  ,  SystemVersion=(select value from TblGlobalConfiguration where name='SystemVersion')    
  ,  Eventdistance=(select value from TblGlobalConfiguration where name='Eventdistance')    
  ,  [From]=(select value from TblGlobalConfiguration where name='From')    
  ,  FromName=(select value from TblGlobalConfiguration where name='FromName')    
  ,  AdministratorEmail=(select value from TblGlobalConfiguration where name='AdministratorEmail')    
      
  ,  GoogleCalendarUsername=(select value from TblGlobalConfiguration where name='GoogleCalendarUsername')    
  ,  GoogleCalendarPassword=(select value from TblGlobalConfiguration where name='GoogleCalendarPassword')    
  ,  CouponPrefix=(select value from TblGlobalConfiguration where name='CouponPrefix')    
  ,  CCRepDashBoardRefereshTime=(select value from TblGlobalConfiguration where name='CCRepDashBoardRefereshTime')    
  ,  DisplayBarOnQA=isnull((select value from TblGlobalConfiguration where name='DisplayBarOnQA'),'')
  -- get the value of maxdollar commission for advocate
  ,  MaxDollarCommission=isnull((select value from TblGlobalConfiguration where name='MaxDollarCommission'),'0.0')
  ,  MaxPercentCommission=isnull((select value from TblGlobalConfiguration where name='MaxPercentCommission'),'0.0')
  ,  MaxDollarCommissionSalesRep=isnull((select value from TblGlobalConfiguration where name='MaxDollarCommissionSalesRep'),'0.0')
  ,  MaxPercentCommissionSalesRep=isnull((select value from TblGlobalConfiguration where name='MaxPercentCommissionSalesRep'),'0.0')
  ,  Competitor=(select value from TblGlobalConfiguration where name='Competitor')   
  ,  CancellationFee=(select value from TblGlobalConfiguration where name='CancellationFee') 
  ,  EventStartTime=(select value from TblGlobalConfiguration where name='EventStartTime') 
  ,  EventEndTime=(select value from TblGlobalConfiguration where name='EventEndTime') 
  ,  MinimumPurchaseAmount=(select value from TblGlobalConfiguration where name='MinimumPurchaseAmount')
  ,  IncomingPhoneLineRequired=(select value from TblGlobalConfiguration where name='IncomingPhoneLineRequired') 
  ,  EnableAlaCarte=(select value from TblGlobalConfiguration where name='EnableAlaCarte')   
  ,  AreaCode=(select value from TblGlobalConfiguration where name='AreaCode')  
  ,  EnableBarCode=(select value from TblGlobalConfiguration where name='EnableBarCode')
  ,  UpsellPackage=(select value from TblGlobalConfiguration where name='UpsellPackage') 
  ,  UpsellCD=(select value from TblGlobalConfiguration where name='UpsellCd')
  ,  PaperSize=(select value from TblGlobalConfiguration where name='PaperSize')
 END       
END      
/* SET NOCOUNT ON */       
RETURN
