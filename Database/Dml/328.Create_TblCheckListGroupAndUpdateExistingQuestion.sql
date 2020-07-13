use [$(dbName)]
Go

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


Declare @groupQuestionId bigint
Declare @Groupalias varchar(512)

set @Groupalias ='EKGV1'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'EKG V1','EKG V1', 319,null, @Groupalias , 1 )
 END 
 select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

 update TblCheckListQuestion set groupId=@groupQuestionId Where Id >= 133 and Id <= 150 and GroupId in(select Id from tblCheckListGroup Where Alias = 'CARDIOVASCULAREXAMSECTION')


 set @Groupalias ='ABIFLOCHCKLEADV1'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'ABI/Flochec/LEAD V1','ABI/Flochec/LEAD V1', 319,null, @Groupalias , 1 )
 END 
 select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

 update TblCheckListQuestion set groupId=@groupQuestionId Where Id >= 151 and Id <= 165 and GroupId in(select Id from tblCheckListGroup Where Alias = 'CARDIOVASCULAREXAMSECTION')

 
 set @Groupalias ='AAAV1'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'AAA V1','AAA V1', 319,null, @Groupalias , 1 )
 END 
 select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

 update TblCheckListQuestion set groupId=@groupQuestionId Where Id >= 166 and Id <= 199 and GroupId in(select Id from tblCheckListGroup Where Alias = 'CARDIOVASCULAREXAMSECTION')
 
 
 set @Groupalias ='CAROTIDV1'

 If Not Exists (select Id from TblCheckListGroup Where Alias = @Groupalias)
 BEGIN
	INSERT INTO TblCheckListGroup (Name,[Description],TypeId,ParentId,Alias,IsActive)
		values( 'CAROTID V1','CAROTID V1', 319,null, @Groupalias , 1 )
 END 
 select @groupQuestionId = Id from TblCheckListGroup where Alias = @Groupalias

 update TblCheckListQuestion set groupId=@groupQuestionId Where Id >= 200 and Id <= 209 and GroupId in(select Id from tblCheckListGroup Where Alias = 'CARDIOVASCULAREXAMSECTION')
