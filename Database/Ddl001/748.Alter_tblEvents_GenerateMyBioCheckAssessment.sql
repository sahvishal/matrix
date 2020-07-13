use [$(dbname)]
go

Alter TABLE TblEvents ADD GenerateMyBioCheckAssessment BIGINT NULL,
	CONSTRAINT FK_TblEvents_TblLookup_GenerateMyBioCheckAssessment FOREIGN KEY(GenerateMyBioCheckAssessment) REFERENCES [TblLookup](LookupId)
GO