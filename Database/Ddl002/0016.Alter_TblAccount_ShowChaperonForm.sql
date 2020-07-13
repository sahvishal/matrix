USE	[$(dbname)]
GO

ALTER TABLE TblAccount 
ADD ShowChaperonForm BIT NOT NULL CONSTRAINT DF_TblAccount_ShowChaperonForm DEFAULT 0

