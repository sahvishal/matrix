USE [$(dbName)]
GO

CREATE TABLE TblAccountEventZipSubstitute
(
	AccountId BIGINT NOT NULL,
	ZipId BIGINT NOT NULL,
	CONSTRAINT PK_TblAccountEventZipSubstitute PRIMARY KEY (AccountId, ZipId),
	CONSTRAINT FK_TblAccountEventZipSubstitute_TblAccount FOREIGN KEY (AccountId) REFERENCES [TblAccount]([AccountId]),
	CONSTRAINT FK_TblAccountEventZipSubstitute_TblZip FOREIGN KEY (ZipId) REFERENCES [TblZip]([ZipId])
)
GO