

USE [$(dbName)]
Go

INSERT INTO TblMedicareQuestionGroup
           (GroupId,GroupName,GroupAlias,IsActive,IsDefault)
     VALUES
           (1,'Part I','PartI',1,1)
           ,(2,'Part II','PartII',1,0)
           ,(3,'Part III','PartIII',1,1)
           ,(4,'Part IV - Age','PartIV',1,0)
           ,(5,'Part V - Disability','PartV',1,0)
           ,(6,'Part VI - ESRD','PartVI',1,0)
           

INSERT INTO TblMedicareQuestion
           (QuestionId,GroupId,Question,ControlValue,ControlType,Delimiter,IsActive,IsRequired,DisplaySequence,ParentQuestionId)
     VALUES
			(1,1,'Are you receiving Black Lung (BL) Benefits?','Yes,No',124,',',1,1,1,null)
			,(2,1,'Are the services to be paid by a government program such as a research grant?','Yes,No',124,',',1,1,2,1)
			,(3,1,'Has the Department of Veterans Affairs (DVA) authorized and agreed to pay for care at this facility?','Yes,No',124,',',1,1,3,2)
			,(4,1,'Was the illness injury due to a work related accident/condition?','Yes,No',124,',',1,1,4,3)
			,(5,1,'Date of Injury/Illness:','',126,'',1,1,5,4)
			,(6,1,'Name and address of WC Plan:','',126,'',1,1,6,4)
			,(7,1,'Policy or Identification number:','',126,'',1,1,7,4)
			,(8,1,'Name and address of your employer:','',126,'',1,1,8,4)
			,(9,2,'Was the illness/injury due to a non-work related accident?','Yes,No',124,',',1,1,9,null)
			,(10,2,'Date of Injury/Illness:','',126,'',1,1,10,9)   
			,(11,2,'What type of accident caused the illness/injury?','Automobile,Non-Automobile,Other',124,',',1,1,11,null) 
			,(12,2,'Name and address of no-fault or liability insurer:','',127,',',1,1,12,11) 
			,(13,2,'Insurance claim number:','',126,',',1,1,13,11)
			,(14,2,'Was another party responsible for the accident?','Yes,No',124,',',1,1,14,null)
			,(15,2,'Name and address of no-fault or liability insurer:','',127,',',1,1,15,14)   
			,(16,2,'Insurance claim number:','',126,',',1,1,16,14) 
			,(17,3,'Are you entitled to medicare based on:','Age,Disability,ESRD',124,',',1,1,17,null) 
			,(18,4,'Are you currently employed?','Yes,No,Never',124,',',1,1,18,null) 
			,(19,4,'Name and address of your employer:','',127,'',1,1,19,18)
			,(20,4,'Date of retirement:','',126,'',1,1,20,18)
			,(21,4,'Is your spouse currently employed?:','Yes,No,Never',124,',',1,1,21,null)
			,(22,4,'Name and address of your employer:','',127,'',1,1,22,21) 
			,(23,4,'Date of retirement:','',126,'',1,1,23,21)
			
			,(24,4,'Do you have group health plan (GHP) coverage based on you own, or a spouse''s current employement?','Yes,No',124,',',1,1,24,null) 
			
			,(25,4,'Does the employer that sponsors your GHP employ 20 or more employees?','Yes,No',124,',',1,1,25,null) 
			,(26,4,'Name and address of GHP:','',127,'',1,1,26,25)
			,(27,4,'Policy identification number (this number is sometimes referred to as the health insurance benefit package number):','',126,'',1,1,27,25)
			
			,(28,4,'Group identification number:','',126,'',1,1,28,25)
			,(29,4,'Membership number (prior to the Health Insurance Protability and Accountability Act (HIPAA), this number was frequently the individual''s Social Security Number (SSN); it is the unique identifier assigned to the policyholder/patient):','',126,'',1,1,29,25)                     
			,(30,4,'Name of policyholder/named insured:','',126,'',1,1,30,25)
			,(31,4,'Relationship to patient:','',126,'',1,1,31,25)			
			,(32,5,'Are you currently employed?','Yes,No,Never',124,',',1,1,32,null) 
			,(33,5,'Name and address of your employer:','',127,'',1,1,33,32)
			,(34,5,'Date of retirement:','',126,'',1,1,34,32)
			,(35,5,'If married, is your spouse currently employed?','Yes,No,Never',124,',',1,1,35,null) 
			,(36,5,'Name and address of your employer:','',126,'',1,1,36,35)
			,(37,5,'Date of retirement:','',126,'',1,1,37,35)
			,(38,5,'Do you have group health plan (GHP) coverage based on your own, or a family member''s current employment?','Yes,No',124,',',1,1,38,null) 
			,(39,5,'Are you covered under the grop health plan of a family member other than your spouse?','Yes,No',124,',',1,1,39,null)
			,(40,5,'Name and adddress of your family member''s employer:','',127,'',1,1,40,39)
			,(41,5,'Does the employer that sponsors the GHP employe 100 or more employees?','Yes,No',124,',',1,1,41,null)
			,(42,5,'Name and Address of GHP:','',127,'',1,1,42,41)
			,(43,5,'Policy identification number (this number is sometimes referred to as the health insurance benefit package number):','',126,'',1,1,43,41)
			,(44,5,'Group identification number:','',126,'',1,1,44,41)
			,(45,5,'Membership number (prior to the Health Insurance Protability and Accountability Act (HIPAA), this number was frequently the individual''s Social Security Number (SSN); it is the unique identifier assigned to the policyholder/patient):','',126,'',1,1,45,41)
			,(46,5,'Name of policyholder/named insured:','',126,'',1,1,46,41)
			,(47,5,'Relationship to patient:','',126,'',1,1,46,41)			
			
			,(48,6,'Do you have group health plan (GHP) coverage?','Yes,No',124,',',1,1,48,null)
			,(49,6,'Name and Address of GHP:','',127,'',1,1,49,48)
			,(50,6,'Policy identification number (this number is sometimes referred to as the health insurance benefit package number):','',126,'',1,1,50,48)
			,(51,6,'Group identification number:','',126,'',1,1,51,48)
			,(52,6,'Membership number (prior to the HIPAA, this number was frequently the individual''s SSN; it is the unique identifier assigned to the policyholder/patient):','',126,'',1,1,52,48)
			,(53,6,'Name of policyholder/named insured:','',126,'',1,1,53,48)
			,(54,6,'Relationship to patient:','',126,'',1,1,54,48)	
			,(55,6,'Name and address of employer, if any, from which you receive GHP coverage:','',127,'',1,1,55,48)
			
			,(56,6,'Have you received a kidney transplant?','Yes,No',124,',',1,1,56,null)
			,(57,6,'Date of transplant:','',126,'',1,1,57,56)	
			
			,(58,6,'Have you received maintenance dialysis treatments?','Yes,No',124,',',1,1,58,null)
			,(59,6,'Date dialysis began','',126,'',1,1,59,58)	
			,(60,6,'If you participated in a self-dialysis training program, provide date training started:','',126,'',1,1,60,58)	
			
			,(61,6,'Are you within the 30-month coordination period that starts MM/DD/CCYY? (The 30-month coordination perod starts the first day of the month an individual is eligible for Medicare (even if not yet enrolled in Medicare) because of kidney failure (usually the fourth month of dialysis. If the Individual is participating in a self-diyalysis training program or has a kidney transplant during the 3-month waiting period, the 30-month coordination period starts with the first day of the month of dialysis or kidney transplant.))','Yes,No',124,',',1,1,61,null)	
			,(62,6,'Are you entitled to Medicare on the basis of either ESRD and age or ESRD and diability?','Yes,No',124,',',1,1,62,null)	
			,(63,6,'Was your intial entitlement to Medicare (including simultaneous or dual entitlement) based on ESRD?','Yes,No',124,',',1,1,63,null)
			,(64,6,'Does the working aged or disability MSP provision apply(i.e., is the GHP primarily based on age or diability entitlement)?','Yes,No',124,',',1,1,64,null)		
			
