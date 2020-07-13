USE [$(dbName)]
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


---------------------------------------------------------------------------------------------
--Host Address
---------------------------------------------------------------------------------------
Select @StateID = StateID from TblState where [Name]='Texas'
select @CityID = CityID from TblCity where [Name]='Austin' and StateID= @StateID
select @ZipID = ZipID from TblZip where ZipCode='78705' and CityID = @CityID

SET IDENTITY_INSERT [TblAddress] ON
INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],
	[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],
	[UseLatLogForMapping])
VALUES
	(6,'A-90','',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,3,1,0)

SET IDENTITY_INSERT [TblAddress] OFF
----------------------------------------------------------------------------------------
--Host
-----------------------------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[TblProspects] ON

INSERT INTO [TblProspects] 
([ProspectID],[ProspectListID],[ProspectStage],[DateCreated],[DateModified],[PropectsState],[OrgRoleUserId],[IsHost],
	[Status],[ProspectTypeID],[EMailID],[PhoneOffice],[PhoneCell],[PhoneOther],[WebSite],[OrganizationName],[Notes],
	[AddressID],[AddressIDMailling],[ActualMembersHIP],[ActualAttendance],[WillPromote],[MAPUrl],[OtherEmail],
	[MethodObtainedID],[County],[DateHostConverted],[FUDate],[IsActive],[ReasonWillPromote],[TaxIdNumber],[CompanyID],
	[Department],[Ext],[Small],[Industry],[WebsiteJobOpenings],[YearlyRevRange],[EmployeeRange],[GroupDescription])
VALUES
	(1,NULL,NULL,GETDATE(),GETDATE(),NULL,3,1,'0',2,'','2222222222','','','',
	'ABC Host',NULL,6,NULL,22,0,1,NULL,NULL,0,NULL,NULL,GETDATE(),1,'NULL',NULL,NULL,NULL,NULL,NULL,
	NULL,NULL,NULL,NULL,NULL)

SET IDENTITY_INSERT [dbo].[TblProspects] OFF

-----------------------------------------------------------------------------------------

SET IDENTITY_INSERT [dbo].[TblProspectDetails] ON

INSERT [dbo].[TblProspectDetails] 
	([ProspectDetailsID],[ProspectID],[FacilitiesFee],[PaymentMethod],[DepositsRequire],[DepositsAmount],[ViableHostSite],
	[HostedInPast],[HostedInPastWith],[WillHost],[DateCreated],[DateModified],[IsActive],[ReasonViableHostSite],
	[ReasonHostedInPast],[ReasonHostedInPastWith],[ReasonWillHost])
VALUES(1,1,'','',0,0.00,2,2,'',2,GETDATE(),GETDATE(),1,' ',' ','NULL',' ')

SET IDENTITY_INSERT [dbo].[TblProspectDetails] OFF

-----------------------------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[TblPackage] ON

INSERT INTO [TblPackage] 
	([PackageID],[PackageName],[Description],[DateCreated],[DateModified],[IsActive],Price,[PackageTypeID],[RelativeOrder],[DescriptiononPublicWebsite],
	[IsSelectedByDefaultForEvent],CreatedByOrgRoleUserId)
VALUES(1,'Platinum package','Description added for the package','Apr 29 2011 11:42:38:577PM','Apr 30 2011  1:07:03:287AM',1,179.00,113,1,1,1,1)

INSERT INTO [TblPackage] 
	([PackageID],[PackageName],[Description],[DateCreated],[DateModified],[IsActive],Price,[PackageTypeID],[RelativeOrder],[DescriptiononPublicWebsite],
	[IsSelectedByDefaultForEvent],CreatedByOrgRoleUserId)
VALUES(2,'Gold Package','Description added for the same','Apr 29 2011 11:44:31:020PM','Apr 30 2011  1:10:20:457AM',1,149.00,113,2,1,1,1)

INSERT INTO [TblPackage] 
	([PackageID],[PackageName],[Description],[DateCreated],[DateModified],[IsActive],Price,[PackageTypeID],[RelativeOrder],[DescriptiononPublicWebsite],
	[IsSelectedByDefaultForEvent],CreatedByOrgRoleUserId)
VALUES(3,'Silver Package','Description added','Apr 29 2011 11:49:12:853PM','Apr 30 2011  1:12:33:020AM',1,129.00,113,3,1,1,1)

SET IDENTITY_INSERT [dbo].[TblPackage] OFF
-------------------------------------------------------------------------------------

INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,10,'Apr 30 2011  1:07:03:290AM','Apr 30 2011  1:07:03:290AM',1,49,49)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,6,'Apr 30 2011  1:07:03:293AM','Apr 30 2011  1:07:03:293AM',1,25,25)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,8,'Apr 30 2011  1:07:03:297AM','Apr 30 2011  1:07:03:297AM',1,59,59)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,9,'Apr 30 2011  1:07:03:297AM','Apr 30 2011  1:07:03:297AM',1,19,19)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,2,'Apr 30 2011  1:07:03:300AM','Apr 30 2011  1:07:03:300AM',1,45,45)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,7,'Apr 30 2011  1:07:03:300AM','Apr 30 2011  1:07:03:300AM',1,25,25)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,1,'Apr 30 2011  1:07:03:303AM','Apr 30 2011  1:07:03:303AM',1,59,59)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(1,5,'Apr 30 2011  1:07:03:303AM','Apr 30 2011  1:07:03:303AM',1,45,45)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(2,10,'Apr 30 2011  1:10:20:460AM','Apr 30 2011  1:10:20:460AM',1,49,49)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(2,8,'Apr 30 2011  1:10:20:460AM','Apr 30 2011  1:10:20:460AM',1,59,59)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(2,2,'Apr 30 2011  1:10:20:463AM','Apr 30 2011  1:10:20:463AM',1,45,45)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(2,1,'Apr 30 2011  1:10:20:467AM','Apr 30 2011  1:10:20:467AM',1,59,59)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(2,5,'Apr 30 2011  1:10:20:467AM','Apr 30 2011  1:10:20:467AM',1,45,45)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(3,10,'Apr 30 2011  1:12:33:023AM','Apr 30 2011  1:12:33:023AM',1,49,49)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(3,2,'Apr 30 2011  1:12:33:023AM','Apr 30 2011  1:12:33:023AM',1,45,45)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(3,1,'Apr 30 2011  1:12:33:027AM','Apr 30 2011  1:12:33:027AM',1,59,59)
INSERT INTO [TblPackageTest] ([PackageID],[TestID],[DateCreated],[DateModified],[IsActive],Price,RefundPrice)VALUES(3,5,'Apr 30 2011  1:12:33:030AM','Apr 30 2011  1:12:33:030AM',1,45,45)


--------------------------------------------------------------------------------------
--Package and test availability to roles
-----------------------------------------------------------------------------------

INSERT INTO [TblTestAvailabilityToRoles]
SELECT TestId, RoleId FROM tbltest, [TblRole]
where RoleID in(10,8,9,1,3) 
and tbltest.TestID NOT IN(select TestID from [TblTestAvailabilityToRoles])

INSERT INTO [TblPackageAvailabilityToRoles] ( [PackageID], [RoleID]) 
SELECT PackageId, RoleId FROM TblPackage, TblRole
where RoleID in(10,8,9,1,3)
and TblPackage.[PackageID] NOT IN (select [PackageID] from [TblPackageAvailabilityToRoles]) 

---------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[TblScheduleTemplate] ON

INSERT [dbo].[TblScheduleTemplate] 
([ScheduleTemplateID],[Name],[Description],[IsGlobal],CreatedByOrgRoleUserId,ModifiedByOrgRoleUserId,
	[DateCreated],[DateModified],[IsActive])
VALUES(1,'Full Day Template','Full Day Schedule Template',1,1,1,GETDATE(),GETDATE(),1)

SET IDENTITY_INSERT [dbo].[TblScheduleTemplate] OFF
--------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[TblScheduleTemplateTime] ON

INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(1,1,'08:00 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(2,1,'08:30 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(3,1,'09:00 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(4,1,'09:30 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(5,1,'10:00 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(6,1,'10:30 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(7,1,'11:00 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(8,1,'11:30 AM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(9,1,'12:00 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(10,1,'12:30 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(11,1,'01:00 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(12,1,'01:30 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(13,1,'02:00 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(14,1,'02:30 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(15,1,'03:00 PM',GETDATE(),GETDATE(),1)
INSERT [dbo].[TblScheduleTemplateTime] ([ScheduleTemplateTimeID],[ScheduleTemplateID],[StartTime],[DateCreated],[DateModified],[IsActive])VALUES(16,1,'03:30 PM',GETDATE(),GETDATE(),1)

SET IDENTITY_INSERT [dbo].[TblScheduleTemplateTime] OFF
-----------------------------------------------------------------------------------------------

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








