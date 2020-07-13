using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.ViewModels;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorEarningFactory
    {
        MedicalVendorEarning CreateMedicalVendorEarning(MedicalVendorEarningAggregate 
            medicalVendorEarningAggregate, long dataRecorderCreatorId, DateTime dateCreated);
    }
}