USE [$(dbName)]

GO

CREATE TABLE [dbo].[TblDiabeticRetinopathyParserlog](
	[Id] [bigint] NOT NULL  IDENTITY (1, 1) CONSTRAINT PK_TblDiabeticRetinopathyParserlog PRIMARY KEY CLUSTERED (Id) ON [PRIMARY],
	[CustomerId] [bigint] NULL,
	[EventId] [bigint] NULL,
	[FileName] [varchar](2000) NOT NULL,
	[ErrorMessage] [varchar](4000) NULL,
	[DateCreated] [datetime] Not null,
) 

GO

