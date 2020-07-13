USE [$(dbName)]
Go

Declare @lookupTypeId bigint

Select @lookupTypeId = LookUpTypeId from TblLookupType Where Alias = 'HAFTemplateCategory'

IF (isnull(@lookupTypeId, 0) = 0)
BEGIN
	Insert Into TblLookupType (Alias, DisplayName, Description, DateCreated)
	values ('HAFTemplateCategory', 'HAF Template Category', '', getdate())
	
	Select @lookupTypeId = Scope_Identity()
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'HealthAssessmentTemplate' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (192, @lookupTypeId, 'HealthAssessmentTemplate', 'Health Assessment Template', 'Health Assessment Template', 1, getdate(), 1, 1)
END

IF NOT EXISTS (Select LookUpId from TblLookup where Alias = 'ClinicalQuestions' and LookupTypeId = @lookupTypeId)
BEGIN
	Insert Into TblLookUp (LookupId, LookupTypeId, Alias, DisplayName, Description, RelativeOrder, DateCreated, DatarecorderCreatorId, IsActive)
	values (193, @lookupTypeId, 'ClinicalQuestions', 'Clinical Questions', 'ClinicalQuestions', 2, getdate(), 1, 1)
END
