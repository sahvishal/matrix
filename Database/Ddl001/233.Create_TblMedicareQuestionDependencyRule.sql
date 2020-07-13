USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblMedicareQuestionDependencyRule]    Script Date: 09/11/2014 16:06:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblMedicareQuestionDependencyRule](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[DependentQuestionId] [bigint] NOT NULL,
	[DependencyValue] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblMedicareQuestionDependencyRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblMedicareQuestionDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareQuestionDependencyRule_TblMedicareQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestionDependencyRule] CHECK CONSTRAINT [FK_TblMedicareQuestionDependencyRule_TblMedicareQuestion]
GO

ALTER TABLE [dbo].[TblMedicareQuestionDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareQuestionDependencyRule_TblMedicareQuestion1] FOREIGN KEY([DependentQuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareQuestionDependencyRule] CHECK CONSTRAINT [FK_TblMedicareQuestionDependencyRule_TblMedicareQuestion1]
GO


