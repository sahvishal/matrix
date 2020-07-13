USE [$(dbName)]
GO       
Alter PROCEDURE [dbo].[usp_saveEventWizard]           
(           
 @eventid bigint,          
 @confirmminrequirement bit,          
 @hostid bigint,          
 @schedulemethodid bigint,          
 @confirmedvisually bit,          
 @confirmedcomments varchar(5000),          
 @eventnotes varchar(5000)='',          
 @eventname varchar(500),          
 @eventdate varchar(500),          
 @eventstarttime varchar(500),          
 @eventendtime varchar(500),          
 @timezone varchar(500),          
 @isrescheduled BIT,           
 @scheduleTemplateID bigint = 0,          
 @eventypeid bigint,          
 @costtousehostsite decimal(18,2),          
 @communicationmodeid bigint,           
 @rowstateid tinyint,          
 @userid varchar(100),          
 @shell varchar(1000),           
 @role varchar(500),          
 @franchiseeid BIGINT,          
 @franchiseefranchiseeuserid BIGINT,           
 @eventactivitytemplateid BIGINT = 0,          
 @InvitationCode VARCHAR(255),          
 @TeamArrivalTime varchar(500),          
 @TeamDepartureTime varchar(500),          
 @PaymentTypeID BIGINT,          
 @IsActive BIT,          
 @PaymentDueBy VARCHAR(50),          
 @HSCSalesRepID BIGINT,          
 @DepositDueBy VARCHAR(50),--          
 @DepositAmount decimal(18,2),--          
 @PayByCheck BIT,--          
 @PayByCreditCard BIT,--          
 @EventStatus INT=0,          
 @UpdatedByOrganizationRoleUser BIGINT,          
 @returnvalue bigint OUTPUT,          
 @InstructionForCallCenter varchar(5000)='',          
 @TaxIdNumber varchar(255)=NULL,          
 @CooperateAccountId bigint,          
 @HospitalPartnerId bigint,           
 @AttachHospitalMaterial bit,          
 @EnableAlaCarteOnline bit,          
 @EnableAlaCarteCallCenter bit,          
 @EnableAlaCarteTechnician bit,          
 @IsDynamicScheduling bit,          
 @SlotInterval int,          
 @ServerRooms int,          
 @LunchStartTime datetime,          
 @LunchDuration int,          
 @HafTemplateId bigint,          
 @CaptureInsuranceId bit,          
 @InsuranceIdRequired bit,          
 @EnableProduct bit,          
 @CaptureSsn bit,          
 @IsFemaleOnly bit,          
 @RecommendPackage bit,          
 @AskPreQualificationQuestion bit,          
 @FixedGroupScreeningTime int,          
 @RestrictEvaluation bit,          
 @EventCancellationReasonId bigint,          
 @EnableForCallCenter  bit,          
 @EnableForTechnician bit,          
 @IsPackageTimeOnly bit,          
 @IsManual bit,          
 @UpdatedByAdmin BIGINT null ,        
 @AllowNonMammoPatients BIT=0,  
 @ProductType nvarchar(100)=null  
)          
           
AS          
SET NOCOUNT ON;          
--DECLARE @franchiseeuserid bigint           
          
declare @diff int          
DECLARE @AssignedToUserID BIGINT          
DECLARE @TaskID BIGINT          
Declare @SlotValue int          
          
if(@SlotInterval is null)          
 set @SlotValue = 15          
else          
 set @SlotValue = @SlotInterval          
           
DECLARE @PrevEventActivityTemplateID BIGINT          
SET @PrevEventActivityTemplateID=0          
          
DECLARE @PrevEventActivitySalesRepID BIGINT          
SET @PrevEventActivitySalesRepID=0          
          
Declare @SlotStartTime datetime, @SlotEndTime datetime, @SlotStatus bigint, @ScreeningRooms int          
/* ******************************************************************************** */          
          
SET @returnvalue=0          
          
