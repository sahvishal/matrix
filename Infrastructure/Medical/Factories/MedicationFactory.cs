using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medicare.ViewModels;
using System.Collections.Generic;
using Falcon.App.Core.Extensions;
using System;
using System.Linq;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class MedicationFactory : IMedicationFactory
    {
        public IEnumerable<Medication> CreateModel(IEnumerable<MedicationEditModel> viewModels, long customerId)
        {
            if (viewModels.IsNullOrEmpty()) return null;

            return viewModels.Select(x => new Medication
            {
                Id = x.Id,
                CustomerId = customerId,
                ProprietaryName = x.ProprietaryName,
                ServiceDate = x.ServiceDate,
                Dose = x.Dose,
                Unit = x.Unit,
                Frequency = x.Frequency,
                IsPrescribed = x.IsPrescribed,
                IsOtc = x.IsOtc,
                Indication = x.Indication,
                IsManual = true,
                IsSynced = false,
                IsActive = true,
            });
        }

        public IEnumerable<MedicationEditModel> CreateViewModel(IEnumerable<Medication> models)
        {
            return models.Select(x => new MedicationEditModel
            {
                CustomerId = x.CustomerId,
                Dose = x.Dose,
                Frequency = x.Frequency,
                Hicn = x.Hicn,
                Id = x.Id,
                Indication = x.Indication,
                IsOtc = x.IsOtc,
                IsPrescribed = x.IsPrescribed,
                MemberDob = x.MemberDob,
                MemberId = x.MemberId,
                NdcProductCode = x.NdcProductCode,
                ProprietaryName = x.ProprietaryName,
                ServiceDate = x.ServiceDate,
                Unit = x.Unit,
            });
        }
    }
}
