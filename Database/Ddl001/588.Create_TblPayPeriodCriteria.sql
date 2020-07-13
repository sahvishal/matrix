USE [$(dbName)]
GO

CREATE TABLE [dbo].[TblPayPeriodCriteria](
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[PayPeriodId] BIGINT NOT NULL,
	[MinCustomer] BIGINT NOT NULL,
	[MaxCustomer] BIGINT NULL,
	[TypeId] BIGINT NOT NULL,
	[Ammount] decimal (18,2),	
		CONSTRAINT PK_TblPayPeriodCriteria PRIMARY KEY([Id])
	) ON [PRIMARY]

GO


ALTER TABLE [dbo].[TblPayPeriodCriteria]  WITH CHECK ADD  CONSTRAINT [FK_TblPayPeriodCriteria_TblPayPeriod_PayPeriodId] FOREIGN KEY([PayPeriodId])
REFERENCES [dbo].[TblPayPeriod] ([Id])
GO
