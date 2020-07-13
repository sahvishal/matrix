Use [$(dbName)]

GO

CREATE TABLE TblMergeCustomerUpload
(
Id bigint IDENTITY (1, 1) NOT NULL, 
FileId bigint NOT NULL,
StatusId bigint NOT NULL, 
UploadedBy bigint Not Null,
UploadTime datetime NOT NULL,
SuccessUploadCount bigint NOT NULL, 
FailedUploadCount bigint NOT NULL,  
ParseStartTime datetime Null, 
ParseEndTime datetime Null
)

GO

Alter Table TblMergeCustomerUpload
Add Constraint PK_TblMergeCustomerUpload PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblMergeCustomerUpload
Add Constraint FK_TblMergeCustomerUpload_TblFile_FileId Foreign Key ([FileId])
References [TblFile](FileId)

GO

Alter Table TblMergeCustomerUpload
Add Constraint FK_TblMergeCustomerUpload_TblLookup_StatusId Foreign Key ([StatusId])
References [TblLookup](LookupId)

GO

Alter Table TblMergeCustomerUpload
Add Constraint FK_TblMergeCustomerUpload_TblOrganizationRoleUser_UploadedBy
Foreign Key ([UploadedBy])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

CREATE TABLE TblMergeCustomerUploadLog
(
Id bigint IDENTITY (1,1) NOT NULL, 
UploadId bigint NOT NULL,
CustomerId bigint NOT NULL, 
DuplicateCustomerId varchar(256),
StatusId bigint NOT NULL, 
IsSuccessful bit NOT NULL,
ErrorMessage nvarchar(2048)
)

GO

Alter Table TblMergeCustomerUploadLog
Add Constraint DF_TblMergeCustomerUploadLog_IsSuccessful
Default 0 for [IsSuccessful]

GO

Alter Table TblMergeCustomerUploadLog
Add Constraint PK_TblMergeCustomerUploadLog PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblMergeCustomerUploadLog
Add Constraint FK_TblMergeCustomerUploadLog_TblMergeCustomerUpload_UploadId Foreign Key ([UploadId])
References [TblMergeCustomerUpload](Id)
GO

Alter Table TblMergeCustomerUploadLog
Add Constraint FK_TblMergeCustomerUploadLog_TblLookup_StatusId Foreign Key ([StatusId])
References [TblLookup](LookupId)

GO

