using System.Collections.Generic;
using Falcon.App.Core.OutboundReport.Domain;

namespace Falcon.App.Core.OutboundReport
{
    public interface ILoincCrosswalkRepository
    {
        void Save(LoincCrosswalk domain);
        IEnumerable<LoincCrosswalk> GetByLoincNumber(string memberId);
    }
}
