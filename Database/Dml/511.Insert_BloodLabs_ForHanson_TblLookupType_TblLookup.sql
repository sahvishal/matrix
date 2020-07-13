
USE [$(dbname)]
GO

DECLARE @LookupTypeId int

IF NOT EXISTS(SELECT 1 FROM TblLookupType Where Alias = 'BloodLabs')
	BEGIN
	   INSERT INTO TblLookupType (Alias,DisplayName,[Description],DateCreated)
	   VALUES('BloodLabs','Blood Labs','Blood Labs',GETDATE())
	END

    SET @LookupTypeId = (SELECT LookupTypeID FROM TblLookupType Where Alias = 'BloodLabs')

If NOT EXISTS (select 1 from TblLookup Where Alias = 'Hanson' and LookupTypeId = @LookupTypeId)
 Begin
	    INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (429,@LookupTypeId,'Hanson','Hanson','Hanson',1,GETDATE(),1,1)	
 End
 