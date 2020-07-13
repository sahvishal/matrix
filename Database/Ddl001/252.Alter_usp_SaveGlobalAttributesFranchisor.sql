    
-- =============================================          
-- Author:          
-- Create date: 02-12-2007          
-- Description: To save the detail of the Franchisor GlobalAttributes          
-- Name:      
-- Parameter: Input ()          
--=============================================   
USE [$(dbName)]
GO
         
ALTER PROCEDURE [dbo].[usp_SaveGlobalAttributesFranchisor]          
 (@daystochangepassword varchar(1000),@numberofpictures varchar(1000),@appointmentslot varchar(1000),          
 @globalcutoffdate varchar(100),@mvaccessips varchar(1000),        
 @returnvalue bigint output,@scheduletemplateid int,        
 @ShowOrderCatalog varchar(100),        
 @MVPermittedKey varchar(100),        
 @SystemVersion varchar(100),        
 @Eventdistance bigint,        
 @From varchar(255),        
 @FromName varchar(255),        
 @AdministratorEmail varchar(255),        
 @HealthyesContactEmail varchar(255),        
 @GoogleCalendarUsername varchar(255),        
 @GoogleCalendarPassword varchar(255),        
 @CouponPrefix varchar(100),    
 @CCRepDashBoardRefereshTime int,    
 @DisplayBarOnQA varchar(100),    
 @MaxCommissionDollar decimal(18,2),    
 @MaxCommissionPercent decimal(18,2),    
 @MaxCommissionDollarSalesRep decimal(18,2),    
 @MaxCommissionPercentSalesRep decimal(18,2),    
 @HealthYesCompetitor VARCHAR(1000),    
 @CancellationFee varchar(10),    
 @EventStartTime varchar(10),    
 @EventEndTime varchar(10),    
 @MinimumPurchaseAmount varchar(10),    
 @IncomingPhoneLineRequired varchar(10),    
 @EnableAlaCarte varchar(10),    
 @AreaCode varchar(10),    
 @EnableBarCode varchar(10),    
 @UpsellPackage varchar(10),    
 @UpsellCD varchar(10),    
 @UpsellAlaCarte varchar(10),    
 @MaxNoOfEventToShowOnline varchar(10),    
 @MaxNoOfAppointmentSlotsToShowOnline varchar(10),    
 @EventListPageSizeOnline varchar(10),    
 @PaperSize varchar(20),    
 @DisplayPremiumVersiononPortal varchar(10),    
 @EnableResultDeliveryNotification varchar(10),    
 @EnableNewsletterPrompt varchar(10),    
 @SourceCodeLabel varchar(20),    
 @CutOffHourNumberforOnlineEventSelection varchar(10),    
 @DisplayRescheduleAppointmentPortal varchar(10),    
 @ShowBasicBiometric varchar(10),    
 @EnableQuickOnsiteRegistration varchar(10),    
 @PayLaterOnlineRegistration varchar(10),    
 @RestrictAvailableTimeSlotForCorporate varchar(10),     
 @ScreeningReminderNotification varchar(10),    
 @EnableDynamicSlot varchar(10),    
 @IsHipaaEnabled varchar(10),    
 @LunchStartTime varchar(10),    
 @SendEmptyQueueEvaluationReminder varchar(10),    
 @EventBookingThreshold varchar(10),    
 @PackageSelectionInfo varchar(10) ,  
 @EnableSmsNotification varchar(10),
 @EnablePhysicianPartnerCustomerResultFaxNotification varchar(10),
 @EnableAWVCustomerResultFaxNotification varchar(10),
 @AskPreQualificationQuestion varchar(10)
  )          
