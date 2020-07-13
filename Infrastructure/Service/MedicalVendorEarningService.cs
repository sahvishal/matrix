using System;
using Falcon.App.Core.Finance.Domain;
using Falcon.App.Core.Finance.Impl;
using Falcon.App.Core.Finance.Interfaces;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users;
using Falcon.App.Infrastructure.Repositories;
using Falcon.App.Infrastructure.Repositories.Users;

namespace Falcon.App.Infrastructure.Service
{
    public class MedicalVendorEarningService : IMedicalVendorEarningService
    {
        private readonly IMedicalVendorEarningAggregateRepository _medicalVendorEarningAggregateRepository;
        private readonly IOrganizationRoleUserRepository _organizationRoleUserRepository;
        private readonly IMedicalVendorEarningFactory _medicalVendorEarningFactory;

        public MedicalVendorEarningService()
            : this(new MedicalVendorEarningAggregateRepository(), new OrganizationRoleUserRepository(), 
            new MedicalVendorEarningFactory())
        {}

        public MedicalVendorEarningService(IMedicalVendorEarningAggregateRepository medicalVendorEarningAggregateRepository, 
            IOrganizationRoleUserRepository organizationRoleUserRepository, IMedicalVendorEarningFactory medicalVendorEarningFactory)
        {
            _medicalVendorEarningAggregateRepository = medicalVendorEarningAggregateRepository;
            _organizationRoleUserRepository = organizationRoleUserRepository;
            _medicalVendorEarningFactory = medicalVendorEarningFactory;
        }

        public MedicalVendorEarning GenerateMedicalVendorEarning(long physicianId, long customerEventTestId, DateTime dateCreated, bool isEventCustomerActive)
        {
            if (physicianId == 0)
            {
                throw new ArgumentNullException("organizationRoleUser");
            }

            MedicalVendorEarningAggregate medicalVendorEarningAggregate = _medicalVendorEarningAggregateRepository.
                GetMedicalVendorEarningAggregate(physicianId, customerEventTestId, isEventCustomerActive);

            return _medicalVendorEarningFactory.CreateMedicalVendorEarning(medicalVendorEarningAggregate, 
                physicianId, dateCreated);
        }
    }
}
