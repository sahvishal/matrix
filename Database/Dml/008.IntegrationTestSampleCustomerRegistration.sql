
USE [$(dbName)]
GO


Begin Try
Begin Tran
-----------------------------------------
--1.Customer Id - 7
-------------------------------------------------
SET IDENTITY_INSERT [TblEventCustomers] ON

INSERT INTO [TblEventCustomers] ([EventCustomerID],[EventID],[CustomerID],[IsPaymentOnline],[AppointmentID],[IsTestConducted],[bMailReports],[Notes],[NoShow],[DateCreated],[OfflineCustomerID],[AffiliateCampaignID],[SignInSource],[AdvocateID],[HIPAAStatus],[MarketingSource],[ClickID],[CreatedByOrgRoleUserId])
VALUES(1,2,7,0,17,0,NULL,NULL,0,'May  4 2011  9:53:23:800AM',NULL,NULL,NULL,0,1,'New paper',NULL,4)
INSERT INTO [TblEventCustomers] ([EventCustomerID],[EventID],[CustomerID],[IsPaymentOnline],[AppointmentID],[IsTestConducted],[bMailReports],[Notes],[NoShow],[DateCreated],[OfflineCustomerID],[AffiliateCampaignID],[SignInSource],[AdvocateID],[HIPAAStatus],[MarketingSource],[ClickID],[CreatedByOrgRoleUserId])
VALUES(2,2,8,0,18,0,NULL,NULL,0,'May  4 2011 10:04:46:783AM',NULL,NULL,NULL,0,1,'News Paper',NULL,4)
INSERT INTO [TblEventCustomers] ([EventCustomerID],[EventID],[CustomerID],[IsPaymentOnline],[AppointmentID],[IsTestConducted],[bMailReports],[Notes],[NoShow],[DateCreated],[OfflineCustomerID],[AffiliateCampaignID],[SignInSource],[AdvocateID],[HIPAAStatus],[MarketingSource],[ClickID],[CreatedByOrgRoleUserId])
VALUES(3,2,11,0,21,0,NULL,NULL,0,'May  4 2011 10:09:24:590AM',NULL,NULL,NULL,0,1,'News Paper',NULL,4)
INSERT INTO [TblEventCustomers] ([EventCustomerID],[EventID],[CustomerID],[IsPaymentOnline],[AppointmentID],[IsTestConducted],[bMailReports],[Notes],[NoShow],[DateCreated],[OfflineCustomerID],[AffiliateCampaignID],[SignInSource],[AdvocateID],[HIPAAStatus],[MarketingSource],[ClickID],[CreatedByOrgRoleUserId])
VALUES(4,2,24,1,24,0,NULL,NULL,0,'May  4 2011 10:19:33:263AM',NULL,NULL,NULL,0,1,NULL,NULL,24)
INSERT INTO [TblEventCustomers] ([EventCustomerID],[EventID],[CustomerID],[IsPaymentOnline],[AppointmentID],[IsTestConducted],[bMailReports],[Notes],[NoShow],[DateCreated],[OfflineCustomerID],[AffiliateCampaignID],[SignInSource],[AdvocateID],[HIPAAStatus],[MarketingSource],[ClickID],[CreatedByOrgRoleUserId])
VALUES(5,2,23,1,27,0,NULL,NULL,0,'May  4 2011 10:24:11:593AM',NULL,NULL,NULL,0,1,NULL,NULL,23)

SET IDENTITY_INSERT [TblEventCustomers] OFF

Update TblEventAppointment Set ScheduledByOrgRoleUserId=4, Status =2 where AppointmentID=17
Update TblEventAppointment Set ScheduledByOrgRoleUserId=4, Status =2 where AppointmentID=18
Update TblEventAppointment Set ScheduledByOrgRoleUserId=4, Status =2 where AppointmentID=21
Update TblEventAppointment Set ScheduledByOrgRoleUserId=4, Status =2 where AppointmentID=24
Update TblEventAppointment Set ScheduledByOrgRoleUserId=4, Status =2 where AppointmentID=27


-------------------------------------
SET IDENTITY_INSERT [TblOrder] ON

