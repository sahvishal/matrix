USE [$(dbName)]
GO

CREATE TABLE TblPreQualificationQuestionRule
(
 [Id] [bigint] IDENTITY(1,1) NOT NULL
,QuestionId BIGINT NOT NULL
,DependentQuestionId BIGINT NOT NULL
,DependencyValue varchar(200)
CONSTRAINT [PK_TblPreQualificationQuestionRule] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPreQualificationQuestionRule]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationQuestionRule_TblPreQualificationQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblPreQualificationQuestion] ([Id])
GO

ALTER TABLE [dbo].[TblPreQualificationQuestionRule]  WITH CHECK ADD  CONSTRAINT [FK_TblPreQualificationQuestionRule_TblPreQualificationQuestion_DependentQuestionId] FOREIGN KEY([DependentQuestionId])
REFERENCES [dbo].[TblPreQualificationQuestion] ([Id])
GO

--DROP TABLE TblPreQualificationQuestionRule
