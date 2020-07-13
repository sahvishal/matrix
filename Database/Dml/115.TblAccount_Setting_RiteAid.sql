
USE [$(dbName)]
Go

--Rite Aid
Declare @AccountId bigint
set @AccountId = 946

Declare @AppointmentConfirmationMailTemplateId bigint
		,@AppointmentReminderMailTemplateId bigint 
		,@ResultReadyMailTemplateId bigint
		,@SurveyMailTemplateId bigint 

select @AppointmentConfirmationMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'AWVScreeningAppointmentConfirmation'

select @AppointmentReminderMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'AWVScreeningAppointmentReminder'

select @ResultReadyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'ResultsReady'

select @SurveyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification'

update TblAccount 
set Tag = 'Rite Aid'
	,MemberIdLabel = 'Member Id'
	,AllowOnlineRegistration = 0
	,AllowPreQualifiedTestOnly = 0
	,AllowCustomerPortalLogin = 1
	,SendResultReadyMail = 0
	,GeneratePcpLetter = 0
	,ShowBasicBiometricPage = 1
	,SendSurveyMail = 0
	,AppointmentConfirmationMailTemplateId = @AppointmentConfirmationMailTemplateId
	,AppointmentReminderMailTemplateId = @AppointmentReminderMailTemplateId
	,ResultReadyMailTemplateId = @ResultReadyMailTemplateId
	,SurveyMailTemplateId = @SurveyMailTemplateId
	,SendResultReadyMailWithFax=0
where AccountID = @AccountId

