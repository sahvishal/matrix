USE [$(dbName)]
Go 

--TblNotificationType
--IF EXISTS (SELECT *  FROM sys.foreign_keys   WHERE object_id = OBJECT_ID(N'dbo.DF_TblNotificationType_AllowTemplateCreation')   AND parent_object_id = OBJECT_ID(N'dbo.TblNotificationType'))
IF (OBJECT_ID('DF_TblNotificationType_AllowTemplateCreation', 'D') IS NOT NULL)
BEGIN
		ALTER table TblNotificationType Drop DF_TblNotificationType_AllowTemplateCreation
		ALTER TABLE TblNotificationType DROP COLUMN AllowTemplateCreation
End

ALTER TABLE dbo.TblNotificationType 
	ADD AllowTemplateCreation bit NOT NULL CONSTRAINT DF_TblNotificationType_AllowTemplateCreation DEFAULT 0

GO

--IF EXISTS (SELECT *  FROM sys.foreign_keys   WHERE object_id = OBJECT_ID(N'dbo.FK_TblEmailTemplate_TblNotificationType')   AND parent_object_id = OBJECT_ID(N'dbo.TblEmailTemplate'))
IF (OBJECT_ID('FK_TblEmailTemplate_TblNotificationType', 'F') IS NOT NULL)
BEGIN
		Alter table TblEmailTemplate Drop FK_TblEmailTemplate_TblNotificationType
		ALTER TABLE TblEmailTemplate DROP COLUMN NotificationTypeId
End
--TblEmailTemplate
ALTER TABLE dbo.TblEmailTemplate ADD NotificationTypeId int NULL
GO

ALTER TABLE dbo.TblEmailTemplate ADD CONSTRAINT FK_TblEmailTemplate_TblNotificationType FOREIGN KEY 
									( NotificationTypeId ) REFERENCES dbo.TblNotificationType ( NotificationTypeID)
GO	


----TblEmailTemplateMacro
--ALTER TABLE dbo.TblTemplateMacro ADD NotificationTypeId int NULL
--GO

--ALTER TABLE dbo.TblTemplateMacro ADD CONSTRAINT	FK_TblTemplateMacro_TblNotificationType FOREIGN KEY
--									( NotificationTypeId ) REFERENCES dbo.TblNotificationType ( NotificationTypeID ) 
	
--GO
