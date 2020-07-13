USE [$(dbName)]
Go 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblCorporateTag](
	[CorporateTagId] [bigint] IDENTITY(1,1) NOT NULL, 
	[CorporateId] [bigint] NOT NULL, 
	[Tag] [varchar](255) NOT NULL,	
	[DateCreated] [datetime] NOT NULL, 
	[IsActive] [bit] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.TblCorporateTag ADD CONSTRAINT
	PK_TblCorporateTag PRIMARY KEY CLUSTERED 
	(
	[CorporateTagId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblCorporateTag]  WITH CHECK ADD  CONSTRAINT [FK_TblCorporateTag_TblAccount] FOREIGN KEY([CorporateId])
REFERENCES [dbo].[TblAccount] ([AccountId])
GO   
 
ALTER TABLE [dbo].[TblCorporateTag] ADD CONSTRAINT [DF_TblCorporateTag_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

 
  
  