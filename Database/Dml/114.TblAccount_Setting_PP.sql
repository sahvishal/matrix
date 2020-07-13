
USE [$(dbName)]
Go

--PP
Declare @AccountId bigint
set @AccountId = 929

Declare @AppointmentConfirmationMailTemplateId bigint
		,@AppointmentReminderMailTemplateId bigint 
		,@ResultReadyMailTemplateId bigint
		,@SurveyMailTemplateId bigint 

select @AppointmentConfirmationMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerScreeningAppointmentConfirmation'

select @AppointmentReminderMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerScreeningAppointmentReminder'

select @ResultReadyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnersCustomerResultReady'

select @SurveyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'PhysicianPartnerSurveyEmailNotification'

update TblAccount 
set Tag = 'Physician Partner'
	,MemberIdLabel = 'Member Id'
	,AllowOnlineRegistration = 0
	,AllowPreQualifiedTestOnly = 1
	,AllowCustomerPortalLogin = 0
	,SendResultReadyMail = 0
	,GeneratePcpLetter = 1
	,ShowBasicBiometricPage = 0
	,SendSurveyMail = 1
	,AppointmentConfirmationMailTemplateId = @AppointmentConfirmationMailTemplateId
	,AppointmentReminderMailTemplateId = @AppointmentReminderMailTemplateId
	,ResultReadyMailTemplateId = @ResultReadyMailTemplateId
	,SurveyMailTemplateId = @SurveyMailTemplateId
	,SendResultReadyMailWithFax=1
where AccountID = @AccountId

