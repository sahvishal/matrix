USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_GetProspectLists]    Script Date: 03/07/2013 17:58:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


-------------------------------------------------------------------------------------------------------------------------

-- =============================================
-- Author: Viranjay Singh
-- Create date: 24 Mar,09
-- Description:	To get prospect list data in the table
-- Name: usp_GetProspectLists
-- Example usp_GetProspectLists '','','','','','',0,0,'2'
--=================================================
ALTER PROCEDURE [dbo].[usp_GetProspectLists]
(
	@ListName varchar(500)=NULL,
	@ListSource varchar(500)=NULL,
	@UploadedStartDate varchar(20)=NULL,
	@UploadedEndDate varchar(20)=NULL,
	@UploadedBy varchar(50)=NULL,
	@Status varchar(50)=NULL,
	@mode TINYINT,
	@ProspectListId BIGINT=NULL,	
	@RoleID Int=NULL
)
AS
BEGIN
	Declare @strquery varchar(4000)
	SET @strquery=''
	DECLARE @RoleID1 INT
	DECLARE @USERID BIGINT
IF (@mode=0)
BEGIN
	SET @strquery='		
		SELECT 
		PLD.ProspectFileId ProspectListID,
		ISNULL(PLD.FileName,'''') FileName,
		ISNULL(PLD.ListName,'''') ListName,
		ISNULL(PLD.ListSource,'''') ListSource,
		ISNULL(PLD.ListType,'''') ListType,
		PLD.[DateCreated],
		ISNULL(P.NoOfProspects,0) NoOfProspects,
		ISNULL(TPFR.NoOfProspectsFailure,0) NoOfProspectsFailure,
		CASE 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NULL) THEN 1 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NOT NULL) THEN 2 
		WHEN P.NoOfProspects IS NULL AND TPFR.NoOfProspectsFailure IS NULL THEN 3 END AS Status,
		ISNULL(TU.FirstName + '' '' + TU.LastName,'''') UserName,
		ISNULL(TblRole.NAME,'''') [ROLE],
		ISNULL(PLD.FileSize,0) FileSize,
		ISNULL(PLD.UploadTime,'''') UploadTime		
		FROM TblProspectListDetails PLD
		LEFT OUTER JOIN 
		(
			SELECT COUNT(ProspectListID) "NoOfProspects",MAX(ProspectListID) "ProspectListID" FROM TblProspects GROUP BY ProspectListID
		) P	ON PLD.ProspectFileID = P.ProspectListID
		LEFT OUTER JOIN
		(
			SELECT COUNT(ProspectListID) "NoOfProspectsFailure",MAX(ProspectListID) "ProspectListID"  FROM [TblProspectFaliureReport] GROUP BY ProspectListID
		) TPFR ON TPFR.ProspectListID = P.ProspectListID 
		Left Outer Join TblOrganizationRoleUser TORU on TORU.OrganizationroleUserId = PLD.AddedBy 
		Inner JOIN TblUser TU ON TU.[UserID]=TORU.UserId
		LEFT OUTER JOIN TblRole On TblRole.RoleId=PLD.RoleID
		WHERE PLD.IsActive=1 '
	-- Check For ListName
	IF(@ListName!='' AND LEN(@ListName)>0)
	BEGIN
		SET @ListName= '%'+ @ListName + '%' 
		SET @strquery = @strquery + ' AND PLD.ListName like ' + '''' +  @ListName + ''''
	END
	
	-- Check For ListSource
	IF(@ListSource!='' AND LEN(@ListSource)>0)
	BEGIN
		SET @ListSource =  '%'+ @ListSource + '%' 
		SET @strquery = @strquery + ' AND PLD.ListSource like ' + '''' + @ListSource + ''''
	END
	
	-- Check For Uploaded start date and Uploaded end date
	IF(@UploadedStartDate!='' AND LEN(@UploadedStartDate)>0 AND @UploadedEndDate!='' AND LEN(@UploadedEndDate)>0)
	BEGIN
		
		SET @strquery=@strquery + ' AND convert(datetime,convert(VARCHAR(10),PLD.DateCreated,101),101) >= Convert(DateTime,'+''''+@UploadedStartDate+''''+',101)
        AND convert(datetime,convert(VARCHAR(10),PLD.DateCreated,101),101) <=Convert(DateTime,'+''''+@UploadedEndDate+''''+',101)'
	END
	
	-- Check For UploadedBy
	IF(@UploadedBy!='' AND LEN(@UploadedBy)>0 AND (@ProspectListId <=0))
	BEGIN
		
			SELECT @RoleID1=RoleID FROM [TblRole] WHERE [NAME]='FranchiseeAdmin'
			SELECT @USERID=UserID  FROM TblFranchiseeUser WHERE FranchiseeUserID
			=(SELECT TOP 1 FranchiseeUserID   FROM TblFranchiseefranchiseeUser WHERE roleid=@RoleID1 AND IsDefault=1 AND [FranchiseeID]=@UploadedBy)	
			SET @strquery = @strquery + ' AND PLD.AddedBy=' + CAST(@USERID AS VARCHAR) + ' AND PLD.RoleID=' + CAST(@RoleID1 AS VARCHAR)
			SET @strquery = @strquery + ' OR FranchiseeID=' + @UploadedBy
	END
	ELSE IF (LEN(@UploadedBy)>0 AND @ProspectListId > 0 AND @RoleID > 0)
	BEGIN
		SET @strquery = @strquery + ' AND PLD.AddedBy=' + CAST(@ProspectListId AS VARCHAR)
		SET @strquery = @strquery + ' AND PLD.RoleId=' + CAST(@RoleId AS VARCHAR)
		SET @strquery = @strquery + ' OR PLD.FranchiseeID=' + @UploadedBy
	END	
	-- Check For Status
	IF(@Status!='' AND LEN(@Status)>0 AND LTRIM(RTRIM(@Status))!='0')
	BEGIN
		SET @strquery = 'SELECT *FROM( '  + @strquery +  ') DvProspectList WHERE Status=' + @Status
		--SET @strquery = @strquery + ' AND Status='+ @Status
	END	 
	-- 
	
	
	SET @strquery = @strquery + ' ORDER BY [DateCreated] Desc'
	-- Execute Query
	PRINT @strquery
	EXECUTE (@strquery)
END	
ELSE IF (@mode=1)
BEGIN
	SELECT 
		PLD.ProspectFileId ProspectListID,
		ISNULL(PLD.FileName,'') FileName,
		ISNULL(PLD.ListName,'') ListName,
		ISNULL(PLD.ListSource,'') ListSource,
		ISNULL(PLD.ListType,'') ListType,
		PLD.[DateCreated],
		ISNULL(P.NoOfProspects,0) NoOfProspects,
		ISNULL(TPFR.NoOfProspectsFailure,0) NoOfProspectsFailure,
		CASE 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NULL) THEN 1 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NOT NULL) THEN 2 
		WHEN P.NoOfProspects IS NULL AND TPFR.NoOfProspectsFailure IS NULL THEN 3 END AS Status,
		ISNULL(TU.FirstName + ' ' + TU.LastName,'') UserName,
		ISNULL(TblRole.NAME,'') [ROLE],
		ISNULL(PLD.FileSize,0) FileSize,
		ISNULL(PLD.LOG_LIST,'') LOG_LIST,
		ISNULL(PLD.UploadTime,'') UploadTime
		FROM TblProspectListDetails PLD
		LEFT OUTER JOIN 
		(
			SELECT COUNT(ProspectListID) "NoOfProspects",MAX(ProspectListID) "ProspectListID" FROM TblProspects GROUP BY ProspectListID
		) P	ON PLD.ProspectFileID = P.ProspectListID
		LEFT OUTER JOIN
		(
			SELECT COUNT(ProspectListID) "NoOfProspectsFailure",MAX(ProspectListID) "ProspectListID"  FROM [TblProspectFaliureReport] GROUP BY ProspectListID
		) TPFR ON TPFR.ProspectListID = P.ProspectListID 
		Left Outer Join TblOrganizationRoleUser TORU on TORU.OrganizationroleUserId = PLD.AddedBy 
		Inner JOIN TblUser TU ON TU.[UserID]=TORU.UserId
		LEFT OUTER JOIN TblRole On TblRole.RoleId=PLD.RoleID
		WHERE PLD.IsActive=1  AND PLD.[ProspectFileID] = @ProspectListId
END
ELSE IF (@mode=2)
BEGIN
	SELECT 
		PLD.ProspectFileId ProspectListID,
		ISNULL(PLD.FileName,'') FileName,
		ISNULL(PLD.ListName,'') ListName,
		ISNULL(PLD.ListSource,'') ListSource,
		ISNULL(PLD.ListType,'') ListType,
		PLD.[DateCreated],
		ISNULL(P.NoOfProspects,0) NoOfProspects,
		ISNULL(TPFR.NoOfProspectsFailure,0) NoOfProspectsFailure,
		CASE 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NULL) THEN 1 
		WHEN (P.NoOfProspects IS NOT NULL) AND (TPFR.NoOfProspectsFailure IS NOT NULL) THEN 2 
		WHEN P.NoOfProspects IS NULL AND TPFR.NoOfProspectsFailure IS NULL THEN 3 END AS Status,
		ISNULL(TU.FirstName + ' ' + TU.LastName,'') UserName,
		ISNULL(TblRole.NAME,'') [ROLE],
		ISNULL(PLD.FileSize,0) FileSize,
		ISNULL(PLD.LOG_LIST,'') LOG_LIST,
		ISNULL(PLD.UploadTime,'') UploadTime
		FROM TblProspectListDetails PLD
		LEFT OUTER JOIN 
		(
			SELECT COUNT(ProspectListID) "NoOfProspects",MAX(ProspectListID) "ProspectListID" FROM [TblProspectCustomer] GROUP BY ProspectListID HAVING 
			ProspectListID > 0
		) P	ON PLD.ProspectFileID = P.ProspectListID
		LEFT OUTER JOIN
		(
			SELECT COUNT(ProspectListID) "NoOfProspectsFailure",MAX(ProspectListID) "ProspectListID"  FROM [TblProspectFaliureReport] GROUP BY ProspectListID
		) TPFR ON TPFR.ProspectListID = P.ProspectListID 
		Left Outer Join TblOrganizationRoleUser TORU on TORU.OrganizationroleUserId = PLD.AddedBy 
		Inner JOIN TblUser TU ON TU.[UserID]=TORU.UserId
		LEFT OUTER JOIN TblRole On TblRole.RoleId=PLD.RoleID
		WHERE PLD.IsActive=1  AND PLD.[ProspectFileID] = @ProspectListId
END

END

