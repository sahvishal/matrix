USE [$(dbName)]
Go

UPDATE TblGlobalConfiguration
   SET Name = 'EnablePhysicianPartnerCustomerResultFaxNotification'   
      ,Description = 'EnablePhysicianPartnerCustomerResultFaxNotification'      
      ,DateModified = GETDATE()
 WHERE Name='EnableFaxNotification'
GO 

UPDATE TblNotificationType
   SET [NotificationTypeName] = 'PhysicianPartnerCustomerResultFaxNotification'
      ,[NotificationTypeNameAlias] = 'PhysicianPartnerCustomerResultFaxNotification'      
      ,[DateModified] = GETDATE()      
 WHERE NotificationTypeNameAlias='FaxResultNotification'
GO

