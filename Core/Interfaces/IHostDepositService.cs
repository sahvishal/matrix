using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Enum;
using Falcon.App.Core.Sales.ViewModels;

namespace Falcon.App.Core.Interfaces
{
    public interface IHostDepositService
    {
        List<EventHostDepositViewData> GetHostDepositsByFilters(long? eventId, DateTime? dueStartDate,
                                                               DateTime? dueEndDate,
                                                               HostPaymentStatus? hostPaymentStatus, bool? isDeposit, int pageNumber, int pageSize, out long totalRecord
                                                               );

    }
}