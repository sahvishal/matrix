using System.Collections.Generic;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Finance.Interfaces
{
    public interface IMedicalVendorEarningCustomerAggregateFactory
    {
        List<MedicalVendorEarningCustomerAggregate> CreateMedicalVendorEarningAggregates(MedicalVendorEarningCustomerTypedView 
            medicalVendorEarningCustomerTypedView);

        MedicalVendorEarningCustomerAggregate CreateMedicalVendorEarningAggregate(MedicalVendorEarningCustomerRow medicalVendorEarningCustomerRow);
    }
}