use [$(dbname)]

go

CREATE TABLE [dbo].[TblAccountEventZip](
	
	[AccountId] [bigint] NOT NULL,
	[ZipId] [bigint] NOT NULL	
		
 CONSTRAINT [PK_TblAccountEventZip] PRIMARY KEY CLUSTERED 
(
	[AccountId] ASC,
	ZipId Asc
) ON [PRIMARY]
)

GO
