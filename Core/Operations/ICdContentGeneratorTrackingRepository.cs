using System;
using System.Collections.Generic;
using Falcon.App.Core.Operations.Domain;

namespace Falcon.App.Core.Operations
{
    public interface ICdContentGeneratorTrackingRepository
    {
        CdContentGeneratorTracking Save(CdContentGeneratorTracking cdContentGeneratorTracking);
        bool IsCdContentGenerated(long eventId, long customerId);
        bool IsCdContentGenerated(IList<long> eventCustomerIds);

        IEnumerable<CdContentGeneratorTracking> GetCdContentGeneratedforEventCustomerIds(IEnumerable<long> eventCustomerIds);
        CdContentGeneratorTracking Get(long id);
        IEnumerable<long> GetCdContentGeneratedEventIds(IEnumerable<long> eventIds);
        bool UpdateCdContentDownloadedinfo(long eventId, long downloadedByOrgRoleUserId);
        IEnumerable<CdContentGeneratorTracking> GetCdContentGeneratedforCleanUp(DateTime dateTo);
        void Delete(long cdContentGenratedTrackingId);
        CdContentGeneratorTracking GetByEventIdAndCustomerId(long eventId, long customerId);
    }
}
