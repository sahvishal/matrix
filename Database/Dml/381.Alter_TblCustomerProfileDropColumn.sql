use [$(dbname)]
go

Alter Table TblCustomerProfile  Drop constraint DF_TblCustomerProfile_IsMailingList
Alter Table TblCustomerProfile  Drop constraint DF_TblCustomerProfile_IsDirectMail
Alter Table TblCustomerProfile  Drop constraint DF_TblCustomerProfile_IsSpecialOffer
Alter Table TblCustomerProfile  Drop constraint DF_TblCustomerProfile_AdvocateID
Alter Table TblCustomerprofile Drop constraint DF_TblCustomerProfile_IsDuplicate

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'_dta_stat_962102468_15_1_8')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[_dta_stat_962102468_15_1_8]
END

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_IsDirMail_CustId_IsIncPh_IsLanBar_DNCRId_Tag')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_IsDirMail_CustId_IsIncPh_IsLanBar_DNCRId_Tag]
END

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_IDM_CId_IIPN_IsLangBarr_IsElig_DNCTId')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_IDM_CId_IIPN_IsLangBarr_IsElig_DNCTId]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_Dire_CId_Elig_DNCT_Acti')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_Dire_CId_Elig_DNCT_Acti]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_CId_Elig_Lang_DNCT_Acti')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_CId_Elig_Lang_DNCT_Acti]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_Dire_CId_Elig_Incorr_Lang_DNCT_Acti')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_Dire_CId_Elig_Incorr_Lang_DNCT_Acti]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_CallDate_CustId_IsEl_DNCTypeId_ActId')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_CallDate_CustId_IsEl_DNCTypeId_ActId]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_CallDate_CustId_IsEl_IsLB_DNCTypeId_ActId')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_CallDate_CustId_IsEl_IsLB_DNCTypeId_ActId]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_CallDate_CustId_IsEl_IsIPN_IsLB_DNCTypeId_ActId')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_CallDate_CustId_IsEl_IsIPN_IsLB_DNCTypeId_ActId]
END

go

IF EXISTS (select * from sys.stats where object_id = object_id(N'[dbo].[TblCustomerProfile]')  and name = N'STAT_TblCustomerProfile_IsDir_IsLang_CId')
BEGIN
	DROP STATISTICS [dbo].[TblCustomerProfile].[STAT_TblCustomerProfile_IsDir_IsLang_CId]
END

go

Alter Table TblCustomerProfile 
	Drop Column
			ContactMethod, CollectionMode, 
			IsMailingList, IsDirectMail, IsSpecialOffer,
			AdvocateID, UserDefined1,
			SignInSource, IsDuplicate
Go