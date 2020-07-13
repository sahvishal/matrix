USE [$(dbName)]
GO

ALTER TABLE TblEvents ADD  GenerateHealthAssesmentFormStatus bigint NULL
GO

ALTER TABLE TblEvents ADD CONSTRAINT TblEvents_TblLookup_GenerateHealthAssesmentFormStatus FOREIGN KEY (GenerateHealthAssesmentFormStatus) REFERENCES TblLookup (LookupId)
  ON DELETE NO ACTION
  ON UPDATE NO ACTION;
Go