USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_saveEventWizard]    Script Date: 08/24/2012 13:55:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Abhinav Goel
-- Create date: 27-12-2007
-- Description:	To insertevent master
-- Name: usp_saveEventWizard
--=============================================
ALTER PROCEDURE [dbo].[usp_saveEventWizard] 
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
	@EnableAlaCarteTechnician bit
)
	
AS
SET NOCOUNT ON;
--DECLARE @franchiseeuserid bigint
 
Declare @slotvalue int
declare @diff int
DECLARE @AssignedToUserID BIGINT
DECLARE @TaskID BIGINT
set @slotvalue = 15
DECLARE @PrevEventActivityTemplateID BIGINT
SET @PrevEventActivityTemplateID=0

DECLARE @PrevEventActivitySalesRepID BIGINT
SET @PrevEventActivitySalesRepID=0


/* ******************************************************************************** */

SET @returnvalue=0

BEGIN TRAN
	declare @paymentdueTaskId bigint
	declare @depositedueTaskID bigint
	declare @taskstatusid int
	declare	@CreatedByOrgRoleUserId bigint

	select @CreatedByOrgRoleUserId=OrganizationRoleUserId from TblOrganizationRoleUser where UserId=@userid and RoleId=@role and OrganizationId=@shell
	
	select @taskstatusid=taskstatusid from TblTaskStatusTypes where name='In Progress'
	DECLARE @taskPriorityId INT
	SELECT @taskPriorityId=[TaskPriorityID] FROM TblTaskPriorityTypes WHERE [Name]='High'
	
	-- Update TaxIdNumber (Host)
	if (@hostid > 0 and len(@taxIdNumber) > 0)
	Update TblProspects set TaxIdNumber=@taxIdNumber where ProspectId=@hostID and IsHost=1

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
		EnableAlaCarteOnline,EnableAlaCarteCallCenter,EnableAlaCarteTechnician)

		Values(@franchiseefranchiseeuserid,@eventname,@eventdate,@eventstarttime,@eventendtime,@timezone,@eventypeid,@isrescheduled,@costtousehostsite, @communicationmodeid, 
		getdate(),getdate(),@IsActive, @eventnotes, @schedulemethodid, @eventactivitytemplateid,@HSCSalesRepID,@TeamArrivalTime,@TeamDepartureTime,@InvitationCode,@CreatedByOrgRoleUserId,@EventStatus,@UpdatedByOrganizationRoleUser,
		@EnableAlaCarteOnline,@EnableAlaCarteCallCenter,@EnableAlaCarteTechnician)
		set @eventid=@@identity
		set @returnvalue=@eventid
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
		IF(@CooperateAccountId>0)
		BEGIN
			INSERT INTO TblEventAccount (EventID,AccountID)
			VALUES (@eventid,@CooperateAccountId)
		END
		
		IF(@HospitalPartnerId>0)
		BEGIN
			INSERT INTO TblEventHospitalPartner (EventID,HospitalPartnerID, AttachHospitalMaterial)
			VALUES (@eventid, @HospitalPartnerId, @AttachHospitalMaterial)
		END
		
		
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
		IF(@scheduleTemplateID > 0)
		BEGIN
			INSERT INTO [TblEventScheduleTemplate]
			   ([EventID]
			   ,[ScheduleTemplateID]
			   ,[DateCreated]
			   ,[DateModified]
			   ,[IsActive])
			VALUES
			   (@eventid
			   ,@scheduleTemplateID
			   ,getdate()
			   ,getdate()
			   ,1)

			IF @@ERROR <>0 
			BEGIN
				SET @returnvalue=-1
				ROLLBACK TRAN
				RETURN
			END
		END
		
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

