USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getprospectsdetailByProspectlistID]    Script Date: 03/07/2013 13:47:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================          
-- Author:  Viranjay singh
-- Create date: 26-Mar-2009
-- Description: To Get prospect details by prospectlist id
-- Name: [usp_getprospectsdetailByProspectlistID]
-- Example : usp_getprospectsdetailByProspectlistID 138,1
-- =============================================          
ALTER PROCEDURE [dbo].[usp_getprospectsdetailByProspectlistID]
(          
	@ProspectListID BigInt,
	@mode int,
	@PageSize INT=10,
	@PageIndex INT=1,
	@SortColumn VARCHAR(255)=NULL,
	@SortOrder VARCHAR(10)=NULL,
	@assignedTo BIGINT
)          
AS
BEGIN      
-- Get Prospect Details By ProspectList ID
Declare @strquery nvarchar(4000)
IF (LEN(@SortColumn) <= 0)
SET @SortColumn = ' DateModified '
DECLARE @FirstRec int, @LastRec int  
SET  @FirstRec = (@PageIndex  - 1) * @PageSize  
SET  @LastRec  = (@PageIndex * @PageSize) 

set @strquery=''

IF (@mode=1) 
BEGIN
	-- Sort column 
	IF(len(@SortColumn) > 0)
	BEGIN
			IF (@SortColumn='ContactName') 
			SET @SortColumn='ContactFirstName ' + @SortOrder + ', ' + 'ContactLastName '
	END
	set @strquery ='
	select *from 
	(
		Select ROW_NUMBER() OVER (ORDER BY DateModified DESC) AS RowNumber,* FROM Dv_Prospects where prospectlistid=' + CAST (@ProspectListID  AS VARCHAR) + 
	')DvProspect ' + 'where 1=1 '
	IF (@assignedTo > 0)
	BEGIN
		set @strquery = @strquery + ' and SalesRepID=' + cast(@assignedTo as varchar)
	END
	set @strquery = @strquery + 'and RowNumber between ' +  Cast(@FirstRec+1 as varchar) + ' and ' + CAST(@LastRec as varchar) 
	set @strquery = @strquery + ' ORDER BY ' + @SortColumn
	-- Sort Order
	IF(len(@SortOrder) > 0)
	BEGIN
			set @strquery = @strquery +  ' ' + @SortOrder
	END	
    Execute(@strquery)
	print (@strquery)
	IF (@assignedTo > 0)
	BEGIN
		SELECT COUNT(ProspectId) AS TotalRecord FROM Dv_Prospects where prospectlistid=@ProspectListID and SalesRepID=@assignedTo
	END
	ELSE
	BEGIN
		SELECT COUNT(ProspectId) AS TotalRecord FROM Dv_Prospects where prospectlistid=@ProspectListID
	END
END 
END
