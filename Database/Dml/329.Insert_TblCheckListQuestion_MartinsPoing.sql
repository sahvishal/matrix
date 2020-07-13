use [$(dbname)]
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
values(240, 'CS', 323, null, @groupQuestionId, 1, '', '',184,240)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(241, 'Pulse', 323, null, @groupQuestionId, 1, '', '',184,241)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(242, 'Intial BP', 323, null, @groupQuestionId, 1, '', '',184,242)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(243, 'Secondary BP', 323, null, @groupQuestionId, 1, '', '',184,243)


Set @Groupalias ='BIOMETRICANDMINICOGSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'BIOMETRIC and MINI COG SECTION','BIOMETRIC and MINI COG SECTION', 319,null, @Groupalias , 1)
 END 

 select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
		values(245, 'All diabetic patients that have not had an A1C done this plan year', 322, 11, @groupQuestionId, 1, 'Yes,No', ',',184,245 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(246, 'A1c is 6.5 or greater', 322, 13, @groupQuestionId, 1, 'Yes,No', ',',184,246 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(247, 'All diabetic patients', 322, 13, @groupQuestionId, 1, 'Yes,No', ',',184,247 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(248, 'All patients that have not had a lipid panel done within the last 5 years', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,248  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(249, 'Patients with any of the following conditions that have not had a lipid panel done this plan year', 321, 17, @groupQuestionId, 1, 'Yes,No', ',',184,249  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(251, 'Hypertension', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,251  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(252, 'High cholesterol', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,252  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(253, 'Diabetes', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,253  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(254, 'Current/former smoker', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,254)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(255, 'Family history of aortic aneurysm', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,255)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(256, 'Obesity', 322, 17, @groupQuestionId, 1, 'Yes,No', ',',184,256)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(257, 'Standing orders criteria not met', 322, 35, @groupQuestionId, 1, 'Yes,No', ',', 184, 257  )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(258, 'Lipids not completed', 321, null, @groupQuestionId, 1, '', '', 184, 258 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(259, 'Test performed this year', 322, 258, @groupQuestionId, 1, 'Yes,No', ',', 184, 259  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(260, 'Patient refused', 322, 258, @groupQuestionId, 1, 'Yes,No', ',',184,260  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(261, 'Standing orders criteria not met', 322, 258, @groupQuestionId, 1, 'Yes,No', ',', 184, 261)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(262, 'Equipment Malfunction', 322, 258, @groupQuestionId, 1, 'Yes,No', ',', 184, 262)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(263, 'A1c not completed', 321, null, @groupQuestionId, 1, '', '', 184, 263 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(264, 'Test performed this year', 322, 263, @groupQuestionId, 1, 'Yes,No', ',', 184, 264  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(265, 'Patient refused', 322, 263, @groupQuestionId, 1, 'Yes,No', ',',184,265  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(266, 'Standing orders criteria not met', 322, 263, @groupQuestionId, 1, 'Yes,No', ',', 184, 266)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(267, 'Equipment Malfunction', 322, 263, @groupQuestionId, 1, 'Yes,No', ',', 184, 267)



Set @Groupalias ='TAKEHOMEKITSECTION'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'TAKE HOME KIT SECTION','TAKE HOME KIT SECTION', 319,null, @Groupalias , 1)
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(268, 'ANY patient that has not had colorectal cancer screening this plan year', 322, 47, @groupQuestionId, 1, 'Yes,No', ',',184,268  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(269, 'UMA not completed', 321, null, @groupQuestionId, 1, '', '', 184, 268 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(270, 'Test performed this year', 322, 269, @groupQuestionId, 1, 'Yes,No', ',', 184, 270  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(271, 'Patient refused', 322, 269, @groupQuestionId, 1, 'Yes,No', ',',184,271  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(272, 'Standing orders criteria not met', 322, 269, @groupQuestionId, 1, 'Yes,No', ',', 184, 272 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(273, 'Supplies unavailable', 322, 269, @groupQuestionId, 1, 'Yes,No', ',', 184, 273 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(371, 'Standing orders criteria not met', 322, 58, @groupQuestionId, 1, 'Yes,No', ',', 184, 273 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(372, 'Supplies unavailable', 322, 58, @groupQuestionId, 1, 'Yes,No', ',', 184, 273 )

Set @Groupalias ='CARDIOVASCULAREXAMSECTIONV2'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'CARDIOVASCULAR EXAM SECTION','CARDIOVASCULAR EXAM SECTION', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(281, 'Order Echocardiogram if the patient has at least 1 from either Column A or Column B, and 1 from Column C.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,281  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(282, 'Column A Symptoms/History (through HRA)', 321, 281, @groupQuestionId, 1, '', '', 184,282 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(283, 'Shortness of Breath ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 283 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(284, 'Dyspnea on Exertion ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 284 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(285, 'Chest Pain ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 285 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(286, 'Peripheral Edema ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 286 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(287, 'Palpitations ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 287 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(288, 'TIA’s', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 288 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(289, 'Lightheadedness ', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 289 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(290, 'Presyncope/Syncope', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 290 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(291, 'H/O Pulmonary Hypertension', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 291 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(292, 'H/O Arrhythmia', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 292 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(293, 'H/O Stroke', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 293 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(294, 'H/O “enlarged heart”', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 294 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(295, 'Column B Signs', 321, 281, @groupQuestionId, 1, '', '', 184,295 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(296, 'Peripheral Edema', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 296 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(297, 'Labored Breathing', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 297 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(298, 'Arrhythmia', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 298 )



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(299, 'Column C Clinical Findings (PE/Labs)', 321, 281, @groupQuestionId, 1, '', '', 184,299 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(300, 'Frequent PVC’s on EKG', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 300 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(301, 'Abnormal ECG (suggesting structural heart disease)', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 301 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(302, 'Irregular heartbeat', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 302 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(303, 'Heart Murmur', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 303 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(304, 'Rales (crackles)', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 304 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(305, 'Hepatomegaly', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 305 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(306, 'Jugular Venous Distension', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 306 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(307, 'Peripheral Edema', 322, 281, @groupQuestionId, 1, 'Yes,No', ',', 184, 307 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(308, 'Not completed', 321, NULL, @groupQuestionId, 1, '', '',184,308 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(309, 'Test performed this year', 322, 308, @groupQuestionId, 1, 'Yes,No', ',',184,309  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(310, 'Patient refused', 322, 308, @groupQuestionId, 1, 'Yes,No', ',' ,184,310 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(311, 'Standing orders criteria not met', 322, 308, @groupQuestionId, 1, 'Yes,No', ',',184,311  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(312, 'Equipment Malfunction', 322, 308, @groupQuestionId, 1, 'Yes,No', ',',184,312 )

Set @Groupalias ='EKGV2'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'EKG V2','EKG V2', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(313, 'Order EKG if the patient has met at least 1 criteria from below.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,313  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(314, 'H/O arrhythmias', 322, 313, @groupQuestionId, 1, 'Yes,No', ',', 184, 314 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(315, 'Personal H/O CAD/MI', 322, 313, @groupQuestionId, 1, 'Yes,No', ',', 184, 315 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(316, 'Hypertension', 322, 313, @groupQuestionId, 1, 'Yes,No', ',', 184, 316 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(317, 'Clinical exam findings (irregular pulse)', 322, 313, @groupQuestionId, 1, 'Yes,No', ',', 184, 317 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(318, 'Signs and Symptoms (palpitations, rapid heartbeat, chest pain)', 322, 313, @groupQuestionId, 1, 'Yes,No', ',', 184, 318)



INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(319, 'Not completed', 321, NULL, @groupQuestionId, 1, '', '',184,319 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(320, 'Test performed this year', 322, 319, @groupQuestionId, 1, 'Yes,No', ',',184,320  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(321, 'Patient refused', 322, 319, @groupQuestionId, 1, 'Yes,No', ',' ,184,321 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(322, 'Standing orders criteria not met', 322, 319, @groupQuestionId, 1, 'Yes,No', ',',184,322  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(323, 'Equipment Malfunction', 322, 319, @groupQuestionId, 1, 'Yes,No', ',',184,323 )

Set @Groupalias ='ABILEADV2'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'ABI/LEAD','ABI/LEAD', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(324, 'Order ABI/LEAD if the patient has met at least 1 criteria from below.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,324  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(325, 'Hypertension', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 325 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(326, 'High cholesterol', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 326 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(327, 'Diabetes in combination with HTN and/or high cholesterol', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 327 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(328, 'Current/former smoker', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 328 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(329, 'Claudication symptoms', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 329 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(330, 'Clinical exam findings consistent with PVD (absence or diminished peripheral pulses; loss of hair from the extremities; asymmetrical temperature differences in the extremities, discolored skin)', 322, 324, @groupQuestionId, 1, 'Yes,No', ',', 184, 330 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(331, 'Not completed', 321, NULL, @groupQuestionId, 1, '', '',184,331 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(332, 'Test performed this year', 322, 331, @groupQuestionId, 1, 'Yes,No', ',',184,332  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(333, 'Patient refused', 322, 331, @groupQuestionId, 1, 'Yes,No', ',' ,184,333 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(334, 'Standing orders criteria not met', 322, 331, @groupQuestionId, 1, 'Yes,No', ',',184,334  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(335, 'Equipment Malfunction', 322, 331, @groupQuestionId, 1, 'Yes,No', ',',184,335 )


Set @Groupalias ='AAAV2'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'AAA V2','AAA V2', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(336, 'Order Male AAA ultrasound if the patient has met the criteria below:', 322, null, @groupQuestionId, 1, 'Yes,No', ',',185,336  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(337, 'Male patient: ', 321, 336, @groupQuestionId, 1, '', '', 185, 337 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(338, 'Current/former smoker and ≥ 65 years old', 322, 336, @groupQuestionId, 1, 'Yes,No', ',', 185, 338 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(339, 'Not completed', 321, NULL, @groupQuestionId, 1, '', '',185,339 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(340, 'Test performed this year', 322, 339, @groupQuestionId, 1, 'Yes,No', ',',185,340  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(341, 'Patient refused', 322, 339, @groupQuestionId, 1, 'Yes,No', ',' ,185,341 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(342, 'Standing orders criteria not met', 322, 339, @groupQuestionId, 1, 'Yes,No', ',',185,342  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(343, 'Equipment Malfunction', 322, 339, @groupQuestionId, 1, 'Yes,No', ',',185,344 )




INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(344, 'Order Female AAA ultrasound if the patient has met at least 1 criteria from Column A and 1 from Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',186,344  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(345, 'Column A ', 321, 344, @groupQuestionId, 1, '', '', 186, 345 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(346, 'Female patient', 321, 344, @groupQuestionId, 1, '', '', 186, 346 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(347, 'Current/former smoker and ≥ 65 years old', 322, 336, @groupQuestionId, 1, 'Yes,No', ',', 186, 347 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(348, 'Column B', 321, 344, @groupQuestionId, 1, '', '', 186, 348 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(349, 'Female patient: age 65 to 75 who has smoked but have ANY of these risk factors ', 321, 344, @groupQuestionId, 1, '', '', 186, 349 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(350, 'Hypertension', 322, 344, @groupQuestionId, 1, 'Yes,No', ',', 186, 350 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(351, 'High cholesterol', 322, 344, @groupQuestionId, 1, 'Yes,No', ',', 186, 351 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(352, 'Diabetes in combination with HTN and/or high cholesterol ', 322, 344, @groupQuestionId, 1, 'Yes,No', ',', 186, 352 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(353, 'Family history of AA', 322, 344, @groupQuestionId, 1, 'Yes,No', ',', 186, 353 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(354, 'Personal or family history of CAD/MI', 322, 344, @groupQuestionId, 1, 'Yes,No', ',', 186, 354 )


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(355, 'Not completed', 321, NULL, @groupQuestionId, 1, '', '', 186, 355 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(356, 'Test performed this year', 322, 355, @groupQuestionId, 1, 'Yes,No', ',', 186, 356  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(357, 'Patient refused', 322, 355, @groupQuestionId, 1, 'Yes,No', ',' , 186, 357 )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(358, 'Standing orders criteria not met', 322, 355, @groupQuestionId, 1, 'Yes,No', ',', 186, 358  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(359, 'Equipment Malfunction', 322, 355, @groupQuestionId, 1, 'Yes,No', ',', 186, 359 )

Set @Groupalias ='EXITINTERVIEW'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'EXIT INTERVIEW','EXIT INTERVIEW', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(360, 'All Mandatory Test completed per the plans requirements? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',', 184, 360  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(361, 'Tech Initial ', 323, null, @groupQuestionId, 1, '', '', 184, 361  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(362, 'All Testing above ordered appropriately and performed? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',', 184, 362  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(363, 'Tech Initial ', 323, null, @groupQuestionId, 1, '', '', 184, 363  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(364, 'Paperwork in order and signatures confirmed on consent? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',', 184, 364  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(365, 'Tech Initial ', 323, null, @groupQuestionId, 1, '', '', 184, 365  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(366, 'Gift card distributed? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',', 184, 366  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(367, 'Tech Initial ', 323, null, @groupQuestionId, 1, '', '', 184, 367  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(368, 'Customer Survey distributed? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',', 184, 368  )

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(369, 'Tech Initial ', 323, null, @groupQuestionId, 1, '', '', 184, 369)




Set @Groupalias ='RESPIRATORYEXAMSECTIONV2'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'RESPIRATORY EXAM SECTION','RESPIRATORY EXAM SECTION', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias


INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(373, 'Order Spirometry if the patient has met at least 1 criteria from criteria from either column A or Column B.', 322, null, @groupQuestionId, 1, 'Yes,No', ',',184,373)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(374, 'Column A', 321, 373, @groupQuestionId, 1, '', '',184,374)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(375, 'Current/former smoker WITH symptoms of respiratory disease (SOB, chronic cough, wheezing)', 322, 373, @groupQuestionId, 1, 'Yes,No', ',',184,375)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(376, 'Column B', 321, 373, @groupQuestionId, 1, '', '',184,376)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(377, 'Any patient, regardless of smoking history, with symptoms of respiratory disease (SOB, chronic cough, wheezing, frequent respiratory infections) OR positive clinical exam findings (rales, rhonchi, wheezing)', 322, 373, @groupQuestionId, 1, 'Yes,No', ',',184,377)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(378, 'Results compromised (Patient did not have sufficient air intake or exhale to complete the test to instruction specifications).', 322, 373, @groupQuestionId, 1, 'Yes,No', ',',184,378)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(379, 'Results compromised (Patient started coughing or gasping for air during testing).', 322, 373, @groupQuestionId, 1, 'Yes,No', ',',184,379)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(380, 'Patient could not follow the directions of the test successfully.', 322, 373, @groupQuestionId, 1, 'Yes,No', ',',184,380)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(381, 'Not completed', 321, null, @groupQuestionId, 1, '', '',184,381)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(382, 'Test performed this year', 322, 381, @groupQuestionId, 1, 'Yes,No', ',',184,382)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(383, 'Patient refused', 322, 381, @groupQuestionId, 1, 'Yes,No', ',',184,383)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(384, 'Standing orders criteria not met', 322, 381, @groupQuestionId, 1, 'Yes,No', ',',184,384)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(385, 'Equipment Malfunction', 322, 381, @groupQuestionId, 1, 'Yes,No', ',',184,385)


Set @Groupalias ='CRITICALFINDINGS'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'CRITICAL FINDINGS','CRITICAL FINDINGS', 319,null, @Groupalias , 1 )
 END 

select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(386, 'Were any critical findings identified? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,386)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(387, 'Test: ', 323, 386, @groupQuestionId, 1, '', '',184,387)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(388, 'Is patient Symptomatic? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,388)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(389, 'If yes to symptomatic, were additional notes entered into EMR? ', 324, 388, @groupQuestionId, 1, 'Yes,No', ',',184,389)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(390, 'Was PCP contacted? ', 324, null, @groupQuestionId, 1, 'Yes,No,Unavailable', ',',184,390)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(391, 'Was EMS initiated? ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,391)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(392, 'Was patient stable at time of transfer ', 324, null, @groupQuestionId, 1, 'Yes,No', ',',184,392)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(393, 'NP initials ', 323, null, @groupQuestionId, 1, '', '',184,393)

INSERT INTO TblCheckListQuestion (Id,Question,TypeId,ParentId,GroupId,IsActive,ControlValues,ControlValueDelimiter,Gender,[Index])
values(394, 'Date/Time ', 323, null, @groupQuestionId, 1, '', '',184,394)