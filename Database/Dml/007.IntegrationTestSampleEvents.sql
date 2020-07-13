USE [$(dbName)]
Go

Declare @AddressID int
	,@CityID int
	,@StateID int
	,@ZipID int
	,@CountryID int
	
Begin Try
Begin Tran
	select @CountryID = CountryID from TblCountry where [Name]='USA'

	select @StateID = TblState.StateID, @CityID = TblCity.CityID, @ZipID = TblZip.ZipID
	from TblCity 
	inner join TblState on TblCity.StateID = TblState.StateID
	inner JOIN TblZip on TblZip.CityID = TblCity.CityID
	where TblCity.[Name]='Austin' and TblState.[Name] = 'Texas' and TblZip.ZipCode='78705'
	
--Van

	SET IDENTITY_INSERT [dbo].[TblVanDetails] ON

	INSERT [dbo].[TblVanDetails] 
	([VanID],[RegistrationNumber],[StateID],[VIN],[Name],[Make],[Description],[DateCreated],[DateModified],[IsActive])
	VALUES(1,'123456',@StateID,'12345678','Texas VAN','2010','Test',GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblVanDetails] OFF
	
--Pod

	SET IDENTITY_INSERT [dbo].[TblPodDetails] ON

	INSERT [dbo].[TblPodDetails] 
		([PodID],[OrganizationId],[Name],[Description],[VanID],[PodProcessingCapacity],
		[IsActive],[IsDefault],[CreatedByOrgRoleUserID],[CreatedOn],[UpdatedByOrgRoleUserID],[UpdatedOn])
	VALUES(1,2,'Texas POD1','Texas pod',1,50,1,0,1,GETDATE(),1,GETDATE())

	SET IDENTITY_INSERT [dbo].[TblPodDetails] OFF
	
--Event Role
	SET IDENTITY_INSERT [TblStaffEventRole] ON

	INSERT INTO [TblStaffEventRole] 
		([StaffEventRoleID],[Name],[Description],[IsActive],[CreatedByOrgRoleUserID],[CreatedOn],[UpdatedByOrgRoleUserID],[UpdatedOn])
	VALUES(1,'Welcome Technician','Welcome Technician',1,1,'May  3 2011  3:24:55:623PM',1,'May  3 2011  3:24:55:623PM')

	INSERT INTO [TblStaffEventRole] 
		([StaffEventRoleID],[Name],[Description],[IsActive],[CreatedByOrgRoleUserID],[CreatedOn],[UpdatedByOrgRoleUserID],[UpdatedOn])
	VALUES(2,'Sonosite Machine Operator','Sonosite Machine Operator',1,1,'May  3 2011  3:24:55:623PM',1,'May  3 2011  3:24:55:623PM')

	INSERT INTO [TblStaffEventRole] 
		([StaffEventRoleID],[Name],[Description],[IsActive],[CreatedByOrgRoleUserID],[CreatedOn],[UpdatedByOrgRoleUserID],[UpdatedOn])
	VALUES(3,'Cardiovascular Machine Operator','Cardiovascular Machine Operator',1,1,'May  3 2011  3:24:55:623PM',1,'May  3 2011  3:24:55:623PM')

	INSERT INTO [TblStaffEventRole] 
		([StaffEventRoleID],[Name],[Description],[IsActive],[CreatedByOrgRoleUserID],[CreatedOn],[UpdatedByOrgRoleUserID],[UpdatedOn])
	VALUES(4,'Osteoporosis Machine Operator','Osteoporosis Machine Operator',1,1,'May  3 2011  3:29:48:837PM',1,'May  3 2011  3:29:48:837PM')

	SET IDENTITY_INSERT [TblStaffEventRole] OFF

--Event Role Test

	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(1,2)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(1,5)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(2,1)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(2,10)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(3,6)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(3,7)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(4,8)
	INSERT INTO [TblStaffEventRoleTest] ([StaffEventRoleID],[TestID])VALUES(4,9)
	
--Pod default team

	SET IDENTITY_INSERT [TblPodDefaultTeam] ON

	INSERT INTO [TblPodDefaultTeam] 
		([PodTeamID],[PodID],[DateCreated],[DateModified],[IsActive],[StaffEventRoleID],[OrganizationRoleUserId])
	VALUES(1,1,'May  3 2011  3:59:26:747PM','May  3 2011  3:59:26:747PM',1,1,25)
	
	INSERT INTO [TblPodDefaultTeam] 
		([PodTeamID],[PodID],[DateCreated],[DateModified],[IsActive],[StaffEventRoleID],[OrganizationRoleUserId])
	VALUES(3,1,'May  3 2011  3:59:26:747PM','May  3 2011  3:59:26:747PM',1,2,26)

	SET IDENTITY_INSERT [TblPodDefaultTeam] OFF

