USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblMedicareGroupDependencyRule]    Script Date: 09/11/2014 16:06:55 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblMedicareGroupDependencyRule](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[DependentGroupId] [bigint] NOT NULL,
	[DependencyValue] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblMedicareGroupDependencyRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblMedicareGroupDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareGroupDependencyRule_TblMedicareQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblMedicareGroupDependencyRule] CHECK CONSTRAINT [FK_TblMedicareGroupDependencyRule_TblMedicareQuestion]
GO

ALTER TABLE [dbo].[TblMedicareGroupDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblMedicareGroupDependencyRule_TblMedicareQuestionGroup] FOREIGN KEY([DependentGroupId])
REFERENCES [dbo].[TblMedicareQuestionGroup] ([GroupId])
GO

ALTER TABLE [dbo].[TblMedicareGroupDependencyRule] CHECK CONSTRAINT [FK_TblMedicareGroupDependencyRule_TblMedicareQuestionGroup]
GO


