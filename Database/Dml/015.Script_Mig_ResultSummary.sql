
USE [$(dbName)]
Go

update TblCustomerEventTestState set TestSummary = Case when Y.IsCritical = 1 And X.SelfPresent = 1 then 104
														when Y.IsCritical = 1 then 133														
														else TestSummary end
from TblCustomerEventTestState X inner join TblCustomerEventTestPhysicianEvaluation Y on X.CustomerEventScreeningTestId = Y.CustomerEventScreeningTestId
where X.TestSummary <> (Case when Y.IsCritical = 1 And X.SelfPresent = 1 then 104 when Y.IsCritical = 1 then 133 else TestSummary end)

----------------------------------------------

Update TblEventCustomerResult Set ResultSummary = (case when b_tbl.Max_Summary = 4 then 104 
		when b_tbl.Max_Summary = 3 then 133 
		when b_tbl.Max_Summary = 2 then 103
		else 102 end)
from TblEventCustomerResult a_tbl
inner join (
Select T1.*, T2.EventDate from(
select a.EventCustomerResultId, EventId, CustomerId, MAX(TestSummary) Max_Summary, Case when ResultSummary = 104 then 4
														when ResultSummary = 133 then 3
														when ResultSummary = 103 then 2
														else 1 end as  ResultSummary from TblEventCustomerResult A 
inner join TblCustomerEventScreeningTests B on A.EventCustomerResultId = B.EventCustomerResultId
inner join (select X.CustomerEventScreeningTestId, Case when Y.IsCritical = 1 And X.SelfPresent = 1 then 4
														when Y.IsCritical = 1 then 3
														when X.TestSummary = 104 then 4
														when X.TestSummary = 133 then 3
														when X.TestSummary = 103 then 2
														else 1 end as testsummary from TblCustomerEventTestState X 
				left outer join TblCustomerEventTestPhysicianEvaluation Y on X.CustomerEventScreeningTestId = Y.CustomerEventScreeningTestId) 
c on b.CustomerEventScreeningTestID = c.CustomerEventScreeningTestId
where a.ResultState between 5 and 7
group by a.EventCustomerResultId, EventId, CustomerId, ResultSummary) T1 
inner join TblEvents T2 on T1.EventID = T2.EventID
where Max_Summary <> ResultSummary ) b_tbl on a_tbl.EventCustomerResultId = b_tbl.EventCustomerResultId