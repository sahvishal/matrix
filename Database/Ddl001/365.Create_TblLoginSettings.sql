USE [$(dbName)]
GO


Create TABLE dbo.TblLoginSettings
(
	[UserLoginId] [bigint] NOT NULL, 
	[GoogleAuthenticatorSecretKey] [nvarchar](max) NULL,
	[DownloadFilePin] [varchar](10) NULL,
	[AuthenticationModeId] bigint  NULL,
	[IsFirstLogin] bit CONSTRAINT DF_TblLoginSettings_IsFirstLogin DEFAULT 1
	
)
GO 

ALTER TABLE dbo.[TblLoginSettings] ADD CONSTRAINT
	PK_TblLoginSettings PRIMARY KEY CLUSTERED 
	(
	[UserLoginId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblLoginSettings]  
					ADD  CONSTRAINT [FK_TblLoginSettings_Tbllookup_AuthenticationModeId] FOREIGN KEY([AuthenticationModeId])
					REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE dbo.[TblLoginSettings] ADD  CONSTRAINT [FK_TblLoginSettings_TblUserLogin] FOREIGN KEY([UserLoginId])
					REFERENCES [dbo].[TblUserLogin] ([UserLoginId])
Go