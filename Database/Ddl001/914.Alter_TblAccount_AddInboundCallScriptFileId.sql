USE [$(dbName)]
GO

ALTER TABLE TblAccount
ADD InboundCallScriptFileId BIGINT NULL,
	CONSTRAINT FK_TblAccount_TblFile_InboundCallScriptFileId FOREIGN KEY([InboundCallScriptFileId]) REFERENCES [TblFile]([FileId])

GO