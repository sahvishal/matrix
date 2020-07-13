USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_SaveGlobalAttributesFranchisor]    Script Date: 02/17/2012 15:52:07 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================      
-- Author:  Nitin Tikkha      
-- Create date: 02-12-2007      
-- Description: To save the detail of the Franchisor GlobalAttributes      
-- Name: usp_getcity      
-- Parameter: Input ()      
--=============================================        
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
 @CutOffHourNumberforOnlineEventSelection varchar(10)
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
