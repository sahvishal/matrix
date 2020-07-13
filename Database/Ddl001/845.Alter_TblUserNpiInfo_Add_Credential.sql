USE[$(dbName)]

GO

ALTER TABLE TblUserNpiInfo
ALTER COLUMN Npi varchar(100)

GO

ALTER TABLE TblUserNpiInfo
ADD [Credential] varchar(20)

GO