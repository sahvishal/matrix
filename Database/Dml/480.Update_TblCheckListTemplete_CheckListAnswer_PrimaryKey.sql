USE [$(dbName)]
GO

UPDATE TblCheckListTemplate set [Type] = 418 

UPDATE TblCheckListAnswer set [Type] = 418

alter table TblCheckListTemplate  alter column [type]  bigint not null
alter table TblCheckListAnswer  alter column [type]  bigint not null

alter table TblCheckListAnswer drop constraint PK_TblCheckListAnswer

ALTER TABLE TblCheckListAnswer ADD CONSTRAINT PK_TblCheckListAnswer primary KEY(EventCustomerId, QuestionId, [Version],[Type]) 