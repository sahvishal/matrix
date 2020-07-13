USE [$(dbName)]
GO

INSERT INTO  TblExitInterviewQuestion ([Id], [Question], [TypeId], [Gender], [ParentId], [ControlValues], [ControlValueDelimiter], [Index])
VALUES (1, 'All Pre-approved tests are completed', 322, 44, NULL, 'True,False', ',', 1)

INSERT INTO  TblExitInterviewQuestion ([Id], [Question], [TypeId], [Gender], [ParentId], [ControlValues], [ControlValueDelimiter], [Index])
VALUES (2, 'Ensure in CHAT, all clinically indicated tests were ordered in HIP', 322, 44, NULL, 'True,False', ',', 2)

INSERT INTO  TblExitInterviewQuestion ([Id], [Question], [TypeId], [Gender], [ParentId], [ControlValues], [ControlValueDelimiter], [Index])
VALUES (3, 'For critical members, all the documents and directions were given to patient?', 322, 44, NULL, 'True,False', ',', 3)

INSERT INTO  TblExitInterviewQuestion ([Id], [Question], [TypeId], [Gender], [ParentId], [ControlValues], [ControlValueDelimiter], [Index])
VALUES (4, 'Gift Card provided to customer and consent form is signed?', 322, 44, NULL, 'True,False', ',', 4)

GO