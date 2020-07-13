 USE [$(dbname)]
 GO
 
 -- insert script for cover letter type
 
 DECLARE @LookupTypeId BIGINT
 
 Set @LookupTypeId = 64
 
 If Not Exists (select * from TblLookup Where Alias = 'EquipmentMalfunction' and LookupTypeId = @LookupTypeId)
 Begin
	 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
		VALUES (414,@LookupTypeId,'EquipmentMalfunction','Equipment Malfunction',14,GETDATE(),1,1)	
 End
 GO