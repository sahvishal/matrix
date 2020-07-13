USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblMedicareQuestion]    Script Date: 09/11/2014 16:04:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblMedicareQuestion](
	[QuestionId] [bigint] NOT NULL,
	[GroupId] [bigint] NOT NULL,
	[Question] [varchar](2000) NOT NULL,
	[ControlValue] [varchar](50) NOT NULL,
	[ControlType] [bigint] NOT NULL,
	[Delimiter] [nchar](10) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsRequired] [bit] NOT NULL,
	[DisplaySequence] [int] NOT NULL,
	[ParentQuestionId] [bigint] NULL,
 CONSTRAINT [PK_TblMedicareQuestion] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblMedicareQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareQuestion_TblLookup] FOREIGN KEY([ControlType])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblMedicareQuestion] CHECK CONSTRAINT [FK_TblMedicareQuestion_TblLookup]
GO

ALTER TABLE [dbo].[TblMedicareQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareQuestion_TblMedicareQuestion] FOREIGN KEY([GroupId])
REFERENCES [dbo].[TblMedicareQuestionGroup] ([GroupId])
GO

ALTER TABLE [dbo].[TblMedicareQuestion] CHECK CONSTRAINT [FK_TblMedicareQuestion_TblMedicareQuestion]
GO

ALTER TABLE [dbo].[TblMedicareQuestion]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareQuestion_TblMedicareQuestion2] FOREIGN KEY([ParentQuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestion] CHECK CONSTRAINT [FK_TblMedicareQuestion_TblMedicareQuestion2]
GO


