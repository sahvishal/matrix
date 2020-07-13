USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD EnableSms BIT NOT NULL CONSTRAINT DF_TblAccount_EnableSMS DEFAULT 0,
	MaximumSms INT NULL,
	ConfirmationSmsTemplateId INT NULL,
	ReminderSmsTemplateId INT NULL,
	CONSTRAINT FK_TblAccount_TblEmailTemplate_ConfirmationSmsTemplateId FOREIGN KEY (ConfirmationSmsTemplateId) REFERENCES [TblEmailTemplate](EmailTemplateId),
	CONSTRAINT FK_TblAccount_TblEmailTemplate_ReminderSmsTemplateId FOREIGN KEY (ReminderSmsTemplateId) REFERENCES [TblEmailTemplate](EmailTemplateId)

GO