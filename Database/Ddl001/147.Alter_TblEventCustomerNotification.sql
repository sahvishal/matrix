USE [$(dbName)]
GO
--TblEventCustomerNotification

ALTER TABLE dbo.TblEventCustomerNotification ADD CONSTRAINT FK_TblEventCustomerNotification_TblEventCustomers FOREIGN KEY (EventCustomerId) 
	REFERENCES dbo.TblEventCustomers (EventCustomerID) 	
GO

ALTER TABLE dbo.TblEventCustomerNotification ADD CONSTRAINT FK_TblEventCustomerNotification_TblNotification FOREIGN KEY (NotificationId) 
	REFERENCES dbo.TblNotification(NotificationID) 	
GO

Alter Table dbo.TblEventCustomerNotification Add NotificationTypeId int NOT NULL
GO

ALTER TABLE dbo.TblEventCustomerNotification ADD CONSTRAINT FK_TblEventCustomerNotification_TblNotificationType FOREIGN KEY (NotificationTypeId) 
	REFERENCES dbo.TblNotificationType(NotificationTypeID) 
	
GO


