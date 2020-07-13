USE [$(dbName)]
GO

CREATE TABLE TblZipRadiusDistance
(
	SourceZipId BIGINT NOT NULL,
	DestinationZipId BIGINT NOT NULL,
	Radius int NOT NULL,
	Distance float(53) Not Null,
	CONSTRAINT PK_TblZipRadiusDistance PRIMARY KEY (SourceZipId, DestinationZipId),
	CONSTRAINT FK_TblZipRadiusDistance_TblZip_SourceZipId FOREIGN KEY (SourceZipId) REFERENCES [TblZip]([ZipId]),
	CONSTRAINT FK_TblZipRadiusDistance_TblZip_DestinationZipId FOREIGN KEY (DestinationZipId) REFERENCES [TblZip]([ZipId])
)



GO