USE [$(dbName)]
GO

Alter Table TblAccount 
		Add ParticipantLetterId bigint  NULL 
GO

Alter Table [dbo].[TblAccount]
		Add Constraint FK_TblAccount_ParticipantLetterId FOREIGN KEY([ParticipantLetterId]) REFERENCES dbo.TblFile (FileId)

GO
