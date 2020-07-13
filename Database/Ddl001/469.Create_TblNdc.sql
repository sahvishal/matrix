USE [$(dbName)]
GO

/****** Object:  Table [dbo].[Ndc]    Script Date: 11-11-2016 11:43:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO
 
CREATE TABLE [dbo].[TblNdc](
	[Id] [bigint] Identity(1,1) NOT NULL,
	[ProductId] [varchar](50) NOT NULL,
	[ProductNdc] [varchar](10) NOT NULL,
	[ProductTypeName] [varchar](100) NOT NULL,
	[ProprietaryName] [varchar](512) NOT NULL,
	[ProprietaryNameSuffix] [varchar](256) NULL,
	[NonProprietaryName] [varchar](1024) NOT NULL,
	[DosageFormName] [varchar](128) NULL,
	[RouteName] [varchar](256) NULL,
	[StartMarketingDate] [varchar](8) NOT NULL,
	[EndMarketingDate] [varchar](8) NULL,
	[MarketingCategoryName] [varchar](128) NOT NULL,
	[ApplicationNumber] [varchar](20) NULL,
	[LabelerName] [varchar](256) NULL,
	[SubstanceName] [varchar](max) NULL,
	[ActiveNumeratorStrength] [varchar](1024) NULL,
	[ActiveIngredUnit] [varchar](4096) NULL,
	[PharmaClasses] [varchar](max) NULL,
	[Deaschedule] [varchar](10) NULL,
	CONSTRAINT [PK_TblNdc] PRIMARY KEY CLUSTERED 
	(
		[Id]  ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_PADDING OFF
GO

