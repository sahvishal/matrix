USE [$(dbname)]
GO
/****** Object:  StoredProcedure [dbo].[usp_NotificationCenterReServiced]    Script Date: 31-08-2017 12:01:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------------------------------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------------------  
-- Author		: Viranjay Singh    
-- Create date	: 17-11-2008    
-- Description	: Re Serviced the notification
-- Name			: usp_NotificationCenterReServiced
-- Example		: -- exec usp_NotificationCenterReServiced 
-------------------------------------------------------------------------------------------------------------  
ALTER PROCEDURE [dbo].[usp_NotificationCenterReServiced]
(
	@NotificationID bigint,
	@ClientLabel varchar(255),
	@RequestedBy bigint,
	@NotificationMedium varchar(255),
	@Emailsubject varchar(255),
	@EmailBody text,
	@mode int,
	@returnvalue bigint output
	
)
AS
BEGIN
	DECLARE @NotificationIDNew as bigint
	DECLARE @NotificationMediumID as INT
	DECLARE @userId BIGINT
	DECLARE @EmailId VARCHAR(255)
	DECLARE @PhoneCell varchar(50)
	
	SET @returnvalue=0;
	set @NotificationMediumID=(select NotificationMediumID from TblNotificationMedium where NotificationMedium =@NotificationMedium)
	-- get user id 
	SELECT TOP 1 @userId=userid  FROM [TblNotification] WHERE [NotificationID]=@NotificationID
	-- get email address
	SELECT TOP 1 @userId=userid  FROM [TblNotification] WHERE [NotificationID]=@NotificationID
	SELECT @EmailId = Email1, @PhoneCell = PhoneCell FROM [TblUser] WHERE [UserID] = @userId
	
	Begin Tran
		insert tblNotification 
		(RequestedByOrgRoleUserId,
		UserID,
		NotificationDate,
		NotificationMediumID,
		NotificationTypeID,
		Source,
		Priority,
		Notes)
		select 
		@RequestedBy as RequestedByOrgRoleUserId,
		UserID,
		getdate() as NotificationDate,
		@NotificationMediumID as NotificationMediumID,
		NotificationTypeID,
		@ClientLabel as ClientLabel,
		2 as Priority,
		'' as Notes 
		from TblNotification
		where NotificationID=@NotificationID
		
		if (@@error=0)
		BEGIN			
			set @NotificationIDNew=(select @@identity)
			IF(@NotificationMedium = 'Email')
				BEGIN
					IF(@mode=1)
						BEGIN
							insert tblNotificationEmail
							(EmailNotificationID,
							ToEmail,
							Subject,
							Body,
							FromEmail,
							FromName,
							AttachmentPath)			
							select 
							@NotificationIDNew,
							@EmailId,
							Subject,
							Body,
							FromEmail,
							FromName,
							AttachmentPath
							from TblNotificationEmail
							where 
							EmailNotificationID=@NotificationID
						END
						ELSE IF (@mode=2)
						BEGIN
							IF (@EmailSubject='' and  @EmailSubject is null)
							BEGIN
								select @EmailSubject=Subject from TblNotificationEmail WHERE EmailNotificationID=@NotificationID
							END
				
							insert tblNotificationEmail
							(EmailNotificationID ,
							ToEmail,
							Subject,
							Body,
							FromEmail,
							FromName,
							AttachmentPath)			
							select 
							@NotificationIDNew,
							@EmailId,
							@EmailSubject,
							@EmailBody,
							FromEmail,
							FromName,
							AttachmentPath
							from TblNotificationEmail
							where 
							EmailNotificationID=@NotificationID						
						END
				END
				ELSE IF (@NotificationMedium = 'SMS')
					BEGIN
						IF(@mode=1)
						BEGIN
							insert TblNotificationPhone
							(
								PhoneNotificationID,
								PhoneCell,
								[Message],
								ServicedBy
							)			
							select 
								@NotificationIDNew,
								@PhoneCell,
								[Message],
								ServicedBy							
							from TblNotificationPhone
							where 
							PhoneNotificationID=@NotificationID
						END
						ELSE IF (@mode=2)
						BEGIN
							IF (@EmailSubject='' and  @EmailSubject is null)
							BEGIN
								select @EmailSubject=[Message] from TblNotificationPhone WHERE PhoneNotificationID = @NotificationID
							END
				
							insert TblNotificationPhone
							(
								PhoneNotificationID,
								PhoneCell,
								[Message]
							)			
							select 
								@NotificationIDNew,
								@PhoneCell,								
								@EmailBody
							from TblNotificationPhone
							where 
							PhoneNotificationID=@NotificationID						
						END
					END	

			IF (@@error=0)
				COMMIT TRAN
			ELSE
				BEGIN
					SET @returnvalue=-1
					ROLLBACK TRAN
				END
		END
		ELSE
			BEGIN
				SET @returnvalue=-1
				ROLLBACK TRAN		
			END
	END

-------------------------------------------------------------------------------------------------------------------------
