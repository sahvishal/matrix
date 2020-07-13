USE [$(dbName)]
Go


/****** Object:  Table [dbo].[TblMedicaresQuestionsRemarks]    Script Date: 09/11/2014 16:07:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblMedicareQuestionsRemarks](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[QuestionValue] [varchar](10) NOT NULL,
	[DependentQuestionId] [bigint] NULL,
	[DependentQuestionValue] [varchar](10) NULL,
	[CombinedQuestionId] [bigint] NULL,
	[CombinedQuestionValue] [varchar](10) NULL,
	[IsDefault] [bit] NOT NULL,
	[Remarks] [varchar](1000) NOT NULL,
 CONSTRAINT [PK_TblMedicareQuestionsRemarks] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks] CHECK CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion]
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion1] FOREIGN KEY([DependentQuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks] CHECK CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion1]
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion2] FOREIGN KEY([CombinedQuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestionsRemarks] CHECK CONSTRAINT [FK_TblMedicaresRemarks_TblMedicareQuestion2]
GO


