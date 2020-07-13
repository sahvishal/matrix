USE [$(dbName)]
Go

/****** Object:  StoredProcedure [dbo].[usp_removeevent]    Script Date: 08/10/2012 16:06:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
ALTER PROCEDURE [dbo].[usp_removeevent](@eventID bigint, @returnvalue smallint output)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SET @returnvalue=0
	
	If Exists (Select EventCustomerID from TblEventCustomers where EventID =  @eventID and AppointmentID is not null and NoShow = 0)
	BEGIN
		IF EXISTS(Select EventID from TblEvents where EventID = @eventID and EventDate < getdate())
		BEGIN
			Set @returnvalue = -2 --- Past Date and customers registered
			return
		END
		ELSE
		BEGIN
			Set @returnvalue = -3 --- Future Date but customers registered
			return
		END
	END
	

	BEGIN TRAN

--		UPDATE TblEventCustomers set EventPackageID = 0 where EventID =  @eventID and (AppointmentID is null or NoShow = 1)
--		IF @@ERROR <>0 
--		BEGIN
--			SET @returnvalue=-1
--			ROLLBACK TRAN
--			RETURN
--		END

		DELETE from TblHostEventDetails where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
		
		DELETE from TblEventPackageTest where EventPackageId in (select EventPackageId from TblEventPackageDetails where EventID = @eventID)
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
		DELETE from TblEventPackageDetails where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE from TblEventAppointment where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE from TblEventPod where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE from TblEventStaffAssignment where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE from TblEventPublication where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE from TblEventHostPromotions where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		DELETE FROM TblEventAccount where EventID=@eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
		DELETE FROM TblEventHospitalPartner where EventID=@eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
		UPDATE TblEvents set IsActive = 0 where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END

		delete from TblEventCoupons where EventID = @eventID
		IF @@ERROR <>0 
		BEGIN
			SET @returnvalue=-1
			ROLLBACK TRAN
			RETURN
		END
		
	COMMIT TRAN	

END


GO


