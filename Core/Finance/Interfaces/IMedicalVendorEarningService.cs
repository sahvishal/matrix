using System;
using Falcon.App.Core.Finance.Domain;

namespace Falcon.App.Core.Finance.Interfaces
{
    public interface IMedicalVendorEarningService
    {
        MedicalVendorEarning GenerateMedicalVendorEarning(long physicianId, long customerEventTestId, DateTime dateCreated, bool isEventCustomerActive);
    }
}