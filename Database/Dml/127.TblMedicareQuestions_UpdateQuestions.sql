USE [$(dbName)]
Go

Update TblMedicareQuestionsRemarks Set [Remarks] ='GO TO PART III' where QuestionId=9 and QuestionValue='No'
Update TblMedicareQuestion set  Question ='Date benifits began:' where QuestionId=65
Update TblMedicareQuestion set  Question ='Is your spouse currently employed?' where QuestionId=21
Update TblMedicareQuestion set  Question ='Name and address of spouse''s employer:' where QuestionId=22
Update TblMedicareQuestion set  Question ='Do you have group health plan (GHP) coverage based on your own, or a spouse''s current employment?' where QuestionId=24
Update TblMedicareQuestion set  Question =' Are you entitled to Medicare on the basis of either ESRD and age or ESRD and disability?' where QuestionId=62
Update TblMedicareQuestion set  Question =' Does the working aged or disability MSP provision apply (i.e., is the GHP primarily based on age or disability entitlement?' where QuestionId=64
Delete TblMedicareQuestionDependencyRule where QuestionId=25 and DependentQuestionId=32 and DependencyValue='Yes'