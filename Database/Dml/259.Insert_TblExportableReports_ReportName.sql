
USE [$(dbName)]
GO

	Delete from TblExportableReports

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (1,'Appointments Booked','AppointmentsBooked',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (2,'Customer Schedule','CustomerSchedule',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (3,'Event Volume (Retail Events)','EventVolumeRetailEvents',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (4,'Event Volume (Corporate Events)','EventVolumeCorporateEvents',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (5,'Event Volume (Health Plan)','EventVolumeHealthPlan',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (6,'NoShow Customers','NoShowCustomers',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (7,'Canceled Customer','CanceledCustomer',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (8,'Customer Export','CustomerExport',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (9,'Reschedule Appointment','RescheduleAppointment',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (10,'Event Cancelation','EventCancelation',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (11,'TestBooked','TestBooked',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (12,'Pcp Appointment Disposition','PcpAppointmentDisposition',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (13,'Manage Customer Prospects','ManageCustomerProspects',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (14,'Call Queue Report','CallQueueReport',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (15,'Outreach Call Report','OutreachCallReport',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (16,'Uncontacted Customers','UncontactedCustomers',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (17,'Product Shipping Status','ProductShippingStatus',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (18,'Critical/Urgent Management','CriticalUrgentManagement',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (19,'Technical Limited Screening','TechnicalLimitedScreening',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (20,'Test Performed','TestPerformed',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (21,'Customer KYN\HAF Report','CustomerKynHafReport',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (22,'Detail Open Order','DetailOpenOrder',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (23,'Upgrade/Downgrade','UpgradeDowngrade',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (24,'Daily Recap (Event)','DailyRecapEvent',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (25,'Daily Recap (Customer)','DailyRecapCustomer',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (26,'Credit Card Reconcilation','CreditCardReconcilation',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (27,'Deferred Revenue','DeferredRevenue',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (28,'Shipping Revenue Summary','ShippingRevenueSummary',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (29,'Corporate Invoice','CorporateInvoice',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (30,'Refund Requests','RefundRequests',GETDATE())

	INSERT INTO TblExportableReports (Id,Name,Alias,CreatedOn) VALUES (31,'Manage System Users','ManageSystemUsers',GETDATE())

go