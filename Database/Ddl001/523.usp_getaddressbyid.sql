
USE [$(dbName)]
GO
/****** Object:  StoredProcedure [dbo].[usp_getaddressbyid]    Script Date: 2/28/2017 5:14:23 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



-- =============================================
-- Author:		Nitin Tikkha
-- Create date: 19-11-2007
-- Description:	To get the Address detail
-- Name: usp_getaddressbyidcity
-- Parameter:	Input (mode "1->Rows by addressID")
--=============================================

ALTER PROCEDURE [dbo].[usp_getaddressbyid]( @mode tinyint, @filterstring varchar(500) ) 
	
AS
BEGIN 
	/*if(@mode = 0)
	BEGIN
		----
	END
	
	Else*/
	 if(@mode = 1)
	BEGIN
		
		select AddressID, Address1, Address2,TC.CityID,TC.Name as City,TS.StateID,
			   TS.Name as State,TCO.CountryID,TCO.Name as Country,	TZ.ZipCode, TZ.ZipID
				from TblAddress TA WITH (NOLOCK)
		  inner join tblCity	TC WITH (NOLOCK)	on TA.CityID=TC.CityID
		  inner join tblZip		TZ WITH (NOLOCK)	on TA.ZipID= TZ.ZipID
		  inner join tblState	TS WITH (NOLOCK)	on TA.StateID= TS.StateID
		  inner join tblCountry	TCO WITH (NOLOCK)	on TA.CountryID=TCO.CountryID
			where  TA.AddressID = @filterstring 
	END
	
	else if(@mode = 0)
	BEGIN
		
		select AddressID, Address1, Address2,TC.CityID,TC.Name as CityName,TS.StateID,
			   TS.Name as StateName ,TCO.CountryID,TCO.Name as CountryName ,	TZ.ZipCode, TZ.ZipID
				from TblAddress TA WITH (NOLOCK) 
		  inner join tblCity	TC WITH (NOLOCK)	on TA.CityID=TC.CityID
		  inner join tblZip		TZ WITH (NOLOCK)	on TA.ZipID= TZ.ZipID
		  inner join tblState	TS WITH (NOLOCK)	on TA.StateID= TS.StateID
		  inner join tblCountry	TCO	 WITH (NOLOCK) on TA.CountryID=TCO.CountryID
			where  TA.AddressID = @filterstring 
	END
	
	

END



	/* SET NOCOUNT ON */ 
	RETURN


