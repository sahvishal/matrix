using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface ILoincLabDataRepository
    {
        void Save(LoincLabData domain);
        IEnumerable<LoincLabData> GetByMemberId(string memberid);
        IEnumerable<LoincLabData> GetByGmpi(string gmpi);
    }
}
