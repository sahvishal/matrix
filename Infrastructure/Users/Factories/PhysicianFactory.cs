using System.Linq;
using Falcon.App.Core;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Factories
{
    public class PhysicianFactory : IPhysicianFactory
    {
        private readonly IMapper<PhysicianLicense, PhysicianLicenseEntity> _licenseMapper;

        public PhysicianFactory(IMapper<PhysicianLicense, PhysicianLicenseEntity> licenseMapper)
        {
            _licenseMapper = licenseMapper;
        }

        public PhysicianFactory() : this(new PhysicianLicenseMapper()) { }

        // TODO: This Factory needs rethinking .. 
        public Physician CreatePhysician(Physician physician, PhysicianProfileEntity physicianProfile)
        {
            NullArgumentChecker.CheckIfNull(physician, "physician");
            NullArgumentChecker.CheckIfNull(physicianProfile, "PhysicianProfileEntity");

            physician.PhysicianId = physicianProfile.PhysicianId;
            physician.MedicalVendorId = physicianProfile.OrganizationRoleUser.OrganizationId;

            physician.SignatureFile = physicianProfile.DigitalSignatureFileId != null
                                          ? new File(physicianProfile.DigitalSignatureFileId.Value)
                                          : null;

            physician.ResumeFile = physicianProfile.ResumeFileId != null
                                         ? new File(physicianProfile.ResumeFileId.Value)
                                         : null;
            physician.SpecializationId = physicianProfile.SpecializationId.HasValue
                                             ? physicianProfile.SpecializationId.Value
                                             : 0;
            physician.CanSeeEarnings = physicianProfile.ShowEarningAmount;
            physician.CanDoAuthorizations = physicianProfile.IsAuthorizationAllowed;
            physician.SkipAudit = physicianProfile.SkipAudit;
            physician.CutOffDate = physicianProfile.CutOffDate;

            if (!physicianProfile.PhysicianPermittedTest.IsNullOrEmpty())
                physician.PermittedTests =
                    physicianProfile.PhysicianPermittedTest.ToList().Select(test => test.TestId).ToList();

            if (!physicianProfile.PhysicianLicense.IsNullOrEmpty())
            {
                physician.AuthorizedStateLicenses =
                    _licenseMapper.MapMultiple(physicianProfile.PhysicianLicense).ToList();
            }

            if (!physicianProfile.PhysicianPod.IsNullOrEmpty())
                physician.AssignedPodIds =
                    physicianProfile.PhysicianPod.ToList().Select(tpr => tpr.PodId).ToList();

            if (physicianProfile.PhysicianCustomerPayRate != null)
            {
                physician.StandardRate = physicianProfile.PhysicianCustomerPayRate.StandardRate;
                physician.OverReadRate = physicianProfile.PhysicianCustomerPayRate.OverReadRate;
            }
            physician.IsDefault = physicianProfile.IsDefaultPhysician;
            physician.DisplayName = physicianProfile.DisplayName;
            physician.UpdateResultEntry = physicianProfile.UpdateResultEntry;
            physician.Npi = physicianProfile.Npi;
            return physician;
        }

        public PhysicianProfileEntity CreatePhysicianEntity(Physician physician)
        {
            return new PhysicianProfileEntity(physician.PhysicianId)
                       {
                           ResumeFileId = physician.ResumeFile != null ? (long?)physician.ResumeFile.Id : null,
                           DigitalSignatureFileId =
                               physician.SignatureFile != null ? (long?)physician.SignatureFile.Id : null,
                           IsAuthorizationAllowed = physician.CanDoAuthorizations,
                           ShowEarningAmount = physician.CanSeeEarnings,
                           SpecializationId = physician.SpecializationId,
                           SkipAudit = physician.SkipAudit,
                           CutOffDate = physician.CutOffDate,
                           IsDefaultPhysician = physician.IsDefault,
                           DisplayName = physician.DisplayName,
                           UpdateResultEntry = physician.UpdateResultEntry,
                           Npi = physician.Npi
                       };
        }

    }
}
