Use [$(dbName)]

GO

Alter Table TblMergeCustomerUpload Add LogFileId Bigint NULL
GO

Alter Table TblMergeCustomerUpload
Add Constraint FK_TblMergeCustomerUpload_TblFile_LogFileId Foreign Key ([LogFileId])
References [TblFile](FileId)

GO
