USE [$(dbname)]
GO

ALTER TABLE TblTag
ADD ForPreAssessment bit null  CONSTRAINT DF_ForPreAssessment_ForPreAssessment DEFAULT 0 
 
 

 