--		INSERT INTO TblEventPackageDetails (EventID, PackageID ,PackagePrice ,DateCreated ,DateModified)
--		Select @eventid, PackageID, RecommendedPrice, getdate(), getdate() from TblPackage where IsActive = 1
--		and PackageName not like '%Package Osteo%'
        
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END 

		IF (@scheduleTemplateID < 1)
		BEGIN
			Select @scheduleTemplateID = isnull([value],0) from tblGlobalConfiguration
			where [Name] = 'DefaultScheduleTemplate'
		END

		Insert Into TblEventAppointment (EventID, ScheduledByOrgRoleUserId, StartDate, StartTime, EndDate, EndTime, Subject, Reason, DateCreated, DateModified)
		Select @eventid, null, @eventdate, dateadd(mi, 0, StartTime), @eventdate, dateadd(mi, @slotvalue, StartTime), '', '', getdate(), getdate() from TblScheduleTemplateTime
		where ScheduleTemplateID = @scheduleTemplateID and IsActive = 1
		
		------ Adding code to add template
		IF((@eventactivitytemplateid IS NOT NULL) AND (@HSCSalesRepID IS NOT NULL))
			BEGIN
			
				EXECUTE usp_saveEventActivityDetails @eventid,@eventactivitytemplateid,@HSCSalesRepID,@userid,@shell,@role
			
			END
		------------
	END
	ELSE IF (@rowstateid = 1)
	BEGIN
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
		 WHERE eventid = @eventid
			IF @@ERROR <>0 
				BEGIN
					SET @returnvalue=-1
					ROLLBACK TRAN
					RETURN
				END
		Update TblEventAppointment
		set StartDate=@eventdate,EndDate=@eventdate
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
				UPDATE TblEventHospitalPartner SET HospitalPartnerID=@HospitalPartnerId,AttachHospitalMaterial=@AttachHospitalMaterial WHERE EventID=@eventid
			End
			Else
			Begin
				INSERT INTO TblEventHospitalPartner (EventID,HospitalPartnerID,AttachHospitalMaterial)
				VALUES (@eventid, @HospitalPartnerId,@AttachHospitalMaterial)
			End
		END
		ELSE
		BEGIN
			DELETE FROM TblEventHospitalPartner WHERE EventID=@eventid
		END
		
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
				
--				UPDATE dbo.TblEventTaskDetails
--				SET IsActive=0
--				WHERE EventID=@eventid AND TaskID=@TaskID
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
				
--				UPDATE dbo.TblEventTaskDetails
--				SET IsActive=0
--				WHERE EventID=@eventid AND TaskID=@TaskID
			END
		END
		IF(@scheduleTemplateID > 0)
		BEGIN
			IF NOT Exists(Select EventCustomerID from TblEventCustomers where EventID =  @eventid and AppointmentId is not null)
			BEGIN
				Declare @dummyScheduletemplateID bigint
				Select @dummyScheduletemplateID = isnull(ScheduleTemplateID, 0) from [TblEventScheduleTemplate]
				where EventID = @eventid

				
				IF (@scheduleTemplateID < 1)
				BEGIN
					Select @scheduleTemplateID = isnull([value],0) from tblGlobalConfiguration
					where [Name] = 'DefaultScheduleTemplate'
				END


				IF(@dummyScheduletemplateID <> @scheduleTemplateID)
				BEGIN
					Update [TblEventScheduleTemplate] set [ScheduleTemplateID] = @scheduleTemplateID
					   ,[DateModified] = getdate() where EventID = @eventid

					Delete TblEventAppointment where EventID = @eventid

					Insert Into TblEventAppointment (EventID, ScheduledByOrgRoleUserId, StartDate, StartTime, EndDate, EndTime, Subject, Reason, DateCreated, DateModified)
					Select @eventid, null, @eventdate, dateadd(mi, 0, StartTime), @eventdate, dateadd(mi, @slotvalue, StartTime), '', '', getdate(), getdate() from TblScheduleTemplateTime
					where ScheduleTemplateID = @scheduleTemplateID and IsActive = 1

					IF @@ERROR <>0 
					BEGIN
						SET @returnvalue=-1
						ROLLBACK TRAN
						RETURN
					END
			
					
				END
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
RETURN
