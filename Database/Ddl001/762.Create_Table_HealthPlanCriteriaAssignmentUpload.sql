Use [$(dbName)]

GO

CREATE TABLE TblHealthPlanCriteriaAssignmentUpload
(
Id bigint IDENTITY (1, 1) NOT NULL, 
FileId bigint NOT NULL,
UploadTime datetime NOT NULL,
UploadedByOrgRoleUserId bigint Not Null,
CriteriaId bigint Not Null
)

GO

Alter Table TblHealthPlanCriteriaAssignmentUpload
Add Constraint PK_TblHealthPlanCriteriaAssignmentUpload PRIMARY KEY CLUSTERED(Id)
WITH( STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]

GO

Alter Table TblHealthPlanCriteriaAssignmentUpload
Add Constraint FK_TblHealthPlanCriteriaAssignmentUpload_TblFile_FileId Foreign Key ([FileId])
References [TblFile](FileId)

GO

Alter Table TblHealthPlanCriteriaAssignmentUpload
Add Constraint FK_TblHealthPlanCriteriaAssignmentUpload_TblOrganizationRoleUser_UploadedByOrgRoleUserId 
Foreign Key ([UploadedByOrgRoleUserId])
References [TblOrganizationRoleUser](OrganizationRoleUserID)

GO

Alter Table TblHealthPlanCriteriaAssignmentUpload
Add Constraint FK_TblHealthPlanCriteriaAssignmentUpload_TblHealthPlanCallQueueCriteria_CriteriaId
Foreign Key ([CriteriaId])
References [TblHealthPlanCallQueueCriteria](Id)

GO