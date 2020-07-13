Use [$(dbName)]

GO

CREATE TABLE TblCustomerResultPosted
(
	CustomerId bigint NOT NULL, 
	ResultPostId bigint IDENTITY (1, 1) NOT NULL, 
	CONSTRAINT [PK_TblCustomerResultPosted] PRIMARY KEY CLUSTERED 
	(
		[CustomerId] ASC
	) ON [PRIMARY]
)

ALTER TABLE [dbo].[TblCustomerResultPosted]  WITH CHECK ADD  CONSTRAINT [FK_ TblCustomerResultPosted_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO