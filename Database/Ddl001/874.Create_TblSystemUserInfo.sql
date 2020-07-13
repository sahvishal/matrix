use [$(dbName)]
go

Create Table [dbo].[TblSystemUserInfo]
(
	UserId bigint NOT NULL,
	EmployeeId varchar(64) NOT NULL,CONSTRAINT [PK_TblSystemUserInfo] PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblSystemUserInfo]  WITH CHECK ADD  CONSTRAINT [FK_TblSystemUserInfo_TblUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[TblUser] ([UserID])
GO

ALTER TABLE [dbo].[TblSystemUserInfo] CHECK CONSTRAINT [FK_TblSystemUserInfo_TblUser]
GO
