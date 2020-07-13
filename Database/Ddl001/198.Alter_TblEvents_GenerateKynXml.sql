USE [$(dbName)]
GO

ALTER TABLE TblEvents ADD  GenerateKynXml bigint NULL
GO
ALTER TABLE TblEvents ADD CONSTRAINT TblEvents_TblLookup_kynxml FOREIGN KEY (GenerateKynXml) REFERENCES TblLookup (LookupId)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
Go