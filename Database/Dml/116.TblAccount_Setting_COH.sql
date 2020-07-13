
USE [$(dbName)]
Go

--City of Houston
Declare @AccountId bigint
set @AccountId = 887

Declare @AppointmentConfirmationMailTemplateId bigint
		,@AppointmentReminderMailTemplateId bigint 
		,@ResultReadyMailTemplateId bigint
		,@SurveyMailTemplateId bigint 

select @AppointmentConfirmationMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'AppointmentConfirmationWithEventDetails'

select @AppointmentReminderMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'ScreeningReminderMail'

select @ResultReadyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'ResultsReady'

select @SurveyMailTemplateId = EmailTemplateId from TblEmailTemplate where EmailTitle = 'SurveyEmailNotification'

update TblAccount 
set Tag = 'COH'
	,MemberIdLabel = 'AMI'
	,AllowOnlineRegistration = 1
	,AllowPreQualifiedTestOnly = 0
	,AllowCustomerPortalLogin = 1
	,SendResultReadyMail = 1
	,GeneratePcpLetter = 0
	,ShowBasicBiometricPage = 1
	,SendSurveyMail = 0
	,AppointmentConfirmationMailTemplateId = @AppointmentConfirmationMailTemplateId
	,AppointmentReminderMailTemplateId = @AppointmentReminderMailTemplateId
	,ResultReadyMailTemplateId = @ResultReadyMailTemplateId
	,SurveyMailTemplateId = @SurveyMailTemplateId
	,SendResultReadyMailWithFax=0
where AccountID = @AccountId

