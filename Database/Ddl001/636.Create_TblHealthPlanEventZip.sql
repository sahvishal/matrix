use [$(dbname)]
GO


CREATE TABLE [dbo].[TblHealthPlanEventZip](
	[AccountID] [bigint] NOT NULL,
	[AccountTag] [varchar](255) NOT NULL,
	[EventZipID] [varchar](Max) NOT NULL,
	[DateCreated] [datetime] NOT NULL,
 CONSTRAINT [PK_TblHealthPlanEventZip] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[TblHealthPlanEventZip]  WITH CHECK ADD  CONSTRAINT [FK_TblHealthPlanEventZip_TblAccountID] FOREIGN KEY([AccountID])
REFERENCES [dbo].[TblAccount] ([AccountID])
GO

ALTER TABLE [dbo].[TblHealthPlanEventZip] CHECK CONSTRAINT [FK_TblHealthPlanEventZip_TblAccountID]
GO


