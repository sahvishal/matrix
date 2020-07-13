
USE [$(dbname)]
GO

    UPDATE TblAccount SET AcesClientShortName='BCBSFLM',ClientId='192' WHERE AccountID=1040 AND Tag='FL Blue'

	UPDATE TblAccount SET AcesClientShortName='CRABCBSFLM',ClientId='193' WHERE AccountID=1062 AND Tag='fl blue com'
	
	UPDATE TblAccount SET AcesClientShortName='QVMBCBSFLM',ClientId='194' WHERE AccountID=1076 AND Tag='Fl blue mammo'
	
	UPDATE TblAccount SET AcesClientShortName='QVBCBSFLM',ClientId='195' WHERE AccountID=1112 AND Tag='Fl blue gaps'

	UPDATE TblAccount SET AcesClientShortName='WELLMEDM',ClientId='196' WHERE AccountID=1003 AND Tag='WellMed'
	UPDATE TblAccount SET AcesClientShortName='WELLMEDM',ClientId='196' WHERE AccountID=1004 AND Tag='WellMed - Texas'

	UPDATE TblAccount SET AcesClientShortName='OPTUMNVM',ClientId='197' WHERE AccountID=1061 AND Tag='Optum NV'
	UPDATE TblAccount SET AcesClientShortName='OPTUMUTM',ClientId='198' WHERE AccountID=1014 AND Tag='Optum-UT'
	UPDATE TblAccount SET AcesClientShortName='OPTUMAZM',ClientId='199' WHERE AccountID=1047 AND Tag='Optum-AZ'
	
	UPDATE TblAccount SET AcesClientShortName='EXCELLUSM',ClientId='200' WHERE AccountID=1066 AND Tag='excellus'
	
	UPDATE TblAccount SET AcesClientShortName='MARTINPM',ClientId='201' WHERE AccountID=1037 AND Tag='Martins Point'
	
	UPDATE TblAccount SET AcesClientShortName='QVBCBSALM',ClientId='202' WHERE AccountID=1079 AND Tag='BCBS AL'
		
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1085 AND Tag='UHC AL'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1087 AND Tag='uhc az'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1093 AND Tag='UHC CT'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1082 AND Tag='UHC FL'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1094 AND Tag='uhc ga'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1086 AND Tag='UHC OH'
	UPDATE TblAccount SET AcesClientShortName='UNITEDM',ClientId='203' WHERE AccountID=1083 AND Tag='UHC TX'


	--Without ClientId's
	UPDATE TblAccount SET AcesClientShortName='BCBSSC' WHERE AccountID=1044 AND Tag='BCBS SC'

	UPDATE TblAccount SET AcesClientShortName='CTCAREM' WHERE AccountID=1063 AND Tag='Connecticare'

	UPDATE TblAccount SET AcesClientShortName='BCBSMIM' WHERE AccountID=1043 AND Tag='BCBS Michigan'