using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain.MedicalVendors;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.ViewModels;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Infrastructure.Medical.Impl
{
    [DefaultImplementation]
    public class PrimaryCarePhysicianImportService : IPrimaryCarePhysicianImportService
    {
        private readonly IPhysicianMasterRepository _physicianMasterRepository;
        private readonly IPrimaryCarePhysicianRepository _primaryCarePhysicianRepository;
        private readonly IStateRepository _stateRepository;

        public PrimaryCarePhysicianImportService(IPhysicianMasterRepository physicianMasterRepository, IPrimaryCarePhysicianRepository primaryCarePhysicianRepository, IStateRepository stateRepository)
        {
            _physicianMasterRepository = physicianMasterRepository;
            _primaryCarePhysicianRepository = primaryCarePhysicianRepository;
            _stateRepository = stateRepository;
        }

        public PhysicianMaster SavePhysicianMaster(PhysicianMaster physicianMaster, long stateId, long countryId)
        {
            var existingPhysicianMaster = _physicianMasterRepository.GetByNpi(physicianMaster.Npi);
            if (existingPhysicianMaster != null)
            {
                physicianMaster.Id = existingPhysicianMaster.Id;
                physicianMaster.DateCreated = existingPhysicianMaster.DateCreated;
                physicianMaster.DateModified = DateTime.Now;
            }
            else
            {
                physicianMaster.DateCreated = DateTime.Now;
            }
            physicianMaster = _physicianMasterRepository.Save(physicianMaster);

            if (existingPhysicianMaster != null)
                UpdateCustomerPrimaryCarePhysician(physicianMaster, stateId, countryId);

            return physicianMaster;
        }

        public void UpdateCustomerPrimaryCarePhysician(PhysicianMaster physicianMaster, long stateId, long countryId)
        {
            var primaryCarePhysicians = _primaryCarePhysicianRepository.GetByPhysicianMasterId(physicianMaster.Id);

            if (primaryCarePhysicians != null && primaryCarePhysicians.Any())
            {
                foreach (var primaryCarePhysician in primaryCarePhysicians)
                {
                    primaryCarePhysician.Name = new Name(physicianMaster.FirstName, physicianMaster.MiddleName, physicianMaster.LastName);
                    primaryCarePhysician.Primary = physicianMaster.PracticePhone;
                    primaryCarePhysician.Fax = physicianMaster.PracticeFax;
                    primaryCarePhysician.DataRecorderMetaData.DataRecorderModifier = new OrganizationRoleUser(1);//TaazaaAdmin
                    primaryCarePhysician.DataRecorderMetaData.DateModified = DateTime.Now;

                    primaryCarePhysician.Npi = physicianMaster.Npi;
                    primaryCarePhysician.PrefixText = physicianMaster.PrefixText;
                    primaryCarePhysician.SuffixText = physicianMaster.SuffixText;
                    primaryCarePhysician.CredentialText = physicianMaster.CredentialText;

                    if (!string.IsNullOrEmpty(physicianMaster.PracticeAddress1) && !string.IsNullOrEmpty(physicianMaster.PracticeState) && !string.IsNullOrEmpty(physicianMaster.PracticeCity) && !string.IsNullOrEmpty(physicianMaster.PracticeZip))
                    {
                        long addressId = 0;
                        if (primaryCarePhysician.Address != null)
                            addressId = primaryCarePhysician.Address.Id;

                        primaryCarePhysician.Address = new Address(addressId)
                        {
                            StreetAddressLine1 = physicianMaster.PracticeAddress1,
                            StreetAddressLine2 = physicianMaster.PracticeAddress2,
                            City = physicianMaster.PracticeCity,
                            StateId = stateId,//physicianMaster.PracticeState,
                            ZipCode = new ZipCode(physicianMaster.PracticeZip),
                            CountryId = countryId
                        };
                    }

                    _primaryCarePhysicianRepository.Save(primaryCarePhysician);
                }
            }
        }

        public PhysicianMasterListModel SearchPcp(string firstName, string lastName, string zipcode, int pageNumber, int pageSize, out int totalRecords)
        {
            var physicians = _physicianMasterRepository.Search(firstName, lastName, zipcode, pageNumber, pageSize, out totalRecords);

            if (physicians.IsNullOrEmpty())
                return null;
            var model = new PhysicianMasterListModel();
            model.Physicians = Mapper.Map<IEnumerable<PhysicianMaster>, IEnumerable<PhysicianMasterViewModel>>(physicians);

            var states = _stateRepository.GetAllStates();
            foreach (var physician in model.Physicians)
            {
                physician.PracticeState = states.Single(s => s.Code.Trim().ToLower() == physician.PracticeState.Trim().ToLower() || s.Name.Trim().ToLower() == physician.PracticeState.Trim().ToLower()).Name;
            }
            return model;
        }
    }
}
