using System.Collections.Generic;
using Falcon.App.Core.Interfaces;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Scheduling
{
    public interface IMyBioCheckAssessmentJsonHelper
    {
        void GenerateJsonforEventCustomers(Event eventData, ILogger logger);
        void GenerateJsonforEventCustomers(Event eventData, IEnumerable<EventCustomer> eventCusomters, ILogger logger);
    }
}