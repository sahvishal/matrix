USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getvieweventForHostDetails]    Script Date: 6/14/2019 11:13:41 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Abhinav Goel
-- Create date: 27-12-2007
-- Description:	To get the detail of the event for a sales rep
-- Name: [usp_getuserevent]
-- Parameter:	Input (mode "0->All rows,1->Rows by eventID,",name,dbid)
-- =============================================
ALTER PROCEDURE [dbo].[usp_getvieweventForHostDetails] 
(
	@filterstring varchar(200),
	@mode int=1,
	@userid bigint,
	@roleid bigint,
	@shellid bigint,
	@SortColumn VARCHAR(255)=NULL,
	@SortOrder VARCHAR(10)=NULL,
	@PageSize INT=10,
	@PageIndex INT=1
	
)
AS
BEGIN

Declare @query nvarchar(max)
Declare @query1 nvarchar(max)
Declare @query2 nvarchar(max)
Declare @queryTotal nvarchar(max)
declare @HostZipId bigint
declare @HostZipCode bigint
declare @Distance varchar(100)
---------------------------------------------------------
-- set start and end row
DECLARE @FirstRec int, @LastRec int  
SET  @FirstRec = (@PageIndex  - 1) * @PageSize  
SET  @LastRec  = (@PageIndex * @PageSize) 

---------------------------------------------------------
-- set default sort column
IF (LEN(@SortColumn) <= 0)
SET @SortColumn = ' EventDate '
ELSE SET @SortColumn = ' ' + @SortColumn + ' '
-- set default sort order
IF (LEN(@SortOrder) <= 0)
SET @SortOrder= ' DESC '
ELSE SET @SortOrder = ' ' + @SortOrder + ' '
---------------------------------------------------------
set @query=''
set @query1=''
set @query2=''

		-- Get ZipId Host
		select @HostZipCode=TZ.ZipCode,@HostZipId=TZ.ZipId from TblProspects TP
		INNER JOIN dbo.TblAddress TA ON TA.AddRessID=TP.AddressID
		INNER JOIN dbo.TblCity TC ON TA.CityID = TC.CityID
		INNER JOIN dbo.TblState TS ON TA.StateID=TS.StateID
		INNER JOIN dbo.TblZip TZ ON TA.ZipID=TZ.ZipID
		where TP.ProspectId=@filterstring			
		-- Get Distance for event within X Miles
		select @Distance=[value] from [TblGlobalConfiguration] where [Name]='HostEventDistance'

IF (@mode =1)
BEGIN
		-- Events on Host
		set @query = '
		SELECT 
		ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,
		TblEvents.EventID,
		EventName,
		TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName Host,
		count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,	
		isnull(TblEvents.EventStatus,1) EventStatus,1 ''HostEventType''
		from TblEvents WITH (NOLOCK)
		left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
		inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
		inner join tblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
		left outer join TblEventCustomers WITH (NOLOCK) on TblEventCustomers.EventID = TblEvents.EventID
		where TblEvents.IsActive=1 and TblHostEventDetails.HostID=' + isnull(@filterstring,'') + 
		'group by TblEvents.EventID, 
		EventName,
		TblEvents.AssignedToOrgRoleUserId,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName,
		TblEventPod.EventID,TblEvents.EventStatus'
		set @queryTotal = 'SELECT Count(EventId) as TotalRecord FROM ( ' + @query + ' )DvEvents'
		set @query = 'SELECT * FROM (  ' + @query + ' )DvEvents WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
		--print @query
		Execute(@query + @queryTotal)
		
END
ELSE IF (@mode =2)
BEGIN
--------------------------------------------------------------------------------
--Events on Host Zip
---------------------------------------------------------------------------------
		set @query = '
		SELECT 
		ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,		
		TblEvents.EventID,
		EventName,
		TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName Host,
		count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
		isnull(TblEvents.EventStatus,1) EventStatus,2 ''HostEventType''
		from TblEvents WITH (NOLOCK)
		left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
		inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
		inner join TblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
		INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddRessID=TblProspects.AddressID
		left outer join TblEventCustomers on TblEventCustomers.EventID = TblEvents.EventID
		where TblEvents.IsActive=1 and TA.ZipId=' + cast(isnull(@HostZipId,'') as varchar) + 'and TblHostEventDetails.HostID!='+ @filterstring + 
		'group by TblEvents.EventID, 
		EventName,
		TblEvents.AssignedToOrgRoleUserId,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName,
		TblEventPod.EventID,TblEvents.EventStatus'
		set @queryTotal = 'SELECT Count(EventId) as TotalRecord FROM ( ' + @query + ' )DvEvents'
		set @query = 'SELECT * FROM (  ' + @query + ' )DvEvents WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
		--print @query
		Execute(@query + @queryTotal)
		
