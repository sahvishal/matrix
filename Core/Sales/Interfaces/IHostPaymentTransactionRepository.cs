using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostPaymentTransactionRepository
    {
         List<HostPaymentTransaction> GetById(long eventId);
        HostPaymentTransaction Save(HostPaymentTransaction hostPaymentTransaction);
        void DeleteByIdAndStatus(long hostPaymentId, HostPaymentStatus hostPaymentStatus);
        HostPaymentTransaction GetByIdAndStatus(long hostPaymentId, long hostPaymentStatus);
        bool UpdateHostPaymentTransactionByIdAndStatus(HostPaymentTransaction hostPaymentTransaction); 
    }
}