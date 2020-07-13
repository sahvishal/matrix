using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostDeositRepository 
    {
        HostDeposit GetById(long eventId);
        HostDeposit Save(HostDeposit hostDeposit);
        List<HostDeposit> GetByFilters(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate,
                                       HostPaymentStatus? hostPaymentStatus);

        HostDeposit GetByHostDepositById(long hostDepositId);
    }
}