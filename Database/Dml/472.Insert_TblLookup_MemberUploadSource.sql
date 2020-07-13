 USE [$(dbname)]
 GO
  
 DECLARE @LookupTypeId BIGINT
 
 INSERT TblLookupType (Alias,DisplayName,DateCreated)
 VALUES ('MemberUploadSource','Member Upload Source',GETDATE())
 
 SELECT @LookupTypeId = IDENT_CURRENT('TblLookupType');
 
 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
 VALUES (413,@LookupTypeId,'Aces','Aces',1,GETDATE(),1,1)
 
 