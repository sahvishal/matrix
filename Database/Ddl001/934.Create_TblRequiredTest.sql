USE [$(dbName)]
GO

CREATE TABLE TblRequiredTest
(
 Id bigint Identity(1,1) NOT NULL 
,CustomerId bigint NOT NULL
,TestId bigint NOT NULL
,IsActive bit NOT NULL
,CreatedBy bigint  
,CreatedDate Datetime 
CONSTRAINT [PK_TblRequiredTest] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblRequiredTest] ADD CONSTRAINT [DF_TblRequiredTest_IsActive] DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblRequiredTest]  WITH CHECK ADD  CONSTRAINT [FK_TblRequiredTest_TblOrganizationRoleUser_CreatedBy] FOREIGN KEY([CreatedBy])
REFERENCES [dbo].[TblOrganizationRoleUser] ([OrganizationRoleUserID])
GO

ALTER TABLE [dbo].[TblRequiredTest]  WITH CHECK ADD  CONSTRAINT [FK_TblRequiredTest_TblTest_TestId] FOREIGN KEY([TestId])
REFERENCES [dbo].[TblTest] ([TestId])
GO

ALTER TABLE [dbo].[TblRequiredTest]  WITH CHECK ADD  CONSTRAINT [FK_TblRequiredTest_TblCustomerProfile_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerId])
GO