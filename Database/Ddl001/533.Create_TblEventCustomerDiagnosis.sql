USE [$(dbname)]
GO

/****** Object:  Table [dbo].[TblEventCustomerDiagnosis]    Script Date: 31-03-2017 14:22:02 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblEventCustomerDiagnosis](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[EventCustomerId] [bigint] NOT NULL,
	[Diagnosis] [varchar](max) NULL,
	[Accepted] [bit] NULL,
	[ClinicalMonitor] [varchar](512) NULL,
	[ClinicalEvaluation] [varchar](512) NULL,
	[ClinicalAssessment] [varchar](512) NULL,
	[ClinicalTreatment] [varchar](512) NULL,
	[ClinicalComment] [varchar](max) NULL,
	[Icd] [varchar](50) NULL,
 CONSTRAINT [PK_TblEventCustomerDiagnosis] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblEventCustomerDiagnosis]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerDiagnosis_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerID])
GO

ALTER TABLE [dbo].[TblEventCustomerDiagnosis] CHECK CONSTRAINT [FK_TblEventCustomerDiagnosis_TblEventCustomers]
GO