USE [$(dbName)]

GO

INSERT INTO TblLookupType
(Alias,DisplayName,[Description],DateCreated)
VALUES
('AgentTeamType' , 'Agent Team Type','Used to Categorize call center agent teams',GETDATE())

Declare @lookupTypeId bigint

SELECT @lookupTypeId = LookupTypeId from TblLookupType where alias = 'AgentTeamType'

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(353,@lookupTypeId ,'Inbound','Inbound','Team Type inbound',1,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(354,@lookupTypeId ,'Outbound','Outbound','Team Type outbound',2,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(355,@lookupTypeId ,'Confirmation','Confirmation','Team Type Confirmation',3,GETDATE(),1,1)

INSERT INTO TblLookup
(LookupId,LookupTypeId,Alias,DisplayName,[Description],RelativeOrder,DateCreated,DataRecorderCreatorID,IsActive)
VALUES
(356,@lookupTypeId ,'HRA','HRA','Team Type HRA',1,GETDATE(),4,1)

GO