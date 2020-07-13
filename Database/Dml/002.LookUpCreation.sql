USE [$(dbName)]
Go

begin try

Begin Tran

-- Organization Types
delete from [TblOrganizationRoleUser]
delete from [TblRole]
delete from [TblOrganizationType]
delete from [TblUserLogin]
delete from [TblUser]
delete from [TblAddress]

INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(1,'Franchisor','Franchisor')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(2,'Franchisee','Franchisee')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(3,'Call Center','CallCenter')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(4,'Medical Vendor','MedicalVendor')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(5,'Corporate Account','Account')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(6,'Marketing Vendor','MarketingVendor')
INSERT INTO [TblOrganizationType] ([OrganizationTypeID],[Name],[Alias])VALUES(7,'Print Vendor','PrintVendor')

-- Roles
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(1,1,'Administrator','FranchisorAdmin','Feb 11 2007 12:00:00:000AM','Feb 11 2007 12:00:00:000AM','Test','App/Franchisor/Dashboard.aspx',1,'Franchisor')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(2,2,'Manager','FranchiseeAdmin','Jun 11 2007 12:00:00:000AM','Jun 11 2007 12:00:00:000AM','','App/Franchisee/Dashboard.aspx',1,'Franchisee')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(3,3,'Call Center Manager','CallCenterManager','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',NULL,'App/CallCenter/CallCenterManagerDashBoard.aspx',1,'CallCenter')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(4,4,'Medical Vendor Administrator','MedicalVendorAdmin','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',NULL,'App/MedicalVendor/MVDashboard.aspx',1,'MedicalVendor')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(5,4,'Physician','MedicalVendorUser','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',NULL,'App/MedicalVendor/MVUserDashboard.aspx',1,'MedicalVendor')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(6,2,'Operation Manager','OperationManager','Feb 12 2007 12:00:00:000AM','Feb 12 2007 12:00:00:000AM',NULL,'App/CallCenter/CallCenterAdminDasboard.aspx',1,'CallCenter')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(7,2,'Coordinator','SalesRep','Feb 12 2007 12:00:00:000AM','Feb 12 2007 12:00:00:000AM',NULL,'App/Franchisee/SalesRep/Dashboard.aspx',1,'Franchisee')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(8,2,'Technician','Technician','Oct 12 2007 12:00:00:000AM','Oct 12 2007 12:00:00:000AM','Tech','App/Franchisee/Technician/HomePage.aspx',1,'Franchisee')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(9,1,'Customer','Customer','Dec 18 2007 12:00:00:000AM','Dec 18 2007 12:00:00:000AM','Customer','App/Customer/HomePage.aspx',1,'Customer')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(10,3,'Call Center Agent','CallCenterRep','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',NULL,'App/CallCenter/CallCenterRep/CallCenterRepDashBoard.aspx',1,'CallCenter')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(11,2,'Advocate Manager','Advocate Manager','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',NULL,'App/MarketingPartner/AdvocateManager/Dashboard.aspx',1,'Franchisor')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(12,2,'Advocate Sales Manager','AdvocateSalesManager','Mar  6 2009  3:51:42:290AM','Mar  6 2009  3:51:42:290AM','Sales Manager for Franchisee','App/MarketingPartner/AdvocateSalesManager/Dashboard.aspx',1,'Franchisee')
INSERT INTO [TblRole] ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])VALUES(13,6,'Print Vendor Administrator','PrintVendorAdmin','Mar  6 2009  4:24:46:180AM','Mar  6 2009  4:24:46:180AM','Print Vendor','App/PrintVendor/Dashboard.aspx',1,'PrintVendor')
INSERT INTO [TblRole]
           ([RoleID],[OrganizationTypeID],[Name],[Alias],[DateCreated],[DateModified],[Description],[DefaultPage],[IsActive],[ShellType])
     VALUES
           (14,4,'Care Coordinator','HospitalPartnerCoordinator', getdate(),getdate(),'Hospital Partner Coordinator','/Users/Dashboard/HospitalPartnerCoordinator',1,'MedicalVendor')
           
Insert Into TblRole(RoleId, OrganizationTypeId, Name, Alias, DateCreated, DateModified, Description, DefaultPage, IsActive, ShellType)
values (15, 5, 'Account Coordinator', 'CorporateAccountCoordinator', getdate(), getdate(), 'Role for Corporate Account Coordinator', '/Users/Dashboard/CorporateAccountCoordinator', 1, 'CorporateAccountCoordinator')

--[TblLookUpType]
-------------------------------------------------------------------------------------------------------------
Delete from [TblLookup]
Delete from [TblLookUpType]

SET IDENTITY_INSERT [TblLookUpType] ON

INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(1,'UnableScreenReason','Unable Screen Reason','Used for Categorizing Pre-Iden','Feb 22 2010  4:06:40:427AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(2,'AdvocateType','Advocate Type','Lookup for advocate type used ','Feb 22 2010  4:21:53:480AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(3,'HostPaymentMode','Host Payment Mode','Lookup for Payment Mode of Hos','Mar 11 2010  8:53:36:310AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(4,'HostPaymentStatus','Host Payment Status','Lookup for Host Payment Status','Mar 11 2010  8:53:36:357AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(5,'DepositType','DepositType','DepositType                   ','Mar 11 2010  8:53:36:403AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(6,'PrintOrderItemShippingStatus','Print Order Item Shipping Status','Placed/Assigned/Shipped/Confir','Mar 24 2010  6:23:15:397AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(7,'PrintOrderItemConfirmationMode','Print Order Item Confirmation Mode','CallCenter, Unique URL and Ema','Mar 24 2010  6:23:15:507AM',NULL)
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(8,'ProspectCustomerConversionStatus','Prospect Customer Conversion Status','Prospect Customer Conversion S','Apr 13 2010  4:32:52:000AM','Apr 13 2010  4:32:52:000AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(9,'CallStatus','Call Status','No Answer, Voice Message, Atte','Apr 13 2010  4:32:52:050AM','Apr 13 2010  4:32:52:050AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(10,'FacilityViabilityRating','Facility Viability Rating','                              ','May 27 2010  4:49:04:010AM','May 27 2010  4:49:04:010AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(11,'InternetAccess','Internet Access','What is status of Internet Acc','May 27 2010  4:49:12:447AM','May 27 2010  4:49:12:447AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(12,'FileType','FileType','Describing File Type which has','May 27 2010  4:49:19:447AM','May 27 2010  4:49:19:447AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(13,'HostImageType','HostImageType','Types of Image uploaded concer','May 27 2010  4:49:31:820AM','May 27 2010  4:49:31:820AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(14,'EvaluationMode','Evaluation Mode','                              ','May  7 2011  4:36:51:380AM','May  7 2011  4:36:51:380AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(15,'PaymentFrequency','Payment Frequency','                              ','May  7 2011  4:36:51:380AM','May  7 2011  4:36:51:380AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(16,'VendorPaymentMode','Vendor Payment Mode','                              ','May  7 2011  4:36:51:380AM','May  7 2011  4:36:51:380AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(17,'AccountType','Account Type','                              ','May  7 2011  4:36:51:380AM','May  7 2011  4:36:51:380AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(18,'EventType','Event Type','                              ','May  7 2011  4:36:51:380AM','May  7 2011  4:36:51:380AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(19,'RefundType','Refund Type','Type of Refund being triggered','Jun  9 2011 12:14:27:423AM','Jun  9 2011 12:14:27:423AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(20,'RequestResultType','Request Result Type','how Request Result is Resolved','Jun  9 2011 12:14:27:427AM','Jun  9 2011 12:14:27:427AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(21,'CustomerRegistrationNoteType','Customer Registration Note Type','Type of notes saved while regi','Jun  9 2011 12:14:27:427AM','Jun  9 2011 12:14:27:427AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(22,'ResultArchiveUploadStatus','Result Archive Upload Status','Status of a Result Archive    ','Aug 20 2011  4:38:36:430AM','Aug 20 2011  4:38:36:430AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(23,'HospitalPartnerCustomerStatus','Hospital Partner Customer Status','Status of hospital partner cus','Nov  4 2011  3:57:18:967AM','Nov  4 2011  3:57:18:967AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(24,'HospitalPartnerCustomerScheduledOutcome','Hospital Partner Customer Scheduled Outcome','Outcome of hospital partner cu','Nov  4 2011  3:57:18:973AM','Nov  4 2011  3:57:18:973AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(25,'ResultInterpretation','Result Interpretation','Result Interpretation         ','Nov  4 2011  3:57:32:060AM','Nov  4 2011  3:57:32:060AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(26,'ProspectCustomerSource','Prospect Customer Source','Prospect Customer Source      ','Nov  4 2011  3:58:05:127AM','Nov  4 2011  3:58:05:127AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(27,'DoNotContactReason','Do Not Contact Reason','If a customer wishes, he/she s','Nov  4 2011  3:58:46:493AM','Nov  4 2011  3:58:46:493AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(28,'PackageType','Package Type','Retail or Corporate           ','Dec  3 2011  3:54:11:677AM','Dec  3 2011  3:54:11:677AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(29,'CriticalFollowUpStatus','Critical Follow Up Status','                              ','Mar 22 2012  4:33:34:470AM','Mar 22 2012  4:33:34:470AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(30,'DisplayControlType','Control Type','                              ','Mar 22 2012  4:38:07:220AM','Mar 22 2012  4:38:07:220AM')
INSERT [dbo].[TblLookUpType] ([LookupTypeID],[Alias],[DisplayName],[Description],[DateCreated],[DateModified])VALUES(31,'HospitalPartnerCustomerNotScheduledOutcome','Hospital Partner Customer Not Scheduled Outcome','                              ','Mar 22 2012  4:40:00:653AM','Mar 22 2012  4:40:00:653AM')

SET IDENTITY_INSERT [TblLookUpType] OFF

--[TblLookup]
-------------------------------------------------------------------------------------------------------

INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(1,2,'SalesRep','SalesRep','SalesRep Incomming phone numbe',1,'Feb 22 2010  4:31:00:857AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(2,2,'Host','Host','Host Incomming phone number   ',2,'Feb 22 2010  4:31:00:857AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(3,2,'Prospect','Prospect','Prospect Incomming phone numbe',3,'Feb 22 2010  4:31:00:873AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(4,2,'Advocate','Advocate','Advocate Incomming phone numbe',4,'Feb 22 2010  4:31:00:873AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(5,1,'IncreasedBodyHabitus','Increased Body Habitus','                              ',0,'Feb 22 2010  4:06:40:443AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(6,1,'No Pulse Wave Detected','No Pulse Wave Detected','                              ',0,'Feb 22 2010  4:06:40:443AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(7,1,'LymphNodesRemoved','Lymph Nodes Removed','                              ',0,'Feb 22 2010  4:06:40:443AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(8,1,'Other','Other','                              ',0,'Feb 22 2010  4:06:40:443AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(9,3,'Check','Check','Check                         ',1,'Mar 11 2010  8:53:36:323AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(10,3,'CreditCard','Credit Card','CreditCard                    ',2,'Mar 11 2010  8:53:36:323AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(11,3,'Both','Both','Credit Card and Check         ',3,'Mar 11 2010  8:53:36:340AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(12,4,'Pending','Pending','Pending                       ',1,'Mar 11 2010  8:53:36:357AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(13,4,'Paid','Paid','Paid                          ',2,'Mar 11 2010  8:53:36:370AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(14,4,'Refunded','Refunded','Refunded                      ',3,'Mar 11 2010  8:53:36:387AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(15,5,'AppliedToCost','AppliedToCost','AppliedToCost                 ',1,'Mar 11 2010  8:53:36:420AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(16,5,'Refunded','Refunded','Refunded                      ',2,'Mar 11 2010  8:53:36:450AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(17,4,'Receivable','Receivable','Receivable                    ',4,'Mar 30 2010  5:43:00:570AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(18,6,'Placed','Placed','Print Order Item Placed       ',1,'Mar 24 2010  6:23:15:443AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(19,6,'Assigned','Assigned','Print Order Item Assigned to v',1,'Mar 24 2010  6:23:15:477AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(20,6,'OutForDelivery','OutForDelivery','Print Order Item Out For Deliv',1,'Mar 24 2010  6:23:15:477AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(21,6,'Confirmed','Confirmed','Print Order Item Confirmed by ',1,'Mar 24 2010  6:23:15:477AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(22,6,'Returned','Returned','Print Order Item Placed return',1,'Mar 24 2010  6:23:15:490AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(23,7,'CallCenter','CallCenter','CallCenter                    ',1,'Mar 24 2010  6:23:15:507AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(24,7,'UniqueURL','UniqueURL','UniqueURL                     ',2,'Mar 24 2010  6:23:15:507AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(25,7,'Email','Email','Email                         ',3,'Mar 24 2010  6:23:15:523AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(26,6,'Delivered','Delivered','Print Order Item Delivered    ',1,'Mar 24 2010  6:23:15:490AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(27,6,'InTransit','InTransit','Print Order Item InTransit    ',1,'Mar 24 2010  6:23:15:490AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(28,6,'UnKnown','UnKnown','Print Order Item status UnKnow',1,'Mar 24 2010  6:23:15:507AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(29,8,'Converted','Converted','Signed Up or Regsitered for th',1,'Apr 13 2010  4:32:52:017AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(30,8,'NotConverted','Not Converted','In Process or Not yet picked  ',2,'Apr 13 2010  4:32:52:033AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(31,8,'Declined','Declined','Declined. Strictly Rejected.  ',3,'Apr 13 2010  4:32:52:033AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(32,9,'NoAnswer','No Answer','NoAnswer                      ',1,'Apr 13 2010  4:32:52:050AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(33,9,'VoiceMessage','Voice Message','VoiceMessage                  ',2,'Apr 13 2010  4:32:52:063AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(34,9,'Attended','Attended','Attended                      ',3,'Apr 13 2010  4:32:52:063AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(35,9,'Initiated','Initiated','Initiated                     ',4,'Apr 13 2010  4:32:52:063AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(36,7,'HSC','HSC Acknowledgement','Print order item receipt ackno',4,'May 13 2010  4:47:21:773AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(37,10,'DoNotSchedule','Do Not Schedule','Host is not good enough for sc',1,'May 27 2010  4:49:04:027AM','May 27 2010  4:49:04:027AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(38,10,'LastResort','Last Resort','If no other host is available.',1,'May 27 2010  4:49:04:027AM','May 27 2010  4:49:04:027AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(39,10,'Difficult','Difficult','Host is about average.        ',1,'May 27 2010  4:49:04:027AM','May 27 2010  4:49:04:027AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(40,10,'Acceptable','Acceptable','Host is acceptable for schedul',1,'May 27 2010  4:49:04:040AM','May 27 2010  4:49:04:040AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(41,10,'Optimal','Optimal','Host is fulfilling what is req',1,'May 27 2010  4:49:04:040AM','May 27 2010  4:49:04:040AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(42,11,'Available (Good Speed)','Available (Good Speed)','Status of Internet Access at h',1,'May 27 2010  4:49:12:463AM','May 27 2010  4:49:12:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(43,11,'Available (Average Speed)','Available (Average Speed)','Status of Internet Access at h',1,'May 27 2010  4:49:12:463AM','May 27 2010  4:49:12:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(44,11,'Available (Unreliable)','Available (Unreliable)','Status of Internet Access at h',1,'May 27 2010  4:49:12:463AM','May 27 2010  4:49:12:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(45,11,'Not Available','Not Available','Status of Internet Access at h',1,'May 27 2010  4:49:12:480AM','May 27 2010  4:49:12:480AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(46,12,'Image','Image','File Type: Image              ',1,'May 27 2010  4:49:19:463AM','May 27 2010  4:49:19:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(47,12,'Document','Document','File type: Document           ',1,'May 27 2010  4:49:19:463AM','May 27 2010  4:49:19:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(48,12,'Flat Files','Flat Files','File Type: Flat Files         ',1,'May 27 2010  4:49:19:463AM','May 27 2010  4:49:19:463AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(49,13,'Marketing','Marketing','                              ',1,'May 27 2010  4:49:31:820AM','May 27 2010  4:49:31:820AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(50,13,'HostInfrastructure','Host Infrastructure','                              ',2,'May 27 2010  4:49:31:837AM','May 27 2010  4:49:31:837AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(51,12,'Video','Video','Video Files                   ',1,'Aug 20 2011  4:38:24:543AM','Aug 20 2011  4:38:24:543AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(52,13,'Marketing Marquee','Marketing Marquee','                              ',3,'May 27 2010  4:49:31:837AM','May 27 2010  4:49:31:837AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(53,13,'Marketing Logo','Marketing Logo','                              ',4,'May 27 2010  4:49:31:837AM','May 27 2010  4:49:31:837AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(54,1,'Technically Limited but readable','Technically Limited but readable','                              ',0,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(55,1,'Repeat Study/Unreadable','Repeat Study/Unreadable','                              ',0,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(56,1,'Unable to Technically Visualize','Unable to Technically Visualize','                              ',0,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(57,1,'Technically Limited Images','Technically Limited Images','                              ',0,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(58,14,'Customer','Customer','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(59,14,'Test','Test','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(60,15,'Weekly','Weekly','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(61,15,'Weekly','Weekly','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(62,15,'Monthly','Monthly','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(63,16,'Check','Check','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(64,16,'CreditCard','Credit Card','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(65,16,'Wire','Wire','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(66,17,'Checking','Checking','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(67,17,'Savings','Savings','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(68,18,'Retail','Retail','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(69,18,'Corporate','Corporate','                              ',1,'May  7 2011  4:36:51:383AM','May  7 2011  4:36:51:383AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(70,19,'CustomerCancellation','Customer Cancellation','Customer being cancelled.     ',1,'Jun  9 2011 12:14:27:427AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(71,19,'DowngradesorDiscount','Downgrade or Discount','Package being downgraded or Co',1,'Jun  9 2011 12:14:27:427AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(72,19,'EventCancellation','Event Cancellation','Event being cancelled.        ',1,'Jun  9 2011 12:14:27:430AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(73,19,'ForcedCancellation','Forced Cancellation','In Case Customer being asked f',1,'Jun  9 2011 12:14:27:430AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(74,19,'TestNotPerformed','Test not performed','Test not performed.           ',1,'Jun  9 2011 12:14:27:430AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(75,19,'FieldIssue','Field Issue','Some Field Issue.             ',1,'Jun  9 2011 12:14:27:437AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(76,20,'AdjustOrder','Adjust Order','                              ',1,'Jun  9 2011 12:14:27:437AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(77,20,'RescheduleAppointment','Reschedule Appointment','                              ',1,'Jun  9 2011 12:14:27:437AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(78,20,'OfferFreeAddonsAndDiscounts','Offer Free Addons And Discounts','                              ',1,'Jun  9 2011 12:14:27:437AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(79,20,'IssueGiftCertificate','Issue Gift Certificate','                              ',1,'Jun  9 2011 12:14:27:437AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(80,20,'IssueRefund','Issue Refund','                              ',1,'Jun  9 2011 12:14:27:440AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(81,21,'AppointmentNote','Appointment Note','Appointment Note.             ',1,'Jun  9 2011 12:14:27:440AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(82,21,'CustomerNote','Customer Note','Customer Note.                ',1,'Jun  9 2011 12:14:27:440AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(83,19,'ChangePackage','Change Package','Package Change                ',1,'Jul  6 2011 10:04:16:607PM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(84,19,'ApplySourceCode','Apply Source Code','Apply Source Code             ',1,'Jul  6 2011 10:04:16:610PM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(85,19,'CDRemoval','CD Removal','CD Removal                    ',1,'Jul  6 2011 10:04:16:610PM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(86,19,'CancelShipping','Cancel Shipping','Cancel Shipping               ',1,'Jul  6 2011 10:04:16:610PM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(88,12,'Compressed','Compressed','Compressed Files              ',1,'Aug 20 2011  4:38:24:547AM','Aug 20 2011  4:38:24:547AM',1,1,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(89,22,'Uploading','Upload - In Progress','                              ',4,'Aug 20 2011  4:38:36:430AM','Aug 20 2011  4:38:36:430AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(90,22,'UploadFailed','Upload - Failed','                              ',4,'Aug 20 2011  4:38:36:430AM','Aug 20 2011  4:38:36:430AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(91,22,'Uploaded','Upload - Succeeded','                              ',4,'Aug 20 2011  4:38:36:433AM','Aug 20 2011  4:38:36:433AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(92,22,'Parsing','Parse - In Progress','                              ',4,'Aug 20 2011  4:38:36:433AM','Aug 20 2011  4:38:36:433AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(93,22,'ParseFailed','Parse - Failed','                              ',4,'Aug 20 2011  4:38:36:433AM','Aug 20 2011  4:38:36:433AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(94,22,'Parsed','Parse - Succeeded','                              ',4,'Aug 20 2011  4:38:36:433AM','Aug 20 2011  4:38:36:433AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(95,22,'InvalidFileFormat','Parse - Invalid File Format','                              ',4,'Aug 20 2011  4:38:36:433AM','Aug 20 2011  4:38:36:433AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(96,22,'FileNotFound','Parse - File Not Found','                              ',4,'Aug 20 2011  4:38:36:437AM','Aug 20 2011  4:38:36:437AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(97,23,'NotCalled','Not Called','                              ',1,'Nov  4 2011  3:57:18:970AM','Nov  4 2011  3:57:18:970AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(98,23,'LeftVoiceMail','Left Voice Mail','                              ',3,'Nov  4 2011  3:57:18:970AM','Nov  4 2011  3:57:18:970AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(99,23,'TalkedToPerson','Talked To Person','                              ',2,'Nov  4 2011  3:57:18:970AM','Nov  4 2011  3:57:18:970AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(100,24,'Scheduled','Scheduled','                              ',5,'Nov  4 2011  3:57:18:973AM','Nov  4 2011  3:57:18:973AM',1,NULL,0)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(101,31,'NotScheduled','Not Scheduled','                              ',8,'Nov  4 2011  3:57:18:973AM','Nov  4 2011  3:57:18:973AM',1,NULL,0)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(102,25,'Normal','Normal','                              ',6,'Nov  4 2011  3:57:32:060AM','Nov  4 2011  3:57:32:060AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(103,25,'Abnormal','Abnormal','                              ',6,'Nov  4 2011  3:57:32:060AM','Nov  4 2011  3:57:32:060AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(104,25,'Critical','Critical','                              ',6,'Nov  4 2011  3:57:32:060AM','Nov  4 2011  3:57:32:060AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(105,31,'NotScheduledSentInformation','Not Scheduled / Sent Information','                              ',6,'Nov  4 2011  3:57:46:217AM','Nov  4 2011  3:57:46:217AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(106,26,'Online','Online','                              ',1,'Nov  4 2011  3:58:05:127AM','Nov  4 2011  3:58:05:127AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(107,26,'CallCenter','CallCenter','                              ',1,'Nov  4 2011  3:58:05:130AM','Nov  4 2011  3:58:05:130AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(108,26,'SalesRep','SalesRep','                              ',1,'Nov  4 2011  3:58:05:130AM','Nov  4 2011  3:58:05:130AM',1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(109,27,'DeadPassedAway','Dead/Passed Away','If a customer wishes, he/she s',1,'Nov  4 2011  3:58:46:497AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(110,27,'InvalidAddress','Invalid Address','If a customer wishes, he/she s',1,'Nov  4 2011  3:58:46:497AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(111,27,'CustomerRequest','Customer Request','If a customer wishes, he/she s',1,'Nov  4 2011  3:58:46:497AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(112,27,'Other','Other','If a customer wishes, he/she s',1,'Nov  4 2011  3:58:46:500AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(113,28,'Retail','Retail','                              ',1,'Dec  3 2011  3:54:11:680AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(114,28,'Corporate','Corporate','                              ',2,'Dec  3 2011  3:54:11:680AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(115,29,'NoFollowUp','No Follow Up','                              ',1,'Mar 22 2012  4:33:34:470AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(116,29,'FollowUpIn48hrs','Follow up in 48 hrs','                              ',1,'Mar 22 2012  4:33:34:473AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(117,29,'FollowUpIn6Weeks','Follow up in 6 weeks','                              ',1,'Mar 22 2012  4:33:34:473AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(118,23,'Unreachable','Unreachable','                              ',7,'Mar 22 2012  4:34:13:920AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(119,24,'ScheduledWithAffiliatedPCP','Scheduled with Affiliated PCP','                              ',1,'Mar 22 2012  4:34:13:920AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(120,24,'ScheduledWithAffiliatedSpecialist','Scheduled with Affiliated Specialist','                              ',2,'Mar 22 2012  4:34:13:920AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(121,24,'ReferredToAffiliatedPhysician','Referred to Affiliated Physician','                              ',3,'Mar 22 2012  4:34:13:920AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(122,24,'ScheduledWithNonAffiliatedPhysician','Scheduled with Non Affiliated Physician','                              ',4,'Mar 22 2012  4:34:13:923AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(123,31,'Other','Other','                              ',9,'Mar 22 2012  4:34:13:923AM',NULL,1,NULL,0)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(124,30,'Radio','Radio','                              ',1,'Mar 22 2012  4:38:07:223AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(125,30,'CheckBox','CheckBox','                              ',1,'Mar 22 2012  4:38:07:223AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(126,30,'TextBox','TextBox','                              ',1,'Mar 22 2012  4:38:07:227AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(127,30,'TextArea','TextArea','                              ',1,'Mar 22 2012  4:38:07:227AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(128,21,'CancellationNote','Cancellation Note','                              ',1,'Mar 22 2012  4:39:11:367AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(129,23,'LeftVoiceMail2','Left Voice Mail 2','                              ',4,'Mar 22 2012  4:39:31:137AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(130,23,'LeftVoiceMail3','Left Voice Mail 3','                              ',5,'Mar 22 2012  4:39:31:137AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(131,23,'LeftVoiceMail4','Left Voice Mail 4','                              ',6,'Mar 22 2012  4:39:31:140AM',NULL,1,NULL,1)
INSERT [dbo].[TblLookUp] ([LookupId],[LookupTypeId],[Alias],[DisplayName],[Description],[RelativeOrder],[DateCreated],[DateModified],[DataRecorderCreatorID],[DataRecorderModifierID],[IsActive])VALUES(132,31,'NotScheduledNotInterested','Not Scheduled / Not Interested','                              ',7,'Mar 22 2012  4:40:00:657AM',NULL,1,NULL,1)
		
--TblCommunicationMode
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
delete from TblCommunicationMode

SET IDENTITY_INSERT TblCommunicationMode ON
--Email
IF NOT Exists(select CommunicationModeID from TblCommunicationMode where [Name]='Email')
Begin
INSERT INTO [dbo].[TblCommunicationMode]
([CommunicationModeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])
VALUES
(1,'Email','','1', getdate(),getdate())
End

--Mail
IF NOT Exists(select CommunicationModeID from TblCommunicationMode where [Name]='Mail')
Begin
INSERT INTO [dbo].[TblCommunicationMode]
([CommunicationModeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])
VALUES
(2,'Mail','','1', getdate(),getdate())
End

--Fax
IF NOT Exists(select CommunicationModeID from TblCommunicationMode where [Name]='Fax')
Begin
INSERT INTO [dbo].[TblCommunicationMode]
([CommunicationModeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])
VALUES
(3,'Fax','','1', getdate(),getdate())
End

--Phone
IF NOT Exists(select CommunicationModeID from TblCommunicationMode where [Name]='Phone')
Begin
INSERT INTO [dbo].[TblCommunicationMode]
([CommunicationModeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])
VALUES
(4,'Phone','','1', getdate(),getdate())
End

--In person
IF NOT Exists(select CommunicationModeID from TblCommunicationMode where [Name]='In person')
Begin
INSERT INTO [dbo].[TblCommunicationMode]
([CommunicationModeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])
VALUES
(5,'In person','','1', getdate(),getdate())
End

SET IDENTITY_INSERT TblCommunicationMode OFF

--TblContactType
-------------------------------------------------------------------------------------------
delete from TblContactType

SET IDENTITY_INSERT TblContactType ON
--Work Contact  
IF NOT Exists(select ContactTypeID from TblContactType where [Name]='Work Contact')  Begin  INSERT INTO [dbo].[TblContactType]  ([ContactTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (1,'Work Contact','','1', getdate(),getdate())  End  
--Non Work Contact  
IF NOT Exists(select ContactTypeID from TblContactType where [Name]='Non Work Contact')  Begin  INSERT INTO [dbo].[TblContactType]  ([ContactTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (2,'Non Work Contact','','1', getdate(),getdate())  End  

SET IDENTITY_INSERT TblContactType OFF

--TblCarrier
-------------------------------------
delete from [TblCarrier]
SET IDENTITY_INSERT [TblCarrier] ON

IF NOT Exists(select CarrierID from TblCarrier where [Carrier]='Fedex')  Begin  INSERT INTO [dbo].[TblCarrier]  ([CarrierID], [Carrier])  VALUES  (1,'Fedex')  End  
IF NOT Exists(select CarrierID from TblCarrier where [Carrier]='UPS')  Begin  INSERT INTO [dbo].[TblCarrier]  ([CarrierID],[Carrier])  VALUES  (2,'UPS')  End  
IF NOT Exists(select CarrierID from TblCarrier where [Carrier]='USPS')  Begin  INSERT INTO [dbo].[TblCarrier]  ([CarrierID],[Carrier])  VALUES  (3,'USPS')  End  

SET IDENTITY_INSERT [TblCarrier] OFF

--TblCouponType
-------------------------------------------------------------------------------------------------------------------
delete from TblCouponType
SET IDENTITY_INSERT TblCouponType ON

IF NOT Exists(select CouponTypeID from TblCouponType where [Name]='Applicable on the whole order')  Begin  INSERT INTO [dbo].[TblCouponType]  ([CouponTypeID],[Name],[Description],[IsEventCoupon],[IsActive],[DateCreated],[DateModified])  VALUES  (1,'Applicable on the whole order','Applicable on the whole Order Amount',0,'1', getdate(),getdate())  End  
IF NOT Exists(select CouponTypeID from TblCouponType where [Name]='Applicable only on the package or test')  Begin  INSERT INTO [dbo].[TblCouponType]  ([CouponTypeID],[Name],[Description],[IsEventCoupon],[IsActive],[DateCreated],[DateModified])  VALUES  (2,'Applicable only on the package or test','Applicable on the selected Package/Test Amount',0,'1', getdate(),getdate())  End  

Insert Into TblCouponType (CouponTypeId, Name, Description, IsEventCoupon, DateCreated, Datemodified, IsActive)
values ( 3, 'Applicable only on add-on products', 'Applicable on the Product Amount', 0, getdate(), getdate(), 1 ) 

Insert Into TblCouponType (CouponTypeId, Name, Description, IsEventCoupon, DateCreated, Datemodified, IsActive)
values ( 4, 'Applicable only on the Shipping', 'Applicable on the Shipping Amount', 0, getdate(), getdate(), 1 ) 

SET IDENTITY_INSERT TblCouponType OFF

--TblCreditCardType
----------------------------------------------------------------------------------------------------------------------
DELETE FROM [TblCreditCardType]
SET IDENTITY_INSERT [TblCreditCardType] ON

IF NOT Exists(select CreditCardTypeID from TblCreditCardType where [Name]='MasterCard')  Begin  INSERT INTO [dbo].[TblCreditCardType]  ([CreditCardTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (1,'Master Card','desc','1', getdate(),getdate())  End  
IF NOT Exists(select CreditCardTypeID from TblCreditCardType where [Name]='Visa')  Begin  INSERT INTO [dbo].[TblCreditCardType]  ([CreditCardTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (2,'Visa','desc','1', getdate(),getdate())  End  
IF NOT Exists(select CreditCardTypeID from TblCreditCardType where [Name]='Discover')  Begin  INSERT INTO [dbo].[TblCreditCardType]  ([CreditCardTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (3,'Discover','desc','1', getdate(),getdate())  End  
IF NOT Exists(select CreditCardTypeID from TblCreditCardType where [Name]='AmericanExpress')  Begin  INSERT INTO [dbo].[TblCreditCardType]  ([CreditCardTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (4,'American Express','desc','1', getdate(),getdate())  End  

SET IDENTITY_INSERT [TblCreditCardType] OFF


--TblEventType
------------------------------------------------------------------------------------------------------------------
delete from TblEventType
SET IDENTITY_INSERT TblEventType ON

IF NOT Exists(select EventTypeID from TblEventType where [Name]='Public')  Begin  INSERT INTO [dbo].[TblEventType]  ([EventTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (1,'Public','','1', getdate(),getdate())  End  
IF NOT Exists(select EventTypeID from TblEventType where [Name]='Private')  Begin  INSERT INTO [dbo].[TblEventType]  ([EventTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified])  VALUES  (2,'Private','','1', getdate(),getdate())  End  

SET IDENTITY_INSERT TblEventType OFF

--TblGlobalConfiguration
-----------------------------------------------------------------------------------------------------------------
delete from TblGlobalConfiguration

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DaysToChangePassword')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DaysToChangePassword','DaysToChangePassword','1', getdate(),getdate(),'13',NULL,NULL,'Admin','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='NumberOfPictures')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('NumberOfPictures','NumberOfPictures','1', getdate(),getdate(),'8',NULL,NULL,'Admin','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='AppointmentSlot')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('AppointmentSlot','Appointment Slot in minutes','1', getdate(),getdate(),'0',NULL,NULL,'Event','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DefaultScheduleTemplate')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DefaultScheduleTemplate','DefaultScheduleTemplate','1', getdate(),getdate(),'9',NULL,NULL,'Event','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='defaultPaymentThreshold')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('defaultPaymentThreshold','default PaymentThreshold','1', getdate(),getdate(),'100',NULL,NULL,'Admin','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='defaultMarketingCookieExpiry')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('defaultMarketingCookieExpiry','default value in days for marketing material to expire','1', getdate(),getdate(),'90',NULL,NULL,'Admin','integer','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='GlobalCutOffDate')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('GlobalCutOffDate','Date after which Physician can start evaluation','1', getdate(),getdate(),'01/01/2009',NULL,NULL,'Medical Vendor Settings','DateTime','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MVAccessIPs')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MVAccessIPs','IPs which are given search features in Evaluation Queue','1', getdate(),getdate(),'202.71.133.162|76.253.137.242',NULL,NULL,'Medical Vendor Settings','varchar','|')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='ShowOrderCatalog')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('ShowOrderCatalog','Show Order Catalog','1', getdate(),getdate(),'No',NULL,NULL,'Admin','Varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MVPermittedKey')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MVPermittedKey','Medical Vendor PermittedKey','1', getdate(),getdate(),'QWERTY123',NULL,NULL,'Medical Vendor Settings','int','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='SystemVersion')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('SystemVersion','System Version','1', getdate(),getdate(),'2.9.5',NULL,NULL,'Admin','varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='Eventdistance')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('Eventdistance','Event Distance','1', getdate(),getdate(),'25',NULL,NULL,'Event','Bigint','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='AdministratorEmail')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('AdministratorEmail','Administrator Email Address','1', getdate(),getdate(),'bidhan@Taazaa.com',NULL,NULL,'Admin','Varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='CouponPrefix')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('CouponPrefix','Coupon Prefix','1', getdate(),getdate(),'HSS',NULL,NULL,'Admin','Varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='GoogleCalendarUrl')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('GoogleCalendarUrl','Google Calendar Url','1', getdate(),getdate(),'http://www.google.com/calendar/feeds/default/private/full',NULL,NULL,'Admin','varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='CCRepDashBoardRefereshTime')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('CCRepDashBoardRefereshTime','Call Center DashBoard Referesh Time in Minutes','1', getdate(),getdate(),'5',NULL,NULL,'Admin','Varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DisplayBarOnQA')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DisplayBarOnQA','Display Top Bar On QA','1', getdate(),getdate(),'',NULL,NULL,'Admin','Varchar','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxDollarCommission')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MaxDollarCommission','Max Dollar Commission for advocate','1', getdate(),getdate(),'10.00',NULL,NULL,'Admin','decimal(18,2)','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxPercentCommission')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MaxPercentCommission','Max Percent Commission for advocate','1', getdate(),getdate(),'15.00',NULL,NULL,'Admin','decimal(18,2)','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxDollarCommissionSalesRep')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MaxDollarCommissionSalesRep','Max Dollar Commission for Sales Rep','1', getdate(),getdate(),'0.00',NULL,NULL,'Admin','decimal(18,2)','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxPercentCommissionSalesRep')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MaxPercentCommissionSalesRep','Max Percent Commission for SalesRep','1', getdate(),getdate(),'5.00',NULL,NULL,'Admin','decimal(18,2)','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DefaultCampaignValidity')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DefaultCampaignValidity','DEFAULT validity TIME FOR campaign in months','1', getdate(),getdate(),'6',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EpochDate')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('EpochDate','The start of business for HY!','1', getdate(),getdate(),'11/1/2007',NULL,NULL,'Admin','DateTime','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='BadHostPerformanceUpperLimit')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('BadHostPerformanceUpperLimit','Bad Host Performance Upper Limit','1', getdate(),getdate(),'15',NULL,NULL,'Admin','VARCHAR','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='AverageHostPerformanceUpperLimit')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('AverageHostPerformanceUpperLimit','Average Host Performance Upper Limit','1', getdate(),getdate(),'35',NULL,NULL,'Admin','VARCHAR','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DefaultMarketingOfferID')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DefaultMarketingOfferID','Default Marketing Offer ID','1', getdate(),getdate(),'1',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MinimumDaysToFreezeEventDate')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('MinimumDaysToFreezeEventDate','Minimum  Days To Freeze EventDate','1', getdate(),getdate(),'49',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='Maximum Event Slot Interval')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('Maximum Event Slot Interval','Maximum Event Slot Interval','1', getdate(),getdate(),'15',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='Maximum Event Slot Interval')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('Maximum Event Slot Interval','Maximum Event Slot Interval','1', getdate(),getdate(),'15',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DaysToFreezeEventWizardPrintOrderForSalesRep')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DaysToFreezeEventWizardPrintOrderForSalesRep','Last modification date to edit print order by SalesRep','1', getdate(),getdate(),'60',NULL,NULL,'SalesRep','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DaysToFreezeEventWizardPrintOrderForFranchisee')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DaysToFreezeEventWizardPrintOrderForFranchisee','Last modification date to edit print order by Franchisee','1', getdate(),getdate(),'53',NULL,NULL,'Franchisee','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DefaultMarketingOfferForWelnessSeminar')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('DefaultMarketingOfferForWelnessSeminar','Default Marketing Offer for wellness seminars 7PAC','1', getdate(),getdate(),'2',NULL,NULL,'Admin','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='HostEventDistance')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('HostEventDistance','The Distance in miles to show events on host details page.','1', getdate(),getdate(),'5',NULL,NULL,'Franchisor Franchisee and SalesRep','INT','')  End  
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='NonStandardEventTimeNotificationEmail')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('NonStandardEventTimeNotificationEmail','Non-Standard Event Start and EndTime Alert','1', getdate(),getdate(),'bidhan@taazaa.com',NULL,NULL,'Admin','VARCHAR','')  End  

IF NOT EXISTS(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='CancellationFee')
BEGIN
	INSERT INTO [TblGlobalConfiguration] 
	([Name],[Description],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[IsActive],[Delimiter],[DateCreated],	[DateModified]) 
	VALUES 
	( 'CancellationFee', 'Fee charged if a customer canels the appointment' , '25', NULL, NULL, 'Admin', 'decimal',1, '', GETDATE(), GETDATE())
END

IF NOT EXISTS(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EventStartTime')
BEGIN
	INSERT INTO [TblGlobalConfiguration] 
	([Name],[Description],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[IsActive],[Delimiter],[DateCreated],	[DateModified]) 
	VALUES 
	( 'EventStartTime', 'Default event start time' , '09:00 AM', NULL, NULL, 'Admin', 'string',1, '', GETDATE(), GETDATE())
END


IF NOT EXISTS(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EventEndTime')
BEGIN
	INSERT INTO [TblGlobalConfiguration] 
	([Name],[Description],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[IsActive],[Delimiter],[DateCreated],	[DateModified]) 
	VALUES 
	( 'EventEndTime', 'Default event end time' , '05:00 PM', NULL, NULL, 'Admin', 'string',1, '', GETDATE(), GETDATE())
END

IF NOT EXISTS(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MinimumPurchaseAmount')
BEGIN
	INSERT INTO [TblGlobalConfiguration] 
	([Name],[Description],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[IsActive],[Delimiter],[DateCreated],	[DateModified]) 
	VALUES 
	( 'MinimumPurchaseAmount', 'Minimum amount for an order' , '0', NULL, NULL, 'Admin', 'decimal',1, '', GETDATE(), GETDATE())
END

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='IncomingPhoneLineRequired')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('IncomingPhoneLineRequired','Incoming Phone Line Required','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  


IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EnableAlaCarte')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('EnableAlaCarte','Enable/Disable Ala Carte','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  


IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='AreaCode')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('AreaCode','Area code','1', getdate(),getdate(),'717',NULL,NULL,'Admin','Varchar','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EnableBarCode')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('EnableBarCode','Enable Bar Code','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End 

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='UpsellPackage')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('UpsellPackage','Upsell Package','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='UpsellCd')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('UpsellCd','Upsell Cd','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='UpsellAlaCarte')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('UpsellAlaCarte','Upsell A la Carte','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxNoOfEventToShowOnline')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('MaxNoOfEventToShowOnline','Maximum Number Of Events To Show on Online','1', getdate(),getdate(),'25',NULL,NULL,'Admin','INT','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='MaxNoOfAppointmentSlotsToShowOnline')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('MaxNoOfAppointmentSlotsToShowOnline','Maximum Number Of Appointments To Show on  Online','1', getdate(),getdate(),'12',NULL,NULL,'Admin','INT','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EventListPageSizeOnline')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('EventListPageSizeOnline','Page Size on Online Event List','1', getdate(),getdate(),'5',NULL,NULL,'Admin','INT','')  
End  
--[TblPaymentType]
------------------------------------------------------------------------------------
delete from [TblPaymentType]

SET IDENTITY_INSERT [TblPaymentType] ON

INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(1,'Check','test','Check','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(2,'Credit Card','test','Credit Card','Dec 12 2007 12:00:00:000AM','Dec 12 2007 12:00:00:000AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(4,'Cash','test','Cash','Dec 21 2007 12:00:00:000AM','Dec 21 2007 12:00:00:000AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(5,'Demand Draft','test','Demand Draft','Dec 21 2007 12:00:00:000AM','Dec 21 2007 12:00:00:000AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(6,'Money Order','test','Money Order','Dec 21 2007 12:00:00:000AM','Dec 21 2007 12:00:00:000AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(7,'eCheck','test','eCheck','Mar  6 2009  4:20:28:557AM','Mar  6 2009  4:20:28:557AM',1)
INSERT INTO [TblPaymentType] ([PaymentTypeID],[Name],[Description],[Alias],[DateCreated],[DateModified],[IsActive])VALUES(8,'Gift Certificate','Payment is made by Gift Certificate','Gift Certificate','Dec 22 2009  4:40:33:340AM','Dec 22 2009  4:40:33:340AM',1)

SET IDENTITY_INSERT [TblPaymentType] OFF


--tblCategories
------------------------------------------------
delete from tblCategories
SET IDENTITY_INSERT TblCategories ON

IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Grassroot')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (1,'Grassroot','1', getdate(),getdate())  End  
IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Print')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (2,'Print','1', getdate(),getdate())  End  
IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Advocate Group')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (3,'Advocate Group','1', getdate(),getdate())  End  
IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Internet')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (4,'Internet','1', getdate(),getdate())  End  
IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Direct Mail')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (5,'Direct Mail','1', getdate(),getdate())  End  
IF NOT Exists(select CategoryId from tblCategories where [CategoryName]='Other')  Begin  INSERT INTO [dbo].[tblCategories]  ([CategoryId],[CategoryName],[IsActive],[DateCreated],[DateModified])  VALUES  (6,'Other','1', getdate(),getdate())  End  

SET IDENTITY_INSERT TblCategories OFF

--TblItemType
--------------------------------------------------------------------------------------------------------------
delete from TblItemType
SET IDENTITY_INSERT TblItemType ON

IF NOT Exists(select ItemTypeID from TblItemType where [Name]='Consumables')  Begin  INSERT INTO [dbo].[TblItemType]  ([ItemTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified],[IsTestAssociated])  VALUES  (1,'Consumables','Test Item1','1', getdate(),getdate(),0)  End  
IF NOT Exists(select ItemTypeID from TblItemType where [Name]='Non Consumables')  Begin  INSERT INTO [dbo].[TblItemType]  ([ItemTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified],[IsTestAssociated])  VALUES  (2,'Non Consumables','desc','1', getdate(),getdate(),0)  End  
IF NOT Exists(select ItemTypeID from TblItemType where [Name]='Non Consumables')  Begin  INSERT INTO [dbo].[TblItemType]  ([ItemTypeID],[Name],[Description],[IsActive],[DateCreated],[DateModified],[IsTestAssociated])  VALUES  (3,'Non Consumables','desc1','1', getdate(),getdate(),0)  End  

SET IDENTITY_INSERT TblItemType OFF

--[TblMarketingOfferSignUpMode]
---------------------------------------------------------------------------------------------------------
delete from [TblMarketingOfferSignUpMode]

SET IDENTITY_INSERT [TblMarketingOfferSignUpMode] ON

INSERT INTO [TblMarketingOfferSignUpMode] ([MarketingOfferSignUpModeID],[MarketingOfferID],[SignUpMode],[IsActive])VALUES(1,1,0,1)
INSERT INTO [TblMarketingOfferSignUpMode] ([MarketingOfferSignUpModeID],[MarketingOfferID],[SignUpMode],[IsActive])VALUES(2,2,0,1)

SET IDENTITY_INSERT [TblMarketingOfferSignUpMode] OFF



--[TblProspectContactRole]
------------------------------------------------------------------------------------------

delete from [TblProspectContactRole]
SET IDENTITY_INSERT [TblProspectContactRole] ON

INSERT INTO [TblProspectContactRole] ([ProspectContactRoleID],[ProspectContactRoleName])VALUES(1,'Primary Contact')
INSERT INTO [TblProspectContactRole] ([ProspectContactRoleID],[ProspectContactRoleName])VALUES(2,'Secondary Contact')
INSERT INTO [TblProspectContactRole] ([ProspectContactRoleID],[ProspectContactRoleName])VALUES(3,'Decision Maker')

SET IDENTITY_INSERT [TblProspectContactRole] OFF


--[TblProspectListType]
-------------------------------------------------------------------------------------------
delete from [TblProspectListType]

SET IDENTITY_INSERT [TblProspectListType] ON

INSERT INTO [TblProspectListType] ([ProspectListTypeId],[ProspectListType],[DateCreated])VALUES(1,'Host Prospect','Apr 17 2009  4:41:46:437AM')
INSERT INTO [TblProspectListType] ([ProspectListTypeId],[ProspectListType],[DateCreated])VALUES(2,'Customer Prospect','Apr 17 2009  4:41:46:453AM')

SET IDENTITY_INSERT [TblProspectListType] OFF

--[TblProspectType]
--------------------------------------------------------------------------
delete from [TblProspectType]

SET IDENTITY_INSERT [TblProspectType] ON

INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Faith Based Organization',NULL,'Feb 27 2008 12:00:00:000AM','Feb 27 2008 12:00:00:000AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'YMCA / YWCA',NULL,'Feb 27 2008 12:00:00:000AM','Feb 27 2008 12:00:00:000AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'Hospital / Clinic / Medical Office',NULL,'Feb 27 2008 12:00:00:000AM','Feb 27 2008 12:00:00:000AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(7,'Other',NULL,'Feb 27 2008 12:00:00:000AM','Feb 27 2008 12:00:00:000AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(8,'Conference / Banquet Center',NULL,'Feb 27 2008 12:00:00:000AM','Feb 27 2008 12:00:00:000AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(9,'Senior Center','','Apr 24 2008  8:20:48:683AM','Apr 24 2008  8:20:48:683AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(10,'Fraternal / Social Organization','','Apr 24 2008  8:21:17:920AM','Apr 24 2008  8:21:17:920AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(11,'Active Adult Community','','Apr 25 2008  8:40:02:153AM','Apr 25 2008  8:40:02:153AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(12,'Community / Activity / Recreational / Civic Center','','Apr 25 2008  8:40:19:683AM','Apr 25 2008  8:40:19:683AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(13,'Hotel / Motel','','Apr 28 2008 11:27:32:867AM','Apr 28 2008 11:27:32:867AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(14,'Apartment / Condo','','Apr 28 2008 12:18:42:727PM','Apr 28 2008 12:18:42:727PM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(15,'Chiropractor','','Apr 28 2008 12:33:40:303PM','Apr 28 2008 12:33:40:303PM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(16,'Country Club','','Apr 28 2008  1:01:47:757PM','Apr 28 2008  1:01:47:757PM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(17,'Government',NULL,'Apr 10 2009  2:32:45:657AM','Apr 10 2009  2:32:45:657AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(18,'Library / School',NULL,'Apr 10 2009  2:32:45:657AM','Apr 10 2009  2:32:45:657AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(19,'Health Club / Gymnasium',NULL,'Apr 10 2009  2:32:45:657AM','Apr 10 2009  2:32:45:657AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(20,'Assisted Living Center',NULL,'Apr 10 2009  2:32:45:670AM','Apr 10 2009  2:32:45:670AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(21,'Corporation / Business',NULL,'Apr 10 2009  2:32:45:670AM','Apr 10 2009  2:32:45:670AM',1)
INSERT INTO [TblProspectType] ([ProspectTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(22,'RV / Mobile Home Community',NULL,'Apr 10 2009  2:32:45:670AM','Apr 10 2009  2:32:45:670AM',1)
insert into TblProspectType 
		(ProspectTypeId,Name,Description,DateCreated,DateModified,IsActive)
	values
		(27,'Corporate Location','Corporate Location',getdate(),getdate(),1)
SET IDENTITY_INSERT [TblProspectType] OFF


--TblAFChannel


delete from[tblAFCampaignTemplate]
delete from [tblAFAdvertiser]
delete from [tblAFChannel]

SET IDENTITY_INSERT [tblAFChannel] ON

INSERT INTO [tblAFChannel] ([ChannelID],[ChannelName],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(1,'Print','Jun  6 2008 12:00:00:000AM','Jun  6 2008 12:00:00:000AM',1)
INSERT INTO [tblAFChannel] ([ChannelID],[ChannelName],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(2,'Internet','Dec 23 2008  1:13:32:107AM','Dec 23 2008  1:13:32:107AM',1)

SET IDENTITY_INSERT [tblAFChannel] OFF
-------------------------------------------------------------------------------------
--[TblGiftCertificateType]
------------------------------------------------------------------------------------
delete from [TblGiftCertificateType]

SET IDENTITY_INSERT [TblGiftCertificateType] ON

INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(1,'Birthday','',NULL,'Dec 22 2009  4:39:48:260AM',1)
INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(2,'Anniversary','',NULL,'Dec 22 2009  4:39:48:277AM',1)
INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(3,'Father''s Day','',NULL,'Dec 22 2009  4:39:48:293AM',1)
INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(4,'Mother''s Day','',NULL,'Dec 22 2009  4:39:48:293AM',1)
INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(5,'Christmas','',NULL,'Dec 22 2009  4:39:48:293AM',1)
INSERT INTO [TblGiftCertificateType] ([GiftCertificateTypeID],[Name],[Description],[ImageID],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(6,'Other','',NULL,'Dec 22 2009  4:46:10:637AM',1)

SET IDENTITY_INSERT [TblGiftCertificateType] OFF

--[TblNotificationType]
-----------------------------------------------------------------------------
delete from [TblNotificationType]

SET IDENTITY_INSERT [TblNotificationType] ON

INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (1,'Global Exception','GlobalException','When an exception occured in the application.',1,GETDATE(),GETDATE(),1, null,null,0)
           
INSERT INTO [TblNotificationType]
       (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
	 VALUES
		   (2,'Customer Welcome Email With Username','CustomerWelcomeEmailWithUsername','Send customer username',1,GETDATE(),GETDATE(),1, null,null,0)
       
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (3,'Customer Welcome Email With Password','CustomerWelcomeEmailWithPassword','Send customer password',1,GETDATE(),GETDATE(),1, null,null,0)    
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (4,'Employee Welcome Email With Username','EmployeeWelcomeEmailWithUsername','Send employee username',1,GETDATE(),GETDATE(),1, null,null,0)     
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (5,'Employee Welcome Email With Password','EmployeeWelcomeEmailWithPassword','Send employee password',1,GETDATE(),GETDATE(),1, null,null,0) 
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (6,'Appointment Confirmation With Event Details','AppointmentConfirmationWithEventDetails','Send appointment confirmation mail with event detail',1,GETDATE(),GETDATE(),1, null,null,0)   
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (7,'Reset Password','ResetPassword','Send reset password mail',1,GETDATE(),GETDATE(),1, null,null,0)   
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (8,'Login Issues Send Username','LoginIssuesSendUsername','Send username retrival mail',1,GETDATE(),GETDATE(),1, null,null,0)  
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (9,'Login Issues Send Password','LoginIssuesSendPassword','Send password retrival mail',1,GETDATE(),GETDATE(),1, null,null,0)    
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (10,'Change Password','ChangePassword','Send change password',1,GETDATE(),GETDATE(),1, null,null,0)
           
INSERT INTO [TblNotificationType]
           (NotificationTypeID, [NotificationTypeName],[NotificationTypeNameAlias],[Description],[IsStarted],[DateCreated],[DateModified],[IsActive],[LastStatusChangedDate],[EscalateToPhone],[NoOfAttempts])
     VALUES
           (11,'Screening Reminder Mail','ScreeningReminderMail','Send Screening Reminder Mail',1,GETDATE(),GETDATE(),1, null,null,0) 
           
INSERT INTO [TblNotificationType] (
	[NotificationTypeID],	[NotificationTypeName],	[NotificationTypeNameAlias],	[Description],	[IsStarted],	[DateCreated],	[DateModified],
	[IsActive],	[LastStatusChangedDate],	[EscalateToPhone],	[NoOfAttempts]) 
VALUES ( 
	12,	'GiftCertificateClaimCodeEmail',	'GiftCertificateClaimCodeEmail',	'Claim Code notification to the one for whom gift certificate has been purchased.',	1,	GETDATE(),	GETDATE(),	1,	null,	null,	0 ) 


INSERT INTO [TblNotificationType] (
	[NotificationTypeID],	[NotificationTypeName],	[NotificationTypeNameAlias],	[Description],	[IsStarted],	[DateCreated],	[DateModified],
	[IsActive],	[LastStatusChangedDate],	[EscalateToPhone],	[NoOfAttempts]) 
VALUES ( 
	13,	'GiftCertificateAcknowledgmentEmail',	'GiftCertificateAcknowledgmentEmail',	'Acknowledgment mail to the person who has purchased the gift certificte.',	1,	GETDATE(),	GETDATE(),	1,	null,	null,	0 ) 
 
 INSERT INTO [TblNotificationType] (
      [NotificationTypeID], [NotificationTypeName], [NotificationTypeNameAlias],  [Description],    [IsStarted],      [DateCreated],    [DateModified],
      [IsActive], [LastStatusChangedDate],      [EscalateToPhone],      [NoOfAttempts]) 
VALUES ( 
      14, 'ResultsReady',   'ResultsReady',   'When EMR results ready online send this notification.',   1,    GETDATE(),  GETDATE(),  1,    null, null, 0 )

INSERT INTO [TblNotificationType] (
      [NotificationTypeID], [NotificationTypeName], [NotificationTypeNameAlias],  [Description],    [IsStarted],      [DateCreated],    [DateModified], [IsActive], [LastStatusChangedDate],      [EscalateToPhone],      [NoOfAttempts]) 
VALUES ( 
      15, 'AppointmentBookedInTwentyFourHours',   'AppointmentBookedInTwentyFourHours',   'Appointment Booked For Very Recent Event',   1,    GETDATE(),  GETDATE(),  1,    null, null, 0 )

INSERT INTO [TblNotificationType] (
      [NotificationTypeID], [NotificationTypeName], [NotificationTypeNameAlias],  [Description],    [IsStarted],      [DateCreated],    [DateModified], [IsActive], [LastStatusChangedDate],      [EscalateToPhone],      [NoOfAttempts]) 
VALUES (16, 'CriticalCustomer',   'CriticalCustomer',   'Critical Customer',   1,    GETDATE(),  GETDATE(),  1,    null, null, 0 )

INSERT INTO [TblNotificationType] (
      [NotificationTypeID], [NotificationTypeName], [NotificationTypeNameAlias],  [Description],    [IsStarted],      [DateCreated],    [DateModified], [IsActive], [LastStatusChangedDate],      [EscalateToPhone],      [NoOfAttempts]) 
VALUES (17, 'EvaluationReminder',   'EvaluationReminder',   'Evaluation Reminder',   1,    GETDATE(),  GETDATE(),  1,    null, null, 0 )
            
SET IDENTITY_INSERT [TblNotificationType] OFF

---------------------------------------------------------------------------------
--[TblScriptType]
--[TblScripts]
---------------------------------------------------------------------------------
delete from [TblScripts]
delete from [TblScriptType]

SET IDENTITY_INSERT [TblScriptType] ON

INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(9,'Welcome Script','Welcome','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(10,'New Customer Registration','New Customer Registration','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(11,'Event and Package Selection','Event and Package Selection','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(12,'Billing Information','Billing Information','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(13,'Final Thank you','Final Thank you','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(14,'Request Callback Number','Request Callback Number','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(15,'Existing Customer Call Back','Existing Customer Call Back','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(16,'Password Request','Password Request','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(17,'Upsell','Upsell','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(18,'Above 40','Above 40','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(19,'Conclusion Script','Conclusion Script','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(20,'LoginIssues','Login Issues Script','Oct  6 2008 12:00:00:000AM','Oct  6 2008 12:00:00:000AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(22,'OutboundOnlineProspect','Outbound Online Prospect Call','Mar  6 2009  4:20:28:540AM','Mar  6 2009  4:20:28:540AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(23,'OutboundCallCenterProspect','Outbound CallCenter Prospect Call','Mar  6 2009  4:20:28:557AM','Mar  6 2009  4:20:28:557AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(24,'Under 40 MV Authorization','Under 40 MV Authorization','Apr 28 2009  1:45:12:563PM','Apr 28 2009  1:45:12:563PM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])VALUES(25,'OutboundSeminarProspect','Outbound Seminar Prospect Call','Aug 14 2009  3:32:51:077AM','Aug 14 2009  3:32:51:077AM',1)
INSERT INTO [TblScriptType] ([ScriptTypeID],[ScriptName],[Description],[DateCreated],[DateModified],[IsActive])
VALUES(26,'ForwardRefundCall','Forward Refund Call','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1)
SET IDENTITY_INSERT [TblScriptType] OFF


---------------------------------------------------------------------------------------
--[TblSecurityQuestion]
--------------------------------------------------------------------------------------
delete from [TblSecurityQuestion]

SET IDENTITY_INSERT [TblSecurityQuestion] ON

INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'Who is your favorite actor/actress?','Description','Feb 11 2007 12:00:00:000AM','Nov 20 2008  1:21:51:320PM',1)
INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'What is your favorite pet''s name?','Description','Feb 11 2007 12:00:00:000AM','Feb 11 2007 12:00:00:000AM',1)
INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(6,'Which city were you born in?','Description','Nov 23 2007 12:49:34:060PM','Nov 23 2007 12:50:31:173PM',1)
INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(7,'What is your mother''s maiden name?','Description','Dec 26 2007 12:00:00:000AM','Dec 26 2007 12:00:00:000AM',1)
INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(8,'What make was your first car?','Description','Dec 26 2007 12:00:00:000AM','Dec 26 2007 12:00:00:000AM',1)
INSERT INTO [TblSecurityQuestion] ([SecurityQuestionID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(9,'What color was your first car?','Dale added to replace actress question at mikes request Oct 27 2008','Oct 27 2008  1:16:35:217PM','Oct 29 2008  3:14:03:190AM',1)

SET IDENTITY_INSERT [TblSecurityQuestion] OFF

----------------------------------------------------------------------------
--[TblTaskPriorityTypes]
-----------------------------------------------------------------------------
delete from [TblTaskPriorityTypes]

SET IDENTITY_INSERT [TblTaskPriorityTypes] ON

INSERT INTO [TblTaskPriorityTypes] ([TaskPriorityID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Low',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskPriorityTypes] ([TaskPriorityID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'Medium',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskPriorityTypes] ([TaskPriorityID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'High',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)

SET IDENTITY_INSERT [TblTaskPriorityTypes] OFF

--------------------------------------------------------------------------
--[TblTaskStatusTypes]
-------------------------------------------------------------------------
delete from[TblTaskStatusTypes]

SET IDENTITY_INSERT [TblTaskStatusTypes] ON

INSERT INTO [TblTaskStatusTypes] ([TaskStatusID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Not started',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskStatusTypes] ([TaskStatusID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'In Progress',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskStatusTypes] ([TaskStatusID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'Completed',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskStatusTypes] ([TaskStatusID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(4,'Pending Input',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)
INSERT INTO [TblTaskStatusTypes] ([TaskStatusID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(5,'Deferred',NULL,'May  8 2008 12:00:00:000AM','May  8 2008 12:00:00:000AM',1)

SET IDENTITY_INSERT [TblTaskStatusTypes] OFF

------------------------------------------------------------------------
--[TblToolTip]
-------------------------------------------------------------------------
delete from [TblToolTip]

SET IDENTITY_INSERT [TblToolTip] ON

INSERT INTO [TblToolTip] ([TagID],[Tag],[Content])VALUES(1,'EventWizardEventStatus','<div style="float:left; width:350px; padding:5px"><div style="float:left; width:340px; font:normal 11px arial;"><strong>Active:</strong><br />Default, this means the event is  as planned.<br /><br /><strong>Suspended:</strong><br />If you do not want anyone to register for this event, set the status to Suspended. This will stop further registrations.<br /><br /><strong>Canceled:</strong><br />If you want to cancel this event, select "Cancel".<br /><br /></div></div>')
INSERT INTO [TblToolTip] ([TagID],[Tag],[Content])VALUES(2,'EventWizardTechnicianInstructions','<div style="float:left; width:350px; padding:5px"><div style="float:left; width:340px; font:normal 11px arial;">Put information here that will help the technician like specific direction, how to get into the host location and any other useful information.</div></div>')
INSERT INTO [TblToolTip] ([TagID],[Tag],[Content])VALUES(3,'EventWizardInstructionsForCallCenterRep','<div style="float:left; width:350px; padding:5px"><div style="float:left; width:340px; font:normal 11px arial;">Put information here that will help the Call Center Rep like specific direction, how to get into the host location and any other useful information.</div></div>')

SET IDENTITY_INSERT [TblToolTip] OFF

------------------------------------------------------------------------------
--[TblScheduleMethod]
------------------------------------------------------------------------------
delete from [TblScheduleMethod]
SET IDENTITY_INSERT [TblScheduleMethod] ON

INSERT INTO [TblScheduleMethod] ( [ScheduleMethodID],[Name], [Description], [DateCreated], [DateModified], [IsActive])   
VALUES (1,'Phone', '', GETDATE(), GETDATE(),1)

INSERT INTO [TblScheduleMethod] ( [ScheduleMethodID],[Name], [Description], [DateCreated], [DateModified], [IsActive])   
VALUES (2,'Face to Face', '', GETDATE(), GETDATE(),1)

INSERT INTO [TblScheduleMethod] ( [ScheduleMethodID],[Name], [Description], [DateCreated], [DateModified], [IsActive])   
VALUES (3,'Email', '', GETDATE(), GETDATE(),1)

SET IDENTITY_INSERT [TblScheduleMethod] OFF

------------------------------------------------------------------------------------
--[TblCustomerHealthQuestionGroup]
--[TblCustomerHealthQuestions]
------------------------------------------------------------------------------------

delete from [TblCustomerHealthQuestions]
delete from [TblCustomerHealthQuestionGroup]

SET IDENTITY_INSERT [dbo].[TblCustomerHealthQuestionGroup] ON

INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1005,'Cardiovascular disease and family history? Have you ever:','Cardio History',1)
INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1007,'Risk Factors:','Risk Factor information',1)
INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1008,'Do you have now or have you had in the last year:','Generic information',1)
INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1009,'Specific to osteoporosis and thyroid:','osteoporosis',1)
INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1010,'Previous Exams? Have you ever had:','details about previous examination',1)
INSERT [dbo].[TblCustomerHealthQuestionGroup] ([CustomerHealthQuestionGroupID],[Name],[Description],[IsActive])VALUES(1013,'Health Insurance Provided By:','details about health insurance',1)

SET IDENTITY_INSERT [dbo].[TblCustomerHealthQuestionGroup] OFF

-----------------------------------------------------------------------------------------

INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1004,1005,'Been hospitalized for a heart attack or had any kind of heart operation?','Cardio History',124,'Yes,No',',',1,1,1,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1009,1005,'Had a procedure to improve blood flow to your heart (bypass, angioplasty, stenting)?','Cardio History',124,'Yes,No',',',1,1,2,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1010,1005,'Been hospitalized for a stroke or had an operation on your carotid arteries?','Cardio History',124,'Yes,No',',',1,1,3,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1011,1005,'Had a surgical or special procedure to improve blood flow to your legs?','Cardio History',124,'Yes,No',',',1,1,5,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1012,1005,'Had a surgical or special procedure to repair an aneurysm in your abdominal aorta?','Cardio History',124,'Yes,No',',',1,1,6,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1018,1005,'Is there an immediate family history of stroke?','Cardio History',124,'Yes,No',',',1,1,7,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1019,1005,'Is there an immediate family history of heart disease?','Cardio History',124,'Yes,No',',',1,1,8,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1022,1005,'Is there an immediate family history of abdominal aortic aneurysm?','Cardio History',124,'Yes,No',',',1,1,9,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1025,1007,'Do you smoke or use smokeless tobacco?','Risk Factors',124,'Yes,No',',',1,1,1,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1026,1007,'How many years have you smoked?','Risk Factors',126,NULL,NULL,1,1,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1027,1007,'Do you have an irregular heart beat (atrial fibrillation)?','Risk Factors',124,'Yes,No',',',1,1,2,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1028,1007,'Do you have high blood pressure or do you take medication for high blood pressure?','Risk Factors',124,'Yes,No',',',1,1,3,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1029,1007,'Do you have high cholesterol or take medication for high cholesterol?','Risk Factors',124,'Yes,No',',',1,1,4,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1030,1007,'Do you have diabetes?','Risk Factors',124,'Yes,No',',',1,1,5,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1033,1008,'Sudden weakness or numbness of face, arm, leg or one side of body?','Risk Factors',124,'Yes,No',',',1,1,1,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1034,1008,'Loss of speech, difficulty talking or difficulty understanding speech?','Risk Factors',124,'Yes,No',',',1,1,2,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1035,1008,'Sudden dimness or loss of vision, particularly in one eye?','Risk Factors',124,'Yes,No',',',1,1,3,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1036,1008,'Sudden unexplained headache or pattern of headaches?','Risk Factors',124,'Yes,No',',',1,1,4,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1037,1008,'Unexplained dizziness, unsteadiness or falls?','Risk Factors',124,'Yes,No',',',1,1,5,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1039,1008,'Cramping or pain in the legs after walking that is relieved by rest?','Risk Factors',124,'Yes,No',',',1,1,7,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1040,1008,'Burning or tingling in legs or feet?','Risk Factors',124,'Yes,No',',',1,1,8,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1041,1008,'Numbness or loss of sensation in legs or feet?','Risk Factors',124,'Yes,No',',',1,1,9,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1042,1008,'Poor wound healing in legs or feet?','Risk Factors',124,'Yes,No',',',1,1,10,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1043,1009,'Are you a post-menopausal female?','osteoporosis',124,'Yes,No',',',1,1,1,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1045,1009,'Have you ever had thyroid replacement therapy?','osteoporosis',124,'Yes,No',',',1,1,3,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1046,1009,'Have you ever had cortisone therapy (prednisone, steroids, etc.)?','osteoporosis',124,'Yes,No',',',1,1,4,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1047,1009,'Do you get less than 1000 mg of calcium per day?','osteoporosis',124,'Yes,No',',',1,1,5,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1048,1009,'Is there a lack of weight-bearing exercise in your daily routine?','osteoporosis',124,'Yes,No',',',1,1,6,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1049,1009,'Have you had a previous fracture with only mild trauma?','osteoporosis',124,'Yes,No',',',1,1,7,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1050,1009,'Have you experienced a height loss of 1-1/2 inches?','osteoporosis',124,'Yes,No',',',1,1,8,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1051,1010,'A carotid ultrasound exam?','details about previous examination',124,'Yes,No',',',1,1,1,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1052,1010,'When?','details about previous examination',126,NULL,NULL,1,1,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1053,1010,'Results:','details about previous examination',124,'Normal,Abnormal',',',1,1,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1054,1010,'An abdominal aortic ultrasound exam?','details about previous examination',124,'Yes,No',',',1,1,2,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1055,1010,'When?','details about previous examination',126,NULL,NULL,1,1,2,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1057,1010,'Results:','details about previous examination',124,'Normal,Abnormal',',',1,1,2,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1058,1010,'A peripheral arterial disease exam?','details about previous examination',124,'Yes,No',',',1,1,3,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1059,1010,'When?','details about previous examination',126,NULL,NULL,1,1,3,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1060,1010,'Results:','details about previous examination',124,'Normal,Abnormal',',',1,1,3,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1061,1010,'A previous osteoporosis exam?','details about previous examination',124,'Yes,No',',',1,1,4,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1062,1010,'When?','details about previous examination',126,NULL,NULL,1,1,4,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1063,1010,'Results:','details about previous examination',124,'Normal,Abnormal',',',1,1,4,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1064,1005,'Been told that you had a TIA (transient ischemic attack) or mini stroke?','Cardio History',124,'Yes,No',',',1,1,4,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1065,1005,'Is there an immediate family history of diabetes?','Cardio History',124,'Yes,No',',',1,1,10,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1066,1005,'Is there an immediate family history of cancer?','Cardio History',124,'Yes,No',',',1,1,11,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1067,1009,'Is there an immediate family history of osteoporosis?','osteoporosis',124,'Yes,No',',',1,1,9,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1082,1009,'Do you currently or have you taken a thyroid medication such as Snythroid?','osteoporosis',124,'Yes,No',',',1,1,10,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1083,1009,'Have you ever had a thyroid surgery of any type?','osteoporosis',124,'Yes,No',',',1,1,11,'No')
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1084,1013,'Employer’s Program','details about health insurance',125,'Yes,No',',',1,0,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1085,1013,'Spouse’s Program','details about health insurance',125,'Yes,No',',',1,0,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1086,1013,'Medicare','details about health insurance',125,'Yes,No',',',1,0,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1087,1013,'Medicaid','details about health insurance',125,'Yes,No',',',1,0,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1088,1013,'No Health Insurance','details about health insurance',125,'Yes,No',',',1,0,1,NULL)
INSERT [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID],[CustomerHealthQuestionGroupID],[Question],[Label],[ControlType],[ControlValues],[ControlValueDelimiter],[IsActive],[IsRequired],[DisplaySequence],[DefaultValue])VALUES(1089,1013,'Other','details about health insurance',125,'Yes,No',',',1,0,1,NULL)

--------------------------------------------------------------------------------------


delete from [tblAFMarketingMaterialType]
delete from [tblAFMarketingMaterialGroup]

SET IDENTITY_INSERT [dbo].[tblAFMarketingMaterialGroup] ON

INSERT INTO [tblAFMarketingMaterialGroup] ([MarketingMaterialGroupId],[Title],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Internet',NULL,'May  2 2009  5:30:51:260AM',NULL,1)
INSERT INTO [tblAFMarketingMaterialGroup] ([MarketingMaterialGroupId],[Title],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'Printed Material',NULL,'May  2 2009  5:30:51:260AM',NULL,1)
INSERT INTO [tblAFMarketingMaterialGroup] ([MarketingMaterialGroupId],[Title],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'Radio',NULL,'May  2 2009  5:30:51:260AM',NULL,1)
INSERT INTO [tblAFMarketingMaterialGroup] ([MarketingMaterialGroupId],[Title],[Description],[DateCreated],[DateModified],[IsActive])VALUES(4,'TV',NULL,'May  2 2009  5:30:51:273AM',NULL,1)

SET IDENTITY_INSERT [dbo].[tblAFMarketingMaterialGroup] OFF


---------------------------------------------------------------------------
SET IDENTITY_INSERT [dbo].[tblAFMarketingMaterialType] ON

INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(1,'BannerAd','BannerAd','BannerAd',1,'Nov  4 2008 12:18:35:000PM','Nov  4 2008 12:18:35:000PM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(2,'Text Ad','Text Ad','Text Ad',1,'Nov  4 2008 12:18:39:000PM','Nov  4 2008 12:18:39:000PM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(3,'Third Party Code','Third Party Code','Third Party Code',1,'Nov  5 2008  5:22:22:000PM','Nov  5 2008  5:21:48:000PM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(4,'Flyer','Flyer','Flyer',2,'Nov  5 2008  5:22:22:000PM','Nov  5 2008  5:21:48:000PM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(5,'Brochure','Brochure','Brochure',2,'May  2 2009  5:30:51:290AM','May  2 2009  5:30:51:290AM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(6,'Poster','Poster','Poster',2,'May  2 2009  5:30:51:290AM','May  2 2009  5:30:51:290AM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(7,'Direct Mail','Direct Mail','Direct Mail',2,'May  2 2009  5:30:51:303AM','May  2 2009  5:30:51:303AM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(8,'NewsPaper','NewsPaper','NewsPaper',2,'May  2 2009  5:30:51:303AM','May  2 2009  5:30:51:303AM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(9,'Bulletin','Bulletin','Bulletin',2,'May 13 2009  5:16:36:830AM','May 13 2009  5:16:36:830AM',1)
INSERT INTO [tblAFMarketingMaterialType] ([MarketingMaterialTypeID],[Title],[Description],[Tag],[GroupId],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(10,'Blurb','Blurb','Blurb',1,'May 13 2010  4:06:16:007AM','May 13 2010  4:06:16:007AM',1)

SET IDENTITY_INSERT [dbo].[tblAFMarketingMaterialType] OFF


---------------------------------------------------------------------------------------------------------

delete from [TblContactCallStatus]

INSERT INTO [TblContactCallStatus] ([ContactCallStatusID],[Status],[IsActive])VALUES(1,'Planned',1)
INSERT INTO [TblContactCallStatus] ([ContactCallStatusID],[Status],[IsActive])VALUES(2,'Not Held',1)
INSERT INTO [TblContactCallStatus] ([ContactCallStatusID],[Status],[IsActive])VALUES(3,'Held',1)

-----------------------------------------------------------

delete from [TblAfMarketingMaterialBannerSize]
SET IDENTITY_INSERT [dbo].[TblAfMarketingMaterialBannerSize] ON

INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(1,'300 x 250 IMU - (Medium Rectangle)','May  6 2009  4:13:32:553AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(2,'250 x 250 IMU - (Square Pop-Up)','May  6 2009  4:13:32:553AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(3,'240 x 400 IMU - (Vertical Rectangle)','May  6 2009  4:13:32:570AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(4,'336 x 280 IMU - (Large Rectangle)','May  6 2009  4:13:32:570AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(5,'180 x 150 IMU - (Rectangle)','May  6 2009  4:13:32:570AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(6,'300 x 100 IMU - (3:1 Rectangle)','May  6 2009  4:13:32:570AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(7,'720 x 300 IMU – (Pop-Under)','May  6 2009  4:13:32:587AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(8,'468 x 60 IMU - (Full Banner)','May  6 2009  4:13:32:587AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(9,'234 x 60 IMU - (Half Banner)','May  6 2009  4:13:32:587AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(10,'88 x 31 IMU - (Micro Bar)','May  6 2009  4:13:32:587AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(11,'120 x 90 IMU - (Button 1)','May  6 2009  4:13:32:600AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(12,'120 x 60 IMU - (Button 2)','May  6 2009  4:13:32:600AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(13,'120 x 240 IMU - (Vertical Banner)','May  6 2009  4:13:32:600AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(14,'125 x 125 IMU - (Square Button)','May  6 2009  4:13:32:600AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(15,'728 x 90 IMU - (Leaderboard)','May  6 2009  4:13:32:617AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(16,'160 x 600 IMU - (Wide Skyscraper)','May  6 2009  4:13:32:617AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(17,'120 x 600 IMU - (Skyscraper)','May  6 2009  4:13:32:617AM',NULL,1)
INSERT INTO [TblAfMarketingMaterialBannerSize] ([MarketingMaterialBannerSizeID],[BannerSize],[DateCreated],[DateModified],[IsActive])VALUES(18,'300 x 600 IMU - (Half Page Ad)','May  6 2009  4:13:32:617AM',NULL,1)

SET IDENTITY_INSERT [dbo].[TblAfMarketingMaterialBannerSize] OFF

SET IDENTITY_INSERT [TblNotificationMedium] ON
INSERT INTO [TblNotificationMedium] ([NotificationMediumID],[NotificationMedium],[Description],[DateCreated],[DateModified])VALUES(1,'Email',NULL,'Oct 31 2008 12:00:00:000AM','Oct 31 2008  2:37:15:000PM')
INSERT INTO [TblNotificationMedium] ([NotificationMediumID],[NotificationMedium],[Description],[DateCreated],[DateModified])VALUES(2,'Phone',NULL,'Oct 31 2008  2:38:33:000PM','Oct 31 2008  2:38:33:000PM')
INSERT INTO [TblNotificationMedium] ([NotificationMediumID],[NotificationMedium],[Description],[DateCreated],[DateModified])VALUES(3,'SMS',NULL,'Oct 31 2008 12:00:00:000AM','Oct 31 2008 12:00:00:000AM')

SET IDENTITY_INSERT [TblNotificationMedium] OFF


SET IDENTITY_INSERT [TblMedicalVendorType] ON

INSERT INTO [TblMedicalVendorType] ([MedicalVendorTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Individual','','Apr 13 2011  4:19:11:860PM','Apr 13 2011  4:19:11:860PM',1)
INSERT INTO [TblMedicalVendorType] ([MedicalVendorTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'Hospital','','Apr 13 2011  4:19:11:860PM','Apr 13 2011  4:19:11:860PM',1)
INSERT INTO [TblMedicalVendorType] ([MedicalVendorTypeID],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'RadiologyGroup','','Apr 13 2011  4:19:11:867PM','Apr 13 2011  4:19:11:867PM',1)

SET IDENTITY_INSERT [TblMedicalVendorType] OFF

------------------------------------------------------------------------------------
--[TblEmailTemplate]
-------------------------------------------------------------------------------------

delete from [TblEmailTemplate]

SET IDENTITY_INSERT [TblEmailTemplate] ON

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(1,'CustomerWelcomeEmailWithUsername','Customer Welcome Email With Username','<table style="border-collapse: collapse; border-color: black;" border="1px" cellpadding="0px"    cellspacing="0px" width="600px">    <tr>        <td>            <table style="font-family: Arial" border="0px" cellpadding="10px" cellspacing="0px"                width="600px">                <tr>                    <td style="height: 143px">                        <table border="0px" cellpadding="10px" cellspacing="0px" width="600px">                            <tr>                                <td>                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath"/>                                </td>                                <td style="color: #5DB3ED" align="right">                                    Welcome                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px">                        Dear @Model.FullName,<br />                        <br />                        Thank you for registering for screening with @Model.EmailCommunicationBaseInfo.CompanyName.<br />                        <br />                        Your Username is: <b>@Model.UserName</b><br /><br />                        If you have signed up online, you can use the password you have selected to login. However we will send you the password in a separate mail.                        <br /><br />                        Please use this Username and Password to log in to @Model.EmailCommunicationBaseInfo.CompanyName <a href="@Model.EmailCommunicationBaseInfo.LoginUrl">(@Model.EmailCommunicationBaseInfo.LoginUrl)</a> to access your account, or register for an event.                        <br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">                            @Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree&nbsp;                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl"                            target="_blank">Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl"                                target="_blank">Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your                        password or credit card number in an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you                        or someone on your behalf registered online at <a href="@Model.EmailCommunicationBaseInfo.SiteUrl"                            target="_blank">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;                        @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(2,'CustomerWelcomeEmailWithPassword','Customer Welcome Email With password','<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0"    cellspacing="0" width="600">    <tr>        <td>            <table style="font-family: Arial" border="0" cellpadding="10" cellspacing="0" width="600">                <tr>                    <td style="height: 143px">                        <table border="0" cellpadding="10" cellspacing="0" width="600">                            <tr>                                <td>                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td style="color: #5DB3ED" align="right">                                    Welcome                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px">                        Dear @Model.FullName,<br />                        <br />                        Thank you for registering for screening with @Model.EmailCommunicationBaseInfo.CompanyName.<br />                        <br />                        Your Password is: <b>@Model.Password</b><br />                        <br />                        During future sign up please use this password and login during the event registration.                        <br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank"                            href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a>                        and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                            Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card                        number in an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your                        behalf registered online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(3,'AppointmentConfirmationWithEventDetails','Appointment Confirmation With Event Details','<table width="600" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;    border-color: black;">    <tr>        <td style="vertical-align: top;">            <table width="600" cellpadding="2" cellspacing="0" border="0" style="font-family: Arial">                <tr>                    <td style="height: 100px">                        <table width="600" cellpadding="2" cellspacing="0" border="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Screening Appointment Confirmation&nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 13px">                        Dear @Model.CustomerName,<br />                        <br />                        Below are your preventive screening appointment details:<br />                        <br />                        When:&nbsp;&nbsp;<b>@Model.EventDate.ToString("MM/dd/yyyy") at @Model.AppointmentTime.ToString("hh:mm                            tt")</b><br />                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color: black;                            font: 13px Arial">                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 50px">                                    &nbsp;                                </td>                                <td class="normaltxt_pw" style="font-size: 13px">                                    &nbsp;                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 50px">                                    Where:&nbsp;<br />                                </td>                                <td class="normaltxt_pw" style="font-size: 13px">                                    <b>@Model.AddressOfVenue.ToString()</b> <a href="http://maps.google.com/maps?f=q&hl=en&geocode=&q=@Model.AddressOfVenue.StreetAddressLine1,@Model.AddressOfVenue.City,@Model.AddressOfVenue.State,@Model.AddressOfVenue.ZipCode&ie=UTF8&z=16"                                        target="_blank">[Map to the location]</a>                                    <br />                                </td>                            </tr>                        </table>                        <br />                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font: normal 12px arial">                            <tr>                                <td colspan="2" style="font-weight: bold">                                    <u>Order Detail</u>                                </td>                            </tr>                            <tr>                                <td width="17%" valign="top">                                    Package:                                </td>                                <td width="83%" valign="top">                                    <b>@Model.Packages.Name</b>                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        @foreach( var test in Model.Packages.Tests) {                                        <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                        }                                    </ul>                                </td>                            </tr>                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            @if(Model.Tests!=null) {                            <tr>                                <td width="17%" valign="top">                                    Additional Test(s):                                </td>                                <td valign="top">                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        <strong>@foreach( var test in Model.Tests) {                                            <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                            } </strong>                                    </ul>                                </td>                            </tr>                            }                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Screening Price:                                </td>                                <td valign="top">                                    <b>$@Model.PackagePrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Product Price:                                </td>                                <td valign="top">                                    <b>$@Model.AddlnProductPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Shipping Price:                                </td>                                <td valign="top">                                    <b>$@Model.ShippingPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Order Value:                                </td>                                <td valign="top">                                    <strong>$@Model.TotalDue.ToString("0.00"), @Model.PaymentStatus</strong>                                </td>                            </tr>                        </table>                        <br />                        <i>*If payment status is ''Unpaid'', please bring payment to your scheduled appointment                            in the form of credit card, check or cash. If ''Paid'', thank you for your participation.</i><br />                        <br />                        <b>Preparation for the screening:</b> To learn how to prepare for your screening                        please follow the link below:<br />                        <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TestPreparationInstructions">                            @Model.EmailCommunicationBaseInfo.TestPreparationInstructions</a><br />                        (If the link is not clickable, please copy and paste it into your browser&rsquo;s                        address field.)<br />                        <br />                        We applaud you for taking a proactive approach to your health and look forward to                        seeing you for this valuable health screening.<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!You                        may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a>                        or @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">                            Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                                Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or creditcard number in                        an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered                        online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;                        @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(4,'ScreeningReminderMail','ScreeningReminderMail','<table width="600" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;    border-color: black;">    <tr>        <td style="vertical-align: top;">            <table width="600" cellpadding="2" cellspacing="0" border="0" style="font-family: Arial">                <tr>                    <td style="height: 100px">                        <table width="600" cellpadding="2" cellspacing="0" border="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Screening Appointment Reminder&nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px">                        Dear @Model.CustomerName,<br />                        <br />                        Please find this email as a reminder of your preventive health screening with us.                        Below are your preventive screening appointment details:<br />                        <br />                        When:&nbsp;&nbsp;<b>@Model.EventDate.ToString("MM/dd/yyyy") at @Model.AppointmentTime.ToString("hh:mm                            tt")</b><br />                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color: black;">                            <tr>                                <td style="font-size: 13px; vertical-align: top;">                                    Where:                                </td>                                <td style="font-size: 13px">                                    <b>@Model.AddressOfVenue.ToString()</b> <a href="http://maps.google.com/maps?f=q&hl=en&geocode=&q=@Model.AddressOfVenue.StreetAddressLine1,@Model.AddressOfVenue.City,@Model.AddressOfVenue.State,@Model.AddressOfVenue.ZipCode&ie=UTF8&z=16"                                        target="_blank">[Map to the location]</a>                                    <br />                                </td>                            </tr>                        </table>                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font: normal 12px arial">                            <tr>                                <td colspan="2" style="font-weight: bold">                                    <u>Order Detail</u>                                </td>                            </tr>                            <tr>                                <td width="17%" valign="top">                                    Package:                                </td>                                <td width="83%" valign="top">                                    <b>@Model.Packages.Name</b>                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        @foreach( var test in Model.Packages.Tests) {                                        <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                        }                                    </ul>                                </td>                            </tr>                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            @if(Model.Tests!=null) {                            <tr>                                <td width="17%" valign="top">                                    Additional Test(s):                                </td>                                <td valign="top">                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        <strong>@foreach( var test in Model.Tests) {                                            <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                            } </strong>                                    </ul>                                </td>                            </tr>                            }                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Screening Price:                                </td>                                <td valign="top">                                    <b>$@Model.PackagePrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Product Price:                                </td>                                <td valign="top">                                    <b>$@Model.AddlnProductPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Shipping Price:                                </td>                                <td valign="top">                                    <b>$@Model.ShippingPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Order Value:                                </td>                                <td valign="top">                                    <strong>$@Model.TotalDue.ToString("0.00"), @Model.PaymentStatus</strong>                                </td>                            </tr>                        </table>                        <br />                        <i>*If payment status is ''Unpaid'', please bring payment to your scheduled appointment                            in the form of credit card, check or cash. If ''Paid'', thank you for your participation.</i><br />                        <br />                        <b>Preparation for the screening:</b> To learn how to prepare for your screening                        please follow the link below:<br />                        <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TestPreparationInstructions">                            @Model.EmailCommunicationBaseInfo.TestPreparationInstructions</a><br />                        (If the link is not clickable, please copy and paste it into your browser&rsquo;s                        address field.)<br />                        <br />                        We applaud you for taking a proactive approach to your health and look forward to                        seeing you for this valuable health screening.<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">                            @Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">                            Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                                Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or creditcard number in                        an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered                        online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;                        @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(5,'LoginIssuesSendPassword','Login Issues Send Password','<table border="1" width="600" cellpadding="0" cellspacing="0" style="border-collapse: collapse;    border-color: black;">    <tr>        <td style="width: 600px; border: 1px">            <table border="0" width="600" cellpadding="10" cellspacing="0" style="font-family: Arial">                <tr>                    <td style="height: 143px">                        <table border="0" width="600" cellpadding="10" cellspacing="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath"/>                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Password Reset Request&nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        Dear  @Model.FullName,<br />                        <br />                        We have received your request to retreive your password on @Model.EmailCommunicationBaseInfo.SiteUrl.<br />                        <br />                        Your temporary password is: <b>@Model.Password</b><br />                        <br />                        You can login to the @Model.EmailCommunicationBaseInfo.CompanyName online system at: @Model.EmailCommunicationBaseInfo.LoginUrl using the                        username and temporary password provided above. Once you login, you will be asked                        to change your password to something you can remember.<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank"                            href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                                Terms of Service</a><br />                        Reminder:  @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in                        an email.<br />                        <br />                        This email was sent by  @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered                        online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(6,'LoginIssuesSendUsername','Login Issues Send UserName','<table style="border-collapse: collapse; border-color: black;" border="1px" cellpadding="0px"    cellspacing="0px" width="600px">    <tr>        <td style="width: 600px; border: 1px">            <table style="font-family: Arial" border="0px" cellpadding="10px" cellspacing="0px"                width="600px">                <tr>                    <td style="height: 143px">                        <table border="0px" cellpadding="10px" cellspacing="0px" width="600px">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td style="color: #5DB3ED; width: 350px" align="right">                                    Username Retrieve Request&nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        Dear @Model.FullName,<br />                        <br />                        We have received your request to retrieve username on @Model.EmailCommunicationBaseInfo.SiteUrl<sup>&reg;</sup>.<br />                        <br />                        Your User Name is: <b>@Model.UserName</b><br />                        <br />                        You can login to the @Model.EmailCommunicationBaseInfo.CompanyName online system at: @Model.EmailCommunicationBaseInfo.LoginUrl using this                        username and password with you.<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl"                            target="_blank">Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl" target="_blank">                                Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in                        an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered                        online at <a href="@Model.EmailCommunicationBaseInfo.SiteUrl" target="_blank">@Model.EmailCommunicationBaseInfo.SiteUrl</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(7,'ResetPassword','Reset Password','<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0"    cellspacing="0" width="600">    <tr>        <td style="width: 600px; border: 1px">            <table style="font-family: Arial" border="0" cellpadding="10" cellspacing="0" width="600">                <tr>                    <td style="height: 143px">                        <table border="0" cellpadding="10" cellspacing="0" width="600">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.AppUrl/Config/Content/Images/Logo-Small-160x60.gif" />                                </td>                                <td style="color: #5DB3ED; width: 350px" align="right">                                    Password Reset Request&nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        Dear @Model.FullName,<br />                        <br />                        We have received your request to reset your password on @Model.EmailCommunicationBaseInfo.SiteUrl.<br />                        <br />                        To complete the password reset process you need to click on the link given below                        and this link is for single time use:<br />                        <br />                        <a target="_blank" href="@Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString">                            @Model.EmailCommunicationBaseInfo.AppUrl/App/ResetPassword.aspx?UserID=@Model.UserId&amp;AuthStr=@Model.ResetPasswordQueryString</a><br />                        (If the link is not clickable, please copy and paste it into your browser&rsquo;s                        address field.)<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!                        You may contact us at <a href="mailto:@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree                        (Toll free).<br />                        <br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName Team<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank"                            href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                                Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or credit card number in                        an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered                        online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(8,'EmployeeWelcomeEmailWithUsername','Employee Welcome Email With Username','<table style="font-family: Verdana, Arial; color: Gray; font-size: 14">    <tr>        <td>            Dear @Model.FullName,<br />            <br />            Your account has been setup with <b>@Model.EmailCommunicationBaseInfo.ProductName</b>            <br />            Your User Name is : @Model.UserName<br />            <br />            Your Password will be send in an seperate email due to security issues.            <br />            Please confirm joining the @Model.EmailCommunicationBaseInfo.CompanyName by logging            in the Application:<br />            <a href="@Model.EmailCommunicationBaseInfo.LoginUrl">@Model.EmailCommunicationBaseInfo.LoginUrl</a><br />            <br />            (If the link is not clickable, please copy and paste it into your browser&rsquo;s            address field.)<br />            <br />            If you ever need to contact us, we&rsquo;are just an email away.            <br />            <br />            You can reach us at @Model.EmailCommunicationBaseInfo.SupportEmail.<br />            <br />            <font size="1">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">                Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                    Terms of Service</a></font>            <br />            <br />            <font size="1">Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask                for your password or credit card number in an email.</font><br />            <br />        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(9,'EmployeeWelcomeEmailWithPassword','Employee Welcome Email With Password','<table style="font-family: Verdana, Arial; color: Gray; font-size: 14">    <tr>        <td>            Dear @Model.FullName,<br />            <br />            Your account has been setup with <b>@Model.EmailCommunicationBaseInfo.ProductName</b>            <br />            Your Password is : @Model.Password<br />            <br />            Please confirm joining the @Model.EmailCommunicationBaseInfo.CompanyName by logging            in the Application:<br />            <a href="@Model.EmailCommunicationBaseInfo.LoginUrl">@Model.EmailCommunicationBaseInfo.LoginUrl</a><br />            <br />            (If the link is not clickable, please copy and paste it into your browser&rsquo;s            address field.)<br />            <br />            If you ever need to contact us, we&rsquo;are just an email away.            <br />            <br />            You can reach us at @Model.EmailCommunicationBaseInfo.SupportEmail.<br />            <br />            <font size="1">&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">                Privacy Policy</a> and <a href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">                    Terms of Service</a></font>            <br />            <br />            <font size="1">Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask                for your password or credit card number in an email.</font><br />            <br />        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate] 
(	[EmailTemplateID], [EmailTitle], [EmailSubject],	[EmailBody],	[DateCreated],	[DateModified]) 
VALUES 
( 10,	 'GiftCertificateClaimCodeEmail',	 'Gift Certificate Claim Code',	 '<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0" cellspacing="0" width="600"> <tr> <td style="width: 600px; border: 1px"> <table style="font-family: Arial" border="0" cellpadding="10" cellspacing="0" width="600"> <tr> <td style="height: 113px"> <table border="0" cellpadding="10" cellspacing="0" width="600"> <tr> <td style="width: 250px"> <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" /> </td> <td style="color: #5DB3ED; width: 350px" align="right"> @Model.EmailCommunicationBaseInfo.CompanyName Gift Certificate&nbsp; </td> </tr> </table> </td> </tr> <tr><td style="font-size: 13px; font-weight: bold; width: 600px"> @Model.FromName has sent you a @Model.EmailCommunicationBaseInfo.CompanyName Gift Certificate to use when purchasing a @Model.EmailCommunicationBaseInfo.CompanyName Preventive Screening. </td></tr><tr><td style="font-size: 13px; width: 600px;"><b>@Model.EmailCommunicationBaseInfo.CompanyName</b> is a leading preventive screening provider focused on identifying underlying Heart &amp; Stroke risk in asymptomatic individuals, like you. Screenings are completely painless AND are conducted in the convenience of your own neighborhood at community centers, schools, and even faith-based organizations.</td></tr><tr><td style="font-size: 13px; width: 600px">Dear @Model.ToName,<br /><br />Congratulations! You have been sent a @Model.EmailCommunicationBaseInfo.CompanyName gift certificate from @Model.FromName, in the amount of $@(Model.Value.ToString("0.00")). Not only is this a valuable gift, but it is one that could actually save your life. @Model.EmailCommunicationBaseInfo.CompanyName screenings are the same tests provided by leading clinics and hospitals for as much as $2,000.<br /> <br /> <b>Message from @Model.FromName:</b> "<i>@Model.Message</i>"<br /> <br /> <table style="border-top: solid 1px #88c0d6; border-bottom: solid 1px #88c0d6;" bgcolor="#f3fcff" border="0" cellpadding="0" cellspacing="0" width="100%"><tr> <td style="text-align: center">&nbsp;</td></tr><tr><td style="text-align: center">YOUR CLAIM CODE</td></tr><tr><td style="text-align: center; font: bold 16px arial">@Model.ClaimCode<br />Value: $@Model.Value.ToString("0.00")</td></tr><tr><td style="text-align: center"><a href="@Model.EmailCommunicationBaseInfo.SiteUrl">Purchase Screening</a></td></tr><tr><td style="text-align: center">&nbsp;</td></tr></table><br /><br />How to redeem your @Model.EmailCommunicationBaseInfo.CompanyName Gift Certificate? <ol> <li>Go to <a href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl</a></li><li>Search for a screening event in your neighborhood using the zip code search tool</li><li>Click on the preferred screening date/location</li><li>Register for the screening package of your choice</li><li>Pick your appointment time of your choice</li><li>Enter the &lsquo;Claim Code&rsquo; above, as your mode of payment on the payment page of the signup process to redeem your @Model.EmailCommunicationBaseInfo.CompanyName Gift Certificate.</li></ol> <br /><br /> @Model.EmailCommunicationBaseInfo.CompanyName Team<br /></td></tr><tr><td><hr style="border: 1px; color: Black" /></td></tr><tr><td style="font-size: 12px; color: Gray"><div style="font: normal 8pt arial; color: #999;"><div style="padding: 0px" class="grayinfotxt"><sup>*</sup><i>No expiration date. All sales are final. Not returnable or refundable for cash.</i></div></div><br /><br />&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">Terms of Service</a><br />Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or creditcard number in an email.<br /><br />This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br /><br /><b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;@Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />@Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)</td></tr></table></td></tr></table>',	GETDATE(),	GETDATE() ) 


INSERT INTO [TblEmailTemplate] 
	( [EmailTemplateID], [EmailTitle], [EmailSubject],	[EmailBody],	[DateCreated],	[DateModified]) 
VALUES 
	( 11,	 'GiftCertificateAcknowledgmentEmail',	 'Gift Certificate Acknowledgment',	 '<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0" cellspacing="0" width="600"><tr><td style="vertical-align: top;"><table style="font-family: Arial" border="0" cellpadding="2" cellspacing="0" width="600"><tr><td style="height: 100px"><table border="0" cellpadding="2" cellspacing="0" width="600"><tr><td style="width: 250px"><img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" /> </td><td style="color: #5DB3ED; width: 350px" align="right">Gift Certificate Acknowledgement&nbsp; </td></tr></table></td></tr><tr><td style="font-size: 13px" class="normaltxt_pw">Dear @Model.FromName,<br/><br/>Thank you for purchasing a gift certificate from @Model.EmailCommunicationBaseInfo.CompanyName for $@Model.Value. This email is a confirmation that your transaction was completed successfully. Below are the details of the Gift Certificate:<br/><br/>Claim Code: <b>@Model.ClaimCode</b><br/>Purchased For: <b>@Model.ToName</b><br/><br/>Please note @Model.ToName will get a separate email with the claim code and instructions on how to use it. If you wish, you can also give them this claim code and ask them to call our customer service number. They will help @Model.ToName get setup for a @Model.EmailCommunicationBaseInfo.CompanyName screening. <br/><br/>If you ever need to contact us, we&rsquo;re just an email or a phone call away! You may contact us at <a href="@Model.EmailCommunicationBaseInfo.SupportEmail">@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free). <br/><br/>- The @Model.EmailCommunicationBaseInfo.CompanyName Team<br/></td></tr><tr><td><hr style="border: 1px; color: Black"/></td></tr><tr><td style="font-size: 12px; color: Gray" class="normaltxt_pw"><div style="font: normal 8pt arial; color: #999;"><div style="padding: 0px" class="grayinfotxt"><sup>*</sup><i>No expiration date. All sales are final. Not returnable or refundable for cash.</i></div></div><br /><br />&copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a> and <a target="_blank" href="@Model.EmailCommunicationBaseInfo.TermsConditionsUrl">Terms of Service</a><br />Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or creditcard number in an email.<br /><br />This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a target="_blank" href="@Model.EmailCommunicationBaseInfo.SiteUrl">@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br /><br /><b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />@Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;@Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />@Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)</td></tr></table></td></tr></table>',	GETDATE(),	GETDATE() ) 

INSERT INTO [TblEmailTemplate] ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES(12,'ResultsReady','Result Ready Online','<table style="border-collapse: collapse; border-color: black;" border="1" cellpadding="0" cellspacing="0" width="600">    <tr>        <td style="width: 600px; border: 1px">            <table style="font-family: Arial" border="0" cellpadding="10" cellspacing="0" width="600">                <tr>                    <td style="height: 143px">                        <table border="0" cellpadding="10" cellspacing="0" width="600">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td style="color: #5DB3ED; width: 350px" align="right">                                    <span style="font: bold 14px arial; color: #287AA8;">Health Screening Results Ready Online</span>                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td style="font-size: 13px; width: 600px">                        Dear @Model.CustomerName,<br />                        <br />                        Thank you for attending a @Model.EmailCommunicationBaseInfo.CompanyName Preventive Screening event. Your results were reviewed by a board-certified physician, and are now available online.<br />                        <br />                        Please point your web browser to the link below:<br />                        <br />                        <a href="@Model.EmailCommunicationBaseInfo.LoginUrl">@Model.EmailCommunicationBaseInfo.LoginUrl</a>                        <br />                        <span style="font: normal 11px arial; color: #666;">(If the link is not clickable, please copy and paste it into your browser&rsquo;s address field.)</span><br />                        <br />                        You will be asked for your username <b>(@Model.UserName)</b> and password, which were established when your account was created. If you do not remember your password, you can recover it online (<a href=@Model.EmailCommunicationBaseInfo.LoginUrl + "/Public/LoginManagement/ResetPasswordStep1.aspx"> click here</a>), or by calling our Call Center toll free at @Model.EmailCommunicationBaseInfo.PhoneTollFree.<br />                        <br />                        Once you log in to your personalized portal, you will be able to view your Clinical Form by clicking on the orange button labeled "Download Clinical Form". You can view your results online, print them, and take them to your physician.<br />                        <br />                        If you ever need to contact us, we&rsquo;re just an email or a phone call away!You may contact us at <a href="mailto:" @Model.EmailCommunicationBaseInfo.SupportEmail>@Model.EmailCommunicationBaseInfo.SupportEmail</a> or @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free).<br />                        <br />                        - The @Model.EmailCommunicationBaseInfo.CompanyName<br />                    </td>                </tr>                <tr>                    <td>                        <hr style="border: 1px; color: Black" />                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 12px; color: Gray">                        &copy; @Model.EmailCommunicationBaseInfo.CopyrightText <a target="_blank" href="@Model.EmailCommunicationBaseInfo.PrivacyPolicyUrl">Privacy Policy</a> and <a target="_blank" href=@Model.EmailCommunicationBaseInfo.TermsConditionsUrl>Terms of Service</a><br />                        Reminder: @Model.EmailCommunicationBaseInfo.CompanyName will never ask for your password or creditcard number in an email.<br />                        <br />                        This email was sent by @Model.EmailCommunicationBaseInfo.CompanyName because you or someone on your behalf registered online at <a target="_blank" href=@Model.EmailCommunicationBaseInfo.SiteUrl>@Model.EmailCommunicationBaseInfo.SiteUrl.</a><br />                        <br />                        <b>@Model.EmailCommunicationBaseInfo.CompanyName</b><br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp; @Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>','Mar 26 2008 12:00:00:000AM','Oct 23 2009  6:30:15:060PM')

INSERT INTO [TblEmailTemplate]([EmailTemplateID], [EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES
	(13,'AppointmentBookedInTwentyFourHours','Appointment Booked For Very Recent Event', '<table width="600" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse; border-color: black;">    <tr>        <td style="vertical-align: top;">            <table width="600" cellpadding="2" cellspacing="0" border="0" style="font-family: Arial">                <tr>                    <td style="height: 100px">                        <table width="600" cellpadding="2" cellspacing="0" border="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Last Minute Appointment Booked &nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 13px">                        Hi,<br />                        <br />                        An appointment has been booked for event ID @Model.EventId, which is scheduled on @Model.EventDate.ToString("MM/dd/yyyy"), (appointment time is at @Model.AppointmentTime.ToString("hh:mm tt")).                        <br />                        <u>The details of the Customer is</u>                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color: black; font: 13px Arial">                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    Customer Name : @Model.CustomerName (@Model.CustomerId)                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    Address : @Model.AddressOfCustomer.StreetAddressLine1 @Model.AddressOfCustomer.StreetAddressLine2 @Model.AddressOfCustomer.City, @Model.AddressOfCustomer.State - @Model.AddressOfCustomer.ZipCode                                </td>                            </tr>                        </table>                        <br />                        <table width="100%" border="0" cellspacing="0" cellpadding="0" style="font: normal 12px arial">                            <tr>                                <td colspan="2" style="font-weight: bold">                                    <u>The customer has Ordered the following</u>                                </td>                            </tr>                            <tr>                                <td width="17%" valign="top">                                    Package:                                </td>                                <td width="83%" valign="top">@if (Model.Packages != null){                                   <b>@Model.Packages.Name</b>                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        @foreach( var test in Model.Packages.Tests) {                                        <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                        }                                    </ul>  }                              </td>                            </tr>                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            @if(Model.Tests!=null) {                            <tr>                                <td width="17%" valign="top">                                    Additional Test(s):                                </td>                                <td valign="top">                                    <ul style="margin: 0 0 0 15px; padding: 0 0 0 10px">                                        <strong>@foreach( var test in Model.Tests) {                                            <li style="margin: 0px 10px; padding: 0px 0px; list-style: disc;">@test.Name </li>                                            } </strong>                                    </ul>                                </td>                            </tr>                            }                            <tr>                                <td colspan="2">                                    &nbsp;                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Screening Price:                                </td>                                <td valign="top">                                    <b>$@Model.PackagePrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Product Price:                                </td>                                <td valign="top">                                    <b>$@Model.AddlnProductPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Shipping Price:                                </td>                                <td valign="top">                                    <b>$@Model.ShippingPrice.ToString("0.00")</b>                                </td>                            </tr>                            <tr>                                <td valign="top">                                    Order Value:                                </td>                                <td valign="top">                                    <strong>$@Model.TotalDue.ToString("0.00"), @Model.PaymentStatus</strong>                                </td>                            </tr>                        </table>   <br />                     - The @Model.EmailCommunicationBaseInfo.CompanyName<br />                    </td>                </tr>            </table>        </td>    </tr></table>',getDate(),getDate())

INSERT INTO [TblEmailTemplate]
           ([EmailTemplateID], [EmailTitle] ,[EmailSubject] ,[EmailBody] ,[DateCreated] ,[DateModified])
VALUES
	(14, 'CriticalCustomer','Critical Customer', '<table width="600" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;    border-color: black;">    <tr>        <td style="vertical-align: top;">            <table width="600" cellpadding="2" cellspacing="0" border="0" style="font-family: Arial">                <tr>                    <td style="height: 100px">                        <table width="600" cellpadding="2" cellspacing="0" border="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Critical Customer &nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 13px">                        Hi,<br />                        <br />                        A patient has been marked critical during screening.                        <br />                        <br />                        <u>The details of the Patient are</u>                        <table cellpadding="0" cellspacing="0" style="border-collapse: collapse; border-color: black;                            font: 13px Arial">                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    <b>PID :</b> @Model.CustomerId                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    <b>Event Date :</b> @Model.EventDate.ToString("MM/dd/yyyy")                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    <b>Event ID :</b> @Model.EventId                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    <b>POD :</b> @Model.Pod                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 100%">                                    <b>Hospital Partner :</b> @Model.HospitalPartner                                </td>                            </tr>                        </table>                        @if(Model.Tests !=null && Model.Tests.Count()>0) {                        <br />                        <u>Critical Test(s) Detail</u> @foreach (var test in Model.Tests) {                        <br />                        <table cellpadding="0" cellspacing="0" border="0" style="border-collapse: collapse;                            font: 13px Arial">                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 31%">                                    <b>Test :</b>                                </td>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 69%">                                    @test.TestName                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 31%">                                    <b>Critical Care Criteria :</b>                                </td>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 69%">                                    @test.TechnicianNotes                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 31%">                                    <b>Physician Recommendation :</b>                                </td>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 69%">                                    @test.TechnicianNotesForPhysician                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 31%">                                    <b>Technician :</b>                                </td>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 69%">                                    @test.TechnicianName                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 31%">                                    <b>Validating Technician :</b>                                </td>                                <td class="normaltxt_pw" style="font-size: 13px; vertical-align: top; width: 69%">                                    @test.ValidatingTechnicianName                                </td>                            </tr>                        </table>                        <br />                        } }                        <br />                        - @Model.EmailCommunicationBaseInfo.CompanyName <span>Team</span><br />                    </td>                </tr>            </table>        </td>    </tr></table>', getDate(), getDate())

INSERT INTO [TblEmailTemplate]
           ([EmailTemplateID],[EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified])
VALUES
(15, 'EvaluationReminder','Evaluation Reminder', '<table width="600" cellpadding="0" cellspacing="0" border="1" style="border-collapse: collapse;    border-color: black;">    <tr>        <td style="vertical-align: top;">            <table width="600" cellpadding="2" cellspacing="0" border="0" style="font-family: Arial">                <tr>                    <td style="height: 100px">                        <table width="600" cellpadding="2" cellspacing="0" border="0">                            <tr>                                <td style="width: 250px">                                    <img src="@Model.EmailCommunicationBaseInfo.EmailNotificationLogoRelativePath" />                                </td>                                <td align="right" style="color: #5DB3ED; width: 350px">                                    Evaluation Reminder &nbsp;                                </td>                            </tr>                        </table>                    </td>                </tr>                <tr>                    <td class="normaltxt_pw" style="font-size: 13px">                        Dear @Model.PhysicianName,<br />                        <br />                        This is a routine reminder about the pending evaluation patient files in your queue.                        <br />                        <br />                        <u>Details:</u>                        <br />                        <br />                        <table cellpadding="0" border="1" cellspacing="0" style="border: 1px solid black;                            font: 13px Arial">                            <tr>                                <th>                                    Evaluation Type                                </th>                                <th style="text-align: center">                                    Pending                                </th>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px;">                                    Primary                                </td>                                <td style="text-align: center">                                    @Model.PrimaryEvaluationQueueCount                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px;">                                    Overread                                </td>                                <td style="text-align: center">                                    @Model.OverReadEvaluationQueueCount                                </td>                            </tr>                            <tr>                                <td class="normaltxt_pw" style="font-size: 13px;">                                    Critical                                </td>                                <td style="text-align: center">                                    @Model.CriticalEvaluationQueueCount                                </td>                            </tr>                        </table>                        <br />                        <br />                        - @Model.EmailCommunicationBaseInfo.CompanyName <span>Team</span><br />                        <br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine1<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.StreetAddressLine2<br />                        @Model.EmailCommunicationBaseInfo.CompanyAddress.City, @Model.EmailCommunicationBaseInfo.CompanyAddress.State&nbsp;@Model.EmailCommunicationBaseInfo.CompanyAddress.ZipCode<br />                        @Model.EmailCommunicationBaseInfo.PhoneTollFree (Toll free)                    </td>                </tr>            </table>        </td>    </tr></table>', getDate(), getDate())

SET IDENTITY_INSERT [TblEmailTemplate] OFF

------------------------------
IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='Competitor')  Begin  INSERT INTO [dbo].[TblGlobalConfiguration]  ([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  VALUES  ('Competitor','Competitor','1', getdate(),getdate(),'Life Line Screening|ABC Care',NULL,NULL,'Admin','Varchar','|')  End 

----------------------------------------------------------------

SET IDENTITY_INSERT [TblScripts] ON

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(15,'Welcome Script','description','Thank you for calling ABC Care! This is <<Your Name>>, how may I help you?','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1,1,9)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(25,'Above 40','description','You will not be 40 on the day of the event. Vascular Screenings for people < 40 years of age are typically NOT recommended.  Exceptions include (i) having a family history of vascular and/or heart disease, (ii) extensive risk factors, or (iii) a doctor recommending your participation.  Do you understand the information I just provided you?  Do you wish to move forward scheduling a ABC Care! screening appointment?','Feb  2 2008 12:00:00:000AM','Apr 30 2008  6:35:11:180AM',1,1,18)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(26,'Conclusion Script','description','Thank you for calling ABC Care!  Please remember to tell your family and friends about the health screening.  You could save a life.','Feb  2 2008 12:00:00:000AM','Apr 30 2008  6:39:18:883AM',1,1,19)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(30,'BestCase','description','You have all the details with you, just go for login to your account on www.ABCCare.org. Good luck !!!','Oct  6 2008 12:00:00:000AM','Oct  6 2008 12:00:00:000AM',1,1,20)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(31,'OutboundOnlineProspect','Outbound Online Prospect Call','"Hello, may I speak to <span style="color: #F37C00"><<prospect>></span>. Hi <span style="color: #F37C00"><<prospect>></span>, my name is <span style="color: #F37C00"><<employee>></span> and I work for ABC Care! Preventive Screening. I noticed that you had logged onto our website, and started to signup for a screening.  I simply wanted to give you a courtesy call and see if there is anything I can help with, or any questions I can answer."','Mar  6 2009  4:20:28:540AM','Mar  6 2009  4:20:28:540AM',1,1,22)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(32,'OutboundCallCenterProspect','Outbound CallCenter Prospect Call','"Hello, may I speak to <span style="color: #F37C00"><<prospect>></span>. Hi <span style="color: #F37C00"><<prospect>></span>, my name is <span style="color: #F37C00"><<employee>></span> and I work for ABC Care! Preventive Screening.  I noticed that you had called in, and started to signup for a screening.  However, for some reason you did not complete the appointment process.  I simply wanted to give you a courtesy call and see if there are any questions I can answer, or anything other information I can provide which might help you complete the signup process."','Mar  6 2009  4:20:28:557AM','Mar  6 2009  4:20:28:557AM',1,1,23)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(34,'OutboundSeminarProspect','Outbound Seminar Prospect Call','"Hello, may I speak to <span style="color: #F37C00"><<prospect>></span>. Hi <span style="color: #F37C00"><<prospect>></span>, my name is <span style="color: #F37C00"><<employee>></span> and I work for ABC Care! Preventive Screening. As you have attended Wellnesss Seminar "<<SeminarName>>" on <<SeminarDate>>. I simply wanted to give you a courtesy call and see if there are any questions I can answer, or anything other information I can provide which might help you complete the signup process."','Aug 14 2009  3:32:56:450AM','Aug 14 2009  3:32:56:450AM',1,1,25)

SET IDENTITY_INSERT [TblScripts] OFF

--------------------------------------------------------------------
SET IDENTITY_INSERT [TblShippingOption] ON


INSERT INTO [TblShippingOption] ([ShippingOptionID],[Type],[CarrierID],[Description],[Price],[CostToCompany],[Disclaimer],[ShippableToPOBox],[IsActive],[DateCreated],[DateModified],[Name])
VALUES(1,1,1,'In addition to Unlimited Online Results, a high-quality color printout of your online results packet, including all medical device output and ultrasound images, will be shipped via United States Postal Service (USPS) to your address on file.  USPS results are typically delivered in 3 to 4 business days; however USPS warns that this may vary depending on the time of year and holiday schedule.  P.O. Boxes <u>are</u> acceptable for USPS shipments.',0.00,0.00,'P.O. Boxes <u>are</u> acceptable for USPS shipments.<br/>Re-shipment(s) due to incorrect address information are the responsibility of the customer.',0,1,'Dec 28 2009  2:27:31:303PM','Dec 28 2009  2:27:31:303PM','No images 3 weeks (standard shipping)')

INSERT INTO [TblShippingOption] ([ShippingOptionID],[Type],[CarrierID],[Description],[Price],[CostToCompany],[Disclaimer],[ShippableToPOBox],[IsActive],[DateCreated],[DateModified],[Name])
VALUES(2,1,1,'In addition to Unlimited Online Results, a high-quality color printout of your online results packet, including all medical device output and ultrasound images, will be shipped via FedEx Ground to your address on file.  FedEx Ground provides a tracking number for your shipment, is typically delivered in 3 to 4 business days; however FedEx warns that this may vary depending on the time of year and holiday schedule.  P.O. Boxes are <u>not</u> acceptable for any FedEx shipments.  Physical mailing addresses <u>are</u> required by FedEx.',5.99,0.00,'P.O. Boxes are <u>not</u> acceptable for FedEx shipments.<br />Physical mailing addresses <u>are</u> required by FedEx.<br /> Re-shipment(s) due to incorrect address information are the responsibility of the customer.',0,1,'Dec 28 2009  2:27:35:820PM','Dec 28 2009  2:27:35:820PM','No images (rush shipping)')

INSERT INTO [TblShippingOption] ([ShippingOptionID],[Type],[CarrierID],[Description],[Price],[CostToCompany],[Disclaimer],[ShippableToPOBox],[IsActive],[DateCreated],[DateModified],[Name])
VALUES(3,1,2,'Included in the price of CD',0.00,0.00,'',0,1,GETDATE(),GETDATE(),'CD Shipping')

SET IDENTITY_INSERT [TblShippingOption] OFF

------------------------------------------------------------------

delete from [TblProduct]

SET IDENTITY_INSERT [dbo].[TblProduct] ON

	INSERT INTO [dbo].[TblProduct]
           ([ProductID],[Name],[ShortDescription],[Description],[Price],[Weight],[Height],[Width],[Depth],[DateCreated],[IsActive])
     VALUES
           (1,'Premium Version PDF', 'Premium Version PDF','',20.00,null,null,null,null,getdate(),0)



	INSERT INTO [dbo].[TblProduct]
           ([ProductID],[Name],[ShortDescription],[Description],[Price],[Weight],[Height],[Width],[Depth],[DateCreated],[IsActive])
     VALUES
           (2,'Ultrasound Images', 'This CD shows the moving images of your echocardiogram and digital images of your carotid ultrasound and Abdominal Aortic Ultrasound. This CD is very beneficial in preventing retesting and your doctor can use it in comparison studies in the future.','',25.00,null,null,null,null,getdate(),1)

SET IDENTITY_INSERT [dbo].[TblProduct] OFF

INSERT INTO TblProductShippingOption (ProductId, ShippingOptionId,IsShowVisible)
VALUES (2,3,0)

----------------------------------------------------------------------------------------
--[TblCustomerSurveyQuestion]
--[TblCustomerSurveyQuestionAnswer]
-----------------------------------------------------------------------------------------
delete from [TblCustomerSurveyQuestionAnswer]
delete from [TblCustomerSurveyQuestion]

SET IDENTITY_INSERT [TblCustomerSurveyQuestion] ON

INSERT INTO [TblCustomerSurveyQuestion] ([CustomerSurveyQuestionID],[Question],[IsActive],[DateCreated],[DateModified])VALUES(1,'Which factor was the most important in your decision to participate in preventing screening today?',1,'Oct 22 2008  7:08:03:593AM','Oct 22 2008  7:08:03:593AM')
INSERT INTO [TblCustomerSurveyQuestion] ([CustomerSurveyQuestionID],[Question],[IsActive],[DateCreated],[DateModified])VALUES(2,'Which benefit best describes what you hope to achieve through preventative sreening today?',1,'Oct 22 2008  7:08:14:940AM','Oct 22 2008  7:08:14:940AM')
INSERT INTO [TblCustomerSurveyQuestion] ([CustomerSurveyQuestionID],[Question],[IsActive],[DateCreated],[DateModified])VALUES(3,'To attend this event I came from:',1,'Oct 22 2008  7:08:23:110AM','Oct 22 2008  7:08:23:110AM')

SET IDENTITY_INSERT [TblCustomerSurveyQuestion] OFF

-----------------------------------------------------------------------------------------

SET IDENTITY_INSERT [TblCustomerSurveyQuestionAnswer] ON

INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(1,1,'Concerns about certain health risks due to age, family history, and/or lifestyle choices',0,1,'Oct 22 2008  7:08:03:610AM','Oct 22 2008  7:08:03:610AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(2,1,'Influenced by a family member or a to do it friend',0,1,'Oct 22 2008  7:08:03:610AM','Oct 22 2008  7:08:03:610AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(3,1,'A desire to be more proactive in managing my health and establish a health baseline',0,1,'Oct 22 2008  7:08:03:627AM','Oct 22 2008  7:08:03:627AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(4,1,'Statistics on the benefits of preventative screening',0,1,'Oct 22 2008  7:08:03:627AM','Oct 22 2008  7:08:03:627AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(5,1,'It''s something I do every year',0,1,'Oct 22 2008  7:08:03:627AM','Oct 22 2008  7:08:03:627AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(6,1,'This event was convenient and economical',0,1,'Oct 22 2008  7:08:03:627AM','Oct 22 2008  7:08:03:627AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(7,1,'Other (Please Specify)',1,1,'Oct 22 2008  7:08:03:640AM','Oct 22 2008  7:08:03:640AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(8,2,'Establish a baseline of my health for future reference',0,1,'Oct 22 2008  7:08:14:940AM','Oct 22 2008  7:08:14:940AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(9,2,'Become aware of any health condition that needs attention',0,1,'Oct 22 2008  7:08:14:940AM','Oct 22 2008  7:08:14:940AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(10,2,'Gain specific knowledge about different aspects of my health codition',0,1,'Oct 22 2008  7:08:14:953AM','Oct 22 2008  7:08:14:953AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(11,2,'Assurance and peace of mind that my health is what I think it is',0,1,'Oct 22 2008  7:08:14:953AM','Oct 22 2008  7:08:14:953AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(12,2,'Other (Please Specify)',1,1,'Oct 22 2008  7:08:14:953AM','Oct 22 2008  7:08:14:953AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(13,3,'Home',0,1,'Oct 22 2008  7:08:23:127AM','Oct 22 2008  7:08:23:127AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(14,3,'Office',0,1,'Oct 22 2008  7:08:23:127AM','Oct 22 2008  7:08:23:127AM')
INSERT INTO [TblCustomerSurveyQuestionAnswer] ([CustomerSurveyQuestionAnswerID],[CustomerSurveyQuestionID],[Answer],[IsShowTextBox],[IsActive],[DateCreated],[DateModified])VALUES(15,3,'Other',0,1,'Oct 22 2008  7:08:23:127AM','Oct 22 2008  7:08:23:127AM')

SET IDENTITY_INSERT [TblCustomerSurveyQuestionAnswer] OFF

--------------------------------------------------------------------------------------
--[TblScripts]
-------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblScripts] ON

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(16,'New Customer Registration','','To get you started, we first need some of your basic information. Can you kindly give me tell me your  - [Ask for field information one by one]','Mar 11 2008  3:56:44:673PM','Mar 11 2008  3:56:44:673PM',1,1,10)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(17,'Event and Package Selection','description','We have several events in your area [Mention event date and distance]. Which event suits you best?. [Select Event]. We have appointment times as follows [Give client two options]','Feb  2 2008 12:00:00:000AM','Apr 30 2008  6:41:24:477AM',1,1,11)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(18,'Billing Information','','Your total is &amp;amp;amp;lt;&amp;amp;amp;lt;$ Amount&amp;amp;amp;gt;&amp;amp;amp;gt;. Will you be using your MasterCard or Visa to pay for this? [Ask for : Name on card, Card Number, Exp Date].','Mar 11 2008  3:56:44:000PM','Apr 30 2008  6:37:53:227AM',1,1,12)
INSERT INTO [TblScripts] 
([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES
(19,'Final Thank you','description','Thank you <<Your Name>> for registering for the event. This is the first step towards proactivly managing your health. We look forward to seeing you at the event.<br/> If you had provided an email during registration process then you are going to get an email within 1 hour. If you don’t, then please call back at <<CallCenterTollFreeNumber>>','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1,1,13)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(20,'Request Callback Number','','Just in case the line is dropped is there a good number we can call you back at. [save the number on the call back number textbox]','Mar 11 2008  3:56:44:000PM','Mar 11 2008  3:56:44:000PM',1,1,14)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(21,'Existing Customer Call Back','description','Hello <<Full name with Salutation>>, thank you for calling back. I see that you have registered for an event with us before. How may I help you?','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1,1,15)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(22,'Password Request','','I will be happy to assist you with the password reset request. Can you kindly verify your first and last name and date of birth? [If verified correctly, send email with password reset link]','Mar 11 2008  3:56:44:000PM','Mar 11 2008  3:56:44:000PM',1,1,16)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(23,'Upsell','description','Would you like to upgrade to <<Package Name>> for only <<$dollar diff>>? This will allow you get additional information about your <<test benefits>>','Feb  2 2008 12:00:00:000AM','Feb  2 2008 12:00:00:000AM',1,1,17)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(29,'ManualVerificationScript','description','Please send your documents (Passport,Driving Licence etc.) to ABC Screening! office','Oct  6 2008 12:00:00:000AM','Oct  6 2008 12:00:00:000AM',1,1,20)
INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])VALUES(33,'Under 40 MV Authorization','description','The following information was relayed to the client(s) listed below (verbally for phone registrations and visually for Internet registrations): Vascular Screenings for people < 40 years of age are typically NOT recommended. Exceptions include (i) having a family history of vascular and/or heart disease, (ii) extensive risk factors, or (iii) a doctor recommending your participation.','Apr 28 2009  1:43:20:337PM','Apr 28 2009  4:47:18:210PM',1,1,24)

INSERT INTO [TblScripts] ([ScriptID],[Name],[Description],[ScriptText],[DateCreated],[DateModified],[IsActive],[IsDefault],[ScriptTypeID])
VALUES(35,'ForwardRefundCall','','Please forward the Cancel and refund request to <<Name>>','Aug 14 2009  3:32:56:450AM','Aug 14 2009  3:32:56:450AM',1,1,26)
SET IDENTITY_INSERT [TblScripts] OFF


------------------------------------------------------------------------------------
----[TblMVUserSpecialization]
-------------------------------------------------------------------------------------
delete from [TblPhysicianSpecialization]

SET IDENTITY_INSERT [TblPhysicianSpecialization] ON

INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(1,'Pediatrician','Pediatrician','Nov  6 2007 10:23:14:533AM','Nov  6 2007 10:29:22:507AM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(2,'Radiologist','Radiologist','Nov  7 2007  8:21:08:467PM','Nov  7 2007  8:21:08:467PM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(3,'Internal Medicine','Internal Medicine','Apr 27 2009  2:31:00:197PM','Apr 27 2009  2:31:00:197PM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(4,'Family Practice','Family Practice','Apr 27 2009  2:31:33:057PM','Apr 27 2009  2:31:33:057PM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(5,'Osteopathy','Osteopathic Doctor','Apr 28 2009  8:15:25:867AM','Apr 28 2009  8:15:25:867AM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(6,'Pulmonary Critical Care','Pulmonary Critical Care','Apr 28 2009  8:52:19:053AM','Apr 28 2009  8:52:19:053AM',1)
INSERT INTO [TblPhysicianSpecialization] ([PhysicianSpecializationId],[Name],[Description],[DateCreated],[DateModified],[IsActive])VALUES(7,'Cardiologist','Cardiologist','Feb 24 2010 11:45:34:590AM','Feb 24 2010 11:45:34:590AM',1)

SET IDENTITY_INSERT [TblPhysicianSpecialization] OFF



SET IDENTITY_INSERT [dbo].[tblAFAdvertiser] ON

INSERT INTO [tblAFAdvertiser] ([AdvertiserID],[AdvertiserName],[ChannelID],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(1,'Self',1,'Jun  6 2008 12:00:00:000AM','Jun  6 2008 12:00:00:000AM',1)
INSERT INTO [tblAFAdvertiser] ([AdvertiserID],[AdvertiserName],[ChannelID],[CreatedDate],[LastModifiedDate],[IsActive])VALUES(2,'Advocate (Advocate Sales Group)',2,'Jun  6 2008 12:00:00:000AM','Jun  6 2008 12:00:00:000AM',1)

SET IDENTITY_INSERT [dbo].[tblAFAdvertiser] OFF

INSERT INTO [tblAFCampaignTemplate] ([CampaignTemplateID],[TemplateType],[TemplateCampaignName],[PromoCodeID],[AdvertiserID],[IncomingPhone],[StartDate],[EndDate],[Cost],[Commision],[ParentAffiliateCommision],[IsCommisionPercentage],[CreatedDate],[LastModifiedDate],[IsActive],[IsGlobal],[OwnerOrganizationId])VALUES(1,1,'Phone Referral',1,1,'8666713609','Sep  8 2008 12:00:00:000AM','1-1-1900',0,15,0,0,'Sep  8 2008 12:00:00:000AM','Sep  8 2008 12:00:00:000AM',1,1,NULL)
INSERT INTO [tblAFCampaignTemplate] ([CampaignTemplateID],[TemplateType],[TemplateCampaignName],[PromoCodeID],[AdvertiserID],[IncomingPhone],[StartDate],[EndDate],[Cost],[Commision],[ParentAffiliateCommision],[IsCommisionPercentage],[CreatedDate],[LastModifiedDate],[IsActive],[IsGlobal],[OwnerOrganizationId])VALUES(2,2,'Phone Referral',1,1,'8666713609','Sep  8 2008 12:00:00:000AM','1-1-1900',0,15,0,0,'Sep  8 2008 12:00:00:000AM','Sep  8 2008 12:00:00:000AM',1,1,NULL)
INSERT INTO [tblAFCampaignTemplate] ([CampaignTemplateID],[TemplateType],[TemplateCampaignName],[PromoCodeID],[AdvertiserID],[IncomingPhone],[StartDate],[EndDate],[Cost],[Commision],[ParentAffiliateCommision],[IsCommisionPercentage],[CreatedDate],[LastModifiedDate],[IsActive],[IsGlobal],[OwnerOrganizationId])VALUES(3,3,'Email Referral',1,1,'8666713609','Sep  8 2008 12:00:00:000AM','1-1-1900',0,15,0,0,'Sep  8 2008 12:00:00:000AM','Sep  8 2008 12:00:00:000AM',1,1,NULL)
INSERT INTO [tblAFCampaignTemplate] ([CampaignTemplateID],[TemplateType],[TemplateCampaignName],[PromoCodeID],[AdvertiserID],[IncomingPhone],[StartDate],[EndDate],[Cost],[Commision],[ParentAffiliateCommision],[IsCommisionPercentage],[CreatedDate],[LastModifiedDate],[IsActive],[IsGlobal],[OwnerOrganizationId])VALUES(4,4,'Phone Referral',1,1,'8666713609','Sep  8 2008 12:00:00:000AM','1-1-1900',0,15,0,0,'Sep  8 2008 12:00:00:000AM','Sep  8 2008 12:00:00:000AM',1,1,NULL)


----------------------------------------------------------------------
--TblTag
-------------------------------------------------------------------
insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(106,'Online registration','OnlineSignup',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(106,'Non-Serviced Zip code','NotServicedZip',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(106,'Cancellation','Cancellation',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(106,'No Show','NoShow',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(106,'Gift Certificate Purchase','GiftCertificatePurchase',1,1)

----------------------------------------------------------
insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'CallCenter Registration','CallCenterSignup',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Non-Serviced Zip code','NotServicedZip',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Insurance concerns','InsuranceConcerns',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Pricing concerns','PricingConcerns',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'No events in the area','NoEventsInTheArea',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Morning appointment preferred','MorningAppointmentPreferred',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Afternoon appointment preferred','AfternoonAppointmentPreferred',1,0)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Cancellation','Cancellation',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'No Show','NoShow',1,1)

insert into TblTag ([Source],[Name],[Alias],IsActive, [IsSystemDefined])
Values(107,'Gift Certificate Purchase','GiftCertificatePurchase',1,1)


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
