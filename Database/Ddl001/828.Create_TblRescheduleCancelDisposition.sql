USE[$(dbName)]
GO


CREATE TABLE [TblRescheduleCancelDisposition](
	[Id] [bigint] NOT NULL,
	[LookupId] [bigint] NOT NULL,
	[Alias] [varchar](255) NOT NULL,
	[DisplayName] [varchar](1024) NOT NULL,
	[Description] [ntext] NULL,
	[RelativeOrder] [int] NOT NULL,
	[DateCreated] [datetime] NOT NULL,
	[DataRecorderCreatorID] [bigint] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TblRescheduleCancelDisposition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO

ALTER TABLE [TblRescheduleCancelDisposition] ADD  CONSTRAINT [DF_TblRescheduleCancelDisposition_IsActive]  DEFAULT (1) FOR [IsActive]
GO

ALTER TABLE [TblRescheduleCancelDisposition] ADD  CONSTRAINT [DF_TblRescheduleCancelDisposition_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO

ALTER TABLE [TblRescheduleCancelDisposition]  WITH CHECK ADD  CONSTRAINT [FK_TblRescheduleCancelDisposition_TblLookup] FOREIGN KEY([LookupId])
REFERENCES [TblLookup] ([LookupId])
GO

ALTER TABLE [TblRescheduleCancelDisposition] CHECK CONSTRAINT [FK_TblRescheduleCancelDisposition_TblLookup]
GO
