
USE [$(dbName)]
Go

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='PaperSize')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('PaperSize','Paper Size for HAF','1', getdate(),getdate(),'Letter',NULL,NULL,'Admin','Varchar','')  
End  