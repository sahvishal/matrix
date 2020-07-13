use [$(dbName)]
Go

Declare @templateId bigint
set @templateId = 0
if Not Exists (select * from TblCheckListTemplate Where Name = 'Default Checklist Template' )
Begin
	insert TblCheckListTemplate (Name,HealthPlanId,IsActive,IsPublished,DateCreated,DateModified,CreatedBy,ModifiedBy) 
		values ('Default Checklist Template',null,1,1,getdate(),null,1,null)
End

select @templateId = Id from TblCheckListTemplate Where Name = 'Default Checklist Template' 

Delete from TblCheckListTemplateQuestion Where TemplateId = @templateId

Insert into TblCheckListTemplateQuestion
select @templateId,Id from TblCheckListQuestion Where isActive = 1

