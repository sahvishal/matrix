
USE [$(dbName)]
GO

Declare @HafTemplateId bigint, @Type int

BEGIN TRY
Begin Tran

Set @Type = 152

Update [TblHAFTemplate]
set IsDefault = 0
where [Type] = @Type

Insert into [TblHAFTemplate]
	([Name], [Type], [IsDefault],[IsPublished], [CreatedBy], [DateCreated], [ModifiedBy], [DateModified], [IsActive], [PublicationDate],[Notes])
Values
	('Event Default Template', @Type, 1, 1, 1, getdate(), 1, getdate(), 1, getdate(), 'Default template for event.')

Set @HafTemplateId = Scope_Identity()

INSERT INTO [TblHAFTemplateQuestion]
    ([HAFTemplateId], [QuestionId])
    
select @HafTemplateId, CustomerHealthQuestionId from TblCustomerHealthQuestions

Update TblEvents
set HafTemplateId = @HafTemplateId
where HafTemplateId Is null
           

COMMIT TRAN
END TRY
BEGIN CATCH
	ROLLBACK TRAN	
	DECLARE @ErrMsg nvarchar(4000), @ErrSeverity int
	SELECT @ErrMsg = ERROR_MESSAGE(), @ErrSeverity = ERROR_SEVERITY()	
	
	RAISERROR(@ErrMsg, @ErrSeverity, 1)
END CATCH
