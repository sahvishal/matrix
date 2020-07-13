USE [$(dbName)]
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TblSafeComputerHistory](
	[Id] [bigint] IDENTITY(1,1) NOT NULL , 
	[UserLoginId] [bigint] NOT NULL, 	
	[BrowserType] [nvarchar](300) NOT NULL,  
	[ComputerIp] [nvarchar](30) NOT NULL   ,	
	[DateCreated] [datetime] NOT NULL, 
	[DateModified] [datetime] NOT NULL, 
	[IsActive] [bit] NOT NULL CONSTRAINT DF_TblSafeComputerHistory_IsActive DEFAULT 1, 
) ON [PRIMARY]
Go

ALTER TABLE dbo.[TblSafeComputerHistory] ADD CONSTRAINT
	PK_TblSafeComputerHistory PRIMARY KEY CLUSTERED 
	(
	[Id] 
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
Go

ALTER TABLE [dbo].[TblSafeComputerHistory] ADD CONSTRAINT [FK_TblSafeComputerHistory_TblUserLogin] FOREIGN KEY([UserLoginId])
REFERENCES [dbo].[TblUserLogin] ([UserLoginID])
GO   

---[TblUserLoginLog]
 
  