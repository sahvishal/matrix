
USE [$(dbName)]
Go

Update TblMedicareQuestion set  Question ='Was the illness/injury due to a work related accident/condition?' where QuestionId=4
Update TblMedicareQuestion set  Question =' Date of accident:' where QuestionId=10
Update TblMedicareQuestion set  Question ='Name and address of any liability insurer:' where QuestionId=15
Update TblMedicareQuestion set  Question ='Name and address of spouse''s employer' where QuestionId=22
Update TblMedicareQuestion set  Question ='Do you have group health plan (GHP) coverage based on your own, or a spouse''s current employment' where QuestionId=24
Update TblMedicareQuestion set  ControlType=127 where QuestionId=36
Update TblMedicareQuestion set  Question ='Are you covered under the group health plan of a family member other than your spouse?' where QuestionId=39

Update TblMedicareQuestion set  Question ='Name and address of your family member''s employer:' where QuestionId=40
Update TblMedicareQuestion set  Question ='Does the employer that sponsors the GHP employ 100 or more employees?' where QuestionId=41


Update TblMedicareQuestion set  Question ='Are you within the 30-month coordination period that starts MM/DD/CCYY?  (The 30-month coordination period starts the first day of the month an individual is eligible for Medicare (even if not yet enrolled in Medicare) because of kidney failure (usually the fourth month of dialysis. If the individual is participating in a self-dialysis training program or has a kidney transplant during the 3-month waiting period, the 30-month coordination period starts with the first day of the month of dialysis or kidney transplant.) '		where QuestionId=61


Update TblMedicareQuestion set  Question =' Are you entitled to Medicare on the basis of either ESRD and age or ESRD and disability' where QuestionId=62

Update TblMedicareQuestion set  Question =' Does the working aged or disability MSP provision apply (i.e., is the GHP primarily based on age or disability entitlement' where QuestionId=64

Update TblMedicareQuestionsRemarks Set [Remarks] ='NO-FAULT INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.  GO TO PART III' where QuestionId=11 and QuestionValue='Non-Automobile'


update TblMedicareQuestionDependencyRule set QuestionId=48,DependentQuestionId=50,DependencyValue='Yes' where QuestionId=49 and DependentQuestionId=50

INSERT INTO TblMedicareQuestion
           (QuestionId,GroupId,Question,ControlValue,ControlType,Delimiter,IsActive,IsRequired,DisplaySequence,ParentQuestionId)
     VALUES
			(65,1,'Date Benifits began:','',183,'',1,1,2,1)  
	
INSERT INTO TblMedicareQuestionDependencyRule
           (QuestionId,DependentQuestionId,DependencyValue)
     VALUES (1,65,'Yes')

Update TblMedicareQuestionsRemarks Set [Remarks] ='MEDICARE CONTINUES TO PAY PRIMARY.'  where QuestionId=64 and QuestionValue='No'
Update TblMedicareQuestionsRemarks Set [Remarks] ='GHP CONTINUES TO PAY PRIMARY DURING THE 30-MONTH COORDINATION PERIOD.'  where QuestionId=64 and QuestionValue='Yes'

