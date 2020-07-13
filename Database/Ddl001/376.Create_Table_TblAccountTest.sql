USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblAccountTest](
 [AccountID] [bigint] NOT NULL,
 [TestID] [bigint] NOT NULL, 
 CONSTRAINT [PK_TblAccountTest] PRIMARY KEY CLUSTERED 
(
 [AccountID] ASC,
 [TestID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccountTest]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountTest_TblAccount] FOREIGN KEY([AccountID])
REFERENCES [dbo].[TblAccount] ([AccountID])
GO

ALTER TABLE [dbo].[TblAccountTest] CHECK CONSTRAINT [FK_TblAccountTest_TblAccount]
GO

ALTER TABLE [dbo].[TblAccountTest]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountTest_TblTest] FOREIGN KEY([TestID])
REFERENCES [dbo].[TblTest] ([TestID])
GO

ALTER TABLE [dbo].[TblAccountTest] CHECK CONSTRAINT [FK_TblAccountTest_TblTest]
GO

