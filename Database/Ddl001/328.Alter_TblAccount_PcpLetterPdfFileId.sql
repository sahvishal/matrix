USE [$(dbName)]
GO 

ALTER TABLE [dbo].[TblAccount]  
		ADD  PcpLetterPdfFileId bigint NULL
		
GO
Alter Table [dbo].[TblAccount]
		Add Constraint FK_TblAccount_PcpLetterPdfFileId FOREIGN KEY([PcpLetterPdfFileId]) REFERENCES dbo.TblFile (FileId)

GO
Alter Table [dbo].[TblAccount]
		Add Constraint FK_TblAccount_SurveyPdfFileId FOREIGN KEY([SurveyPdfFileId]) REFERENCES dbo.TblFile (FileId)