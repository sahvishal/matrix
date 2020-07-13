
USE [$(dbName)]
Go

IF NOT Exists(select GlobalConfigurationID from TblGlobalConfiguration where [Name]='DisplayRescheduleAppointmentPortal')  
Begin  
	INSERT INTO [dbo].[TblGlobalConfiguration]  
		([Name],[Description],[IsActive],[DateCreated],[DateModified],[Value],[RoleTypeID],[UserID],[SettingGroupName],[DataType],[Delimiter])  
	VALUES  
		('DisplayRescheduleAppointmentPortal','Display Reschedule Appointment Portal','1', getdate(),getdate(),'False',NULL,NULL,'Admin','Varchar','')  --- To Set False for HealthFair and True for PHS 
End  