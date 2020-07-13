USE [$(dbName)]
Go

DECLARE @EditEmailTemplateACO_Id BIGINT 
 
Select @EditEmailTemplateACO_Id = Id from TblAccessControlObject where Alias =  'Edit Email Template'

If (@EditEmailTemplateACO_Id is not Null)
Begin
	INSERT INTO TblAccessControlObjectUrl (AccessControlObjectId, Url) VALUES (@EditEmailTemplateACO_Id, '/Communication/EmailTemplate/PreviewTemplate')
End