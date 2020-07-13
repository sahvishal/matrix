USE [$(dbname)]
GO

DECLARE @LookupTypeId int

IF NOT EXISTS(SELECT 1 FROM TblLookupType Where Alias = 'CheckListType')
	BEGIN
	   INSERT INTO TblLookupType (Alias,DisplayName,[Description],DateCreated)
	   VALUES('CheckListType','Check List Type','Lookup for check list type',GETDATE())
	END

    SET @LookupTypeId = (SELECT LookupTypeID FROM TblLookupType Where Alias = 'CheckListType')

 If Not Exists (select 1 from TblLookup Where Alias = 'CheckList' and LookupTypeId = @LookupTypeId)
 Begin
	 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (418,@LookupTypeId,'CheckList','Check List','CheckList',1,GETDATE(),1,1)	
 End

 If Not Exists (select 1 from TblLookup Where Alias = 'ExitInterviewQuery' and LookupTypeId = @LookupTypeId)
 Begin
	 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (419,@LookupTypeId,'ExitInterviewQuery','Exit Interview Query','Exit Interview Query',2,GETDATE(),1,1)	
 End
 GO