BEGIN TRAN          
 declare @paymentdueTaskId bigint          
 declare @depositedueTaskID bigint          
 declare @taskstatusid int          
 declare @CreatedByOrgRoleUserId bigint          
          
 select @CreatedByOrgRoleUserId=OrganizationRoleUserId from TblOrganizationRoleUser where UserId=@userid and RoleId=@role and OrganizationId=@shell          
           
 select @taskstatusid=taskstatusid from TblTaskStatusTypes where name='In Progress'          
 DECLARE @taskPriorityId INT          
 SELECT @taskPriorityId=[TaskPriorityID] FROM TblTaskPriorityTypes WHERE [Name]='High'          
           
 select  @SlotStatus = LookupId from TblLookup where Alias = 'Free'          
 -- Update TaxIdNumber (Host)          
 if (@hostid > 0 and len(@taxIdNumber) > 0)          
 Update TblProspects set TaxIdNumber=@taxIdNumber where ProspectId=@hostID and IsHost=1          
           
 declare @Lunch_StartTime datetime, @Lunch_EndTime datetime          
          
 if(@rowstateid = 0)          
 BEGIN          
          
  -- Code to attach default template -- to all          
  IF(@eventactivitytemplateid IS NULL OR (len(@eventactivitytemplateid) = 0 AND @eventactivitytemplateid!=0))          
  BEGIN          
    SELECT TOP 1 @eventactivitytemplateid=TEATH .EventActivityTemplateId          
    FROM [TblEventActivityTemplate] TEAT          
    INNER JOIN TblEventActivityTemplateHost TEATH on TEATH.EventActivityTemplateId=TEAT.EventActivityTemplateId          
    -- TODO: Removing this for isGlobal to attached deafult activity template for event(Franchisor - 1 / Franchisee - 0)          
    WHERE --TEAT.[IsGlobal] = 1 AND          
    TEAT.IsActive=1 AND TEATH.IsActive=1          
    And TEATH.HostId = (select ProspectTypeId from TblProspects where IsHost=1 and ProspectId=@HostId)          
    order by TEAT.DateCreated DESC            
  END            
          
  Insert into TblEvents(AssignedToOrgRoleUserId,EventName,EventDate,EventStartTime,EventEndTime,TimeZone,EventTypeID,IsRescheduled,CosttoUseHostSite,CommunicationModeID,          
  DateCreated,DateModified,IsActive, EventNotes, ScheduleMethodID, [EventActivityTemplateID],EventActivityOrgRoleUserId,TeamArrivalTime,TeamDepartureTime,InvitationCode,CreatedByOrgRoleUserId,EventStatus,UpdatedByOrganizationRoleUser,          
  EnableAlaCarteOnline,EnableAlaCarteCallCenter,EnableAlaCarteTechnician, IsDynamicScheduling, LunchStartTime, LunchDuration, HAFTemplateId, CaptureInsuranceId, InsuranceIdRequired, IsFemaleOnly,          
  RecommendPackage, AskPreQualifierQuestion, FixedGroupScreeningTime,EventCancellationReasonId,EnableForCallCenter,EnableForTechnician,IsPackageTimeOnly,IsManual,UpdatedByAdmin,AllowNonMammoPatients)          
          
  Values(@franchiseefranchiseeuserid,@eventname,@eventdate,@eventstarttime,@eventendtime,@timezone,@eventypeid,@isrescheduled,@costtousehostsite, @communicationmodeid,           
  getdate(),getdate(),@IsActive, @eventnotes, @schedulemethodid, @eventactivitytemplateid,@HSCSalesRepID,@TeamArrivalTime,@TeamDepartureTime,@InvitationCode,@CreatedByOrgRoleUserId,@EventStatus,@UpdatedByOrganizationRoleUser,          
  @EnableAlaCarteOnline,@EnableAlaCarteCallCenter,@EnableAlaCarteTechnician, @IsDynamicScheduling, @LunchStartTime, @LunchDuration, @HafTemplateId, @CaptureInsuranceId, @CaptureInsuranceId, @IsFemaleOnly,          
  @RecommendPackage, @AskPreQualificationQuestion, @FixedGroupScreeningTime,@EventCancellationReasonId,@EnableForCallCenter,@EnableForTechnician,@IsPackageTimeOnly,@IsManual,@UpdatedByAdmin,@AllowNonMammoPatients)          
  set @eventid=@@identity  
  set @returnvalue=@eventid          
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
    --------------Product Type Value Insert---------  
  IF(@eventid>0 and @ProductType is not null and @ProductType !='' )  
  BEGIN  
  INSERT INTO TblEventProductType(EventID,ProductTypeId,StartDate,EndDate,DateCreated,IsActive)  
  SELECT @eventid,items,GETDATE(),NULL,GETDATE(),1  
 FROM dbo.Split(@ProductType,',')  
  
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END       
  
  END  
  -------------- End Product Type  
    
  IF(@CooperateAccountId>0)          
  BEGIN          
   INSERT INTO TblEventAccount (EventID,AccountID)          
   VALUES (@eventid,@CooperateAccountId)          
  END          
            
  IF(@HospitalPartnerId>0)          
  BEGIN          
   INSERT INTO TblEventHospitalPartner (EventID,HospitalPartnerID, AttachHospitalMaterial, CaptureSsn, RestrictEvaluation)          
   VALUES (@eventid, @HospitalPartnerId, @AttachHospitalMaterial, @CaptureSsn, @RestrictEvaluation)          
             
   INSERT INTO TblEventHospitalFacility (EventId, HospitalFacilityId)          
   select @eventid, HospitalFacilityId from TblHospitalPartnerHospitalFacility where HospitalPartnerId = @HospitalPartnerId          
  END          
            
  IF(@EnableProduct = 0)          
  Begin          
   Insert Into TblEventProductExclusion(EventId, ProductId)          
   select @eventid, ProductId from TblProduct where IsActive = 1          
  End           
            
  /****************Create Task***********/          
            
  IF(@PaymentDueBy IS NOT NULL)          
  BEGIN             
                
   INSERT INTO dbo.TblTaskDetails (          
    Subject,          
    Notes,         
    StartDate,          
    StartTime,          
    DueDate,          
    DueTime,          
    CreatedByOrgRoleUserId,          
    ModifiedByOrgRoleUserId,          
    AssignedToOrgRoleUserId,              
    TaskPriorityID,          
    TaskStatusID,          
    IsActive,          
    DateCreated,          
    DateModified          
   )           
   VALUES           
   (           
    /* Subject - varchar(1000) */ 'Payment Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PaymentDueBy AS DATETIME), 101),          
    /* Notes - varchar(5000) */ '',          
    /* StartDate - datetime */ GETDATE(),          
    /* StartTime - datetime */ NULL,          
    /* DueDate - datetime */ @PaymentDueBy,          
    /* DueTime - datetime */ NULL,          
    /* CreatedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
    /* ModifiedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
    /* AssignedToOrgRoleUserId - bigint */@franchiseefranchiseeuserid,              
    /* TaskPriorityID - bigint */ @taskPriorityId,          
    /* TaskStatusID - bigint */ @taskstatusid,          
    /* IsActive - bit */ 1,          
    /* DateCreated - datetime */ GETDATE(),          
    /* DateModified - datetime */ GETDATE()           
   )           
   SET @TaskID=@@IDENTITY          
             
   INSERT INTO dbo.TblEventTaskDetails (          
    EventID,          
    TaskID          
              
   ) VALUES           
   (           
    /* EventID - bigint */ @eventid,          
    /* TaskID - bigint */ @TaskID          
              
   )           
  END          
            
  IF(@DepositDueBy IS NOT NULL)          
  BEGIN             
             
   INSERT INTO dbo.TblTaskDetails (          
    Subject,          
    Notes,          
    StartDate,          
    StartTime,          
    DueDate,          
    DueTime,          
    CreatedByOrgRoleUserId,          
    ModifiedByOrgRoleUserId,          
    AssignedToOrgRoleUserId,          
    TaskPriorityID,          
    TaskStatusID,          
    IsActive,          
    DateCreated,          
    DateModified          
   )           
   VALUES           
   (           
    /* Subject - varchar(1000) */ 'Deposit Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@DepositDueBy AS DATETIME), 101),          
    /* Notes - varchar(5000) */ '',          
    /* StartDate - datetime */ GETDATE(),          
    /* StartTime - datetime */ NULL,          
    /* DueDate - datetime */ @DepositDueBy,          
    /* DueTime - datetime */ NULL,          
    /* CreatedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
    /* ModifiedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
    /* AssignedToOrgRoleUserId - bigint */@franchiseefranchiseeuserid,           
    /* TaskPriorityID - bigint */ @taskPriorityId,          
    /* TaskStatusID - bigint */ @taskstatusid,          
    /* IsActive - bit */ 1,          
    /* DateCreated - datetime */ GETDATE(),          
    /* DateModified - datetime */ GETDATE()           
   )           
   SET @TaskID=@@IDENTITY          
             
   INSERT INTO dbo.TblEventTaskDetails (          
    EventID,          
    TaskID          
              
   ) VALUES           
   (           
    /* EventID - bigint */ @eventid,          
    /* TaskID - bigint */ @TaskID          
              
   )           
  END          
  /**************************************/            
            
  INSERT INTO TblHostEventDetails          
           ([HostID]          
           ,[EventID]          
   ,bConfirmMinRequirements          
   ,bConfirmedVisually          
   ,ConfirmedVisuallyComments          
           ,[DateCreated]          
           ,[DateModified]          
           ,DepositAmount          
           ,PayByCheck          
           ,PayByCreditCard          
           ,PaymentDueDate          
           ,DepositDueDate          
           ,InstructionForCallCenter          
           )          
  VALUES          
           (@hostid          
           ,@eventid          
   ,@confirmminrequirement          
   ,@confirmedvisually          
   ,@confirmedcomments          
           ,getdate()          
           ,getdate()          
           ,@DepositAmount          
           ,@PayByCheck          
           ,@PayByCreditCard          
           ,@PaymentDueBy          
           ,@DepositDueBy          
           ,@InstructionForCallCenter          
           )          
          
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
                  
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END           
  IF (@scheduleTemplateID > 0 and @IsDynamicScheduling = 0)          
  BEGIN          
   INSERT INTO [TblEventScheduleTemplate]          
      ([EventID] ,[ScheduleTemplateID] ,[DateCreated] ,[DateModified] ,[IsActive])          
   VALUES          
      (@eventid ,@scheduleTemplateID ,getdate() ,getdate() ,1)          
                
   IF @@ERROR <>0           
   BEGIN          
    SET @returnvalue=-1          
    ROLLBACK TRAN          
    RETURN          
   END          
          
   Insert Into TblEventSchedulingSlot (EventID, StartTime, EndTime, Reason, DateCreated, DateModified,[Status])          
   Select @eventid           
   ,dateadd(mi, 0, Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime))              
   ,dateadd(mi, @SlotValue, Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime))          
  ,'' ,getdate() ,getdate() ,@SlotStatus          
   from TblScheduleTemplateTime          
   where ScheduleTemplateID = @scheduleTemplateID and IsActive = 1          
             
   IF @@ERROR <>0           
   BEGIN          
    SET @returnvalue=-1          
    ROLLBACK TRAN          
    RETURN          
   END          
  END           
            
  ------ Adding code to add template          
  IF((@eventactivitytemplateid IS NOT NULL) AND (@HSCSalesRepID IS NOT NULL))          
   BEGIN             
    EXECUTE usp_saveEventActivityDetails @eventid,@eventactivitytemplateid,@HSCSalesRepID,@userid,@shell,@role          
             
   END          
  ------------          
 END          
 ELSE IF (@rowstateid = 1)          
 BEGIN          
           
  Declare @OldSlotInterval int, @OldServerRooms int, @OldEventStartTime datetime, @OldEventEndTime datetime, @OldLunchStartTime datetime, @OldLunchDuration int          
            
  select @OldSlotInterval = IsNull(SlotInterval,0), @OldServerRooms = IsNull(ServerRooms,0), @OldEventStartTime = [EventStartTime], @OldEventEndTime = [EventEndTime]          
  ,@OldLunchStartTime = LunchStartTime, @OldLunchDuration = LunchDuration          
  from TblEvents where EventId  = @eventid          
              
  set @paymentdueTaskID=0          
  set @depositedueTaskID=0          
  SELECT @PrevEventActivityTemplateID=ISNULL(EventActivityTemplateID,0) , @PrevEventActivitySalesRepID = ISNULL(EventActivityOrgRoleUserId,0) FROM TblEvents WHERE EventID=@eventid          
            
  DECLARE @PrevPaymentDueDate VARCHAR(30)          
    ,@PrevDepositDueDate VARCHAR(30)          
  SELECT @PrevPaymentDueDate=ISNULL(CAST(PaymentDueDate AS VARCHAR(30)),'')          
    ,@PrevDepositDueDate=ISNULL(CAST(DepositDueDate AS VARCHAR(30)),'')          
  FROM [TblHostEventDetails] THED WHERE THED.EventID=@eventid          
            
  UPDATE [TblEvents]          
     SET [EventName] = @eventname          
     ,[EventDate] = @eventdate          
     ,[EventStartTime] = @eventstarttime          
     ,[EventEndTime] = @eventendtime          
     ,[TimeZone] = @timezone          
     ,[EventTypeID] = @eventypeid          
     ,[IsRescheduled] = @isrescheduled          
     ,[CosttoUseHostSite] = @costtousehostsite          
     ,CommunicationModeID =@communicationmodeid               
     ,EventNotes = @eventnotes          
     ,ScheduleMethodID = @schedulemethodid          
     ,[EventActivityTemplateID] = @eventactivitytemplateid--(CASE WHEN ISNULL([EventActivityTemplateID], 0) > 0 THEN [EventActivityTemplateID] ELSE @eventactivitytemplateid END)          
     ,[DateModified] = getdate()          
     ,TeamArrivalTime=@TeamArrivalTime          
     ,TeamDepartureTime=@TeamDepartureTime          
     ,InvitationCode=@InvitationCode          
     ,EventActivityOrgRoleUserId = @HSCSalesRepID          
     ,IsActive=@IsActive          
     ,EventStatus=@EventStatus               
     ,AssignedToOrgRoleUserId=@franchiseefranchiseeuserid          
     ,UpdatedByOrganizationRoleUser=@UpdatedByOrganizationRoleUser           
     ,EnableAlaCarteOnline=@EnableAlaCarteOnline          
     ,EnableAlaCarteCallCenter=@EnableAlaCarteCallCenter          
     ,EnableAlaCarteTechnician=@EnableAlaCarteTechnician          
     ,IsDynamicScheduling = @IsDynamicScheduling          
     ,SlotInterval = @SlotInterval          
     ,ServerRooms = @ServerRooms          
     ,LunchStartTime = @LunchStartTime          
     ,LunchDuration = @LunchDuration          
     ,HAFTemplateId = @HafTemplateId          
     ,CaptureInsuranceId = @CaptureInsuranceId          
     ,InsuranceIdRequired = @InsuranceIdRequired          
     ,IsFemaleOnly = @IsFemaleOnly          
     ,RecommendPackage = @RecommendPackage          
     ,AskPreQualifierQuestion = @AskPreQualificationQuestion          
     ,FixedGroupScreeningTime = @FixedGroupScreeningTime          
     ,EventCancellationReasonId = @EventCancellationReasonId          
     ,EnableForCallCenter = @EnableForCallCenter          
     ,EnableForTechnician = @EnableForTechnician          
     ,IsPackageTimeOnly = @IsPackageTimeOnly          
     ,IsManual = @IsManual          
     ,UpdatedByAdmin = @UpdatedByAdmin ,        
  AllowNonMammoPatients=@AllowNonMammoPatients         
          
   WHERE eventid = @eventid          
   IF @@ERROR <>0           
    BEGIN          
     SET @returnvalue=-1          
     ROLLBACK TRAN          
     RETURN          
    END          
  --------------Product Type Value Insert---------  
  IF(@ProductType ='' or @ProductType is null)
  BEGIN
  Update  TblEventProductType  set IsActive=0 ,EndDate=GETDATE() WHERE EventID=@eventid and EndDate is null
  END
  IF(@eventid>0 and @ProductType is not null  and @ProductType !='')  
  BEGIN  
  Update  TblEventProductType  set IsActive=0 ,EndDate=GETDATE() WHERE EventID=@eventid and EndDate is null And ProductTypeId Not in (
  SELECT items FROM dbo.Split(@ProductType,',')
  )
  INSERT INTO TblEventProductType(EventID,ProductTypeId,StartDate,EndDate,DateCreated,IsActive)  
  SELECT @eventid,items,GETDATE(),NULL,GETDATE(),1  
 FROM dbo.Split(@ProductType,',')  
 where items NOT IN (
	Select ProductTypeId from  TblEventProductType where EventID=@eventid and  EndDate is null
	)
  
 IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
  
  end  
  -------------- End Product Type  
              
  Update TblEventSchedulingSlot          
  set StartTime = Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime)          
   ,EndTime = Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,EndTime, 108) as DateTime)          
  where EventId=@eventid          
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
            
  Update TblEventAppointment          
  set StartTime = Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime)          
   ,EndTime = Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,EndTime, 108) as DateTime)          
  where EventId=@eventid          
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
              
  IF(@CooperateAccountId>0)          
  BEGIN          
   IF EXISTS(Select AccountID from TblEventAccount where EventID=@eventid)          
   Begin          
    UPDATE TblEventAccount SET AccountID=@CooperateAccountId where EventID=@eventid           
   End          
   Else          
   Begin          
    INSERT INTO TblEventAccount (EventID,AccountID)          
    VALUES (@eventid,@CooperateAccountId)          
   End            
  END          
  ELSE          
  BEGIN          
   DELETE FROM TblEventAccount WHERE EventID=@eventid          
  END          
            
  IF(@HospitalPartnerId>0)          
  BEGIN          
   If Exists(Select HospitalPartnerID from TblEventHospitalPartner WHERE EventID=@eventid)          
   Begin           
    UPDATE TblEventHospitalPartner SET HospitalPartnerID=@HospitalPartnerId,AttachHospitalMaterial=@AttachHospitalMaterial, CaptureSsn = @CaptureSsn, RestrictEvaluation = @RestrictEvaluation          
    WHERE EventID=@eventid          
   End          
   Else          
   Begin          
    INSERT INTO TblEventHospitalPartner (EventID,HospitalPartnerID,AttachHospitalMaterial,CaptureSsn, RestrictEvaluation)          
    VALUES (@eventid, @HospitalPartnerId,@AttachHospitalMaterial,@CaptureSsn, @RestrictEvaluation)          
   End          
             
   DELETE FROM TblEventHospitalFacility where EventId = @eventid          
             
   INSERT INTO TblEventHospitalFacility (EventId, HospitalFacilityId)          
   select @eventid, HospitalFacilityId from TblHospitalPartnerHospitalFacility where HospitalPartnerId = @HospitalPartnerId          
  END          
  ELSE          
  BEGIN          
   DELETE FROM TblEventHospitalFacility where EventId = @eventid          
   DELETE FROM TblEventHospitalPartner WHERE EventID=@eventid          
  END          
            
  IF(@EnableProduct = 0)          
  Begin          
   If Not Exists(select EventId from TblEventProductExclusion where EventId = @eventid)          
   Begin          
    Insert Into TblEventProductExclusion(EventId, ProductId)          
    select @eventid, ProductId from TblProduct where IsActive = 1          
   End          
  End           
  Else          
  Begin          
   delete from TblEventProductExclusion where EventId = @eventid          
  End          
  /*----Payment Due Task------------*/          
  IF(@PaymentDueBy IS NOT NULL)          
  BEGIN          
   SET @TaskID=0          
   SELECT @TaskID=TDD.TaskID FROM dbo.TblTaskDetails TDD          
   INNER JOIN [TblEventTaskDetails] TETD ON TETD.TaskID=TDD.TaskID          
   WHERE TETD.EventID=@eventid AND [Subject]='Payment Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PrevPaymentDueDate AS DATETIME), 101)          
   IF(@TaskID>0)          
   BEGIN          
    UPDATE dbo.TblTaskDetails          
    SET Subject='Payment Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PaymentDueBy AS DATETIME), 101),          
      DueDate=@PaymentDueBy,          
      DateModified=GETDATE(),          
      IsActive=1          
    WHERE TaskID=@TaskID          
    SET @paymentdueTaskID=@TaskID          
   END          
   ELSE          
   BEGIN              
              
    INSERT INTO dbo.TblTaskDetails (          
     Subject,          
     Notes,          
     StartDate,          
     StartTime,          
     DueDate,          
     DueTime,          
     CreatedByOrgRoleUserId,          
     ModifiedByOrgRoleUserId,          
     AssignedToOrgRoleUserId,          
     TaskPriorityID,          
     TaskStatusID,          
     IsActive,          
     DateCreated,          
     DateModified          
    )           
    VALUES           
    (           
     /* Subject - varchar(1000) */ 'Payment Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PaymentDueBy AS DATETIME), 101),          
     /* Notes - varchar(5000) */ '',         /* StartDate - datetime */ GETDATE(),          
     /* StartTime - datetime */ NULL,          
     /* DueDate - datetime */ @PaymentDueBy,          
     /* DueTime - datetime */ NULL,          
     /* CreatedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
     /* ModifiedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
     /* AssignedToOrgRoleUserId - bigint */@franchiseefranchiseeuserid,           
     /* TaskPriorityID - bigint */ @taskPriorityId,          
     /* TaskStatusID - bigint */ @taskstatusid,          
     /* IsActive - bit */ 1,          
     /* DateCreated - datetime */ GETDATE(),          
     /* DateModified - datetime */ GETDATE()           
    )           
    SET @TaskID=@@IDENTITY          
    SET @paymentdueTaskID=@TaskID          
    INSERT INTO dbo.TblEventTaskDetails (          
     EventID,          
     TaskID          
               
    ) VALUES           
    (           
     /* EventID - bigint */ @eventid,          
     /* TaskID - bigint */ @TaskID          
               
    )           
   END          
  END          
  ELSE          
  BEGIN          
   SET @TaskID=0          
   SELECT @TaskID=TDD.TaskID FROM dbo.TblTaskDetails TDD          
   INNER JOIN [TblEventTaskDetails] TETD ON TETD.TaskID=TDD.TaskID          
   WHERE TETD.EventID=@eventid AND [Subject]='Payment Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PrevPaymentDueDate AS DATETIME), 101)          
   IF(@TaskID>0)          
   BEGIN          
    UPDATE dbo.TblTaskDetails          
    SET IsActive=0          
    WHERE TaskID=@TaskID          
              
