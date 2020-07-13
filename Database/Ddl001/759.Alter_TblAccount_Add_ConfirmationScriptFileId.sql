USE [$(dbname)]
GO

ALTER TABLE TblAccount
ADD ConfirmationScriptFileId BIGINT NULL,
	CONSTRAINT FK_TblAccount_TblFile_ConfirmationScriptFileId FOREIGN KEY([ConfirmationScriptFileId]) REFERENCES [TblFile]([FileId])

GO