USE[$(dbName)]

GO
IF Exists(select * from sysobjects where xtype='D' and [NAME]='DF_TblEventCustomers_IsGiftCertificateDelivered' and parent_obj = OBJECT_ID('TblEventCustomers'))
BEGIN
	ALTER TABLE TblEventCustomers
	DROP CONSTRAINT [DF_TblEventCustomers_IsGiftCertificateDelivered]
END

GO
Alter TABLE TblEventCustomers
ALTER COLUMN IsGiftCertificateDelivered bit null

GO
UPDATE TblEventCustomers
SET IsGiftCertificateDelivered=NULL
where IsGiftCertificateDelivered=0

GO