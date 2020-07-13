use [$(dbname)]
go

Alter TABLE TblEvents ADD GenerateHkynXml BIGINT NULL,
	CONSTRAINT FK_TblEvents_TblLookup FOREIGN KEY(GenerateHkynXml) REFERENCES [TblLookup](LookupId)
GO