INSERT INTO [TblOrder] ([OrderID],[Type],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(1,1,'May  4 2011  9:53:23:800AM',4)
INSERT INTO [TblOrder] ([OrderID],[Type],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(2,1,'May  4 2011 10:04:46:890AM',4)
INSERT INTO [TblOrder] ([OrderID],[Type],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(3,1,'May  4 2011 10:09:24:710AM',4)
INSERT INTO [TblOrder] ([OrderID],[Type],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(4,1,'May  4 2011 10:19:33:313AM',24)
INSERT INTO [TblOrder] ([OrderID],[Type],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(5,1,'May  4 2011 10:24:11:643AM',23)

SET IDENTITY_INSERT [TblOrder] OFF
------------------------------------------------------
SET IDENTITY_INSERT [TblOrderItem] ON

INSERT INTO [TblOrderItem] ([OrderItemID],[Type])VALUES(1,1)
INSERT INTO [TblOrderItem] ([OrderItemID],[Type])VALUES(2,1)
INSERT INTO [TblOrderItem] ([OrderItemID],[Type])VALUES(3,1)

SET IDENTITY_INSERT [TblOrderItem] OFF
-------------------------------------------------
SET IDENTITY_INSERT [TblOrderDetail] ON

INSERT INTO [TblOrderDetail] ([OrderDetailID],[OrderID],[ForOrganizationRoleUserID],[OrderItemID],[Description],[Quantity],[Price],[Status],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(1,1,7,1,'Package for $149.00',1,149.0000,1,'May  4 2011  9:53:23:800AM',4)
INSERT INTO [TblOrderDetail] ([OrderDetailID],[OrderID],[ForOrganizationRoleUserID],[OrderItemID],[Description],[Quantity],[Price],[Status],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(2,2,8,2,'Package for $129.00',1,129.0000,1,'May  4 2011 10:04:46:887AM',4)
INSERT INTO [TblOrderDetail] ([OrderDetailID],[OrderID],[ForOrganizationRoleUserID],[OrderItemID],[Description],[Quantity],[Price],[Status],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(3,3,11,3,'Package for $179.00',1,179.0000,1,'May  4 2011 10:09:24:710AM',4)
INSERT INTO [TblOrderDetail] ([OrderDetailID],[OrderID],[ForOrganizationRoleUserID],[OrderItemID],[Description],[Quantity],[Price],[Status],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(4,4,24,1,'Package for $149.00',1,149.0000,1,'May  4 2011 10:19:33:313AM',24)
INSERT INTO [TblOrderDetail] ([OrderDetailID],[OrderID],[ForOrganizationRoleUserID],[OrderItemID],[Description],[Quantity],[Price],[Status],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(5,5,23,2,'Package for $129.00',1,129.0000,1,'May  4 2011 10:24:11:643AM',23)

SET IDENTITY_INSERT [TblOrderDetail] OFF
-------------------------------------------------

INSERT INTO [TblEventCustomerOrderDetail] ([OrderDetailID],[EventCustomerId],[IsActive])VALUES(1,1,1)
INSERT INTO [TblEventCustomerOrderDetail] ([OrderDetailID],[EventCustomerId],[IsActive])VALUES(2,2,1)
INSERT INTO [TblEventCustomerOrderDetail] ([OrderDetailID],[EventCustomerId],[IsActive])VALUES(3,3,1)
INSERT INTO [TblEventCustomerOrderDetail] ([OrderDetailID],[EventCustomerId],[IsActive])VALUES(4,4,1)
INSERT INTO [TblEventCustomerOrderDetail] ([OrderDetailID],[EventCustomerId],[IsActive])VALUES(5,5,1)

------------------------------------------------------------

INSERT INTO [TblEventPackageOrderItem] ([OrderItemID],[EventPackageID])VALUES(1,5)
INSERT INTO [TblEventPackageOrderItem] ([OrderItemID],[EventPackageID])VALUES(2,6)
INSERT INTO [TblEventPackageOrderItem] ([OrderItemID],[EventPackageID])VALUES(3,4)

-------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblAddress] ON

INSERT [dbo].[TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(20,'345 Fith Ave.',NULL,2,20,1,5,1,'Apr 28 2011  2:11:45:863AM','Apr 28 2011  2:11:45:863AM',NULL,NULL,NULL,0,0)
INSERT [dbo].[TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(21,'123 Main Street','Apartment # 3',7,60,1,78,1,'May  4 2011 10:04:46:853AM','May  4 2011 10:04:46:853AM',NULL,NULL,NULL,0,0)
INSERT [dbo].[TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(22,'123 Main Street','Apartment # 3',7,60,1,78,1,'May  4 2011 10:09:24:673AM','May  4 2011 10:09:24:673AM',NULL,NULL,NULL,0,0)
INSERT [dbo].[TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(23,'123 Main St','',7,60,1,74,1,'May  4 2011 10:19:33:300AM','May  4 2011 10:19:33:300AM',NULL,NULL,NULL,0,0)
INSERT [dbo].[TblAddress] ([AddressID],[Address1],[Address2],[CityID],[StateID],[CountryID],[ZipID],[IsActive],[DateCreated],[DateModified],[Latitude],[Longitude],[VerificationOrgRoleUserId],[IsManuallyVerified],[UseLatLogForMapping])VALUES(24,'895 Milford Dr','',2,20,1,5,1,'May  4 2011 10:24:11:630AM','May  4 2011 10:24:11:630AM',NULL,NULL,NULL,0,0)

SET IDENTITY_INSERT [TblAddress] OFF
---------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblShippingDetail] ON

INSERT INTO [TblShippingDetail] ([ShippingDetailID],[ShippingOptionID],[ShippingAddressID],[ShipmentDate],[DateCreated],[OrganizationRoleUserCreatorID],[Status],[ActualPrice])
VALUES(1,1,20,NULL,'May  4 2011  9:53:23:800AM',4,1,0.0000)

INSERT INTO [TblShippingDetail] ([ShippingDetailID],[ShippingOptionID],[ShippingAddressID],[ShipmentDate],[DateCreated],[OrganizationRoleUserCreatorID],[Status],[ActualPrice])
VALUES(2,2,21,NULL,'May  4 2011 10:04:46:830AM',4,1,5.9900)

INSERT INTO [TblShippingDetail] ([ShippingDetailID],[ShippingOptionID],[ShippingAddressID],[ShipmentDate],[DateCreated],[OrganizationRoleUserCreatorID],[Status],[ActualPrice])
VALUES(3,1,22,NULL,'May  4 2011 10:09:24:633AM',4,1,0.0000)

INSERT INTO [TblShippingDetail] ([ShippingDetailID],[ShippingOptionID],[ShippingAddressID],[ShipmentDate],[DateCreated],[OrganizationRoleUserCreatorID],[Status],[ActualPrice])
VALUES(4,2,23,NULL,'May  4 2011 10:19:33:287AM',24,1,5.9900)

INSERT INTO [TblShippingDetail] ([ShippingDetailID],[ShippingOptionID],[ShippingAddressID],[ShipmentDate],[DateCreated],[OrganizationRoleUserCreatorID],[Status],[ActualPrice])
VALUES(5,2,24,NULL,'May  4 2011 10:24:11:613AM',23,1,5.9900)

SET IDENTITY_INSERT [TblShippingDetail] OFF
---------------------------------------------------------------------------------------------

INSERT INTO [TblShippingDetailOrderDetail] ([OrderDetailID],[ShippingDetailID],[IsActive])VALUES(1,1,1)
INSERT INTO [TblShippingDetailOrderDetail] ([OrderDetailID],[ShippingDetailID],[IsActive])VALUES(2,2,1)
INSERT INTO [TblShippingDetailOrderDetail] ([OrderDetailID],[ShippingDetailID],[IsActive])VALUES(3,3,1)
INSERT INTO [TblShippingDetailOrderDetail] ([OrderDetailID],[ShippingDetailID],[IsActive])VALUES(4,4,1)
INSERT INTO [TblShippingDetailOrderDetail] ([OrderDetailID],[ShippingDetailID],[IsActive])VALUES(5,5,1)

-----------------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblPayment] ON

INSERT INTO [TblPayment] ([PaymentID],[Notes],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(1,'Payment','May  4 2011 10:09:24:783AM',4)
INSERT INTO [TblPayment] ([PaymentID],[Notes],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(2,'Payment','May  4 2011 10:19:33:327AM',24)
INSERT INTO [TblPayment] ([PaymentID],[Notes],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(3,'Payment','May  4 2011 10:24:11:660AM',23)

SET IDENTITY_INSERT [TblPayment] OFF
---------------------------------------------------------------------------------------------------------------

INSERT INTO [TblPaymentOrder] ([OrderID],[PaymentID])VALUES(3,1)
INSERT INTO [TblPaymentOrder] ([OrderID],[PaymentID])VALUES(4,2)
INSERT INTO [TblPaymentOrder] ([OrderID],[PaymentID])VALUES(5,3)

-------------------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblChargeCard] ON

INSERT INTO [TblChargeCard] ([ChargeCardID],[NameOnCard],[Number],[TypeID],[ExpirationDate],[CVV],[CardIssuer],[IsDebitCard],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(1,'Mary Kay','AR+m6ax/nWVA/Z0YEMhC21/jhbo3HLbCte0FYlVHFI4=',2,'Oct  1 2012 12:00:00:000AM','y5AZNSaWSN/Hpt03NFEtmA==',NULL,0,'May  4 2011 10:09:24:550AM',4)
INSERT INTO [TblChargeCard] ([ChargeCardID],[NameOnCard],[Number],[TypeID],[ExpirationDate],[CVV],[CardIssuer],[IsDebitCard],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(2,'Jerry Walker','AR+m6ax/nWVA/Z0YEMhC21/jhbo3HLbCte0FYlVHFI4=',2,'Oct  1 2012 12:00:00:000AM','y5AZNSaWSN/Hpt03NFEtmA==',NULL,0,'May  4 2011 10:19:33:260AM',24)
INSERT INTO [TblChargeCard] ([ChargeCardID],[NameOnCard],[Number],[TypeID],[ExpirationDate],[CVV],[CardIssuer],[IsDebitCard],[DateCreated],[OrganizationRoleUserCreatorID])VALUES(3,'Kevin Mac','AR+m6ax/nWVA/Z0YEMhC21/jhbo3HLbCte0FYlVHFI4=',2,'Oct  1 2012 12:00:00:000AM','y5AZNSaWSN/Hpt03NFEtmA==',NULL,0,'May  4 2011 10:24:11:590AM',23)

SET IDENTITY_INSERT [TblChargeCard]OFF
---------------------------------------------------------------------------------------------
SET IDENTITY_INSERT [TblChargeCardPayment] ON

INSERT INTO [TblChargeCardPayment] ([ChargeCardPaymentID],[PaymentID],[ChargeCardID],[Amount],[ProcessorResponse],[DateCreated],[OrganizationRoleUserCreatorID],[Status])VALUES(1,1,1,179.0000,'P|ACCEPT,100,2159666982,4zWjD6hi5YfeQQCTTI3QCh5hVGtyVOTB,This transaction has been approved.','May  4 2011 10:09:24:590AM',4,1)
INSERT INTO [TblChargeCardPayment] ([ChargeCardPaymentID],[PaymentID],[ChargeCardID],[Amount],[ProcessorResponse],[DateCreated],[OrganizationRoleUserCreatorID],[Status])VALUES(2,2,2,154.9900,'P|ACCEPT,100,2159667038,4zWjD6hi5YfeQQCTTI3QCh5hVGtyVOTB,This transaction has been approved.','May  4 2011 10:19:33:263AM',24,1)
INSERT INTO [TblChargeCardPayment] ([ChargeCardPaymentID],[PaymentID],[ChargeCardID],[Amount],[ProcessorResponse],[DateCreated],[OrganizationRoleUserCreatorID],[Status])VALUES(3,3,3,134.9900,'P|ACCEPT,100,2159667060,4zWjD6hi5YfeQQCTTI3QCh5hVGtyVOTB,This transaction has been approved.','May  4 2011 10:24:11:593AM',23,1)

SET IDENTITY_INSERT [TblChargeCardPayment] OFF

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
