USE [$(dbname)]
GO
Declare @LookupTypeId bigint
set @LookupTypeId = 12

If NOT EXISTS (select 1 from TblLookup Where Alias = 'Txt' and LookupTypeId = @LookupTypeId)
 Begin
	    INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (422,@LookupTypeId,'Txt','txt','txt',1,GETDATE(),1,1)	
 End