--    UPDATE dbo.TblEventTaskDetails          
--    SET IsActive=0          
--    WHERE EventID=@eventid AND TaskID=@TaskID          
   END          
  END          
          
  /*----Deposit Due Task------------*/          
  IF(@DepositDueBy IS NOT NULL)          
  BEGIN          
   SET @TaskID=0          
   SELECT @TaskID=TDD.TaskID FROM dbo.TblTaskDetails TDD          
   INNER JOIN [TblEventTaskDetails] TETD ON TETD.TaskID=TDD.TaskID          
   WHERE TETD.EventID=@eventid AND [Subject]='Deposit Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PrevDepositDueDate AS DATETIME), 101)          
   PRINT @TaskID          
   IF(@TaskID>0)          
   BEGIN          
    UPDATE dbo.TblTaskDetails          
    SET Subject='Deposit Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@DepositDueBy AS DATETIME), 101),          
      DueDate=@DepositDueBy,          
      DateModified=GETDATE(),          
      IsActive=1          
    WHERE TaskID=@TaskID          
   SET @depositedueTaskID=@TaskID          
   END          
   ELSE          
   BEGIN          
              
    INSERT INTO dbo.TblTaskDetails (          
     Subject,          
     Notes,          
     StartDate,          
     StartTime,          
     DueDate,          
     DueTime,          
     CreatedByOrgRoleUserId,          
     ModifiedByOrgRoleUserId,          
     AssignedToOrgRoleUserId,          
     TaskPriorityID,          
     TaskStatusID,          
     IsActive,          
     DateCreated,          
     DateModified          
    )           
    VALUES           
    (           
     /* Subject - varchar(1000) */ 'Deposit Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@DepositDueBy AS DATETIME), 101),          
     /* Notes - varchar(5000) */ '',          
     /* StartDate - datetime */ GETDATE(),          
     /* StartTime - datetime */ NULL,          
     /* DueDate - datetime */ @DepositDueBy,          
     /* DueTime - datetime */ NULL,          
     /* CreatedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
     /* ModifiedByOrgRoleUserId - bigint */ @CreatedByOrgRoleUserId,          
     /* AssignedToOrgRoleUserId - bigint */@franchiseefranchiseeuserid,           
     /* TaskPriorityID - bigint */ @taskPriorityId,          
     /* TaskStatusID - bigint */ @taskstatusid,          
     /* IsActive - bit */ 1,          
     /* DateCreated - datetime */ GETDATE(),          
     /* DateModified - datetime */ GETDATE()           
    )           
    SET @TaskID=@@IDENTITY          
    SET @depositedueTaskID=@TaskID          
    INSERT INTO dbo.TblEventTaskDetails (          
     EventID,          
     TaskID          
               
    ) VALUES           
    (           
     /* EventID - bigint */ @eventid,          
     /* TaskID - bigint */ @TaskID          
               
    )           
   END          
  END          
  ELSE          
  BEGIN          
   SET @TaskID=0          
   SELECT @TaskID=TDD.TaskID FROM dbo.TblTaskDetails TDD          
   INNER JOIN [TblEventTaskDetails] TETD ON TETD.TaskID=TDD.TaskID          
   WHERE TETD.EventID=@eventid AND [Subject]='Deposit Due For ' + @eventname + ' by ' + CONVERT(VARCHAR,CAST(@PrevDepositDueDate AS DATETIME), 101)          
   IF(@TaskID>0)          
   BEGIN          
    UPDATE dbo.TblTaskDetails          
    SET IsActive=0          
    WHERE TaskID=@TaskID          
              
