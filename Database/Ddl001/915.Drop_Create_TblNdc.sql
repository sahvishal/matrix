USE [$(dbName)]
GO

IF (OBJECT_ID('dbo.FK_TblCurrentMedication_TblNdc', 'F') IS NOT NULL)
BEGIN
  ALTER TABLE [TblCurrentMedication] DROP CONSTRAINT [FK_TblCurrentMedication_TblNdc]
END
go


IF (OBJECT_ID('dbo.FK_TblEventCustomerCurrentMedication_TblNdc', 'F') IS NOT NULL)
BEGIN
	ALTER TABLE [TblEventCustomerCurrentMedication] DROP CONSTRAINT [FK_TblEventCustomerCurrentMedication_TblNdc]
END
go

IF EXISTS (SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'TblNdc') 
	DROP TABLE TblNdc
Go

CREATE TABLE TblNdc
(
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] nvarchar(2048),
	[NdcCode] nvarchar(512),
	[Route] nvarchar(512),
	[Dose] nvarchar (100) Null,
	[ActiveNumeratorStrength] Varchar(1024) Not Null,
	[ActiveIngredUnit]  Varchar(50) Not Null
		
	CONSTRAINT [PK_TblNdc] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = ON, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]
Go


ALTER TABLE [dbo].[TblEventCustomerCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerCurrentMedication_TblNdc] FOREIGN KEY([NdcId])
REFERENCES [dbo].[TblNdc] ([Id])
GO

ALTER TABLE [dbo].[TblCurrentMedication]  WITH CHECK ADD  CONSTRAINT [FK_TblCurrentMedication_TblNdc] FOREIGN KEY([NdcId])
REFERENCES [dbo].[TblNdc] ([Id])
GO