END
ELSE IF (@mode =3)
BEGIN
---------------------------------------------------------------------------------
--Events on Host X miles Distance
---------------------------------------------------------------------------------
		set @query = '
		SELECT 
		ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,		
		TblEvents.EventID,
		EventName,
		TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName Host,
		count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
		isnull(TblEvents.EventStatus,1) EventStatus,3 ''HostEventType''
		from TblEvents WITH (NOLOCK)
		left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
		inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
		inner join TblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
		INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddRessID=TblProspects.AddressID
		left outer join TblEventCustomers WITH (NOLOCK) on TblEventCustomers.EventID = TblEvents.EventID
		where TblEvents.IsActive=1 and TA.ZipId in ( select DestinationZipId from TblZipRadiusDistance where SourceZipId = '+ CONVERT( varchar(10),@HostZipId) +' and Radius <= '  +  CONVERT( varchar(10),@Distance) + ')
		and TblHostEventDetails.HostID!=' + @filterstring + 
		'group by TblEvents.EventID, 
		EventName,
		TblEvents.AssignedToOrgRoleUserId,
		EventDate,		
		TblEvents.IsActive,
		tblProspects.ProspectID,
		tblProspects.OrganizationName,
		TblEventPod.EventID,TblEvents.EventStatus'
		set @queryTotal = 'SELECT Count(EventId) as TotalRecord FROM ( ' + @query + ' )DvEvents'
		set @query = 'SELECT * FROM (  ' + @query + ' )DvEvents WHERE Row between ' + Cast(isnull(@FirstRec+1,'') as varchar) + ' and ' + CAST(isnull(@LastRec,'') as varchar)
		--print @query
		Execute(@query + @queryTotal)
END
-- All Record
ELSE IF (@mode =4)
BEGIN
	-- Events on Host
		set @query = '
			SELECT 
			ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,	
			TblEvents.EventID,
			EventName,
			TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName Host,
			count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
			isnull(TblEvents.EventStatus,1) EventStatus,
			1 ''HostEventType''
			from TblEvents WITH (NOLOCK)
			left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
			inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
			inner join tblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
			left outer join TblEventCustomers WITH (NOLOCK) on TblEventCustomers.EventID = TblEvents.EventID
			where TblEvents.IsActive=1 and TblHostEventDetails.HostID=' + isnull(@filterstring,'') + 
			'group by TblEvents.EventID, 
			EventName,
			TblEvents.AssignedToOrgRoleUserId,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName,
			TblEventPod.EventID,TblEvents.EventStatus ' 
			
			--Events on Host Zip
			---------------------------------------------------------------------------------
			-- Get Events	
			set @query1 = '
			SELECT 
			ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,	
			TblEvents.EventID,
			EventName,
			TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName Host,
			count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
			isnull(TblEvents.EventStatus,1) EventStatus,2 ''HostEventType''
			from TblEvents WITH (NOLOCK)
			left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
			inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
			inner join TblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
			INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddRessID=TblProspects.AddressID			
			left outer join TblEventCustomers WITH (NOLOCK) on TblEventCustomers.EventID = TblEvents.EventID
			where TblEvents.IsActive=1 and TA.ZipId=' + cast(isnull(@HostZipId,'') as varchar) + 'and TblHostEventDetails.HostID!=' + @filterstring + 
			'group by TblEvents.EventID, 
			EventName,
			TblEvents.AssignedToOrgRoleUserId,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName,
			TblEventPod.EventID,TblEvents.EventStatus'
			
			---------------------------------------------------------------------------------
			--Events on Host X miles Distance
			---------------------------------------------------------------------------------
			--set @query2 = '	
			--SELECT 
			--ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,	
			--TblEvents.EventID,
			--EventName,
			--TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
			--EventDate,			
			--TblEvents.IsActive,
			--tblProspects.ProspectID,
			--tblProspects.OrganizationName Host,
			--count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
			--isnull(TblEvents.EventStatus,1) EventStatus,3 ''HostEventType''
			--from TblEvents WITH (NOLOCK)
			--left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
			--inner join TblHostEventDetails WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
			--inner join TblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
			--INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddRessID=TblProspects.AddressID			
			--left outer join TblEventCustomers on TblEventCustomers.EventID = TblEvents.EventID
			--where TblEvents.IsActive=1 and TA.ZipId in (select zipid from dbo.fn_getzips(' + '''' + cast(isnull(@HostZipCode,'') as varchar) + '''' + ',' + @Distance + '))
			--and TblHostEventDetails.HostID!=' + isnull(@filterstring,'') + 
			--'group by TblEvents.EventID, 
			--EventName,
			--TblEvents.AssignedToOrgRoleUserId,
			--EventDate,			
			--TblEvents.IsActive,
			--tblProspects.ProspectID,
			--tblProspects.OrganizationName,
			--TblEventPod.EventID,TblEvents.EventStatus'

			
