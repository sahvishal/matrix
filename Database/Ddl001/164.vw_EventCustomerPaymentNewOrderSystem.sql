USE [$(dbName)]
GO

/****** Object:  View [dbo].[vw_EventCustomerPaymentNewOrderSystem]    Script Date: 12/07/2013 17:45:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


ALTER VIEW [dbo].[vw_EventCustomerPaymentNewOrderSystem]    
AS
SELECT TotalPayment, CreditCardPayment, CashPayment,CheckPayment, ECheckPayment, GCPayment,[EventCustomerId],
		LastPayDate,FirstPayDate, InsurancePayment FROM (
			SELECT   (
						ISNULL(CCPayment,0) +	
						ISNULL( CashPayment ,0) +	
						ISNULL( CheckPayment ,0) +
						ISNULL( ECheckPayment ,0) +
						ISNULL( GCPayment ,0) +
						ISNULL (InsurancePayment,0)) TotalPayment,
						ISNULL( CCPayment,0) CreditCardPayment,
						ISNULL( CashPayment ,0) CashPayment,
						ISNULL( CheckPayment ,0) CheckPayment,
						ISNULL( ECheckPayment ,0) ECheckPayment,
						ISNULL( GCPayment ,0) GCPayment,	TEC.[EventCustomerId]
						, LastPayDate, FirstPayDate
						,ISNULL (InsurancePayment,0) InsurancePayment
						
			FROM [TblEventCustomers] TEC WITH (NOLOCK) INNER JOIN (
					SELECT  EventCustomerID, MAX([TblPayment].[DateCreated]) LastPayDate, MIN([TblPayment].[DateCreated])FirstPayDate
					FROM  [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
					INNER JOIN [TblOrderDetail] WITH (NOLOCK) ON TECOD.orderdetailid=[TblOrderDetail].[OrderDetailID]
					INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON [TblOrderDetail].[OrderID] = [TblPaymentOrder].[OrderID]
					INNER JOIN [TblPayment] WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = [TblPayment].[PaymentID]
					WHERE TECOD.Isactive=1
					GROUP BY TECOD.EventCustomerID
					)vw_PaymentSummary ON vw_PaymentSummary.[EventCustomerID]=TEC.[EventCustomerID]

			LEFT OUTER JOIN
			(
				SELECT tblTemp.[EventCustomerID],ISNULL(SUM(TCCP.[Amount]),0)AS CCPayment	FROM 
				(
					SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
						INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
				)tblTemp 
					INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
					INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
					LEFT OUTER JOIN [TblChargeCardPayment] TCCP WITH (NOLOCK) ON  TP.[PaymentID] = TCCP.[PaymentID]
					GROUP BY tblTemp.[EventCustomerID]
				)vw_CCPayment ON vw_CCPayment.[EventCustomerID]=TEC.[EventCustomerID]

			LEFT OUTER JOIN
			(
				SELECT tblTemp.[EventCustomerID],ISNULL(SUM([TblCheck].[Amount]),0) AS CheckPayment	FROM 
				(
					SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
						INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
				)tblTemp 
					INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
					INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
					LEFT OUTER JOIN [TblCheckPayment] WITH (NOLOCK) ON [TblCheckPayment].[PaymentID]=TP.[PaymentID]
					INNER JOIN [TblCheck] WITH (NOLOCK) ON [TblCheck].[CheckID] = [TblCheckPayment].[CheckID]
					GROUP BY tblTemp.[EventCustomerID]
				)vw_CheckPayment ON vw_CheckPayment.[EventCustomerID]=TEC.[EventCustomerID]

			LEFT OUTER JOIN
			(
				SELECT tblTemp.[EventCustomerID],ISNULL(SUM([TblCheck].[Amount]),0) AS ECheckPayment FROM 
				(
					SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
						INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
				)tblTemp 
					INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
					INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
					LEFT OUTER JOIN [TblECheckPayment] WITH (NOLOCK) ON [TblECheckPayment].[PaymentID]=TP.[PaymentID]
					INNER JOIN [TblCheck] WITH (NOLOCK) ON [TblCheck].[CheckID] = [TblECheckPayment].[ECheckID]
					GROUP BY tblTemp.[EventCustomerID]
			)vw_ECheckPayment ON vw_ECheckPayment.[EventCustomerID]=TEC.[EventCustomerID]

			LEFT OUTER JOIN
			(
				SELECT tblTemp.[EventCustomerID],ISNULL(SUM([TblCashPayment].[Amount]),0) AS CashPayment	FROM 
				(
					SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
						INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
				)tblTemp 
					INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
					INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
					LEFT OUTER JOIN [TblCashPayment] WITH (NOLOCK) ON [TblCashPayment].[PaymentID]=TP.[PaymentID]
					GROUP BY tblTemp.[EventCustomerID]
			)vw_CashPayment ON vw_CashPayment.[EventCustomerID]=TEC.[EventCustomerID]

			LEFT OUTER JOIN
				(
					SELECT tblTemp.[EventCustomerID],ISNULL(SUM([TblGiftCertificatePayment].[Amount]),0) AS GCPayment
					FROM 
					(
						SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
							INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
					)tblTemp 
						INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
						INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
						LEFT OUTER JOIN [TblGiftCertificatePayment] WITH (NOLOCK) ON [TblGiftCertificatePayment].[PaymentID]=TP.[PaymentID]
						GROUP BY tblTemp.[EventCustomerID]
				)vw_GCPayment ON vw_GCPayment.[EventCustomerID]=TEC.[EventCustomerID]
				
			LEFT OUTER JOIN
				(
					SELECT tblTemp.[EventCustomerID],ISNULL(SUM([TblInsurancePayment].[Amount]),0) AS InsurancePayment
					FROM 
					(
						SELECT DISTINCT TOD.OrderID, TECOD.[EventCustomerID] FROM [TblEventCustomerOrderDetail] TECOD WITH (NOLOCK)
							INNER JOIN [TblOrderDetail] TOD WITH (NOLOCK) ON TECOD.[OrderDetailID] = TOD.[OrderDetailID]
					)tblTemp 
						INNER JOIN [TblPaymentOrder] WITH (NOLOCK) ON tblTemp.OrderID = [TblPaymentOrder].[OrderID]
						INNER JOIN [TblPayment] TP WITH (NOLOCK) ON [TblPaymentOrder].[PaymentID] = TP.[PaymentID]
						LEFT OUTER JOIN [TblInsurancePayment] WITH (NOLOCK) ON [TblInsurancePayment].[PaymentID]=TP.[PaymentID]
						GROUP BY tblTemp.[EventCustomerID]
				)vw_InsurancePayment ON vw_InsurancePayment.[EventCustomerID]=TEC.[EventCustomerID]

) PaymentDetail

GO


