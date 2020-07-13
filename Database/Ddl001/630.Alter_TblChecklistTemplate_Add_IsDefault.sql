use [$(dbname)]
GO

ALTER TABLE TblChecklistTemplate
ADD IsDefault BIT NOT NULL CONSTRAINT DF_TblAccount_IsDefault DEFAULT(0)
GO