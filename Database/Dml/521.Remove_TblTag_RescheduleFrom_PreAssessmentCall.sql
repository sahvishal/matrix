USE [$(dbName)]
GO 

------- Update -----------
Update TblTag set IsActive=0 where  Alias='RescheduleAppointment' And  ForPreAssessment=1