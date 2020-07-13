USE [$(dbname)]
GO

ALTER TABLE TblHealthPlanCriteriaAssignment
ADD DateCreated DATETIME NULL,
	CreatedBy BIGINT NULL,
	DateModified DATETIME NULL,
	ModifiedBy BIGINT NULL,
	CONSTRAINT FK_TblHealthPlanCriteriaAssignment_TblOrganizationRoleUser_CreatedBy FOREIGN KEY([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId]),
	CONSTRAINT FK_TblHealthPlanCriteriaAssignment_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY([ModifiedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])

GO


ALTER TABLE TblHealthPlanCriteriaTeamAssignment
ADD DateCreated DATETIME NULL,
	CreatedBy BIGINT NULL,
	DateModified DATETIME NULL,
	ModifiedBy BIGINT NULL,
	CONSTRAINT FK_TblHealthPlanCriteriaTeamAssignment_TblOrganizationRoleUser_CreatedBy FOREIGN KEY([CreatedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId]),
	CONSTRAINT FK_TblHealthPlanCriteriaTeamAssignment_TblOrganizationRoleUser_ModifiedBy FOREIGN KEY([ModifiedBy]) REFERENCES [TblOrganizationRoleUser]([OrganizationRoleUserId])

GO