USE [$(dbName)]
Go

CREATE TABLE [dbo].[TblEventCustomerPreApprovedPackageTest](
	[EventCustomerId] [bigint] NOT NULL,
	[TestId] [bigint] NOT NULL,
	[PackageId] [bigint] NOT NULL,
 CONSTRAINT [PK_TblEventCustomerPreApprovedPackageTest] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[TestId] ASC,
	[PackageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventCustomerPreApprovedPackageTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerPreApprovedPackageTest_TblEventCustomers] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
GO


ALTER TABLE [dbo].[TblEventCustomerPreApprovedPackageTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerPreApprovedPackageTest_TblTest] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestID])
GO

ALTER TABLE [dbo].[TblEventCustomerPreApprovedPackageTest]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerPreApprovedPackageTest_TblPackage] FOREIGN KEY([PackageId])
REFERENCES [dbo].[TblPackage] ([PackageId])
GO

