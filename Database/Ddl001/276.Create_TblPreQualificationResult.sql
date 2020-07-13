USE [$(dbName)]
Go

 CREATE TABLE [dbo].[TblPreQualificationResult](
	[PreQualificationResultId] [bigint] IDENTITY(1,1) NOT NULL,
	[EventId] [bigint] NOT NULL,
	[CustomerId] [bigint] NULL,
	[TempCartId] [bigint] NULL,
	[SignUpModeId] [bigint] NOT NULL,
	[CallId] [bigint] NULL,
	[HighBloodPressure] [bigint] NULL,
	[Smoker] [bigint] NULL,
	[HeartDisease] [bigint] NULL,
	[Diabetic] [bigint] NULL,
	[ChestPain] [bigint] NULL,
	[DiagnosedHeartProblem] [bigint] NULL,
	[HighCholestrol] [bigint] NULL,
	[OverWeight] [bigint] NULL,
	[DateCreated] [datetime] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[AgreedWithPrequalificationQuestion]	bit NOT NULL,
	[SkipPreQualificationQuestion]	bit NOT NULL,
	[AgeOverPreQualificationQuestion]	bigint  NULL,
 CONSTRAINT [PK_TblPreQualificationResult] PRIMARY KEY CLUSTERED  ( [PreQualificationResultId] ASC ) 
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[TblPreQualificationResult] ADD  CONSTRAINT [DF_TblPreQualificationResult_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[TblPreQualificationResult] ADD  CONSTRAINT [DF_TblPreQualificationResult_AgreedWithPrequalificationQuestion]  DEFAULT ((0)) FOR [AgreedWithPrequalificationQuestion]
GO

ALTER TABLE [dbo].[TblPreQualificationResult] ADD  CONSTRAINT [DF_TblPreQualificationResult_SkipPreQualificationQuestion]  DEFAULT ((0)) FOR [SkipPreQualificationQuestion]
GO

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_TblEvents] FOREIGN KEY([EventId])
REFERENCES [dbo].[TblEvents] ([EventID])
GO

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_TblCustomerProfile] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[TblCustomerProfile] ([CustomerID])
GO

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_TblTempCart] FOREIGN KEY([TempCartId])
REFERENCES [dbo].[TblTempCart] ([Id])
GO 

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_TblCalls] FOREIGN KEY([CallId])
REFERENCES [dbo].[TblCalls] ([CallID])
GO

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_ChestPain_Lookup] FOREIGN KEY([ChestPain])
REFERENCES [dbo].[TblLookup] ([LookupId]) 
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_Diabetic_Lookup] FOREIGN KEY([Diabetic])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_DiagnosedHeartProblem_Lookup] FOREIGN KEY([DiagnosedHeartProblem])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_HearthDisease_Lookup] FOREIGN KEY([HeartDisease])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_HighBloodPressure_Lookup] FOREIGN KEY([HighBloodPressure])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_HighCholestrol_Lookup] FOREIGN KEY([HighCholestrol])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_OverWeight_Lookup] FOREIGN KEY([OverWeight])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO
ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_Smoker_Lookup] FOREIGN KEY([Smoker])
REFERENCES [dbo].[TblLookup] ([LookupId])
GO

ALTER TABLE [dbo].[TblPreQualificationResult]  ADD  CONSTRAINT [FK_TblPreQualificationResult_AgeOverPreQualificationQuestion_Lookup] FOREIGN KEY([AgeOverPreQualificationQuestion])
REFERENCES [dbo].[TblLookup] ([LookupId]) 
GO

