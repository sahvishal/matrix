USE [$(dbName)]
GO

IF EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'ShowChatQuestionnaire'
          AND Object_ID = Object_ID(N'dbo.tblAccount'))
BEGIN
	 ALTER TABLE TblAccount
     DROP CONSTRAINT [DF_tblAccount_ShowChatQuestionnaire], COLUMN ShowChatQuestionnaire
END




