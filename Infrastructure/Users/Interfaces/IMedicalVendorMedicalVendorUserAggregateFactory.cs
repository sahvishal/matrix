using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Domain.MedicalVendors.ViewData;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IMedicalVendorMedicalVendorUserAggregateFactory
    {
        List<MedicalVendorMedicalVendorUserAggregate> CreateMedicalVendorMedicalVendorUserAggregates
            (List<MedicalVendorMedicalVendorUser> medicalVendorMedicalVendorUsers,
            MedicalVendorMvuserEarningAndPayRateTypedView medicalVendorMedicalVendorUserEarningAndPayRateView,
            MedicalVendorMvuserPaymentTypedView medicalVendorMedicalVendorUserPaymentView);
        
        MedicalVendorMedicalVendorUserAggregate CreateMedicalVendorMedicalVendorUserAggregate
            (MedicalVendorMedicalVendorUser medicalVendorMedicalVendorUser,
            MedicalVendorMvuserEarningAndPayRateTypedView medicalVendorMedicalVendorUserEarningAndPayRateView,
            MedicalVendorMvuserPaymentTypedView medicalVendorMedicalVendorUserPaymentView);
    }
}