using System;
namespace AuthorizeNet {
    public interface IReportingGateway {
        System.Collections.Generic.List<AuthorizeNet.Batch> GetSettledBatchList(DateTime from, DateTime to);
        System.Collections.Generic.List<AuthorizeNet.Batch> GetSettledBatchList();
        AuthorizeNet.Transaction GetTransactionDetails(string transactionID);
        System.Collections.Generic.List<AuthorizeNet.Transaction> GetTransactionList(DateTime from, DateTime to);
        System.Collections.Generic.List<AuthorizeNet.Transaction> GetTransactionList();
        System.Collections.Generic.List<AuthorizeNet.Transaction> GetTransactionList(string batchId);
    }
}
