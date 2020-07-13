USE [$(dbName)]
Go

delete  from TblMedicareQuestionDependencyRule where QuestionId=18 and DependentQuestionId=25

update TblMedicareQuestionsRemarks set Remarks='GO TO PART III.' where QuestionId=9 and QuestionValue='No' and Remarks='GO TO PART II.'