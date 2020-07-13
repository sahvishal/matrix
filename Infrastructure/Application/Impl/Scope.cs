using System.Transactions;
using Falcon.App.Core.Application;

namespace Falcon.App.Infrastructure.Application.Impl
{
    public class Scope : ITransactionScope
    {
        private readonly TransactionScope _scope = new TransactionScope();

        public void Complete()
        {
            _scope.Complete();
        }

        public void Dispose()
        {
            _scope.Dispose();
        }
    }
}