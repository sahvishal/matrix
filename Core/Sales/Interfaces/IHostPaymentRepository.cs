using System;
using System.Collections.Generic;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Interfaces
{
    public interface IHostPaymentRepository
    {
        HostPayment GetById(long eventId);
        HostPayment Save(HostPayment hostPayment);
        bool UpdateHostPaymentStatusAndNotes(long hostPaymentId, decimal amount, int hostPaymentStatus);
        List<HostPayment> GetByFilters(long? eventId, DateTime? dueStartDate, DateTime? dueEndDate,
                                       HostPaymentStatus? hostPaymentStatus);

        HostPayment GetHostPaymentById(long hostPaymentId);
    }
}
