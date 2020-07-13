
USE [$(dbName)]
GO

Alter Table TblAccount Add Tag varchar(255) NULL
GO

Alter Table TblAccount Add MemberIdLabel varchar(255) NULL
GO

Alter Table TblAccount Add AllowOnlineRegistration bit NOT NULL Constraint DF_TblAccount_AllowOnlineRegistration default 1
GO

Alter Table TblAccount Add AllowPreQualifiedTestOnly bit NOT NULL Constraint DF_TblAccount_AllowPreQualifiedTestOnly default 0
GO

Alter Table TblAccount Add AllowCustomerPortalLogin bit NOT NULL Constraint DF_TblAccount_AllowCustomerPortalLogin default 1
GO

Alter Table TblAccount Add SendResultReadyMail bit NOT NULL Constraint DF_TblAccount_SendResultReadyMail default 1
GO

Alter Table TblAccount Add GeneratePcpLetter bit NOT NULL Constraint DF_TblAccount_GeneratePcpLetter default 0
GO

Alter Table TblAccount Add ShowBasicBiometricPage bit NOT NULL Constraint DF_TblAccount_ShowBasicBiometricPage default 1
GO

Alter Table TblAccount Add SendSurveyMail bit NOT NULL Constraint DF_TblAccount_SendSurveyMail default 0
GO

Alter Table TblAccount Add AppointmentConfirmationMailTemplateId bigint NOT NULL Constraint DF_TblAccount_AppointmentConfirmationMailTemplateId default 3
GO

Alter Table TblAccount Add AppointmentReminderMailTemplateId bigint NOT NULL Constraint DF_TblAccount_AppointmentReminderMailTemplateId default 4
GO

Alter Table TblAccount Add ResultReadyMailTemplateId bigint NOT NULL Constraint DF_TblAccount_ResultReadyMailTemplateId default 12
GO

Alter Table TblAccount Add SurveyMailTemplateId bigint NOT NULL Constraint DF_TblAccount_SurveyMailTemplateId default 21
GO