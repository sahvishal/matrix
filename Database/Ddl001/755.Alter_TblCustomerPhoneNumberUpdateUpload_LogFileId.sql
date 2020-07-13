USE [$(dbName)]

GO

ALTER TABLE TblCustomerPhoneNumberUpdateUpload
ADD LogFileId bigint Null

GO

Alter Table TblCustomerPhoneNumberUpdateUpload
Add Constraint FK_TblCustomerPhoneNumberUpdateUpload_TblFile_LogFileId Foreign Key ([LogFileId])
References [TblFile](FileId)

GO