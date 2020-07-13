using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Operations.Domain;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface IResultArchiveParser
    {
        IEnumerable<ResultArchiveLog> ResultArchiveLogs { get; }
        IEnumerable<EventCustomerScreeningAggregate> Parse();
    }
}