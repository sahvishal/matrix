
USE [$(dbName)]
Go

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='EnableNewsletterPrompt')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('EnableNewsletterPrompt','Enable Newsletter Prompt','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  --- To Set True for HealthFair and False for PHS 
End  

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='SourceCodeLabel')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('SourceCodeLabel', 'Source Code Label', '1', getdate(),getdate(),'Source Code',NULL,NULL,'Admin','Varchar','')  --- To Set 'Coupon Code' for HealthFair and 'Source Code' for PHS
End  


IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='CutOffHourNumberforOnlineEventSelection')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('CutOffHourNumberforOnlineEventSelection', 'CutOff Hour Number for Online Event Selection', '1', getdate(),getdate(),'0',NULL,NULL,'Admin','Varchar','')  --- To Set '0' for HealthFair and '9' for PHS
End 