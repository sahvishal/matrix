USE [$(dbName)]
Go

Update TblMedicareQuestion set  Question ='Date benefits began:' where QuestionId=65
Update TblMedicareQuestion set  Question =' Does the working aged or disability MSP provision apply (i.e., is the GHP primarily based on age or disability entitlement?' where QuestionId=64
Update TblMedicareQuestion set  Question =' Date dialysis began:' where QuestionId=59