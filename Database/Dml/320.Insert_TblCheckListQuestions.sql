use [$(dbName)]
Go

Declare @groupQuestionId bigint
Declare @Groupalias varchar(512)
--Gender Both - 184
--Gender Male = 185
--Gender Female = 186

--GroupType Header = 318
--GroupType Body = 319
--GroupType Footer = 320

-- Question Type 
-- None= 321
-- CheckBox = 322
-- TextBox = 323

set @Groupalias ='HeaderQuestions'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'Header Questions','Header Questions', 318,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias
 
INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(1, 'NP', 323, null, @groupQuestionId, 1, '', '',184,1 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(2, 'CVT', 323, null, @groupQuestionId, 1, '', '',184,2 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(3, 'Front Desk', 323, null, @groupQuestionId,1, '', '',184,3 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(5, 'Height', 323, null, @groupQuestionId, 1, '', '',184,5 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(6, 'Weight', 323, null, @groupQuestionId, 1, '', '',184,6 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(7, 'Blood Pressure', 321, null, @groupQuestionId, 1, '', '',184,7 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(8, 'mm/Hg Sys', 323, null, @groupQuestionId, 1, '', '',184,8 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(9, 'mm/Hg Dia', 323, null, @groupQuestionId, 1, '', '',184,9 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(10, 'Pulse', 323, null, @groupQuestionId, 1, '', '',184,10 )


Set @Groupalias ='BIOMETRICANDMINICOGSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'BIOMETRIC and MINI COG SECTION','BIOMETRIC and MINI COG SECTION', 319,null, @Groupalias , 1)
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias
 
INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(11, 'Perform', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,11 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(12, 'Hemoglobin A1c', 323, 11, @groupQuestionId, 1, '', '',184,12 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(13, 'Perform DRS eye exam if the patient meets any of the criteria below.', 322, null, @groupQuestionId,1, 'Yes,No', ',',184,13 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(14, 'Patient states they are diabetic/diet controlled diabetic', 322, 13, @groupQuestionId, 1, 'Yes,No', ',',184,14 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(15, 'A1c is =>6', 322, 13, @groupQuestionId, 1, 'Yes,No', ',',184,15 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(16, 'Patient has not had an eye exam this year (This exam is used to determine the health of your eyes to detect Glaucoma, macular degeneration, retinal disease).', 322, 13, @groupQuestionId, 1, 'Yes,No', ',',184,16)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(17, 'Perform Lipid Panel', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,17  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(18, 'TC', 323, 17, @groupQuestionId, 1, '', ',',184,18  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(19, 'HDL', 323, 17, @groupQuestionId, 1, '', ',',184,19  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(20, 'TRIG', 323, 17, @groupQuestionId, 1, '', ',',184,20  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(21, 'LDL', 323, 17, @groupQuestionId, 1, '', ',',184,21  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(22, 'Patient eaten in the past 4 hours.', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,22  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(23, 'Patient has not eaten the past 4 hours.', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,23  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(24, 'Patient states they are on Cholesterol Medication.', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,24  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(25, 'Patient states they are on a Statin medication.', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,25 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(26, 'Can patient repeat all 3 of the memory recall words: ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,26  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(27, 'If no how many did they recall', 323, 26, @groupQuestionId, 1, '', ',' ,184,27 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(28, 'Is the clock diagram acceptable?  (To be determined by Provider)  ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,28  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(29, 'Labs not completed', 321, null, @groupQuestionId, 1, '', '',184,29 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(30, 'Patient refused', 322, 29, @groupQuestionId, 1, 'Yes,No', ',',184,30  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(31, 'Test performed this year', 322, 29, @groupQuestionId, 1, 'Yes,No', ',',184,31  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(32, 'Plan criteria not met', 322, 29, @groupQuestionId, 1, 'Yes,No', ',',184,32  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(33, 'Equipment Malfunction', 322, 29, @groupQuestionId, 1, 'Yes,No', ',' ,184,33 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(34, 'Contraindication', 322, 29, @groupQuestionId, 1,'Yes,No', ',',184,34  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(35, 'DRS not completed', 321, null, @groupQuestionId, 1, '', '',184,35 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(36, 'Patient refused', 322, 35, @groupQuestionId, 1, 'Yes,No', ',',184,36  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(37, 'Test performed this year', 322, 35, @groupQuestionId, 1, 'Yes,No', ',',184,37  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(38, 'Plan criteria not met', 322, 35, @groupQuestionId, 1, 'Yes,No', ',',184,38  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(39, 'Equipment Malfunction', 322, 35, @groupQuestionId, 1, 'Yes,No', ',',184,39  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(40, 'Contraindication', 322, 35, @groupQuestionId, 1, 'Yes,No', ',',184,40  )


Set @Groupalias ='TAKEHOMEKITSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'TAKE HOME KIT SECTION','TAKE HOME KIT SECTION', 319,null, @Groupalias , 1)
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(41, 'Order Urine Micro-albumin if the patient has met at least 1 criteria from the column A below.', 322, null, @groupQuestionId, 1, '', '',184,41 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(42, 'Column A', 321, 41, @groupQuestionId, 1, '', '',184,42 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(43, 'Diabetes', 322, 41, @groupQuestionId, 1, 'Yes,No', ',',184,43  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(44, 'Hypertension/high blood pressure', 322, 41, @groupQuestionId, 1, 'Yes,No', ',',184,44  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(45, 'Cardiovascular disease (CAD/PAD)', 322, 41, @groupQuestionId, 1, 'Yes,No', ',',184,45  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(46, 'Personal or Family history of kidney failure', 322, 41, @groupQuestionId, 1, 'Yes,No', ',',184,46  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(47, 'Order iFOBT if the patient has met at least 1 criteria from the column B below.', 322, null, @groupQuestionId, 1, '', '',184,47 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(48, 'Column B', 321, 47, @groupQuestionId, 1, '', '',184,48 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(49, 'Patient has NOT had a Colonoscopy in the last 10 yrs', 322, 47, @groupQuestionId, 1, 'Yes,No', ',',184,49  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(50, 'Patient has NOT had a Barium enema/sigmoidoscopy in the last 5 years', 322, 47, @groupQuestionId, 1, 'Yes,No', ',',184,50  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(51, 'Patient has NOT had an iFOBT in the current calendar year.', 322, 47, @groupQuestionId, 1, 'Yes,No', ',',184,51  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(52, 'Micro not completed', 321, null, @groupQuestionId, 1, '', '',184,52 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(53, 'Patient refused', 322, 52, @groupQuestionId, 1, 'Yes,No', ',',184,53  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(54, 'Test performed this year', 322, 52, @groupQuestionId, 1, 'Yes,No', ',',184,54  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(55, 'Plan criteria not met', 322, 52, @groupQuestionId, 1, 'Yes,No', ',',184,55  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(56, 'Equipment Malfunction', 322, 52, @groupQuestionId, 1, 'Yes,No', ',' ,184,56 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(57, 'Contraindication', 322, 52, @groupQuestionId, 1, 'Yes,No', ',',184,57  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(58, 'iFOBT not completed', 321, null, @groupQuestionId, 1, '', '',184,58 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(59, 'Patient refused', 322, 58, @groupQuestionId, 1, 'Yes,No', ',',184,59  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(60, 'Test performed this year', 322, 58, @groupQuestionId, 1, 'Yes,No', ',',184,60  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(61, 'Plan criteria not met', 322, 58, @groupQuestionId, 1, 'Yes,No', ',',184,61  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(62, 'Equipment Malfunction', 322, 58, @groupQuestionId, 1, 'Yes,No', ',',184,62  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(63, 'Contraindication', 322, 58, @groupQuestionId, 1, 'Yes,No', ',',184,63  )


Set @Groupalias ='RESPIRATORYEXAMSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'RESPIRATORY EXAM SECTION','RESPIRATORY EXAM SECTION', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(64, 'Order Spirometry if the patient has met at least 1 criteria from criteria from column A and Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,64  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(65, 'Column A', 321, 64, @groupQuestionId, 1, '', '',184,65 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(66, 'Current/former smoker WITH symptoms of respiratory disease (SOB, chronic cough, wheezing)', 322, 64, @groupQuestionId, 1, 'Yes,No', ',',184,66  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(67, 'Column B', 321, 64, @groupQuestionId, 1, '', '',184,67 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(68, 'Any patient, regardless of smoking history, with symptoms of respiratory disease (SOB, chronic cough, wheezing, frequent respiratory infections) OR positive clinical exam findings (rales, rhonchi, wheezing)', 322, 64, @groupQuestionId, 1, 'Yes,No', ',',184,68  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(69, 'Results compromised (Patient did not have sufficient air intake or exhale to complete the test to instruction specifications).', 322, 64, @groupQuestionId, 1, 'Yes,No', ',',184,69  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(70, 'Results compromised (Patient started coughing or gasping for air during testing).', 322, 64, @groupQuestionId, 1, 'Yes,No', ',',184,70  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(71, 'Patient could not follow the directions of the test successfully).', 322, 64, @groupQuestionId, 1, 'Yes,No', ',',184,71  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(72, 'Spiro not completed', 321, null, @groupQuestionId, 1, '', '',184,72 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(73, 'Test performed this year', 322, 72, @groupQuestionId, 1, 'Yes,No', ',',184,73  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(74, 'Patient refused', 322, 72, @groupQuestionId, 1, 'Yes,No', ',',184,74  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(75, 'Standing orders criteria not met', 322, 72, @groupQuestionId, 1, 'Yes,No', ',',184,75  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(76, 'Equipment Malfunction', 322, 72, @groupQuestionId, 1, 'Yes,No', ',',184,76  )


Set @Groupalias ='CARDIOVASCULAREXAMSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'CARDIOVASCULAR EXAM SECTION','CARDIOVASCULAR EXAM SECTION', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(77, 'Order Echocardiogram if patient has met at least 1 clinical criteria from at least 2 separate columns below. ', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,77  )



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(78, 'Claims/History', 321, 77, @groupQuestionId, 1, '', '',184,78 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(79, 'Any cardiac disease Or dysfunction ', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,79  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(80, '(CAD/CVD)', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,80  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(81, 'Stent/Angioplasty/CABG', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,81  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(82, 'Prosthetic valve', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,82  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(83, 'MI/Heart Attack', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,83  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(84, 'Pulmonary Hypertension', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,84  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(85, 'COPD', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,85  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(86, 'Arrhythmia', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,86  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(87, 'Enlarged heart/Heart failure/ diastolic dysfunction/decreased EF', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,87  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(88, 'CHF', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,88  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(89, 'Hypertrophic cardiomyopathy/ Idiopathic cardiomyopathy', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,89  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(90, 'Hypertensive heart disease; Infiltrative heart disease; previous ', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,90  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(91, 'Family History of Congenital Heart Disease.', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,91  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(92, 'Stroke/TIA ', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,92  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(93, 'Medication/Specialist', 321, 77, @groupQuestionId, 1, '', '',184,93 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(94, 'Medication treating a condition related to heart disease or dysfunction', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,94  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(95, 'Currently seeing Cardiologist', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,95  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(96, 'Currently seeing a psychiatrist', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,96  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(97, 'Currently seeing Pulmonologist', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,97  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(98, 'Symptoms (Patient Attested)', 321, 77, @groupQuestionId, 1, '', '',184,98 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(99, 'Shortness of Breath', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,99  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(100, 'Dyspnea on Exertion', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,100  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(101, 'Orthopnea', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,101  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(102, 'Increasing fatigue/weakness', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,102  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(103, 'Chest Pain', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,103  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(104, 'Palpitations', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,104  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(105, 'Lightheadedness', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,105  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(106, 'Pre-syncope/Syncope', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,106  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(107, 'Angina', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,107  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(108, 'Edema', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,108  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(109, 'Signs/Clinical Findings (PE/Labs)', 321, 77, @groupQuestionId, 1, '', '',184,109 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(110, 'Frequent PVC’s on EKG', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,110  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(111, 'Abnormal ECG (suggesting structural heart disease)', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,111  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(112, 'Arrhythmia', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,112  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(113, 'Irregular heartbeat', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,113  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(114, 'Heart Murmur', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,114  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(115, 'Rales (crackles)', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,115  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(116, 'Labored Breathing', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,116  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(117, 'Hepatomegaly', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,117  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(118, 'Jugular Venous Distension', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,118  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(119, 'Peripheral Edema', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,119  )



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(120, 'Significant Co-Morbidity Disease Combination', 321, 77, @groupQuestionId, 1, '', '',184,120 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(121, 'Asthma', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,121  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(122, 'Cancer', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,122  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(123, 'COPD (chronic obstructive pulmonary disease)', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,123  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(124, 'Mental health conditions', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,124  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(125, '2 or more comorbidity risk factors such as (diabetes, hypertension, and/or hyperlipidemia', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,125  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(126, 'Gross Morbid Obesity (BMI > 40 or 35-40 with co-morbidity risk factors)', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,126  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(127, 'Alcohol Abuse; Drug Abuse; Tobacco abuse', 322, 77, @groupQuestionId, 1, 'Yes,No', ',',184,127  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(128, 'Echo not completed', 321, NULL, @groupQuestionId, 1, '', '',184,128 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(129, 'Test performed this year', 322, 128, @groupQuestionId, 1, 'Yes,No', ',',184,129  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(130, 'Patient refused', 322, 128, @groupQuestionId, 1, 'Yes,No', ',' ,184,130 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(131, 'Standing orders criteria not met', 322, 128, @groupQuestionId, 1, 'Yes,No', ',',184,131  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(132, 'Equipment Malfunction', 322, 128, @groupQuestionId, 1, 'Yes,No', ',',184,132  )




INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(133, 'Order EKG if the patient has met at least 1 criteria from Column A and Column B both of the columns below.', 322, null, @groupQuestionId, 1, 'Yes,No', ',' ,184,133 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(134, 'Column A', 321, 133, @groupQuestionId, 1, '', '',184, 134 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(135, 'H/O arrhythmias ', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,135  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(136, 'H/O CAD/MI', 322, 133, @groupQuestionId, 1, 'Yes,No', ',' ,184,136 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(137, 'Hypertension', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,137  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(138, 'Clinical exam findings (irregular pulse, heart murmur, bradycardia, tachycardia)', 322, 133, @groupQuestionId, 1, 'Yes,No', ',' ,184,138 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(139, 'Symptoms (palpitations, rapid heartbeat, chest pain, pre-syncope/syncope)', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,139  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(140, 'Column B', 321, 133, @groupQuestionId, 1, '', '',184,140  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(141, 'Has at least 2 of the following Comorbidities/Risk Factors', 321, 133, @groupQuestionId, 1, '', '',184,141  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(142, 'High cholesterol', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,142  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(143, 'Diabetes', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,143  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(144, 'Family history of CAD/MI', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,144  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(145, 'Current/former smoker', 322, 133, @groupQuestionId, 1, 'Yes,No', ',',184,145  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(146, 'EKG not completed', 321, null, @groupQuestionId, 1, '', '',184, 146  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(147, 'Test performed this year', 322, 146, @groupQuestionId, 1, 'Yes,No', ',',184,147  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(148, 'Patient refused', 322, 146, @groupQuestionId, 1, 'Yes,No', ',' ,184, 148 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(149, 'Standing orders criteria not met', 322, 146, @groupQuestionId, 1, 'Yes,No', ',',184,149  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(150, 'Equipment Malfunction', 322, 146, @groupQuestionId, 1, 'Yes,No', ',',184,150  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(151, 'Order ABI/Flochec/LEAD if the patient has met at least 1 criteria from Column A or Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,151  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(152, 'Column A', 321, 151, @groupQuestionId, 1, '', '',184,152)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(153, 'Clinical exam findings and symptoms consistent with PVD (diminished or absent peripheral pulses, loss of hair from the extremities, asymmetrical temperature differences in the extremities, discolored skin, claudication/cramping) ', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184,153  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(154, 'Diabetes ', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184,154  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(155, 'Column B', 321, 151, @groupQuestionId, 1, '', '',184,155)


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(156, 'At least 2 or more of these risk factors for PAD', 321, 151, @groupQuestionId, 1, '', '',184,156)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(157, 'Hypertension ', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184, 157 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(158, 'High cholesterol ', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184,158  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(159, 'Obesity', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184,159  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(160, 'Current/former smoker', 322, 151, @groupQuestionId, 1, 'Yes,No', ',',184,160  )



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(161, 'Test not completed:', 321, null, @groupQuestionId, 1, '', '',184,161)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(162, 'Test performed this year', 322, 161, @groupQuestionId, 1, 'Yes,No', ',',184, 162 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(163, 'Patient refused', 322, 161, @groupQuestionId, 1, 'Yes,No', ',',184, 163 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(164, 'Standing orders criteria not met', 322, 161, @groupQuestionId, 1, 'Yes,No', ',',184, 164 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(165, 'Equipment Malfunction', 322, 161, @groupQuestionId, 1, 'Yes,No', ',',184, 165 )



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(166, 'Order Male AAA (Abdominal Aortic Aneurysm) ultrasound if the patient has met at least 1 criteria from Column A or Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',185, 166 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(167, 'Column A', 321, 166, @groupQuestionId, 1, '', '',185, 167 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(168, 'Male patient', 321, 166, @groupQuestionId, 1, '', '',185, 168 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(169, 'Current/former smoker ≥ 65 years old', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 169 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(170, 'Column B  (USPTF C)', 321, 166, @groupQuestionId, 1, '', '',185, 170 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(171, 'Male patient: age 65 to 75 who have NEVER smoked but have ANY of these risk factors', 321, 166, @groupQuestionId, 1, '', '',185, 171 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(172, 'Is currently Hypertensive or is being treated with a medication to control hypertension ', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 172 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(173, 'Currently has high cholesterol or is being treated with a medication to control cholesterol.', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 173 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(174, 'Family history of AA', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 174 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(175, 'Hx of atherosclerosis (CAD, PAD/vascular disease)', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 175 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(176, 'Currently Obese', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 176 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(177, 'HX of Marfan’s/Turner Syndrome (The Journal of American College Cardiology)', 322, 166, @groupQuestionId, 1, 'Yes,No', ',',185, 177 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(178, 'AAA not completed', 321, null, @groupQuestionId, 1, '', '',185, 178 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(179, 'Test performed this year', 322, 178, @groupQuestionId, 1, 'Yes,No', ',',185, 179 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(180, 'Patient refused ', 322, 178, @groupQuestionId, 1, 'Yes,No', ',',185, 180 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(181, 'Standing orders criteria not met ', 322, 178, @groupQuestionId, 1, 'Yes,No', ',',185, 181 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(182, 'Equipment Malfunction ', 322, 178, @groupQuestionId, 1, 'Yes,No', ',',185, 182 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(183, 'Order Female AAA (Abdominal Aortic Aneurysm) ultrasound if the patient has met at least 1 criteria from Column A or Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',186, 166 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(184, 'Column A', 321, 183, @groupQuestionId, 1, '', '',186, 167 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(185, 'Female patient', 321, 183, @groupQuestionId, 1, '', '',186, 168 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(186, 'Current/former smoker ≥ 65 years old', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 169 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(187, 'Column B   (USPTF I)', 321, 166, @groupQuestionId, 1, '', '',186, 170 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(188, 'Female patient: age 65 to 75 who has smoked but have ANY of these risk factors', 321, 183, @groupQuestionId, 1, '', '',186, 171 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(189, 'Is currently Hypertensive or is being treated with a medication to control hypertension ', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 172 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(190, 'Currently has high cholesterol or is being treated with a medication to control cholesterol.', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 173 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(191, 'Family history of AA', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 174 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(192, 'Hx of atherosclerosis (CAD, PAD/vascular disease)', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 175 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(193, 'Currently Obese', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 176 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(194, 'HX of Marfan’s/Turner Syndrome (The Journal of American College Cardiology)', 322, 183, @groupQuestionId, 1, 'Yes,No', ',',186, 177 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(195, 'AAA not completed', 321, null, @groupQuestionId, 1, '', '',186, 178 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(196, 'Test performed this year', 322, 195, @groupQuestionId, 1, 'Yes,No', ',',186, 179 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(197, 'Patient refused ', 322, 195, @groupQuestionId, 1, 'Yes,No', ',',186, 180 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(198, 'Standing orders criteria not met ', 322, 195, @groupQuestionId, 1, 'Yes,No', ',',186, 181 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(199, 'Equipment Malfunction ', 322, 195, @groupQuestionId, 1, 'Yes,No', ',',186, 182 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(200, 'Order Carotid US if the patient has met at least 1 criteria form column A and Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 200 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(201, 'Column A', 321, 200, @groupQuestionId, 1, '', '',184, 201 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(202, 'Neurological symptoms (i.e., vertigo, paralysis, numbness or weakness, trouble speaking or seeing, confusion, or headache)', 322, 200, @groupQuestionId, 1, 'Yes,No', ',',184, 202 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(203, 'Column B', 321, 200, @groupQuestionId, 1, '', '',184, 203 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(204, 'Carotid bruit OR H/O CEA /Stent and not followed or seen by a vascular surgeon or cardiologist in the current year', 322, 200, @groupQuestionId, 1, 'Yes,No', ',',184, 204 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(205, 'Carotid not completed', 321, null, @groupQuestionId, 1, '', '',184, 205 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(206, 'Test performed this year', 322, 205, @groupQuestionId, 1, 'Yes,No', ',',184, 206 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(207, 'Patient refused ', 322, 205, @groupQuestionId, 1, 'Yes,No', ',',184, 207 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(208, 'Standing orders criteria not met ', 322, 205, @groupQuestionId, 1, 'Yes,No', ',',184, 208 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(209, 'Equipment Malfunction ', 322, 205, @groupQuestionId, 1, 'Yes,No', ',',184, 209 )

Set @Groupalias ='Specialist'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'Patient seeing following Specialist','Patient seeing following Specialist:', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(210, 'Neurologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 210 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(211, 'Name', 323, 210, @groupQuestionId, 1, '', ',',184, 211 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(212, 'City/State', 323, 210, @groupQuestionId, 1, '', ',',184, 212 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(213, 'Rheumatologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 213 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(214, 'Name', 323, 213, @groupQuestionId, 1, '', ',',184, 214 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(215, 'City/State', 323, 213, @groupQuestionId, 1, '', ',',184, 215 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(216, 'Nephrologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 216 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(217, 'Name', 323, 216, @groupQuestionId, 1, '', ',',184, 217 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(218, 'City/State', 323, 216, @groupQuestionId, 1, '', ',',184, 218 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(219, 'Oncologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 219 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(220, 'Name', 323, 219, @groupQuestionId, 1, '', ',',184, 220 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(221, 'City/State', 323, 219, @groupQuestionId, 1, '', ',',184, 221 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(222, 'Endocrinologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 222 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(223, 'Name', 323, 222, @groupQuestionId, 1, '', ',',184, 223 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(224, 'City/State', 323, 222, @groupQuestionId, 1, '', ',',184, 224 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(225, 'Psychologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 225 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(226, 'Name', 323, 225, @groupQuestionId, 1, '', ',',184, 226 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(227, 'City/State', 323, 225, @groupQuestionId, 1, '', ',',184, 227 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(228, 'Pulmonologist', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 222 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(229, 'Name', 323, 228, @groupQuestionId, 1, '', ',',184, 229 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(230, 'City/State', 323, 228, @groupQuestionId, 1, '', ',',184, 230 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(231, 'Other', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184, 231 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(232, 'Name', 323, 231, @groupQuestionId, 1, '', ',',184, 232 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(233, 'City/State', 323, 231, @groupQuestionId, 1, '', ',',184, 233 )

