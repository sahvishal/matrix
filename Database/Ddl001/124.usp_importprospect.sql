USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_importprospect]    Script Date: 03/07/2013 17:02:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-------------------------------------------------------------------------------------------------------------------------

-- =============================================      
-- Author:  Abhinav Goel      
-- Create date: 25-10-2007      
-- Description: To insert,update,delete and deactivate the prospect master      
-- Name: usp_importprospect      
-- Parameter: Input (prospectid,prospectname,description,rowstate "0->Insert,1->Update,2->Deactivate,3->Delete",   
--  Output (returnvalue "999999 -> Insufficient Access,0 -> Success,-1 -> Any DB related Error")      
--=============================================      
ALTER PROCEDURE [dbo].[usp_importprospect]  
(       
 @prospectid bigint,       
 @prospectlistid bigint = null,       
 @prospecttypeid bigint,      
 @membership decimal(18,2),      
 @attendance decimal(18,2),       
 @emailid varchar(500),  
 @phoneoffice varchar(500),      
 @phonecell varchar(500),      
 @phoneother varchar(500),      
 @website varchar(500),      
 @organizationname varchar(500),       
 @notes varchar(1000),      
 @methodobtainedid bigint,      
 @willcommunicate INT,      
 @ReasonWillcommunicate Text,     
 @followdate varchar(100) = null,      
 @ishost bit,      
 @status varchar(100)=null,      
   
 @paddress1 varchar(500),  
 @paddress2 varchar(500),  
 @pcity varchar(100),      
 @pstate varchar(100),  
 @pzipcode bigint,  
 @pcountry varchar(100),      
 @pfax VARCHAR(100),  
   
 @saddress1 varchar(500),  
 @saddress2 varchar(500),  
 @scity varchar(100),      
 @sstate varchar(100),  
 @szipcode bigint,  
 @scountry varchar(100),      
 @sfax VARCHAR(100),  
   
 @title varchar(500)=null,  
 @firstname varchar(500)=null,  
 @middlename varchar(500)=null,  
 @lastname varchar(500)=null,  
   
   
 @rowstate tinyint,  
 @userid varchar(100), 
 @returnvalue bigint OUTPUT,  
 @SalesRepID bigint=NULL,
 @Gender bit,
 @contactEmail varchar(255),
 @contactTitle varchar(255),
 @contactRole varchar(255),
 @prospectType varchar(255)
)    
       
AS      
SET NOCOUNT ON;      
SET @returnvalue=0      
      
DECLARE @contactid bigint      
DECLARE @prospectcontactid BIGINT  
DECLARE @prospectcontactroleid BIGINT  
DECLARE @shelluserid bigint  
DECLARE @notesid BIGINT
DECLARE @notesnew varchar(1000)      

BEGIN TRAN      
      
IF(@rowstate = 0)      
BEGIN
	  

-- set contact roleid
IF (len(@contactRole) > 0)
BEGIN
	if exists( SELECT ProspectContactRoleID FROM [TblProspectContactRole] WHERE ProspectContactRoleName LIKE '%' + @contactRole +'%')
	BEGIN
		SELECT @prospectcontactroleid=ProspectContactRoleID FROM [TblProspectContactRole] WHERE ProspectContactRoleName LIKE '%' + @contactRole +'%' 
	END
	ELSE
	BEGIN
		SELECT @prospectcontactroleid=ProspectContactRoleID FROM [TblProspectContactRole] WHERE ProspectContactRoleName LIKE '%Primary Contact%'
	END
END
ELSE
BEGIN
-- select primary contact role id  
	SELECT @prospectcontactroleid=ProspectContactRoleID FROM [TblProspectContactRole] WHERE ProspectContactRoleName LIKE '%Primary Contact%'
END
-- set prospect type id
IF (len(@prospectType) > 0)
BEGIN
	IF exists( SELECT ProspectTypeID FROM [TblProspectType] WHERE [Name] LIKE '%' + @prospectType +'%' and IsActive=1)
	BEGIN
		SELECT @prospecttypeid=ProspectTypeID FROM [TblProspectType] WHERE [Name] LIKE '%' + @prospectType +'%' and IsActive=1
	END
END

 IF(@pstate='TX') SET @pstate='Texas'  
 IF(@sstate='TX') SET @sstate='Texas'  
 
IF NOT EXISTS    
	(    
	Select TP.ProspectID from TblProspects TP      
	inner join TblProspectAddress TA on TP.prospectid=TA.ProspectID  
	where TP.OrganizationName=@organizationname  and TA.City=@pcity AND TA.State=@pstate and TA.Zip=@pzipcode  
	)
BEGIN        
	 INSERT INTO TblProspects  
	 (  
	 ProspectListID, ProspectTypeID, EMailID,PhoneOffice,PhoneCell,  
	 PhoneOther,WebSite,OrganizationName,DateCreated,DateModified,ActualMembership,ActualAttendance,  
	 MethodObtainedID,WillPromote,ReasonWillPromote,IsHost,FUDate,IsActive,Status,OrgRoleUserId  
	 )      
	 VALUES  
	 (  
	 @prospectlistid,@prospecttypeid,@emailid,@phoneoffice,@phonecell,@phoneother,@website,  
	 @organizationname,getdate(),getdate(),@membership,@attendance,@methodobtainedid,@willcommunicate,@ReasonWillcommunicate,  
	 @ishost,@followdate,1,@status,@SalesRepID  
	 )      
	 Set @prospectid = @@identity  
	 IF @@ERROR <>0       
	 BEGIN      
	  SET @returnvalue=-1      
	  ROLLBACK TRAN      
	  RETURN      
	 END      
	 -- Insert Notes  
	 IF (@notes!='' and len(@notes) > 0)   
	 BEGIN  
	  Insert into TblNotesDetails(Notes,DateCreated,DateModified) values (@notes,getdate(),getdate())  
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1   
	   ROLLBACK TRAN      
	   RETURN  
	  END  
	   set @notesid=@@identity  
	   -- Insert Prospect Notes Relatioship  
	   insert into TblProspectNotesDetails(prospectid,noteid) values(@prospectid,@notesid)   
	 IF @@ERROR <>0  
	   BEGIN      
		SET @returnvalue=-1      
		ROLLBACK TRAN      
		RETURN  
	   END  
	  END  
	  -- Insert Primary Address    
	  
	  INSERT INTO TblProspectAddress  
	  (Address1,Address2,City,State,Country,Zip,fax,DateCreated,DateModified,IsActive,ProspectID,IsMailing)      
	  VALUES(@paddress1,@paddress2,@pcity,@pstate,@pcountry,@pzipcode,@pfax,getdate(),getdate(),1,@prospectid,0)      
	    
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1      
	   ROLLBACK TRAN      
	   RETURN        END        
	    
	  -- Insert Primary Address  
	    
	  INSERT INTO TblProspectAddress  
	  (Address1,Address2,City,State,Country,Zip,fax,DateCreated,DateModified,IsActive,ProspectID,IsMailing)      
	  VALUES(@saddress1,@saddress2,@scity,@sstate,@scountry,@szipcode,@sfax,getdate(),getdate(),1,@prospectid,1)  
	    
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1      
	   ROLLBACK TRAN      
	   RETURN      
	  END  
	    
	  -- Check for contact is not empty  
	  IF (LEN(@FirstName) > 0 or LEN(@LastName) > 0)  
	  BEGIN  
		-- Insert Contact    
		INSERT INTO TblContacts   
		(  
		 Salutation,FirstName,MiddleName,LastName,Gender,Email,[Title],[Addedby],[ModifiedBy],  
		 [DateCreated],[DateModified],IsActive  
		)   
		VALUES   
		(  
		 @title,@FirstName,@MiddleName,@LastName,@Gender,@contactEmail,@contactTitle,@userid,@userid,GETDATE(),GETDATE(),1  
		)  
	      
		Set @contactid = @@IDENTITY  
	      
		IF @@ERROR <>0       
		BEGIN      
		 SET @returnvalue=-1      
		 ROLLBACK TRAN      
		 RETURN      
		END  
	      
		-- Insert Prospect Contact  
		INSERT INTO [TblProspectContact]   
		(  
		 [ProspectID],[ContactID],[DateCreated],[DateModified],[IsActive]  
		)  
		VALUES   
		(  
		 @prospectid,@contactid,GETDATE(),GETDATE(),1  
		)  
		Set @prospectcontactid = @@IDENTITY  
	      
		IF @@ERROR <>0       
		BEGIN      
		 SET @returnvalue=-1      
		 ROLLBACK TRAN      
		 RETURN      
		END  
	      
		-- Insert Prospect Contact Role Mapping   
		INSERT INTO [TblProspectContactRoleMapping]([ProspectContactID],[ProspectContactRoleID],[IsActive])  
		VALUES (@prospectcontactid,@prospectcontactroleid,1)  
	      
		IF @@ERROR <>0       
		BEGIN      
		 SET @returnvalue=-1      
		 ROLLBACK TRAN      
		 RETURN      
		END  
	  END  
     Set @returnvalue=@prospectid  
END
ELSE
BEGIN
	-- Update prospect details incase of duplicate prospects
	Select @prospectid = TP.ProspectID from TblProspects TP      
	inner join TblProspectAddress TA on TP.prospectid=TA.ProspectID  
	where TP.OrganizationName=@organizationname  and TA.City=@pcity AND TA.State=@pstate and TA.Zip=@pzipcode  
	
	-- Update
	 Update TblProspects
	 SET ProspectListID=@prospectlistid,
	 ProspectTypeID=@prospecttypeid,
	 EMailID=@emailid,PhoneOffice=@phoneoffice,PhoneCell=@phonecell,  
	 PhoneOther=@phoneother,WebSite=@website,OrganizationName=@organizationname,DateCreated=GETDATE(),DateModified=GETDATE(),
	 ActualMembership=@membership,ActualAttendance=@attendance,  
	 MethodObtainedID=@methodobtainedid,WillPromote=@willcommunicate,ReasonWillPromote=@ReasonWillcommunicate,
	 IsHost=@ishost,FUDate=@followdate,Status=@status,OrgRoleUserId=@SalesRepID
	 WHERE prospectid=@prospectid
	 
	 IF @@ERROR <>0       
	 BEGIN      
	  SET @returnvalue=-1      
	  ROLLBACK TRAN      
	  RETURN      
	 END      
	 -- Insert Notes  
	 IF (@notes!='' and len(@notes) > 0)   
	 BEGIN  
			SELECT TOP 1 @notesnew=Notes FROM TblNotesDetails 
			INNER JOIN TblProspectNotesDetails ON TblNotesDetails.Noteid=TblProspectNotesDetails.NoteID
			WHERE TblProspectNotesDetails.prospectid=1367 ORDER BY DateCreated DESC
			IF(@notesnew!=@notes)
			Insert into TblNotesDetails(Notes,DateCreated,DateModified) values (@notes,getdate(),getdate())  
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1   
	   ROLLBACK TRAN      
	   RETURN  
	  END  
	   set @notesid=@@identity  
	   -- Insert Prospect Notes Relatioship  
	   insert into TblProspectNotesDetails(prospectid,noteid) values(@prospectid,@notesid)   
	 IF @@ERROR <>0  
	   BEGIN      
		SET @returnvalue=-1      
		ROLLBACK TRAN      
		RETURN  
	   END  
	  END  
	  -- Insert Primary Address    
	  UPDATE TblProspectAddress  
	  SET Address1=@paddress1,Address2=@paddress2,City=@pcity,State=@pstate,Country=@pcountry,
	  Zip=@pzipcode,fax=@pfax,DateModified=GETDATE()
	  WHERE prospectid=@prospectid AND IsMailing=0      
	    
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1      
	   ROLLBACK TRAN      
	   RETURN        END        
	    
	  -- Insert Primary Address  
	  UPDATE TblProspectAddress  
	  SET Address1=@saddress1,Address2=@saddress2,City=@scity,State=@sstate,Country=@scountry,
	  Zip=@szipcode,fax=@sfax,DateModified=GETDATE()
	  WHERE prospectid=@prospectid AND IsMailing=1 AND IsActive=1
	  
	    
	  IF @@ERROR <>0       
	  BEGIN      
	   SET @returnvalue=-1      
	   ROLLBACK TRAN      
	   RETURN      
	  END  
	    
	  -- Check for contact is not empty  
	  IF (LEN(@FirstName) > 0 or LEN(@LastName) > 0)  
	  BEGIN  
		-- Update Contact    
		
		SELECT @contactid=Contactid,@prospectcontactid=prospectcontactid FROM TblProspectContact WHERE prospectcontactid=
		(
			SELECT MIN(ProspectContactId) FROM [TblProspectContactRoleMapping] WHERE ProspectContactid in
			(
			SELECT prospectcontactid FROM [TblProspectContact] WHERE prospectid=@prospectid
			) --AND [ProspectContactRoleID]=@prospectcontactroleid
		)
		
		UPDATE TblContacts   
		SET Salutation=@title,FirstName=@FirstName,MiddleName=@MiddleName,LastName=@LastName,[ModifiedBy]=@userid,  
		[DateModified]=GETDATE()
		WHERE contactid=@contactid
		
		IF @@ERROR <>0       
		BEGIN      
		 SET @returnvalue=-1      
		 ROLLBACK TRAN      
		 RETURN      
		END  
		UPDATE [TblProspectContactRoleMapping] set prospectcontactroleid=@prospectcontactroleid
		WHERE ProspectContactid=@prospectcontactid
		
		IF @@ERROR <>0       
		BEGIN      
		 SET @returnvalue=-1      
		 ROLLBACK TRAN      
		 RETURN      
		END 

	  END  
     Set @returnvalue=@prospectid  
END
END      
COMMIT TRAN  
RETURN
