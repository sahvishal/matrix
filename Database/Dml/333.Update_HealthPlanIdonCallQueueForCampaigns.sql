use [$(dbName)]
go

update hpcqc set HealthPlanId=c.AccountId  from TblHealthPlanCallQueueCriteria hpcqc  join TblCampaign c on hpcqc.CampaignId = c.Id