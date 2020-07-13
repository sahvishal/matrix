USE [$(dbName)]
Go

insert into TblNotificationType (NotificationTypeName
           ,NotificationTypeNameAlias
           ,Description
           ,DateCreated
           ,DateModified
           ,IsActive
           ,NoOfAttempts
           ,IsServiceEnabled
           ,IsQueuingEnabled
           ,ModifiedByOrgRoleUserId
           ,NotificationMediumId)
values('Appointment Confirmation','AppointmentConfirmation','Appointment Confirmation',GETDATE(),GETDATE(),1,1,0,0,null,3);

insert into TblNotificationType
 (NotificationTypeName
           ,NotificationTypeNameAlias
           ,Description
           ,DateCreated
           ,DateModified
           ,IsActive
           ,NoOfAttempts
           ,IsServiceEnabled
           ,IsQueuingEnabled
           ,ModifiedByOrgRoleUserId
           ,NotificationMediumId)
values('Appointment Reminder','AppointmentReminder','Appointment Reminder',GETDATE(),GETDATE(),1,1,0,0,null,3);