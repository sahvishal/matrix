using System.Collections.Generic;
using Falcon.App.Core.Domain;
using Falcon.Data.EntityClasses;
using Falcon.Data.TypedViewClasses;

namespace Falcon.App.Infrastructure.Users.Interfaces
{
    public interface IMedicalVendorMedicalVendorUserFactory
    {
        MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(MedicalVendorInvoiceItemRow medicalVendorInvoiceItemRow);
        MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(long medicalVendorMedicalVendorUserId, UserEntity userEntity);
        MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(long medicalVendorMedicalVendorUserId,
            string firstName, string middleName, string lastName);
        MedicalVendorMedicalVendorUser CreateMedicalVendorMedicalVendorUser(MedicalVendorMedicalVendorUserRow 
            medicalVendorMedicalVendorUserRow);
        List<MedicalVendorMedicalVendorUser> CreateMedicalVendorMedicalVendorUsers
            (MedicalVendorMedicalVendorUserTypedView medicalVendorMedicalVendorUserTypedView);
    }
}