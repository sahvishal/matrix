
USE [$(dbName)]
GO

Alter Table TblCustomerHealthQuestions Add ParentQuestionId bigint null
GO

ALTER TABLE TblCustomerHealthQuestions ADD CONSTRAINT TblCustomerHealthQuestions_ParentQuestionId FOREIGN KEY (ParentQuestionId) REFERENCES TblCustomerHealthQuestions (CustomerHealthQuestionID)
Go

Alter Table TblCustomerHealthQuestions Add IsForFemale bit null
GO

-----------------------------------------------------------------------------------------------

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_DependantQuestionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHealthQuestionDependencyRule]'))
ALTER TABLE [dbo].[TblHealthQuestionDependencyRule] DROP CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_DependantQuestionId]
GO

IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_QuestionId]') AND parent_object_id = OBJECT_ID(N'[dbo].[TblHealthQuestionDependencyRule]'))
ALTER TABLE [dbo].[TblHealthQuestionDependencyRule] DROP CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_QuestionId]
GO


/****** Object:  Table [dbo].[TblHealthQuestionDependencyRule]    Script Date: 05/12/2014 13:57:26 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TblHealthQuestionDependencyRule]') AND type in (N'U'))
DROP TABLE [dbo].[TblHealthQuestionDependencyRule]
GO

/****** Object:  Table [dbo].[TblHealthQuestionDependencyRule]    Script Date: 05/12/2014 13:57:26 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblHealthQuestionDependencyRule](
	[QuestionId] [bigint] NOT NULL,
	[DependantQuestionId] [bigint] NOT NULL,
	[DependencyRule] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblHealthQuestionDependencyRule] PRIMARY KEY CLUSTERED 
(
	[QuestionId] ASC,
	[DependantQuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblHealthQuestionDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_QuestionId] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblHealthQuestionDependencyRule] CHECK CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_QuestionId]
GO

ALTER TABLE [dbo].[TblHealthQuestionDependencyRule]  WITH CHECK ADD  CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_DependantQuestionId] FOREIGN KEY([DependantQuestionId])
REFERENCES [dbo].[TblCustomerHealthQuestions] ([CustomerHealthQuestionID])
GO

ALTER TABLE [dbo].[TblHealthQuestionDependencyRule] CHECK CONSTRAINT [FK_TblHealthQuestionDependencyRule_TblCustomerHealthQuestions_DependantQuestionId]
GO