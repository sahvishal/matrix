USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_CheckDuplicateEventRegistration]    Script Date: 04/17/2012 11:21:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Ashutosh Kumar>
-- Create date: <July 23,2008>
-- Description:	<Checks for a event on same day at same host>
-- =============================================
ALTER PROCEDURE [dbo].[usp_CheckDuplicateEventRegistration]
	-- Add the parameters for the stored procedure here
	(@HostId bigint, @EventDate varchar(20))
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	select TE.EventName,TE.EventDate, TP.OrganizationName
	from TblEventS TE 
	inner join TblHostEventDetails THED ON THED.EventID=TE.EventID
	inner join TblProspects TP ON TP.ProspectID=THED.HostID
	where TP.[ProspectID]=@HostId
		and Convert(varchar(20),TE.EventDate,101)=Convert(varchar(20),@EventDate,101)
		and TE.EventStatus=1
END
