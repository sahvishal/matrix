USE [$(dbName)]
Go

--update with Echocardiogram to HCPEcho
update TblClinicalTestQualificationCriteria set TestId=47 where TestId=4

--update with Stroke to HCPCarotid
update TblClinicalTestQualificationCriteria set TestId=48 where TestId=1

--update with AAA to HCPAAA
update TblClinicalTestQualificationCriteria set TestId=49 where TestId=10
