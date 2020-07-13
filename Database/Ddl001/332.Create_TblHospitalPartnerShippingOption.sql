
USE [$(dbName)]
GO 

CREATE TABLE dbo.TblHospitalPartnerShippingOption
	(
	HospitalPartnerId bigint NOT NULL,
	ShippingOptionId bigint NOT NULL
	)  ON [PRIMARY]
GO
ALTER TABLE dbo.TblHospitalPartnerShippingOption ADD CONSTRAINT
	PK_TblHospitalPartnerShippingOption PRIMARY KEY CLUSTERED 
	(
	HospitalPartnerId,
	ShippingOptionId
	) WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table [dbo].[TblHospitalPartnerShippingOption]
		Add Constraint FK_TblHospitalPartnerShippingOption_HospitalPartnerId FOREIGN KEY([HospitalPartnerId]) REFERENCES dbo.TblHospitalPartner (HospitalPartnerId)

GO


Alter Table [dbo].[TblHospitalPartnerShippingOption]
		Add Constraint FK_TblHospitalPartnerShippingOption_ShippingOptionId FOREIGN KEY([ShippingOptionId]) REFERENCES dbo.TblShippingOption (ShippingOptionId)

GO