--    UPDATE dbo.TblEventTaskDetails          
--    SET IsActive=0          
--    WHERE EventID=@eventid AND TaskID=@TaskID          
   END          
  END          
  IF NOT Exists(Select EventCustomerID from TblEventCustomers where EventID =  @eventid and AppointmentId is not null)          
  BEGIN          
   Declare @dummyScheduletemplateID bigint          
   set @dummyScheduletemplateID = 0          
             
   IF (@scheduleTemplateID > 0 and @IsDynamicScheduling = 0)          
   BEGIN          
              
    Select @dummyScheduletemplateID = isnull(ScheduleTemplateID, 0) from [TblEventScheduleTemplate]          
    where EventID = @eventid          
              
    IF(@dummyScheduletemplateID <> @scheduleTemplateID)          
    BEGIN          
               
     If Exists(select * from TblEventScheduleTemplate where EventId = @eventid)          
     Begin          
      Update [TblEventScheduleTemplate] set [ScheduleTemplateID] = @scheduleTemplateID          
       ,[DateModified] = getdate() where EventID = @eventid          
     End          
     else          
     Begin          
      INSERT INTO [TblEventScheduleTemplate]          
         ([EventID] ,[ScheduleTemplateID] ,[DateCreated] ,[DateModified] ,[IsActive])          
      VALUES          
         (@eventid ,@scheduleTemplateID ,getdate() ,getdate() ,1)          
     End          
          
     Delete TblEventSchedulingSlot where EventID = @eventid          
                    
     Insert Into TblEventSchedulingSlot (EventID, StartTime, EndTime, Reason, DateCreated, DateModified,[Status])          
     Select @eventid           
     ,dateadd(mi, 0, Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime))           
     ,dateadd(mi, @SlotValue, Cast(Convert(varchar,@eventdate, 101) + ' ' + Convert(varchar,StartTime, 108) as DateTime))          
     ,'' ,getdate() ,getdate() ,@SlotStatus          
     from TblScheduleTemplateTime          
     where ScheduleTemplateID = @scheduleTemplateID and IsActive = 1          
          
     IF @@ERROR <>0           
     BEGIN          
      SET @returnvalue=-1          
      ROLLBACK TRAN          
      RETURN          
     END          
    END          
   END          
   ELSE IF (@scheduleTemplateID = 0 and @IsDynamicScheduling = 1)          
   BEGIN          
    Delete TblEventScheduleTemplate where EventId = @eventid          
   END          
  END           
            
 UPDATE TblHostEventDetails set [HostID] = @hostid ,          
   bConfirmMinRequirements = @confirmminrequirement,          
   bConfirmedVisually = @confirmedvisually,          
   ConfirmedVisuallyComments = @confirmedcomments,           
   [DateModified] = getdate(),          
   [DepositAmount]= @DepositAmount,          
   [PayByCheck]= @PayByCheck,          
   [PayByCreditCard]= @PayByCreditCard,          
   [PaymentDueDate]= @PaymentDueBy,          
   [DepositDueDate]=@DepositDueBy,          
   [InstructionForCallCenter]=@InstructionForCallCenter          
   WHERE eventid = @eventid          
          
  IF @@ERROR <>0           
  BEGIN          
   SET @returnvalue=-1          
   ROLLBACK TRAN          
   RETURN          
  END          
            
  /****************** insert Event activity details**************/          
  IF((@eventactivitytemplateid IS NOT NULL) AND (@HSCSalesRepID IS NOT NULL))          
  BEGIN          
     IF(@PrevEventActivityTemplateID=0 OR @PrevEventActivityTemplateID IS NULL OR @PrevEventActivitySalesRepID=0 OR @PrevEventActivitySalesRepID IS NULL)          
      BEGIN          
       EXECUTE usp_saveEventActivityDetails @eventid,@eventactivitytemplateid,@HSCSalesRepID,@userid,@shell,@role          
      END          
     ELSE IF (@PrevEventActivityTemplateID<>@eventactivitytemplateid)          
     BEGIN          
       DELETE FROM [TblEventTaskDetails]WHERE EventID=@eventid and TaskID not in (@paymentdueTaskID,@depositedueTaskID)          
       DELETE FROM TblEventMeetingDetails WHERE EventID=@eventid          
       DELETE FROM TblEventCallDetails WHERE EventID=@eventid          
       DELETE FROM [TblTaskDetails] WHERE [TaskID] IN (SELECT taskid from [TblEventTaskDetails]WHERE EventID=@eventid and TaskID not in (@paymentdueTaskID,@depositedueTaskID))          
