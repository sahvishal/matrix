USE [$(dbName)]
GO 
 
update  TblTag set Alias='Deceased' where  Alias='Deceased/Dead' And ForPreAssessment=1
update  TblTag set Alias='InLongTermCareNursingHome' where  Alias='InLongTermCareNursingHome/Dead' And ForPreAssessment=1
