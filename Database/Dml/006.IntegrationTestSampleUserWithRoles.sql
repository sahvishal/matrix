USE  [$(dbName)]
GO

BEGIN try

BEGIN Tran
SET IDENTITY_INSERT [TblAddress] ON
-- Addresses
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(7,'345 Fith Ave.',NULL,2,20,1,5,1,'Apr 28 2011  2:11:45:863AM','Apr 28 2011  2:11:45:863AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(8,'360Fith Ave.',NULL,2,20,1,5,1,'Apr 28 2011  2:13:13:287AM','Apr 28 2011  2:13:13:287AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(9,'77 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  3:56:32:193AM','Apr 28 2011  3:56:32:193AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(10,'90 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  3:57:45:327AM','Apr 28 2011  3:57:45:327AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(11,'90 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  3:58:39:023AM','Apr 28 2011  3:58:39:023AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(12,'90 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  3:59:08:423AM','Apr 28 2011  3:59:08:423AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(13,'90 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  3:59:53:920AM','Apr 28 2011  3:59:53:920AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(14,'895 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  4:01:06:103AM','Apr 28 2011  4:01:06:103AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(15,'895 Milford Dr',NULL,2,20,1,5,1,'Apr 28 2011  4:01:51:360AM','Apr 28 2011  4:01:51:360AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(16,'123 Main St','',7,60,1,74,1,'Apr 29 2011  1:15:36:953AM','Apr 29 2011  1:15:36:953AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(17,'890 Allen St',NULL,7,60,1,74,1,'Apr 29 2011  1:52:21:713AM','Apr 29 2011  1:52:21:713AM',NULL,NULL,NULL,0,0)
INSERT INTO [TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(18,'1190 Allen St',NULL,7,60,1,74,1,'Apr 29 2011  1:53:05:887AM','Apr 29 2011  1:53:05:887AM',NULL,NULL,NULL,0,0)

SET IDENTITY_INSERT [TblAddress] OFF

-- User 
SET IDENTITY_INSERT [TblUser] ON
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(2,'John',NULL,'Doe',7,'453123334','','','john.doe@mail.com','',NULL,NULL,'Apr 28 2011  2:12:00:000AM',NULL,'Apr 28 2011  2:11:45:933AM','Apr 28 2011  2:11:45:947AM',NULL,1,10,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(3,'Jane',NULL,'Fisher',8,'330123456','','','jane.fisher@mail.com','',NULL,NULL,'Apr  3 1950 12:00:00:000AM',NULL,'Apr 28 2011  2:13:13:287AM','Apr 28 2011  2:13:13:287AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(4,'Mary',NULL,'Kay',9,'','','','mary@mail.com','',NULL,NULL,'Jan  1 2011 12:00:00:000AM',NULL,'Apr 28 2011  3:56:32:200AM','Apr 28 2011  3:56:32:207AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(5,'Will',NULL,'Smith',10,'444585858','','','will.smith@mail.com','',NULL,NULL,'Apr 28 2011  3:58:00:000AM',NULL,'Apr 28 2011  3:57:45:327AM','Apr 28 2011  3:57:45:327AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(6,'Jerry',NULL,'Lee',11,'444585858','','','jerry.lee@mail.com','',NULL,NULL,'Apr 28 2011  3:59:00:000AM',NULL,'Apr 28 2011  3:58:39:027AM','Apr 28 2011  3:58:39:027AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(7,'Jonny',NULL,'Cash',12,'444585858','','','jonny.cash@mail.com','',NULL,NULL,'Apr 28 2011  3:59:00:000AM',NULL,'Apr 28 2011  3:59:08:423AM','Apr 28 2011  3:59:08:423AM',NULL,1,10,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(8,'Betty',NULL,'Copper',13,'444585858','','','betty.copper@verylongdomain.com','',NULL,NULL,'Apr 28 2011  4:00:00:000AM',NULL,'Apr 28 2011  3:59:53:923AM','Apr 28 2011  3:59:53:923AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(9,'VeryLongFirstNameForUser','Middle','LastName',14,'444585858','','','long.last@mail.com','',NULL,NULL,'Apr 28 2011  4:01:00:000AM',NULL,'Apr 28 2011  4:01:06:103AM','Apr 28 2011  4:01:06:103AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(10,'Kevin','K','Mac',15,'444585858','','','kevin.mac@mymail.com','',NULL,NULL,'Apr 28 2011  4:02:00:000AM',NULL,'Apr 28 2011  4:01:51:363AM','Apr 28 2011  4:01:51:363AM',NULL,1,2,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(11,'Jerry','','Walker',16,'','','1231231233','jerry.walker@testing.com','',NULL,NULL,'Jan  1 1902 12:00:00:000AM',NULL,'Apr 29 2011  1:15:36:980AM','Apr 29 2011  1:15:36:980AM',NULL,1,9,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(12,'Avi',NULL,'Dorian',17,'','','','avi.dorian@mail.com','',NULL,NULL,'Apr 29 2011  1:52:00:000AM',NULL,'Apr 29 2011  1:52:21:723AM','Apr 29 2011  1:52:21:730AM',NULL,1,8,NULL,NULL,NULL)
INSERT INTO [TblUser] ([UserID],[FirstName],[MiddleName],[LastName],[HomeAddressID],[PhoneOffice],[PhoneCell],[PhoneHome],[EMail1],[EMail2],[Picture],[AddedMethod],[DOB],[SSN],[DateCreated],[DateModified],[TempUserName],[IsActive],[DefaultRoleID],[DigitalSignature],[CreatedByOrgRoleUserId],[ModifiedByOrgRoleUserId])VALUES(13,'Larry',NULL,'King',18,'','','','larry.king@mail.com','',NULL,NULL,'Apr 29 2011  1:53:00:000AM',NULL,'Apr 29 2011  1:53:05:887AM','Apr 29 2011  1:53:05:887AM',NULL,1,8,NULL,NULL,NULL)
SET IDENTITY_INSERT [TblUser] OFF

-- Login
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(2,'john.doe','1nyoslVM5EU=',1,'Apr 28 2011  2:11:45:950AM','Apr 28 2011  2:11:45:950AM',0,0,'Apr 28 2011  2:11:45:950AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(3,'jane.fisher','1nyoslVM5EU=',1,'Apr 28 2011  2:13:13:287AM','Apr 28 2011  2:13:13:287AM',0,0,'Apr 28 2011  2:13:13:287AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(4,'mary.kay','1nyoslVM5EU=',1,'Apr 28 2011  3:56:32:210AM','Apr 28 2011  3:56:32:210AM',0,0,'Apr 28 2011  3:56:32:210AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(5,'will.smith','1nyoslVM5EU=',1,'Apr 28 2011  3:57:45:327AM','Apr 28 2011  3:57:45:327AM',0,0,'Apr 28 2011  3:57:45:327AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(6,'jerry.lee','1nyoslVM5EU=',1,'Apr 28 2011  3:58:39:027AM','Apr 28 2011  3:58:39:027AM',0,0,'Apr 28 2011  3:58:39:027AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(7,'jonny.cash','1nyoslVM5EU=',1,'Apr 28 2011  3:59:08:423AM','Apr 28 2011  3:59:08:423AM',0,0,'Apr 28 2011  3:59:08:423AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(8,'betty.copper','1nyoslVM5EU=',1,'Apr 28 2011  3:59:53:923AM','Apr 28 2011  3:59:53:923AM',0,0,'Apr 28 2011  3:59:53:923AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(9,'long.last','1nyoslVM5EU=',1,'Apr 28 2011  4:01:06:103AM','Apr 28 2011  4:01:06:103AM',0,0,'Apr 28 2011  4:01:06:103AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(10,'kevin.mac','1nyoslVM5EU=',1,'Apr 28 2011  4:01:51:363AM','Apr 28 2011  4:01:51:363AM',0,0,'Apr 28 2011  4:01:51:363AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(11,'jerry.walker','x9m+HqDPZ/izaYrMqL6Sqg==',1,'Apr 29 2011  1:15:36:983AM','Apr 29 2011  1:15:36:983AM',0,0,'Apr 29 2011  1:15:36:983AM',NULL,NULL,0,'question','teUHMRNKS0c=',0,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(12,'avi.dorian','x9m+HqDPZ/izaYrMqL6Sqg==',1,'Apr 29 2011  1:52:21:730AM','Apr 29 2011  1:52:21:730AM',0,0,'Apr 29 2011  1:52:21:733AM',NULL,NULL,1,NULL,NULL,1,NULL)
INSERT INTO [TblUserLogin] ([UserLoginID],[UserName],[Password],[IsActive],[DateCreated],[DateModified],[IsLocked],[LoginAttempts],[LastLogged],[UserSecurityQuestionID],[BrowserSessionId],[UserVerified],[HintQuestion],[HintAnswer],[IsSecurityQuestionVerified],[ResetPwdQueryString])VALUES(13,'larry.king','1nyoslVM5EU=',1,'Apr 29 2011  1:53:05:887AM','Apr 29 2011  1:53:05:887AM',0,0,'Apr 29 2011  1:53:05:887AM',NULL,NULL,1,NULL,NULL,1,NULL)


-- assign roles to all users created above:
SET IDENTITY_INSERT [TblOrganizationRoleUser] ON
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(6,2,10,1,3)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(7,2,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(8,3,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(9,3,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(10,4,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(11,4,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(12,5,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(13,5,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(14,6,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(15,6,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(16,7,10,1,3)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(17,7,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(18,8,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(19,8,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(20,9,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(21,9,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(22,10,2,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(23,10,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(24,11,9,1,1)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(25,12,8,1,2)
INSERT INTO [TblOrganizationRoleUser] ([OrganizationRoleUserID],[UserID],[RoleID],[IsActive],[OrganizationId])VALUES(26,13,8,1,2)

SET IDENTITY_INSERT [TblOrganizationRoleUser] OFF

SET QUOTED_IDENTIFIER OFF


INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(7,7,NULL,1,'71',170,'Male','Asian',NULL,'Apr 30 2011 12:26:07:560AM','Apr 30 2011 12:44:54:783AM',NULL,0,0,0,'',NULL,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(8,8,NULL,1,'55',170,'Male','Hispanic',NULL,'Apr 30 2011  5:37:34:457AM','Apr 30 2011  5:38:33:923AM',NULL,0,0,0,'',NULL,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(11,9,NULL,1,'69',170,'Male','NativeAmerican',NULL,'Apr 30 2011  5:47:27:817AM','May  2 2011 11:37:59:207AM',NULL,0,0,0,'Flyer',10,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(13,10,NULL,1,'72',170,'Male','Asian',NULL,'Apr 30 2011  5:58:39:227AM','Apr 30 2011  6:10:06:797AM',NULL,0,0,0,'ashu',10,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(15,11,NULL,1,'72',170,'Male','NativeAmerican',NULL,'Apr 30 2011  6:17:50:163AM','Apr 30 2011  6:19:16:040AM',NULL,0,0,0,'Flyer',10,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(17,12,NULL,1,'71',170,'Male','NativeAmerican',NULL,'Apr 30 2011  6:42:21:273AM','Apr 30 2011  6:42:21:273AM',NULL,0,0,0,'Television',10,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(19,13,NULL,1,'72',170,'Male','NativeAmerican',NULL,'Apr 30 2011  7:17:09:537AM','Apr 30 2011  7:20:31:697AM',NULL,0,0,0,'',NULL,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(21,14,NULL,1,'71',170,'Male','NativeAmerican',NULL,'Apr 30 2011  7:30:08:537AM','Apr 30 2011  7:31:26:677AM',NULL,0,0,0,'Television',10,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(23,15,NULL,1,'71',170,'Male','AfricanAmerican',NULL,'May  2 2011 10:22:08:840AM','May  2 2011 10:28:12:650AM',NULL,0,0,0,'',NULL,NULL,0)

INSERT INTO [TblCustomerProfile] 
	([CustomerID],[BillingAddressID],[ContactMethod],[IsActive],[Height],[Weight],[Gender],[Race],[Age],[DateCreated],[DateModified],[CollectionMode],[IsMailingList],[IsDirectMail],[IsSpecialOffer],[TrackingMarketingID],[AddedByRoleID],[SignInSource],[AdvocateID])
VALUES(24,16,NULL,1,'72',170,'Male','NativeAmerican',NULL,'May  2 2011 10:26:52:247AM','May  2 2011 10:48:18:000AM',NULL,0,0,0,'Television',10,NULL,0)

SET QUOTED_IDENTIFIER ON

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