INSERT INTO TblMedicareQuestionsRemarks
           ([QuestionId],[QuestionValue],[DependentQuestionId],[DependentQuestionValue],[CombinedQuestionId],[CombinedQuestionValue],[IsDefault],[Remarks])
     VALUES
			(1,'Yes',null,null,null,null,1,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')
			,(2,'Yes',null,null,null,null,1,'Government Program will pay primary benefits for these services')
			,(3,'Yes',null,null,null,null,1,'DVA IS PRIMARY FOR THESE SERVICES.')	
			,(4,'Yes',null,null,null,null,1,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS, GO TO PART III.')
			,(4,'No',null,null,null,null,1,'GO TO PART II.')
			,(9,'No',null,null,null,null,1,'GO TO PART II.')
			,(11,'Non-Automobile',null,null,null,null,1,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT. GO TO PART III.')
			,(14,'Yes',null,null,null,null,1,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT. GO TO PART III.')
			,(14,'No',null,null,null,null,1,'GO TO PART III.')
			,(17,'Age',null,null,null,null,1,'GO to Part IV.')
			,(17,'Disability',null,null,null,null,1,'GO to Part V.')
			,(17,'ESRD',null,null,null,null,1,'GO to Part VI.')
			
			,(18,'No,Never',1,'Yes',21,'No,Never',0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')
			,(18,'No,Never',2,'Yes',21,'No,Never',0,'Government Program will pay primary benefits for these services')
			,(18,'No,Never',3,'Yes',21,'No,Never',0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(18,'No,Never',4,'Yes',21,'No,Never',0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(18,'No,Never',11,'Yes',21,'No,Never',0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(18,'No,Never',14,'Yes',21,'No,Never',0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(18,'No,Never',null,null,21,'No,Never',0,'MEDICARE IS PRIMARY')
			
			,(24,'No',1,'Yes',null,null,0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')           
			,(24,'No',2,'Yes',null,null,0,'Government Program will pay primary benefits for these services')
			,(24,'No',3,'Yes',null,null,0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(24,'No',4,'Yes',null,null,0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(24,'No',11,'Yes',null,null,0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(24,'No',14,'Yes',null,null,0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(24,'No',null,null,null,null,0,'MEDICARE IS PRIMARY')
			
			,(25,'Yes',null,null,null,null,1,'GHP IS PRIMARY')
			,(25,'No',1,'Yes',null,null,0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')           
			,(25,'No',2,'Yes',null,null,0,'Government Program will pay primary benefits for these services')
			,(25,'No',3,'Yes',null,null,0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(25,'No',4,'Yes',null,null,0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(25,'No',11,'Yes',null,null,0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(25,'No',14,'Yes',null,null,0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(25,'No',null,null,null,null,0,'MEDICARE IS PRIMARY PAYER.')
			
			,(32,'No,Never',1,'Yes',35,'No,Never',0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')
			,(32,'No,Never',2,'Yes',35,'No,Never',0,'Government Program will pay primary benefits for these services')
			,(32,'No,Never',3,'Yes',35,'No,Never',0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(32,'No,Never',4,'Yes',35,'No,Never',0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(32,'No,Never',11,'Yes',35,'No,Never',0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(32,'No,Never',14,'Yes',35,'No,Never',0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(32,'No,Never',null,null,35,'No,Never',0,'MEDICARE IS PRIMARY')
						
			,(38,'No',1,'Yes',null,null,0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')           
			,(38,'No',2,'Yes',null,null,0,'Government Program will pay primary benefits for these services')
			,(38,'No',3,'Yes',null,null,0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(38,'No',4,'Yes',null,null,0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(38,'No',11,'Yes',null,null,0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(38,'No',14,'Yes',null,null,0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(38,'No',null,null,null,null,0,'MEDICARE IS PRIMARY PAYER.')
			
			,(41,'Yes',null,null,null,null,1,'GROUP HEALTH PLAN IS PRIMARY.')
			,(41,'No',null,null,null,null,0,'MEDICARE IS PRIMARY PAYER.')
			,(41,'No',1,'Yes',null,null,0,'BL IS PRIMARY ONLY FOR CLAIMS RELATED TO BL')           
			,(41,'No',2,'Yes',null,null,0,'Government Program will pay primary benefits for these services')
			,(41,'No',3,'Yes',null,null,0,'DVA IS PRIMARY FOR THESE SERVICES.')
			,(41,'No',4,'Yes',null,null,0,'WC IS PRIMARY PAYER ONLY FOR CLAIMS RELATED TO WORK RELATED INJURIES OR ILLNESS.')
			,(41,'No',11,'Yes',null,null,0,'NO-FAULT INSURER IS PRIMARY PLAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')
			,(41,'No',14,'Yes',null,null,0,'LIABILITY INSURER IS PRIMARY PAYER ONLY FOR THOSE CLAIMS RELATED TO THE ACCIDENT.')	
			
			,(48,'No',null,null,null,null,1,'MEDICARE IS PRIMARY PAYER.')	
			
			,(61,'No',null,null,null,null,1,'MEDICARE IS PRIMARY PAYER.')				
			
			,(63,'No',null,null,null,null,1,'INITIAL ENTITLEMENT BASED ON AGE OR DISABILITY.')
			,(63,'Yes',null,null,null,null,1,'GHP CONTINUES TO PAY PRIMARY DURING THE 30-MONTH COORDINATION PERIOD.')
			
			,(64,'No',null,null,null,null,1,'GHP CONTINUES TO PAY PRIMARY DURING THE 30-MONTH COORDINATION PERIOD.')
			,(64,'Yes',null,null,null,null,1,'MEDICARE CONTINUES TO PAY PRIMARY.')
			
			
			
			
INSERT INTO TblMedicareQuestionDependencyRule
           (QuestionId,DependentQuestionId,DependencyValue)
     VALUES 
			(1,2,'No'),(2,3,'No'),(3,4,'No'),(4,5,'Yes'),(4,6,'Yes')
			,(4,7,'Yes'),(4,8,'Yes'),(9,10,'Yes'),(9,11,'Yes'),(11,12,'Non-Automobile'),(11,13,'Non-Automobile'),(9,14,'Yes'),(14,15,'Yes')
			,(14,16,'Yes'),(11,14,'Automobile'),(18,19,'Yes'),(18,20,'No'),(21,22,'Yes'),(18,24,'Yes'),(21,24,'Yes')
			,(21,23,'No'),(18,25,'Yes'),(21,25,'Yes'),(24,25,'Yes'),(25,26,'Yes'),(25,27,'Yes')
			,(25,28,'Yes'),(25,29,'Yes'),(25,30,'Yes'),(25,31,'Yes'),(25,32,'Yes'),(32,33,'Yes')
			,(32,34,'No'),(35,36,'Yes'),(35,37,'No'),(32,38,'Yes'),(35,38,'Yes')
			,(38,39,'Yes'),(39,40,'Yes'),(38,41,'Yes'),(41,42,'Yes'),(41,43,'Yes')
           ,(41,44,'Yes'),(41,45,'Yes'),(41,46,'Yes'),(41,47,'Yes')
           ,(48,49,'Yes'),(49,50,'Yes'),(48,51,'Yes'),(48,52,'Yes'),(48,53,'Yes'),(48,54,'Yes'),(48,55,'Yes'),(48,56,'Yes'),(48,58,'Yes'),(48,61,'Yes')
           ,(56,57,'Yes'),(58,59,'Yes'),(58,60,'Yes'),(61,62,'Yes'),(61,63,'Yes'),(63,64,'No')

                      
INSERT INTO TblMedicareGroupDependencyRule
           (QuestionId,DependentGroupId,DependencyValue)
     VALUES
			(4,2,'No')
			,(17,4,'Age')
			,(17,5,'Disability')
			,(17,6,'ESRD')
			

			Update TblMedicareQuestion set ControlType=183 where QuestionId=5
			Update TblMedicareQuestion set ControlType=183 where QuestionId=10
			Update TblMedicareQuestion set ControlType=183 where QuestionId=20
			Update TblMedicareQuestion set ControlType=183 where QuestionId=23
			Update TblMedicareQuestion set ControlType=183 where QuestionId=34
			Update TblMedicareQuestion set ControlType=183 where QuestionId=37
			Update TblMedicareQuestion set ControlType=183 where QuestionId=57
			Update TblMedicareQuestion set ControlType=183 where QuestionId=59
			Update TblMedicareQuestion set ControlType=183 where QuestionId=60
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=1
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=9
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=17
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=18
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=21
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=32
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=35
			Update TblMedicareQuestion set IsDefault=1 where QuestionId=48