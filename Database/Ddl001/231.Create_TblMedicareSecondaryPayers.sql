USE [$(dbName)]
Go

/****** Object:  Table [dbo].[TblMedicareQuestionGroup]    Script Date: 09/11/2014 16:03:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblMedicareQuestionGroup](
	[GroupId] [bigint] NOT NULL,
	[GroupName] [varchar](255) NOT NULL,
	[GroupAlias] [varchar](255) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[IsDefault] [bit] NOT NULL,
 CONSTRAINT [PK_TblMedicareQuestionGroup] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblMedicareQuestionGroup] ADD  CONSTRAINT [DF_TblMedicareQuestionGroup_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblMedicareQuestionGroup] ADD  CONSTRAINT [DF_TblMedicareQuestionGroup_IsDefault]  DEFAULT ((0)) FOR [IsDefault]
GO


