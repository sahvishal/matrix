USE [$(dbname)]
GO

CREATE TABLE TblLoincLabData
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[MemberId] NVARCHAR(100) NULL,
	[Gmpi] NVARCHAR(100) NULL,
	[Loinc] NVARCHAR(50) NULL,
	[LoincDescription] NVARCHAR(MAX) NULL,
	[ResultValue] NVARCHAR(MAX) NULL,
	[ResultUnits] NVARCHAR(100) NULL,
	[RefRange] NVARCHAR(100) NULL,
	[UploadId] BIGINT NOT NULL,
	[Year] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT DF_TblLoincLabData_DateCreated DEFAULT GETDATE(),
	CONSTRAINT PK_TblLoincLabData PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblLoincLabData_TblOutboundUpload FOREIGN KEY ([UploadId]) REFERENCES [TblOutboundUpload]([Id])
)
GO


CREATE TABLE TblLoincCrosswalk
(
	[Id] BIGINT IDENTITY(1,1) NOT NULL,
	[LoincNumber] NVARCHAR(50) NULL,
	[Component] NVARCHAR(MAX) NULL,
	[System] NVARCHAR(256) NULL,
	[MethodType] NVARCHAR(256) NULL,
	[VersionLastChanged] NVARCHAR(50) NULL,
	[DefinitionDescription] NVARCHAR(MAX) NULL,
	[Formula] NVARCHAR(MAX) NULL,
	[Species] NVARCHAR(100) NULL,
	[ExampleAnswers] NVARCHAR(MAX) NULL,
	[SurveyQuestionText] NVARCHAR(MAX) NULL,
	[SurveyQuestionSource] NVARCHAR(256) NULL,
	[UnitsRequired] NVARCHAR(10) NULL,
	[SubmittedUnits] NVARCHAR(100) NULL,
	[CdiscCommonTests] NVARCHAR(50) NULL,
	[Hl7FieldSubfieldId] NVARCHAR(100) NULL,
	[ExternalCopyrightNotice] NVARCHAR(MAX) NULL,
	[ExampleUnits] NVARCHAR(100) NULL,
	[LongCommonName] NVARCHAR(MAX) NULL,
	[UploadId] BIGINT NOT NULL,
	[Year] INT NOT NULL,
	[DateCreated] DATETIME NOT NULL CONSTRAINT DF_TblLoincCrosswalk_DateCreated DEFAULT GETDATE(),
	CONSTRAINT PK_TblLoincCrosswalk PRIMARY KEY ([Id]),
	CONSTRAINT FK_TblLoincCrosswalk_TblOutboundUpload FOREIGN KEY ([UploadId]) REFERENCES [TblOutboundUpload]([Id])
)
GO

