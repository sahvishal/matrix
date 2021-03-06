USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_SRepDeleteProspectHost]    Script Date: 01/23/2013 13:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author		: <Viranjay Singh>
-- Create date	: 15-Apr-2009
-- Description	: Delete prospect and host
-- Example		: exec usp_SRepDeleteProspectHost 2,1214,@retur
-- =============================================
ALTER PROCEDURE [dbo].[usp_SRepDeleteProspectHost] 
(
	@mode INT, 
	@prospectid BIGINT,	
	@returnvalue BIGINT OUTPUT 
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @returnvalue=0;
	
	
-- delete prospect
IF(@mode=1)
BEGIN	
		BEGIN TRAN
		------------------------------------------------------------------------------	
		-- delete task contact linking
		DELETE FROM TblProspectContactTasks  WHERE [ProspectContactID] IN
		(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete prospect task linking
		delete from TblProspectTasks where ProspectID=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete task
		DELETE from TblTaskDetails WHERE taskid IN
			(
				select taskid from TblProspectContactTasks where ProspectContactID In    
				(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
				Union All     
				select [TaskID] From TblProspectTasks where ProspectID=@prospectid  
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meeting and contact linking
		DELETE FROM TblProspectContactMeetings WHERE [ProspectContactID] IN 
			(
				select ProspectContactID from TblProspectContact where ProspectID=@prospectid
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meeting and prospect linking
		DELETE FROM TblProspectMeetings where ProspectID=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meetings
		DELETE FROM TblContactMeeting WHERE contactmeetingid IN
			(
				select MeetingId from TblProspectContactmeetings where ProspectContactID In    
				(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
		   Union All     
				select [MeetingID] From TblProspectmeetings where ProspectID=@prospectid  
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete call association with prospect
		DELETE FROM TblProspectCalls WHERE prospectid =@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete call association with contacts
		DELETE from TblProspectContactCalls where [ProspectContactID] IN
		(SELECT [ProspectContactID] FROM TblProspectContact where prospectid =@prospectid)
		
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete calls
		DELETE from TblContactCall where contactcallid in
		   (
			select CallID from TblProspectContactCalls where ProspectContactID In    
			(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
		   Union All     
			select CallID From TblProspectCalls where ProspectID=@prospectid  
		   )   
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		-- delete prospect contact role mapping
		Delete from TblProspectContactRoleMapping where prospectcontactid  in 
		(
			select prospectcontactid from TblProspectContact where prospectid = @prospectid
		)
		------------------------------------------------------------------------------
		-- delete prospect contact 
		DELETE FROM TblProspectContact where prospectid =@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END		
		------------------------------------------------------------------------------
		-- delete prospect address
		DELETE FROM [TblProspectAddress] WHERE prospectid=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END	
		
		
		Delete from TblHostFacilityRanking where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END

		Delete from TblHostImage where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		
		Delete from TblHostNotes where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END

		------------------------------------------------------------------------------
		-- delete prospect
		DELETE from TblProspects where prospectid=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		------------------------------------------------------------------------------
		COMMIT TRAN
		SET @returnvalue=1;
	END
	-- delete host
	ELSE IF(@mode=2)
	BEGIN
		DECLARE @addressid BIGINT
		DECLARE @addressidmailing BIGINT
		
		IF EXISTS(SELECT EventID FROM TblHostEventDetails WHERE hostid=@prospectid)
		BEGIN
			SET @returnvalue=2;
			RETURN
		END
		
		BEGIN TRAN
		------------------------------------------------------------------------------	
		-- delete task contact linking
		DELETE FROM TblProspectContactTasks  WHERE [ProspectContactID] IN
		(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete prospect task linking
		delete from TblProspectTasks where ProspectID=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete task
		DELETE from TblTaskDetails WHERE taskid IN
			(
				select taskid from TblProspectContactTasks where ProspectContactID In    
				(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
				Union All     
				select [TaskID] From TblProspectTasks where ProspectID=@prospectid  
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meeting and contact linking
		DELETE FROM TblProspectContactMeetings WHERE [ProspectContactID] IN 
			(
				select ProspectContactID from TblProspectContact where ProspectID=@prospectid
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meeting and prospect linking
		DELETE FROM TblProspectMeetings where ProspectID=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete meetings
		DELETE FROM TblContactMeeting WHERE contactmeetingid IN
			(
				select MeetingId from TblProspectContactmeetings where ProspectContactID In    
				(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
		   Union All     
				select [MeetingID] From TblProspectmeetings where ProspectID=@prospectid  
			)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete call association with prospect
		DELETE FROM TblProspectCalls WHERE prospectid =@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete call association with contacts
		DELETE from TblProspectContactCalls where [ProspectContactID] IN
		(SELECT [ProspectContactID] FROM TblProspectContact where prospectid =@prospectid)
		
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		
		------------------------------------------------------------------------------
		-- delete calls
		DELETE from TblContactCall where contactcallid in
		   (
			select CallID from TblProspectContactCalls where ProspectContactID In    
			(select ProspectContactID from TblProspectContact where ProspectID=@prospectid)    
		   Union All     
			select CallID From TblProspectCalls where ProspectID=@prospectid  
		   )   
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		-- delete prospect contact role mapping
		Delete from TblProspectContactRoleMapping where prospectcontactid  in 
		(
			select prospectcontactid from TblProspectContact where prospectid = @prospectid
		)
		------------------------------------------------------------------------------
		-- delete prospect contact 
		DELETE FROM TblProspectContact where prospectid =@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------		
		
		Delete from TblHostFacilityRanking where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END

		Delete from TblHostImage where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		
		Delete from TblHostNotes where HostId = @prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
		END
		
		------------------------------------------------------------------------------
		-- delete prospect address
		SELECT @addressid=addressid FROM tblprospects WHERE prospectid=@prospectid
		SELECT @addressidmailing=addressidmailling FROM tblprospects WHERE prospectid=@prospectid		
		DELETE FROM [TblProspectAddress] WHERE [ProspectID]=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		---------------------------------------------------------
		--delete host corporate account mapping
		Update TblAccount
		set ConvertedHostId=null
		where ConvertedHostId=@prospectid
		------------------------------------------------------------------------------
		-- delete prospect
		DELETE from TblProspects where prospectid=@prospectid
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		DELETE FROM [TblAddress] WHERE [AddressID] IN(@addressid,@addressidmailing)
		IF(@@ERROR>0)
		BEGIN
			SET @returnvalue=0;
			ROLLBACK TRAN
			RETURN 
		END
		------------------------------------------------------------------------------
		-- delete prospect
	COMMIT TRAN
	
	SET @returnvalue=1;
	
	END
END
