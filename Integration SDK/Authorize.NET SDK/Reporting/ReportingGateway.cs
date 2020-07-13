using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AuthorizeNet.APICore;

namespace AuthorizeNet {
    /// <summary>
    /// The gateway for requesting Reports from Authorize.Net
    /// </summary>
    public class ReportingGateway : IReportingGateway {
    
        HttpXmlUtility _gateway;

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGateway"/> class.
        /// </summary>
        /// <param name="apiLogin">The API login.</param>
        /// <param name="transactionKey">The transaction key.</param>
        /// <param name="mode">Test or Live.</param>
        public ReportingGateway(string apiLogin, string transactionKey, ServiceMode mode) {
            
            if (mode == ServiceMode.Live) {
                _gateway = new HttpXmlUtility(ServiceMode.Live, apiLogin, transactionKey);
            } else {
                _gateway = new HttpXmlUtility(ServiceMode.Test, apiLogin, transactionKey);
            }
        }
    
        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerGateway"/> class.
        /// </summary>
        /// <param name="apiLogin">The API login.</param>
        /// <param name="transactionKey">The transaction key.</param>
        public ReportingGateway(string apiLogin, string transactionKey) : this(apiLogin, transactionKey, ServiceMode.Test) { }
        
        /// <summary>
        /// Returns all Settled Batches for the last 30 days
        /// </summary>
        public List<Batch> GetSettledBatchList() {
            var from = DateTime.Today.AddDays(-30);
            var to = DateTime.Today;
            return GetSettledBatchList(from, to);
        }

        /// <summary>
        /// Returns batch settlements for the specified date range
        /// </summary>
        public List<Batch> GetSettledBatchList(DateTime from, DateTime to) {
            var req = new getSettledBatchListRequest();
            req.firstSettlementDate = from;
            req.lastSettlementDate = to;
            req.includeStatistics = true;
            var response = (getSettledBatchListResponse)_gateway.Send(req);

            return Batch.NewFromResponse(response);
        }

        /// <summary>
        /// Returns all transaction within a particular batch
        /// </summary>
        public List<Transaction> GetTransactionList(string batchId) {
            var req = new getTransactionListRequest();
            req.batchId = batchId;
            var response = (getTransactionListResponse)_gateway.Send(req);
            return Transaction.NewListFromResponse(response.transactions);
        }
        /// <summary>
        /// Returns Transaction details for a given transaction ID (transid)
        /// </summary>
        /// <param name="transactionID"></param>
        public Transaction GetTransactionDetails(string transactionID){
            var req = new getTransactionDetailsRequest();
            req.transId = transactionID;
            var response = (getTransactionDetailsResponse) _gateway.Send(req);
            return Transaction.NewFromResponse(response.transaction);
        }

        /// <summary>
        /// Returns all transactions for the last 30 days
        /// </summary>
        /// <returns></returns>
        public List<Transaction> GetTransactionList() {
            return GetTransactionList(DateTime.Today.AddDays(-30), DateTime.Today);

        }

        /// <summary>
        /// Returns all transactions for a given time period. This can result in a number of calls to the API
        /// </summary>
        public List<Transaction> GetTransactionList(DateTime from, DateTime to) {

            var batches = GetSettledBatchList(from, to);
            var result = new List<Transaction>();
            foreach (var batch in batches) {
                result.AddRange(GetTransactionList(batch.ID.ToString()));
            }
            return result;
        } 

    }
}
