﻿using System.Collections.Generic;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.ViewModels;

namespace Falcon.App.Core.Scheduling
{
    public interface IEventCancellationModelFactory
    {
        EventCancellationListModel Create(IEnumerable<Event> events);
    }
}
