USE [$(dbName)]
Go


/****** Object:  Table [dbo].[TblCustomerMedicaresAnswer]    Script Date: 09/11/2014 16:08:41 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblCustomerMedicareQuestionAnswer](
	[EventCustomerId] [bigint] NOT NULL,
	[QuestionId] [bigint] NOT NULL,
	[Answer] [varchar](50) NOT NULL,
 CONSTRAINT [PK_TblCustomerMedicareQuestionAnswer] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[QuestionId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblCustomerMedicareQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerMedicaresAnswer_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblCustomerMedicareQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerMedicaresAnswer_TblEventCustomers]
GO

ALTER TABLE [dbo].[TblCustomerMedicareQuestionAnswer]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerMedicaresAnswer_TblMedicareQuestion] FOREIGN KEY([QuestionId])
REFERENCES [dbo].[TblMedicareQuestion] ([QuestionId])
GO

ALTER TABLE [dbo].[TblCustomerMedicareQuestionAnswer] CHECK CONSTRAINT [FK_TblCustomerMedicaresAnswer_TblMedicareQuestion]
GO


