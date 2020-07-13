USE [$(dbName)]
Go

begin try

Begin Tran
--------------------------------------------------------------------
Declare @CountryID int
		,@StateID int
		,@CityID bigint
		,@ZipID bigint

select @CountryID = CountryID from TblCountry where [Name]='USA'

select @StateID = TblState.StateID, @CityID = TblCity.CityID, @ZipID = TblZip.ZipID
from TblCity 
inner join TblState on TblCity.StateID = TblState.StateID
inner JOIN TblZip on TblZip.CityID = TblCity.CityID
where TblCity.[Name]='Austin' and TblState.[Name] = 'Texas' and TblZip.ZipCode='78705'

SET IDENTITY_INSERT [TblAddress] ON

INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])
VALUES
	(1,'123 Main Street','Apartment # 3',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,NULL,0,0)

INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])
VALUES
	(2,'123 Main Street','Apartment # 3',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,NULL,0,0)

INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])
VALUES
	(3,'123 Main Street','Apartment # 3',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,NULL,0,0)

INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])
VALUES
	(4,'123 Main Street','Apartment # 3',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,NULL,0,0)

INSERT INTO [TblAddress] 
	([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])
VALUES
	(5,'123 Main Street','Apartment # 3',@CityID,@StateID,@CountryID,@ZipID,1,GETDATE(),GETDATE(),NULL,NULL,NULL,0,0)

SET IDENTITY_INSERT [TblAddress] OFF


--------------------------------------------------------------------------

SET IDENTITY_INSERT [TblOrganization] ON

INSERT INTO [tblOrganization] 
([OrganizationID],[OrganizationTypeID],[Name],[Description],[BusinessAddressId],[BillingAddressId],[PhoneNumber],[FaxNumber],[Email],[LogoImageID],[TeamImageID],[IsActive])
VALUES(1,1,'Falcon Screening - HQ','Conducts Preventive Health Scr',1,1,'123456789','789456123','falcon@email.com',NULL,NULL,1)

INSERT INTO [tblOrganization] 
([OrganizationID],[OrganizationTypeID],[Name],[Description],[BusinessAddressId],[BillingAddressId],[PhoneNumber],[FaxNumber],[Email],[LogoImageID],[TeamImageID],[IsActive])
VALUES(2,2,'Falcon Screening','Conducts Preventive screening ',2,2,'123456789','789456123','falcon@email.com',NULL,NULL,1)

INSERT INTO [tblOrganization] 
([OrganizationID],[OrganizationTypeID],[Name],[Description],[BusinessAddressId],[BillingAddressId],[PhoneNumber],[FaxNumber],[Email],[LogoImageID],[TeamImageID],[IsActive])
VALUES(3,3,'Falcon Inhouse Call Center','Gives Call Center Services    ',3,3,'456321444','888444555','FalconVoice@email.com',NULL,NULL,1)

INSERT INTO [tblOrganization] 
([OrganizationID],[OrganizationTypeID],[Name],[Description],[BusinessAddressId],[BillingAddressId],[PhoneNumber],[FaxNumber],[Email],[LogoImageID],[TeamImageID],[IsActive])
VALUES(4,4,'Falcon Hospital','Gives 24 Hour Patiend Support ',4,4,'258963147','963852741','FalconMed@email.com',NULL,NULL,1)
INSERT INTO [tblOrganization] 
([OrganizationID],[OrganizationTypeID],[Name],[Description],[BusinessAddressId],[BillingAddressId],[PhoneNumber],[FaxNumber],[Email],[LogoImageID],[TeamImageID],[IsActive])
VALUES(5,5,'Exxon Mobil','Its a big Cooperation which av',5,5,'852147852','147852147','Exxon@gmail.com',NULL,NULL,1)

SET IDENTITY_INSERT [TblOrganization] OFF

--Create a franchisor user

---------------------------------------------------
SET IDENTITY_INSERT [TblUser] ON

INSERT INTO [TblUser] 
	([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature])
VALUES
	(1,'Taazaa','','Admin',1,'','','5128071904','support@taazaa.com','','~/App/Images/TestUpload/MyPic20081224074601.JPG',NULL,'1945-01-01 00:00:00',NULL,GETDATE(),GETDATE(),NULL,1,1,NULL)

SET IDENTITY_INSERT [TblUser] OFF
-------------------------------------------------

INSERT INTO [TblUserLogin] 
	([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],
		[IsSecurityQuestionVerified],[ResetPwdQueryString], [Salt], [LastPasswordChangeDate])
VALUES
	(1,'admin','daWeMYcAG19MABapOKe4MCVx73i9m8Fh',1,GETDATE(),GETDATE(),0,0,'Dec 26 2010 10:59:19:873PM',NULL,NULL,1,'last name','YPJm49yJN20=',1,NULL, 'Q2OJBF5zWMOn9qXyFBwhp0hHX84KRgXL', GETDATE())

-----------------

SET IDENTITY_INSERT [TblOrganizationRoleUser] ON
--Administrator
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])
VALUES(1,1,1,1,1)

--Manager
INSERT [dbo].[TblOrganizationRoleUser] 
([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])
VALUES(2,1,2,1,2)

--Coordinator
INSERT [dbo].[TblOrganizationRoleUser] 
([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])
VALUES(3,1,7,1,2)

--Call center agent
INSERT [dbo].[TblOrganizationRoleUser] 
([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])
VALUES(4,1,10,1,3)

--Technician
INSERT [dbo].[TblOrganizationRoleUser] 
([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])
VALUES(5,1,8,1,2)

SET IDENTITY_INSERT [TblOrganizationRoleUser] OFF

INSERT INTO TblCallCenterRepProfile 
values (4,1,1)

SET IDENTITY_INSERT [TblOrganizationRoleUser] OFF

Commit Tran

end try
begin catch
	IF @@TRANCOUNT > 0
		ROLLBACK TRAN
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(),
		 @ErrSeverity = ERROR_SEVERITY()	
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
end catch