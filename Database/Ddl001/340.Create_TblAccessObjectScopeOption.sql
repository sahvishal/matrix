USE [$(dbName)]
Go
  
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblAccessObjectScopeOption](
	[AccessControlObjectId] [bigint] NOT NULL,
	[ScopeId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblAccessObjectScopeOption] PRIMARY KEY CLUSTERED 
(
	[AccessControlObjectId] ASC,
	[ScopeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccessObjectScopeOption]  WITH CHECK ADD  CONSTRAINT [FK_TblAccessObjectScopeOption_AccessControlObject] FOREIGN KEY([AccessControlObjectId])
REFERENCES [dbo].[TblAccessControlObject] ([Id])
GO


ALTER TABLE [dbo].[TblAccessObjectScopeOption]  WITH CHECK ADD  CONSTRAINT [FK_TblAccessObjectScopeOption_Tbllookup] FOREIGN KEY([ScopeId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO


