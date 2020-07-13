USE [$(dbName)]
Go

Declare @NotificationTypeId int
select @NotificationTypeId = NotificationTypeId from TblNotificationType where NotificationTypeNameAlias = 'LoginOTPSmsNotification'

if not Exists (select EmailTemplateId from TblEmailTemplate where EmailTitle = 'LoginOTPSmsNotification')
begin
	INSERT INTO [TblEmailTemplate]
			   ([EmailTitle],[EmailSubject],[EmailBody],[DateCreated],[DateModified],[TemplateType],[NotificationTypeId])
	VALUES
	('LoginOTPSmsNotification','Login OTP Sms Notification' 
		,'One Time Password for Login is @(Model.Otp) . Please use this password to complete login.'
		,getDate(),getDate(),175,@NotificationTypeId)

end
else
begin
	update TblEmailTemplate 
	set [EmailBody] = 'One Time Password for Login is @(Model.Otp) . Please use this password to complete login.'
	where EmailTitle = 'LoginOTPSmsNotification'
end
