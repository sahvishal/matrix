use [$(dbName)]
go

Create Table TblHealthPlanCriteriaDirectMail
(
	CriteriaId bigint NOT NULL,
	CampaignActivityId bigint NOT NULL,
	CONSTRAINT PK_TblHealthPlanCriteriaDirectMail PRIMARY KEY(CriteriaId, CampaignActivityId),
	CONSTRAINT FK_TblHealthPlanCriteriaDirectMail_TblHealthPlanCallQueueCriteria FOREIGN KEY ([CriteriaId]) REFERENCES [TblHealthPlanCallQueueCriteria]([Id]),
	CONSTRAINT FK_TblHealthPlanCriteriaDirectMail_TblCampaignActivity FOREIGN KEY ([CampaignActivityId]) REFERENCES [TblCampaignActivity]([Id])
)