DELETE FROM [tblContactMeeting] WHERE [ContactMeetingID] IN (SELECT [MeetingID] from TblEventMeetingDetails WHERE EventID=@eventid)          
       DELETE FROM [tblContactCall] WHERE [ContactCallID] IN (SELECT [CallID] from TblEventCallDetails WHERE EventID=@eventid)          
       EXECUTE usp_saveEventActivityDetails @eventid,@eventactivitytemplateid,@HSCSalesRepID,@userid,@shell,@role          
     END          
     ELSE IF ((@PrevEventActivitySalesRepID<>@HSCSalesRepID) AND (@PrevEventActivityTemplateID=@eventactivitytemplateid))          
     BEGIN          
      --PRINT 'update only ID in existing task created '          
                
      UPDATE [TblTaskDetails] SET [AssignedToOrgRoleUserID]=@HSCSalesRepID          
      FROM [TblTaskDetails]           
      INNER JOIN [TblEventTaskDetails] ON [TblTaskDetails].[TaskID] = [TblEventTaskDetails].[TaskID]   WHERE [EventID]=@eventid           
      AND [TblTaskDetails].[TaskID] not in (@paymentdueTaskID,@depositedueTaskID)          
          
 UPDATE [tblContactCall] SET [AssignedToOrgRoleUserID]=@HSCSalesRepID           
      FROM [tblContactCall]           
      INNER JOIN [TblEventCallDetails] ON [tblContactCall].[ContactCallID] = [TblEventCallDetails].[CallID]   WHERE [EventID]=@eventid           
                
      UPDATE [tblContactMeeting] SET [AssignedToOrgRoleUserID]=@HSCSalesRepID           
      FROM [tblContactMeeting]           
      INNER JOIN TblEventMeetingDetails ON [tblContactMeeting].[ContactMeetingID] = TblEventMeetingDetails.[MeetingID]   WHERE [EventID]=@eventid           
                
     END          
  END          
  ELSE ---           
    BEGIN          
    IF EXISTS (select eventActivityTemplateID from tblevents where eventid=@eventid and isnull(eventActivityTemplateID,0) > 0)          
     BEGIN           
         DELETE FROM [TblEventTaskDetails]WHERE EventID=@eventid AND TaskID not in (@paymentdueTaskID,@depositedueTaskID)          
      DELETE FROM TblEventMeetingDetails WHERE EventID=@eventid          
      DELETE FROM TblEventCallDetails WHERE EventID=@eventid          
      DELETE FROM [TblTaskDetails] WHERE [TaskID] IN (SELECT taskid from [TblEventTaskDetails]WHERE EventID=@eventid AND TaskID not in (@paymentdueTaskID,@depositedueTaskID))          
      DELETE FROM [tblContactMeeting] WHERE [ContactMeetingID] IN (SELECT [MeetingID] from TblEventMeetingDetails WHERE EventID=@eventid)          
      DELETE FROM [tblContactCall] WHERE [ContactCallID] IN (SELECT [CallID] from TblEventCallDetails WHERE EventID=@eventid)          
     END          
    END          
 END          
COMMIT TRAN          
RETUR