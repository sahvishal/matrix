USE [$(dbName)]
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblLoginOtp](
	[UserLoginId] [bigint] NOT NULL, 	
	[Otp] [varchar](20) NOT NULL,  
	[AttemptCount] [int] NOT NULL  CONSTRAINT DF_TblLoginOtp_AttemptCount DEFAULT 0 ,	
	[DateCreated] [datetime] NOT NULL 
) ON [PRIMARY]
Go

ALTER TABLE dbo.[TblLoginOtp] ADD CONSTRAINT
	PK_TblLoginOtp PRIMARY KEY CLUSTERED 
	(
	[UserLoginId] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblLoginOtp] ADD CONSTRAINT [FK_TblLoginOtp_TblUserLogin] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[TblUserLogin] ([UserLoginID])
GO   
 
 
 -- Alter Table [TblLoginOtp] drop constraint DF_TblLoginOtp_AttemptCount
 -- Alter Table [TblLoginOtp] Add constraint DF_TblLoginOtp_AttemptCount DEFAULT 0 For [AttemptCount]