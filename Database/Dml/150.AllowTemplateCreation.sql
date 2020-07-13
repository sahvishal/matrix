USE [$(dbName)]
Go

Update tblNotificationType Set AllowTemplateCreation=1 where NotificationTypeNameAlias='AppointmentConfirmationWithEventDetails'
Update tblNotificationType Set AllowTemplateCreation=1 where NotificationTypeNameAlias='CustomerWelcomeEmailWithUsername'
Update tblNotificationType Set AllowTemplateCreation=1 where NotificationTypeNameAlias='ResultsReady'
