USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblHospitalPartnerEventNotes]    Script Date: 03/19/2012 15:50:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblHospitalPartnerEventNotes](
	[NotesId] [bigint] NOT NULL,
	[EventId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblHospitalPartnerEventNotes] PRIMARY KEY CLUSTERED 
(
	[NotesId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblHospitalPartnerEventNotes]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalPartnerEventNotes_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblHospitalPartnerEventNotes] CHECK CONSTRAINT [FK_TblHospitalPartnerEventNotes_TblEvents]
GO

ALTER TABLE [dbo].[TblHospitalPartnerEventNotes]  WITH CHECK ADD  CONSTRAINT [FK_TblHospitalPartnerEventNotes_TblNotesDetails] FOREIGN KEY([NotesId])
REFERENCES [dbo].[TblNotesDetails] ([NoteID])
GO

ALTER TABLE [dbo].[TblHospitalPartnerEventNotes] CHECK CONSTRAINT [FK_TblHospitalPartnerEventNotes_TblNotesDetails]
GO


