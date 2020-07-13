using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Core.Scheduling.ViewModels;
using Falcon.App.Core.Users;

namespace Falcon.App.Infrastructure.Users.Impl
{
    [DefaultImplementation]
    public class CustomerRegistrationHelper : ICustomerRegistrationHelper
    {
        private readonly INdcRepository _ndcRepository;

        public CustomerRegistrationHelper(INdcRepository ndcRepository)
        {
            _ndcRepository = ndcRepository;
        }

        public List<OrderedPair<long, string>> PrepareNdcPairs(CorporateCustomerEditModel model)
        {
            var ndcMedicationSourcePairs = new List<OrderedPair<long, string>>();
            if (model.CurrentMedication != null && model.CurrentMedication.Any())
            {
                var pairs = _ndcRepository.GetByNdcCode(model.CurrentMedication);

                int counter = 0;
                var sources = model.CurrentMedicationSource.ToArray();
                foreach (var medicine in model.CurrentMedication)
                {
                    var topmost = (from p in pairs where p.NdcCode.ToLower() == medicine select p).FirstOrDefault();

                    if (topmost != null)
                    {
                        //ndcIds.Add(topmost.Id);
                        if (model.CurrentMedicationSource != null &&
                            model.CurrentMedicationSource.Count() == model.CurrentMedication.Count())
                        {
                            var ndcMedicationSourcePair = new OrderedPair<long, string>(topmost.Id, sources[counter]);
                            ndcMedicationSourcePairs.Add(ndcMedicationSourcePair);
                        }
                        else
                        {
                            var ndcMedicationSourcePair = new OrderedPair<long, string>(topmost.Id, "");
                            ndcMedicationSourcePairs.Add(ndcMedicationSourcePair);
                        }
                    }

                    counter++;
                }
                return ndcMedicationSourcePairs;
            }
            return null;
        }
    }
}
