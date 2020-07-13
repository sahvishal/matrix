using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Scheduling.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IPatientInputFileService
    {
        IEnumerable<PatientInputFileViewModel> GetPatientFileInputByEvent(Event eventData, string tag);
    }
}