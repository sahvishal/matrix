USE [$(dbname)]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[TblCustomerPredictedZip](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[CustomerID] [bigint] NOT NULL,
	[PredictedZip] [varchar](200) NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblCustomerPredictedZip] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblCustomerPredictedZip]  WITH CHECK ADD  CONSTRAINT [FK_TblCustomerPredictedZip_CustomerID] FOREIGN KEY([CustomerID])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblCustomerPredictedZip] CHECK CONSTRAINT [FK_TblCustomerPredictedZip_CustomerID]
GO


