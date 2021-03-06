USE [$(dbName)]
Go
/****** Object:  StoredProcedure [dbo].[usp_notificationGetPhone]    Script Date: 10/18/2012 18:29:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO





-- =============================================    
-- Author  : Viranjay Singh    
-- Create date : 26-11-2008    
-- Description : to get all phone notifications    
-- Name   : exec usp_NotificationGetPhone 0    
-- Parameter : None    
--=============================================    
ALTER PROCEDURE [dbo].[usp_notificationGetPhone]    
(@NotificationTypeID bigint=0)    
AS  
BEGIN     
 ------------- Begin Update Duplicate Records ----------------------------------------------------------    
  UPDATE TblNotificationPhone set ServicedBy=0     
  where PhoneNotificationID IN    
  (    
	  SELECT PhoneNotificationID FROM     
	  (    
		  SELECT      
		  TNP.PhoneNotificationID NotificationPhoneID,    
		  ROW_NUMBER() OVER(PARTITION BY TNT.NotificationTypeName,    
		  TU.FirstName + ' '  + isnull(TU.MiddleName,' ') +   ' ' + TU.LastName     
		  order by TNT.NotificationTypeName) as seq     
		  FROM    
		  TblNotification TN inner join TblNotificationPhone TNP on TN.NotificationID=TNP.PhoneNotificationID    
		  inner join TblNotificationType TNT on TNT.NotificationTypeID=TN.NotificationTypeID    
		  inner join Tbluser TU on TU.UserId=TN.UserId    
		  inner join vw_Customers TC on TC.userId=TN.UserId    
		  where TN.UserId > 0 and (not TN.UserId is null) and ServicedBy is null      
	  ) CALLREPDASHBOARD WHERE Seq > 1     
  )  
   
 ------------- End Update Duplicate Records ----------------------------------------------------------  
 
 ------------- Begin Declare and insert records ------------------------------------------------------

		DECLARE @CallQueue TABLE
		(
			CustomerID bigint,NotificationPhoneID bigint,NotificationId bigint, NotificationDate DateTime, 
			NotificationTypeName varchar(255), [Name] varchar(255),PhoneOffice varchar(50),PhoneCell varchar(50),PhoneHome varchar(50),
			DeadLine datetime,UserId bigint,ProspectCustomerID bigint,Source nvarchar(200),Tag nvarchar(200),[PriorityOrder] INT,
			SalesRep varchar(500), SalesRepId bigint
		)
 
		INSERT INTO @CallQueue 
		(
			CustomerID,NotificationPhoneID,NotificationId, NotificationDate, NotificationTypeName,[Name],
			PhoneOffice,PhoneCell,PhoneHome,DeadLine,UserId,ProspectCustomerID,Source,Tag,[PriorityOrder],
			SalesRep, SalesRepId
		)
 ------------ End Declare and insert records ------------------------------------------------------
		SELECT TOP 15 * FROM
		(
		/****** The query is to get online Prospect Customer*************/ 
		------------- Begin Retrive records -----------------------------------------------------------------  
		SELECT   
			IsNULL(TC.CustomerID,0) as CustomerID,  
			TNP.PhoneNotificationID NotificationPhoneID,     
			TN.NotificationId,   
			TN.NotificationDate,   
			TNT.NotificationTypeName,  
			CASE WHEN TU.UserId is not null and TU.UserId!=0 THEN   
			TU.FirstName + ' '  + isnull(TU.MiddleName,' ') +   ' ' + TU.LastName  
			ELSE TPC.FirstName + ' ' + TPC.LastName END as [Name],  
			isnull(TNP.PhoneOffice,'') as PhoneOffice,    
			isnull(TNP.PhoneCell,'') as PhoneCell,    
			isnull(TNP.PhoneHome,'') as PhoneHome,    
			TNP.DeadLine,     
			IsNULL(TU.UserId,0) as UserId,  
			TPCN.ProspectCustomerID,  
			ISNULL(TPC.Source,'Online') AS Source,
			ISNULL(TPC.[Tag],'') AS Tag,
			2 AS [PriorityOrder],
			'' as SalesRep,
			0 as SalesRepId
		FROM    
		TblNotificationPhone TNP   
			inner join TblNotification TN on TN.NotificationID=TNP.PhoneNotificationID    
			inner join TblNotificationType TNT on TNT.NotificationTypeID=TN.NotificationTypeID  
			Inner join TblProspectCustomerNotification TPCN on TN.NotificationID = TPCN.NotificationId
			Inner join TblProspectCustomer TPC on TPC.ProspectCustomerID=TPCN.ProspectCustomerID  
			LEFT OUTER JOIN Tbluser TU on TU.UserId=TN.UserId  
			LEFT OUTER JOIN vw_Customers TC on TC.userId=TN.UserId    
		where  ((TC.CustomerID IS NULL) OR TC.CustomerID not in (select customerid from tbleventcustomers))
			and ServicedBy is null     
			--and TNT.EscalateToPhone=1   
			AND tpc.[DateCreated] >'2009-06-03 21:00:00.000' AND ISNULL(TPC.[Tag],'') <>'WellnessSeminar'
			AND TN.NotificationDate < Convert(DateTime, Convert(varchar, getdate() + 1, 101))
		------------------------ this is done as per Yasir instruction----  
		
		UNION
		/****** The query is to get Seminar Prospect Customer*************/
		SELECT 
			IsNULL(TC.CustomerID,0) as CustomerID,  
			TNP.PhoneNotificationID NotificationPhoneID,     
			TN.NotificationId,
			TN.NotificationDate,     
			TNT.NotificationTypeName,  
			CASE WHEN TU.UserId is not null and TU.UserId!=0 THEN   
			TU.FirstName + ' '  + isnull(TU.MiddleName,' ') +   ' ' + TU.LastName  
			ELSE TPC.FirstName + ' ' + TPC.LastName END as [Name],  
			isnull(TNP.PhoneOffice,'') as PhoneOffice,    
			isnull(TNP.PhoneCell,'') as PhoneCell,    
			isnull(TNP.PhoneHome,'') as PhoneHome,    
			TNP.DeadLine,     
			IsNULL(TU.UserId,0) as UserId,  
			TPCN.ProspectCustomerID,  
			--TC.CustomerID,
			ISNULL(TPC.Source,'') AS Source,
			ISNULL(TPC.[Tag],'') AS Tag,
			1 AS [PriorityOrder],
			isnull(vw_SeminarSR.SalesRep, '') SalesRep,
			isnull(vw_SeminarSR.SalesRepId, 0) SalesRepId
		FROM    
		TblNotificationPhone TNP   
		inner join TblNotification TN on TN.NotificationID=TNP.PhoneNotificationID    
		inner join TblNotificationType TNT on TNT.NotificationTypeID=TN.NotificationTypeID
		inner join TblProspectCustomerNotification TPCN on TN.NotificationID = TPCN.NotificationId  
		inner join TblProspectCustomer TPC on TPC.ProspectCustomerID=TPCN.ProspectCustomerID  
		left outer join (Select distinct rtrim(ltrim(TU.FirstName)) + (Case when len(isnull(middlename, '')) > 0 then  ' ' + middlename + ' ' else ' ' end) + ltrim(rtrim(TU.LastName)) as SalesRep,
				TS.OrgRoleUserId SalesRepId, TAC.PromoCodeId from TblAFCampaign TAC inner join TblSeminarCampaignDetails TSCD
				on TAC.CampaignId = TSCD.CampaignId inner join TblSeminars TS on TS.SeminarId = TSCD.SeminarId
				inner join TblOrganizationRoleUser TORU ON TS.OrgRoleUserId = TORU.OrganizationRoleUserId
				inner join TblUser TU on TU.UserId = TORU.UserId) as vw_SeminarSR
			On TPC.SourceCodeId = vw_SeminarSR.PromoCodeId
		LEFT OUTER JOIN Tbluser TU on TU.UserId=TN.UserId  
		LEFT OUTER JOIN vw_Customers TC on TC.userId=TN.UserId    
		where ((TC.CustomerID IS NULL) OR TC.CustomerID not in (select customerid from tbleventcustomers))
		and ServicedBy is null     
		--and TNT.EscalateToPhone=1   
		AND tpc.[DateCreated] >'2009-06-03 21:00:00.000'   
		------------------------ this is done as per Yasir instruction----  
		AND TPC.[SourceCodeID] IN 
		(
			SELECT [PromoCodeID] FROM [TblSeminars] TS
			INNER JOIN [TblEvents] TE ON TS.[EventID] = TE.[EventID]
			INNER JOIN [TblSeminarCampaignDetails] TSCD ON TS.[SeminarID] = TSCD.[SeminarID]
			INNER JOIN [tblAFCampaign] TAC ON TSCD.[CampaignID] = TAC.[CampaignID]
			--WHERE TS.[SeminarDate]<Cast(convert(VARCHAR,GETDATE(),101)AS DATETIME)
				 	
		)
		AND TPC.[DateCreated] <=getdate() AND ISNULL(TPC.[Tag],'')='WellnessSeminar'
		AND TN.NotificationDate < GETDATE()
	) tbl ORDER BY [PriorityOrder] --DeadLine DESC 

	------------- End Retrive records ----------------------------------------------------------------- 
	DECLARE @WellnessProspectcount INT
	SELECT @WellnessProspectcount=COUNT(*) FROM @CallQueue WHERE [PriorityOrder]=1
	IF(@WellnessProspectcount=15 OR @WellnessProspectcount=0)
	BEGIN
		SELECT TOP 5 * FROM @CallQueue ORDER BY NEWID()
	END
	ELSE IF(@WellnessProspectcount<15 AND @WellnessProspectcount>=5)
	BEGIN
		SELECT TOP 5 * FROM @CallQueue WHERE [PriorityOrder]=1 ORDER BY NEWID()
	END
	ELSE IF(@WellnessProspectcount<5 AND @WellnessProspectcount>0)
	BEGIN
		SELECT * FROM 
		(
			SELECT TOP 5 *FROM @CallQueue 
		)FinalQueue ORDER BY NEWID()
	END
	
END




