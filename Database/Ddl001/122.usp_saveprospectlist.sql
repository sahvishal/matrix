USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_saveprospectlist]    Script Date: 03/07/2013 12:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================  
-- Author: Sharad  
-- Create date: 13 Dec 07  
-- Description: To insert prospect list data in the table  
-- Name: usp_saveprospectlist  
--=============================================  
ALTER PROCEDURE [dbo].[usp_saveprospectlist]   
(   
 @prospectfileid bigint,   
 @filename varchar(500),   
 @userid bigint, 
 @ListName varchar(255),  
 @ListSource varchar(255),  
 @ListType int,  
 @returnvalue bigint OUTPUT,  
 @LogList VARCHAR(500)=NULL,  
 @mode TINYINT,  
 @roleid INT=NULL,  
 @FileSize VARCHAR(20)=NULL,  
 @UploadTime VARCHAR(10)=NULL,  
 @FranchiseeID BIGINT=NULL,  
 @assigned BIT=0  
)  
   
AS  
SET NOCOUNT ON;  
SET @returnvalue=0  

IF (@mode=0)  
BEGIN  
 BEGIN TRAN  
 IF NOT EXISTS(SELECT [ProspectFileID] FROM TblProspectListDetails WHERE [ListName] = @ListName)  
 BEGIN  
  INSERT INTO TblProspectListDetails  
  ([FileName], DateCreated, DateModified, IsActive,ListName,ListSource,ListType,AddedBy,roleid,FileSize,OrganizationId,Assigned)  
  VALUES (@filename,getdate(),getdate(),1,@ListName,@ListSource,@ListType,@UserID,@roleid,@FileSize,@FranchiseeID,0)   
  SET @returnvalue = @@identity  
   
  IF @@ERROR <>0   
  BEGIN  
   SET @returnvalue=-1  
   ROLLBACK TRAN  
   RETURN  
  END  
 END  
 ELSE  
 BEGIN  
  SET @returnvalue=9999995  
  ROLLBACK TRAN  
  RETURN  
 END  
 COMMIT TRAN  
END  
ELSE IF(@mode=1)  
BEGIN  
 UPDATE TblProspectListDetails SET LOG_LIST=@LogList,UploadTime=@UploadTime,Assigned=@assigned  
 WHERE [ProspectFileID]=@prospectfileid  
 IF @@ERROR <>0   
  BEGIN  
   SET @returnvalue=-1  
   ROLLBACK TRAN  
   RETURN  
  END  
 ELSE SET @returnvalue=@prospectfileid  
END  
RETURN