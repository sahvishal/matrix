using System.Collections.Generic;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Sales.Domain;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IFluVaccinationConsentService
    {
        FluVaccinationConsentViewModel GetFluVaccinationConsentViewModel(long eventId, long customerId);
        FluVaccinationConsentViewModel GetFluVaccinationConsentViewModel(Event eventData, Customer customer, Host host, IEnumerable<FluConsentQuestion> questions, IEnumerable<FluConsentAnswer> answers, FluConsentSignature signature,
            IEnumerable<File> signatureFiles);
    }
}