set @query2 = '	
			SELECT 
			ROW_NUMBER() OVER (ORDER BY ' + @SortColumn +  @SortOrder + ') AS Row,	
			TblEvents.EventID,
			EventName,
			TblEvents.AssignedToOrgRoleUserId AS SalesRepID,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName Host,
			count(TblEventCustomers.EventID) Customer, Case when TblEventPod.EventID is null then 0 else 1 end as IsPodAllocated,
			isnull(TblEvents.EventStatus,1) EventStatus,3 ''HostEventType''
			from TblEvents WITH (NOLOCK)
			left outer join TblEventPod WITH (NOLOCK) on TblEventPod.EventID=TblEvents.EventID and TblEventPod.IsActive = 1
			inner join TblHostEventDetails  WITH (NOLOCK) on TblHostEventDetails.EventID = TblEvents.EventID
			inner join TblProspects WITH (NOLOCK) on tblProspects.ProspectID = TblHostEventDetails.HostID
			INNER JOIN TblAddress TA WITH (NOLOCK) ON TA.AddRessID=TblProspects.AddressID			
			left outer join TblEventCustomers on TblEventCustomers.EventID = TblEvents.EventID
			where TblEvents.IsActive=1 and TA.ZipId in ( select DestinationZipId from TblZipRadiusDistance where SourceZipId = '+ CONVERT( varchar(10),@HostZipId) +' and Radius <= '  +  CONVERT( varchar(10),@Distance) + ')
			and TblHostEventDetails.HostID!=' + isnull(@filterstring,'') + 
			'group by TblEvents.EventID, 
			EventName,
			TblEvents.AssignedToOrgRoleUserId,
			EventDate,			
			TblEvents.IsActive,
			tblProspects.ProspectID,
			tblProspects.OrganizationName,
			TblEventPod.EventID,TblEvents.EventStatus'
			
			set @queryTotal = 'SELECT Count(EventId) as TotalRecord FROM ( ' + @query + ' )DvEvents'
			set @queryTotal = @queryTotal + ' SELECT Count(EventId) as TotalRecordEventsHostZip FROM ( ' + @query1 + ' )DvEvents'
			set @queryTotal = @queryTotal + ' SELECT Count(EventId) as TotalRecordEventsHostZipDistance FROM ( ' + @query2 + ' )DvEvents'

			set @query = 'SELECT * FROM (  ' + @query + ' )DvEvents WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
			set @query1 = 'SELECT * FROM (  ' + @query1 + ' )DvEvents WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
			set @query2 = 'SELECT * FROM (  ' + @query2 + ' )DvEvents WHERE Row between ' + Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
			--print @query
			Execute(@query + ' UNION ALL ' + @query1 + ' UNION ALL ' + @query2)
			--print ('This ' + @query + ' UNION ALL ' + @query1 + ' UNION ALL ' + @query2)
			--print @queryTotal
			execute(@queryTotal)
			
END
END

GO


