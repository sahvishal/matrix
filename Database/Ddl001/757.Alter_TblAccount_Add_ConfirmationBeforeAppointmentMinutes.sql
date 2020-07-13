USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD ConfirmationBeforeAppointmentMinutes INT NULL,
	CONSTRAINT FK_TblAccount_TblFile_CallCenterScriptFileId FOREIGN KEY ([CallCenterScriptFileId]) REFERENCES [TblFile]([FileId])

GO