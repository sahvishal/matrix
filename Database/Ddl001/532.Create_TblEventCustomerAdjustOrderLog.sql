USE [$(dbName)]
Go

CREATE TABLE [dbo].[TblEventCustomerAdjustOrderLog](
	[EventCustomerId] [bigint] NOT NULL,
	[UploadId] [bigint] NOT NULL,
	[StatusId] [bigint] NOT NULL		
 CONSTRAINT [PK_TblEventCustomerAdjustOrderLog] PRIMARY KEY CLUSTERED 
(
	[EventCustomerId] ASC,
	[UploadId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[TblEventCustomerAdjustOrderLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerAdjustOrderLog_TblEventCustomers_EventCustomerId] FOREIGN KEY([EventCustomerId])
REFERENCES [dbo].[TblEventCustomers] ([EventCustomerId])
GO

ALTER TABLE [dbo].[TblEventCustomerAdjustOrderLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerAdjustOrderLog_TblCorporateUpload_UploadId] FOREIGN KEY([UploadId])
REFERENCES [dbo].[TblCorporateUpload] ([Id])
GO


ALTER TABLE [dbo].[TblEventCustomerAdjustOrderLog]  WITH CHECK ADD  CONSTRAINT [FK_TblEventCustomerAdjustOrderLog_TblLookup_StatusId] FOREIGN KEY([StatusId])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO