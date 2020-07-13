USE [$(dbname)]
GO



CREATE TABLE  TblEventCustomerResultBloodLabParser
(
EventCustomerResultId BIGINT  NOT NULL,
BloodLabId BIGINT NOT NULL,
IsActive	BIT NOT NULL CONSTRAINT DF_TblEventCustomerResultBloodLabParser_IsActive DEFAULT 0,
CONSTRAINT [PK_TblEventCustomerResultBloodLabParser] PRIMARY KEY CLUSTERED 
(
	EventCustomerResultId ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]


ALTER TABLE [dbo].TblEventCustomerResultBloodLabParser  
WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResultBloodLabParser_TblEventCustomerResult] 
FOREIGN KEY([EventCustomerResultId])
REFERENCES [dbo].[TblEventCustomerResult] ([EventCustomerResultId])
GO

ALTER TABLE [dbo].TblEventCustomerResultBloodLabParser  
WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerResultBloodLabParser_TblLookup] 
FOREIGN KEY(BloodLabId)
REFERENCES [dbo].[TblLookup] (LookupId)
GO

