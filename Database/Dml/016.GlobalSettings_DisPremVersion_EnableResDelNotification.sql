
USE [$(dbName)]
Go

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DisplayPremiumVersiononPortal')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('DisplayPremiumVersiononPortal','Display Premium Version on Customer Portal','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EnableResultDeliveryNotification')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('EnableResultDeliveryNotification','Enable Result Delivery Notification','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  
End  