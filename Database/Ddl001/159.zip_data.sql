USE [$(dbName)]
GO

/****** Object:  Table [dbo].[ZipData]    Script Date: 11/14/2013 16:12:48 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ZipData]') AND type in (N'U'))
DROP TABLE [dbo].[ZipData]
GO

/****** Object:  Table [dbo].[ZipData]    Script Date: 11/14/2013 16:12:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[ZipData](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ZipCode] [varchar](50) NULL,
	[CityAliasName] [varchar](50) NULL,
	[State] [varchar](50) NULL,
	[County] [varchar](50) NULL,
	[CityType] [varchar](50) NULL,
	[Latitude] [varchar](50) NULL,
	[Longitude] [varchar](50) NULL,
	[TimeZone] [varchar](50) NULL,
	[DayLightSaving] [varchar](50) NULL,
	[PreferredLastLineKey] [varchar](50) NULL,
	[CityMixedCase] [varchar](50) NULL,
	[CityAliasMixedCase] [varchar](50) NULL,
 CONSTRAINT [PK_ZipData] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


