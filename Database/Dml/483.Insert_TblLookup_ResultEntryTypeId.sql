USE [$(dbname)]
GO

DECLARE @LookupTypeId int

IF NOT EXISTS(SELECT 1 FROM TblLookupType Where Alias = 'ResultEntryType')
	BEGIN
	   INSERT INTO TblLookupType (Alias,DisplayName,[Description],DateCreated)
	   VALUES('ResultEntryType','ResultEntryType','Result Entry by Hip or Chat',GETDATE())
	END

    SET @LookupTypeId = (SELECT LookupTypeID FROM TblLookupType Where Alias = 'ResultEntryType')

If NOT EXISTS (select 1 from TblLookup Where Alias = 'Hip' and LookupTypeId = @LookupTypeId)
 Begin
	    INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (420,@LookupTypeId,'Hip','HIP','Hip',1,GETDATE(),1,1)	
 End
 
 If Not Exists (select 1 from TblLookup Where Alias = 'Chat' and LookupTypeId = @LookupTypeId)
 Begin
	   INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (421,@LookupTypeId,'Chat','CHAT','Chat',2,GETDATE(),1,1)	
 End
 
 GO
 