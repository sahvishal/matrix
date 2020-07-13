 USE [$(dbname)]
 GO
 
 -- insert script for cover letter type
 
 DECLARE @LookupTypeId BIGINT
 
 INSERT TblLookupType (Alias,DisplayName,DateCreated)
 VALUES ('CoverLetterType','Cover Letter Type',GETDATE())
 
 SELECT @LookupTypeId = IDENT_CURRENT('TblLookupType');
 
 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
 VALUES (410,@LookupTypeId,'MemberCoverLetter','Member Cover Letter',1,GETDATE(),1,1),
 	    (411,@LookupTypeId,'PcpCoverLetter','PCP Cover Letter',2,GETDATE(),1,1)
 
 
  -- insert cover letter for email template

 SELECT @LookupTypeId = LookupTypeId FROM TblLookupType WHERE Alias = 'EmailTemplate'
 
 INSERT INTO TblLookup (LookupId,LookupTypeId,Alias,DisplayName,RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
 VALUES (412,@LookupTypeId,'CoverLetter','Cover Letter',3,GETDATE(),1,1)
 
 GO