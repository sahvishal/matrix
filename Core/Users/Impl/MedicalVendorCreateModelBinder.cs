using Falcon.App.Core.Geo.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.Users.ViewModels;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Users.Impl
{
    public class MedicalVendorCreateModelBinder
    {
        public MedicalVendor ToDomain(MedicalVendorEditModel model)
        {
            var binder = new OrganizationCreateModelBinder();
            var medicalVendor = new MedicalVendor();
            medicalVendor = binder.ToDomain(medicalVendor, model) as MedicalVendor;
            medicalVendor.MedicalVendorType = model.MedicalVendorType;
            medicalVendor.ContractId = model.ContractId;
            medicalVendor.IsHospitalPartner = model.IsHospitalPartner;
            //medicalVendor.PaymentInstructionId = model.PaymentInstructions.Id;
            //medicalVendor.EvaluationMode = model.EvaluationMode;
            return medicalVendor;
        }

        public MedicalVendorEditModel ToModel(MedicalVendor organization, AddressEditModel billingAddress, AddressEditModel businessAddress, File logoImage, File teamImage, PaymentInstructions instructions,
                                                    TestPayRate[] payRates, decimal customerPayRate, TestType[] permitted)
        {
            var binder = new OrganizationCreateModelBinder();
            var model = new MedicalVendorEditModel();

            model = binder.ToModel(model, organization, billingAddress, businessAddress, logoImage, teamImage) as MedicalVendorEditModel;

            model.ContractId = organization.ContractId;
            model.MedicalVendorType = organization.MedicalVendorType;
            model.IsHospitalPartner = organization.IsHospitalPartner;
            //model.CustomerPayRate = customerPayRate;
            //model.EvaluationMode = organization.EvaluationMode;
            //model.PaymentInstructions = instructions;
            //model.PermittedTests = permitted;
            //model.TestPayRates = payRates;
            return model;
        }

    }
}
