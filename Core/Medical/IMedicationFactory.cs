using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare.ViewModels;
using System;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical
{
    public interface IMedicationFactory
    {
        IEnumerable<Medication> CreateModel(IEnumerable<MedicationEditModel> viewModels, long customerId);

        IEnumerable<MedicationEditModel> CreateViewModel(IEnumerable<Medication> models);
    }
}
