
USE [$(dbName)]
Go

CREATE TABLE dbo.TblCorporateShippingOption
	(
	AccountId bigint NOT NULL,
	ShippingOptionId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblCorporateShippingOption ADD CONSTRAINT
	PK_TblCorporateShippingOption PRIMARY KEY CLUSTERED 
	(
	AccountId,
	ShippingOptionId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

