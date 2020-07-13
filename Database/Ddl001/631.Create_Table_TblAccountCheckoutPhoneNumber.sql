USE [$(dbname)]
GO

CREATE TABLE [dbo].[TblAccountCheckoutPhoneNumber](
	[AccountID] [bigint] NOT NULL,
	[StateID] [bigint] NOT NULL,
	[CheckoutPhoneNumber] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_TblAccountCheckoutPhoneNumber_1] PRIMARY KEY CLUSTERED 
(
	[AccountID] ASC,
	[StateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblAccountCheckoutPhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountCheckoutPhoneNumber_TblAccountId] FOREIGN KEY([AccountID])
REFERENCES [dbo].[TblAccount] ([AccountID])
GO

ALTER TABLE [dbo].[TblAccountCheckoutPhoneNumber] CHECK CONSTRAINT [FK_TblAccountCheckoutPhoneNumber_TblAccountId]
GO

ALTER TABLE [dbo].[TblAccountCheckoutPhoneNumber]  WITH CHECK ADD  CONSTRAINT [FK_TblAccountCheckoutPhoneNumber_TblStateId] FOREIGN KEY([StateID])
REFERENCES [dbo].[TblState] ([StateID])
GO

ALTER TABLE [dbo].[TblAccountCheckoutPhoneNumber] CHECK CONSTRAINT [FK_TblAccountCheckoutPhoneNumber_TblStateId]
GO