Commit Tran

End Try
Begin Catch
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
	@ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
End Catch

GO

Declare @AddressID int
	,@CityID int
	,@StateID int
	,@ZipID int
	,@CountryID int
Begin Try
Begin Tran

select @CountryID = CountryID from TblCountry where [Name]='USA'

select @StateID = TblState.StateID, @CityID = TblCity.CityID, @ZipID = TblZip.ZipID
from TblCity 
inner join TblState on TblCity.StateID = TblState.StateID
inner JOIN TblZip on TblZip.CityID = TblCity.CityID
where TblCity.[Name]='Austin' and TblState.[Name] = 'Texas' and TblZip.ZipCode='78705'

------------------------------------------------------------------------------------------------------------------
--1.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON

	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(1,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)

	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(1,1,1,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(1,1,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment

	SET IDENTITY_INSERT [dbo].[TblEventAppointment] ON

	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(1,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(2,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(11,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(12,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(13,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(14,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(15,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(16,1,NULL,Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 10,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	SET IDENTITY_INSERT [dbo].[TblEventAppointment] OFF
	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(1,1,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package

	SET IDENTITY_INSERT [dbo].[TblEventPackageDetails] ON

	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(1,1,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(2,1,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(3,1,3,129.00,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPackageDetails] OFF
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(1,16,179.00,GETDATE(),GETDATE(),179.00)

	
	
	Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (1,2,3)
	order by TET.EventTestId
	
------------------------------------------------------------------------------------------------------------------
--2.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON	
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(2,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(2,1,2,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(2,2,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment

	SET IDENTITY_INSERT [dbo].[TblEventAppointment] ON

	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(17,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(18,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(19,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(20,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(21,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(22,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(23,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(24,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(25,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(26,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(27,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(28,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(29,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(30,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(31,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([AppointmentID],[EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(32,2,NULL,Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 12,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	SET IDENTITY_INSERT [dbo].[TblEventAppointment] OFF
	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(2,2,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package

	SET IDENTITY_INSERT [dbo].[TblEventPackageDetails] ON

	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(4,2,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(5,2,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventPackageID],[EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(6,2,3,129.00,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPackageDetails] OFF
	
-- Event Test	

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(2,16,179.00,GETDATE(),GETDATE(),179.00)

	
	Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (4,5,6)
	order by TET.EventTestId
	
------------------------------------------------------------------------------------------------------------------
--3.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
		
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(3,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(3,1,3,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(3,3,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(3,NULL,Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 14,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(3,3,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package
	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(3,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(3,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(3,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(3,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=3)
	order by TET.EventTestId
	
------------------------------------------------------------------------------------------------------------------
--4.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON	
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(4,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(4,1,4,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(4,4,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(4,NULL,Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 15,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(4,4,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(4,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(4,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(4,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(4,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=4)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--5.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON	
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(5,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(5,1,5,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(5,5,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(5,NULL,Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 18,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(5,5,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(5,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(5,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(5,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(5,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=5)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--6.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
		
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(6,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(6,1,6,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(6,6,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(6,NULL,Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 60,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(6,6,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(6,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(6,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(6,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(6,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=6)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--7.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(7,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(7,1,7,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(7,7,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(7,NULL,Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 90,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(7,7,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(7,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(7,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(7,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(7,16,179.00,GETDATE(),GETDATE(),179.00)
	
Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=7)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--8.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(8,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(8,1,8,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(8,8,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(8,NULL,Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 130,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(8,8,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(8,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(8,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(8,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(8,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=8)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--9.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(9,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(9,1,9,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(9,9,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(9,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(9,9,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(9,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(9,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(9,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(9,16,179.00,GETDATE(),GETDATE(),179.00)

Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=9)
	order by TET.EventTestId
------------------------------------------------------------------------------------------------------------------
--10.Event
------------------------------------------------------------------------------------------------------------------
--Events

	SET IDENTITY_INSERT [dbo].[TblEvents] ON
	
	INSERT [dbo].[TblEvents] 
		([EventID],[AssignedToOrgRoleUserId],[EventName],[EventDate],[EventStartTime],[EventEndTime],[TimeZone],
		[EventTypeID],[ScheduleMethodID],[IsRescheduled],[CosttoUseHostSite],
		[CommunicationModeID],
		[EventNotes],[DateCreated],[DateModified],[IsActive],
		[Googleuri],[EventActivityTemplateID],[InvitationCode],
		[TeamArrivalTime],[TeamDepartureTime],[CreatedByOrgRoleUserID],
		[EventActivityOrgRoleUserId],[EventStatus],[IsSignoff],[SignOffOrgRoleUserId],
		[SignoffDatetime],[UpdatedByOrganizationRoleUser])
	VALUES(10,3,'ABC Host',Cast(Convert(varchar,GETDATE() + 220,101) as DATETIME),'Jan  1 1900  8:45:00:000AM','Jan  1 1900  4:15:00:000PM','GMT -06:00  U.S. Central Time',
		1,2,0,0,
		5,
		'',GETDATE(),GETDATE(),1,
		NULL,NULL,'',
		'Jan  1 1900  8:00:00:000AM','Jan  1 1900  5:00:00:000PM',3,
		3,1,0,NULL
		,NULL,3)
		
	SET IDENTITY_INSERT [dbo].[TblEvents] OFF
	
--Host event details	

	SET IDENTITY_INSERT [TblHostEventDetails] ON

	INSERT [dbo].[TblHostEventDetails] 
		([HostEventID],[HostID],[EventID],[bConfirmMinRequirements],[bConfirmedVisually],[ConfirmedVisuallyComments],
		[DateCreated],[DateModified],[DepositAmount],[PayByCheck],[PayByCreditCard],[PaymentDueDate],[DepositDueDate],[InstructionForCallCenter],[IsHostRatedbyTechnician])
	VALUES(10,1,10,0,0,NULL,GETDATE(),GETDATE(),0.00,0,0,NULL,NULL,NULL,0)

	SET IDENTITY_INSERT [TblHostEventDetails] OFF
	
-- Event schedule template

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] ON

	INSERT [dbo].[TblEventScheduleTemplate] 
	([EventScheduleTemplateID],[EventID],[ScheduleTemplateID],[DateCreated],[DateModified],[IsActive])
	VALUES(10,10,1,GETDATE(),GETDATE(),1)

	SET IDENTITY_INSERT [dbo].[TblEventScheduleTemplate] OFF
	
--Event appointment
	

	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  8:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  9:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 10:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:00:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:15:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:30:00:000AM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 11:45:00:000AM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900 12:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  1:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  2:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:00:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:15:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')
	INSERT [dbo].[TblEventAppointment] ([EventID],[ScheduledByOrgRoleUserID],[StartDate],[StartTime],[EndDate],[EndTime],[CheckinTime],[CheckoutTime],[Subject],[Reason],[DateCreated],[DateModified])VALUES(10,NULL,Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:30:00:000PM',Cast(Convert(varchar,GETDATE() + 170,101) as DATETIME),'Jan  1 1900  3:45:00:000PM',NULL,NULL,'','','Jan 25 2011 10:34:39:200PM','Jan 25 2011 10:34:39:200PM')

	
--Event Pod

	SET IDENTITY_INSERT [dbo].[TblEventPod] ON

	INSERT INTO [TblEventPod] 
		([EventPodID],[EventID],[PodID],[IsActive],[DateCreated],[DateModified])
	VALUES
		(10,10,1,1,GETDATE(),GETDATE())

	SET IDENTITY_INSERT [dbo].[TblEventPod] OFF
	
--Event package	

	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(10,1,179.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(10,2,149.00,GETDATE(),GETDATE())
	
	INSERT [dbo].[TblEventPackageDetails] 
	([EventID],[PackageID],[PackagePrice],[DateCreated],[DateModified])
	VALUES(10,3,129.00,GETDATE(),GETDATE())
	
	
-- Event Test

	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,1,49.00,GETDATE(),GETDATE(),49.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,2,39.00,GETDATE(),GETDATE(),39.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,5,30.00,GETDATE(),GETDATE(),30.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,6,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,7,29.00,GETDATE(),GETDATE(),29.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,8,59.00,GETDATE(),GETDATE(),59.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,9,24.00,GETDATE(),GETDATE(),24.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,10,45.00,GETDATE(),GETDATE(),45.00)
	INSERT [dbo].[TblEventTest] ([EventID],[TestID],[Price],[DateCreated],[DateModified],RefundPrice)VALUES(10,16,179.00,GETDATE(),GETDATE(),179.00)
	
Insert Into [TblEventPackageTest] ([EventPackageId],[EventTestId],[Price],[RefundPrice],[DateCreated],[DateModified])
	select TEP.EventPackageId,TET.EventTestId,TPT.Price, TPT.RefundPrice,TET.DateCreated, TET.DateModified
	from TblEventPackageDetails TEP
	inner join TblPackageTest TPT on TEP.PackageId = TPT.PackageId
	inner join TblTest TT on TPT.TestId = TT.TestId
	inner join TblEventTest TET on TEP.EventId = TET.EventId and TT.TestId = TET.TestId
	where TEP.EventPackageId in (select EventPackageId from TblEventPackageDetails where EventId=10)
	order by TET.EventTestId

Commit Tran

End Try
Begin Catch
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
	@ErrSeverity = ERROR_SEVERITY()
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
End Catch
