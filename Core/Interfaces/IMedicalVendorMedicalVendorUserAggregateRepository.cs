using System.Collections.Generic;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;

namespace Falcon.App.Core.Interfaces
{
    public interface IMedicalVendorMedicalVendorUserAggregateRepository
    {
        List<MedicalVendorMedicalVendorUserAggregate> GetMedicalVendorMedicalVendorUserAggregates(long medicalVendorId);
    }
}