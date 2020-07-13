    
USE [$(dbName)]
GO   

      
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
  ,  UpsellAlaCarte=(select value from TblGlobalConfiguration where name='UpsellAlaCarte')      
  ,  MaxNoOfEventToShowOnline=(select value from TblGlobalConfiguration where name='MaxNoOfEventToShowOnline')    
  ,  MaxNoOfAppointmentSlotsToShowOnline=(select value from TblGlobalConfiguration where name='MaxNoOfAppointmentSlotsToShowOnline')    
  ,  EventListPageSizeOnline=(select value from TblGlobalConfiguration where name='EventListPageSizeOnline')    
  ,  PaperSize=(select value from TblGlobalConfiguration where name='PaperSize')    
  ,  DisplayPremiumVersiononPortal=(select value from TblGlobalConfiguration where name='DisplayPremiumVersiononPortal')    
  ,  EnableResultDeliveryNotification=(select value from TblGlobalConfiguration where name='EnableResultDeliveryNotification')    
  ,  EnableNewsletterPrompt=(select value from TblGlobalConfiguration where name='EnableNewsletterPrompt')    
  ,  SourceCodeLabel=(select value from TblGlobalConfiguration where name='SourceCodeLabel')    
  ,  CutOffHourNumberforOnlineEventSelection=(select value from TblGlobalConfiguration where name='CutOffHourNumberforOnlineEventSelection')    
  ,  DisplayRescheduleAppointmentPortal=(select value from TblGlobalConfiguration where name='DisplayRescheduleAppointmentPortal')    
  ,  ShowBasicBiometric=(select value from TblGlobalConfiguration where name='ShowBasicBiometric')    
  ,  EnableQuickOnsiteRegistration=(select value from TblGlobalConfiguration where name='EnableQuickOnsiteRegistration')    
  ,  PayLaterOnlineRegistration=(select value from TblGlobalConfiguration where name='PayLaterOnlineRegistration')    
  ,  RestrictAvailableTimeSlotForCorporate=(select value from TblGlobalConfiguration where name='RestrictAvailableTimeSlotForCorporate')    
  ,  ScreeningReminderNotification = (select value from TblGlobalConfiguration where name='ScreeningReminderNotification')    
  ,  EnableDynamicSlot = (select value from TblGlobalConfiguration where name='EnableDynamicSlot')      
  ,  IsHipaaEnabled = (select value from TblGlobalConfiguration where name='IsHipaaEnabled')    
  ,  LunchStartTime=(select value from TblGlobalConfiguration where name='LunchStartTime')     
  ,  SendEmptyQueueEvaluationReminder=(select value from TblGlobalConfiguration where name='SendEmptyQueueEvaluationReminder')     
  ,  EventBookingThreshold=(select value from TblGlobalConfiguration where name='EventBookingThreshold')     
  ,  PackageSelectionInfo=(select value from TblGlobalConfiguration where name='PackageSelectionInfo')     
  ,  EnableSmsNotification=(select value from TblGlobalConfiguration where name='EnableSmsNotification')      
  ,  EnableSmsNotification=(select value from TblGlobalConfiguration where name='EnableFaxNotification')  
 END           
END          
/* SET NOCOUNT ON */           
RETURN 