AS    
SET NOCOUNT ON;          
 SET @returnvalue=0        
      
          
 BEGIN TRAN           
  BEGIN      
 Update TblGlobalConfiguration set value=@globalcutoffdate where name='GlobalCutOffDate'         
    Update TblGlobalConfiguration set value=@ShowOrderCatalog where name='ShowOrderCatalog'     
    Update TblGlobalConfiguration set value=@MVPermittedKey where name='MVPermittedKey'      
    Update TblGlobalConfiguration set value=@SystemVersion where name='SystemVersion'      
    Update TblGlobalConfiguration set value=@Eventdistance where name='Eventdistance'     
    Update TblGlobalConfiguration set value=@AdministratorEmail where name='AdministratorEmail'      
    --Update TblGlobalConfiguration set value=@HealthyesContactEmail where name='HealthyesContactEmail'       
    Update TblGlobalConfiguration set value=@CouponPrefix where name='CouponPrefix'     
    Update TblGlobalConfiguration set value=@scheduletemplateid where name='DefaultScheduleTemplate'        
    Update TblGlobalConfiguration set value=@MaxCommissionDollarSalesRep where name='MaxDollarCommissionSalesRep'    
    Update TblGlobalConfiguration set value=@MaxCommissionPercent where name='MaxPercentCommission'    
    Update TblGlobalConfiguration set value=@MaxCommissionDollar where name='MaxDollarCommission'    
    Update TblGlobalConfiguration set value=@MaxCommissionPercentSalesRep where name='MaxPercentCommissionSalesRep'    
    Update TblGlobalConfiguration set value=@DisplayBarOnQA where name='DisplayBarOnQA'    
    Update TblGlobalConfiguration set value=@HealthYesCompetitor where name='Competitor'    
    Update TblGlobalConfiguration set Value=@CancellationFee where Name='CancellationFee'    
        
    Update TblGlobalConfiguration set Value=@EventStartTime where Name='EventStartTime'    
    Update TblGlobalConfiguration set Value=@EventEndTime where Name='EventEndTime'    
    Update TblGlobalConfiguration set Value=@MinimumPurchaseAmount where Name='MinimumPurchaseAmount'    
    Update TblGlobalConfiguration set Value=@IncomingPhoneLineRequired where Name='IncomingPhoneLineRequired'    
    Update TblGlobalConfiguration set Value=@EnableAlaCarte where Name='EnableAlaCarte'    
    Update TblGlobalConfiguration set Value=@AreaCode where Name='AreaCode'    
    Update TblGlobalConfiguration set Value=@EnableBarCode where Name='EnableBarCode'    
    Update TblGlobalConfiguration set Value=@UpsellPackage where Name='UpsellPackage'    
    Update TblGlobalConfiguration set Value=@UpsellCd where Name='UpsellCd'    
    Update TblGlobalConfiguration set Value=@UpsellAlaCarte where Name='UpsellAlaCarte'    
    Update TblGlobalConfiguration set Value=@MaxNoOfEventToShowOnline where Name='MaxNoOfEventToShowOnline'    
    Update TblGlobalConfiguration set Value=@MaxNoOfAppointmentSlotsToShowOnline where Name='MaxNoOfAppointmentSlotsToShowOnline'    
    Update TblGlobalConfiguration set Value=@EventListPageSizeOnline where Name='EventListPageSizeOnline'    
    Update TblGlobalConfiguration set Value=@PaperSize where Name='PaperSize'    
        
    Update TblGlobalConfiguration set Value=@DisplayPremiumVersiononPortal where Name='DisplayPremiumVersiononPortal'    
    Update TblGlobalConfiguration set Value=@EnableResultDeliveryNotification where Name='EnableResultDeliveryNotification'    
        
    Update TblGlobalConfiguration set Value=@EnableNewsletterPrompt where Name='EnableNewsletterPrompt'    
    Update TblGlobalConfiguration set Value=@SourceCodeLabel where Name='SourceCodeLabel'    
    Update TblGlobalConfiguration set Value=@CutOffHourNumberforOnlineEventSelection where Name='CutOffHourNumberforOnlineEventSelection'    
    Update TblGlobalConfiguration set Value=@DisplayRescheduleAppointmentPortal where Name='DisplayRescheduleAppointmentPortal'    
        
    Update TblGlobalConfiguration set Value = @ShowBasicBiometric where Name = 'ShowBasicBiometric'    
        
    Update TblGlobalConfiguration set Value = @EnableQuickOnsiteRegistration where Name = 'EnableQuickOnsiteRegistration'    
        
    Update TblGlobalConfiguration set Value = @PayLaterOnlineRegistration where Name = 'PayLaterOnlineRegistration'    
        
    Update TblGlobalConfiguration set Value = @RestrictAvailableTimeSlotForCorporate where Name = 'RestrictAvailableTimeSlotForCorporate'    
        
        
    Update TblGlobalConfiguration set Value = @ScreeningReminderNotification where Name = 'ScreeningReminderNotification'    
        
    Update TblGlobalConfiguration set Value = @EnableDynamicSlot where Name = 'EnableDynamicSlot'    
        
    Update TblGlobalConfiguration set Value = @IsHipaaEnabled where Name = 'IsHipaaEnabled'    
        
    Update TblGlobalConfiguration set Value=@LunchStartTime where Name='LunchStartTime'    
        
    Update TblGlobalConfiguration set Value=@SendEmptyQueueEvaluationReminder where Name='SendEmptyQueueEvaluationReminder'    
        
    Update TblGlobalConfiguration set Value=@EventBookingThreshold where Name='EventBookingThreshold'    
        
    Update TblGlobalConfiguration set Value=@PackageSelectionInfo where Name='PackageSelectionInfo'    
        
    Update TblGlobalConfiguration set Value = @EnableSmsNotification where Name = 'EnableSmsNotification'
        
    Update TblGlobalConfiguration set Value = @EnablePhysicianPartnerCustomerResultFaxNotification where Name = 'EnablePhysicianPartnerCustomerResultFaxNotification'    
    Update TblGlobalConfiguration set Value = @EnableAWVCustomerResultFaxNotification where Name = 'EnableAWVCustomerResultFaxNotification'    
    Update TblGlobalConfiguration set Value = @AskPreQualificationQuestion where Name = 'AskPreQualificationQuestion'
        
 --Update TblGlobalConfiguration set value=@daystochangepassword where name='DaysToChangePassword'           
 --Update TblGlobalConfiguration set value=@numberofpictures where name='NumberOfPictures'           
 --Update TblGlobalConfiguration set value=@appointmentslot where name='AppointmentSlot'        
 --Update TblGlobalConfiguration set value=@mvaccessips where name='MVAccessIPs'        
 --Update TblGlobalConfiguration set value=@From where name='From'        
 --Update TblGlobalConfiguration set value=@FromName where name='FromName'        
 --Update TblGlobalConfiguration set value=@GoogleCalendarUsername where name='GoogleCalendarUsername'        
 --Update TblGlobalConfiguration set value=@GoogleCalendarPassword where name='GoogleCalendarPassword'        
 --Update TblGlobalConfiguration set value=@CCRepDashBoardRefereshTime where name='CCRepDashBoardRefereshTime'         
         
       
          
    
    
   IF @@ERROR <>0           
    BEGIN          
      SET @returnvalue=-1          
      ROLLBACK TRAN          
      RETURN          
    END           
  END          
          
COMMIT TRAN          
          
           
 /* SET NOCOUNT ON */           
 RETURN 