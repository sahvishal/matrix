USE [$(dbname)]
GO

CREATE TABLE TblEventZip
(
	EventId BIGINT NOT NULL,
	ZipId BIGINT NOT NULL,
	CONSTRAINT PK_TblEventZip PRIMARY KEY(EventId, ZipId),
	CONSTRAINT FK_TblEventZip_TblEvents FOREIGN KEY ([EventId]) REFERENCES [TblEvents]([EventID]),
	CONSTRAINT FK_TblEventZip_TblZip FOREIGN KEY ([ZipId]) REFERENCES [TblZip]([ZipID])
)

GO