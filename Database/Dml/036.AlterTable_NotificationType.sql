USE [$(dbName)]
Go

Alter Table TblNotificationType Drop Column IsStarted

Alter Table TblNotificationType Drop Column LastStatusChangedDate

Alter Table TblNotificationType Drop Column EscalateToPhone

Alter Table TblNotificationType Add IsServiceEnabled bit not null constraint DF_NotificationType_IsServiceEnabled default(1)

Alter Table TblNotificationType Add IsQueuingEnabled bit not null constraint DF_NotificationType_IsQueuingEnabled default(1)

Alter Table TblNotificationType Add ModifiedByOrgRoleUserId bigint null 

Alter Table TblNotificationType Add Constraint FK_TblOrganizationRoleUser_NotificationType Foreign Key(ModifiedByOrgRoleUserId) References TblOrganizationRoleUser(OrganizationRoleUserId)


Update TblNotificationType Set NoOfAttempts = 1

Alter Table TblNotificationType Alter Column NoOfAttempts int not null
