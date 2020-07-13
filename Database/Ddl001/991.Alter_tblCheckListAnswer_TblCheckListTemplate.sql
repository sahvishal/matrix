 USE [$(dbname)]
 GO
 
ALTER TABLE TblCheckListAnswer ADD [Type]  bigint null

ALTER TABLE TblCheckListTemplate ADD [Type]  bigint null


ALTER TABLE TblCheckListAnswer ADD CONSTRAINT FK_CheckListAnswer_LookupId FOREIGN KEY([Type]) REFERENCES TblLookup(LookupId);
ALTER TABLE TblCheckListTemplate ADD CONSTRAINT FK_CheckListTemplate_LookupId FOREIGN KEY([Type]) REFERENCES TblLookup(LookupId);