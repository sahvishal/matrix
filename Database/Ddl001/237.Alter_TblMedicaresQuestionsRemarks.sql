USE [$(dbName)]
Go

ALTER TABLE [TblMedicareQuestionsRemarks]

  ALTER column  [QuestionValue] varchar(20) not null;
  
ALTER TABLE [TblMedicareQuestionsRemarks]
			
	ALTER column [DependentQuestionValue] varchar(20) null;
	
ALTER TABLE [TblMedicareQuestionsRemarks]
			
	ALTER column [CombinedQuestionValue] varchar(20) null;	
	
Alter TABLE TblMedicareQuestion
	Add IsDefault bit NOT NULL default 0;
	
