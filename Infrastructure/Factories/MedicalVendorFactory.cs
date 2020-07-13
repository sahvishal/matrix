using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.Data.EntityClasses;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.App.Core.Enum;

namespace Falcon.App.Infrastructure.Factories
{
    [DefaultImplementation]
    public class MedicalVendorFactory : IMedicalVendorFactory
    {
        private readonly IMapper<Organization, OrganizationEntity> _mapper;

        public MedicalVendorFactory(IMapper<Organization,OrganizationEntity> mapper)
        {
            _mapper = mapper;
        }

        public MedicalVendorFactory()
            :this(new OrganizationMapper())
        {}

        public List<MedicalVendor> CreateMedicalVendors(IEnumerable<MedicalVendorProfileEntity> medicalVendorEntities)
        {
            if (medicalVendorEntities == null)
            {
                throw new ArgumentNullException("medicalVendorEntities");
            }

            return medicalVendorEntities.Select(CreateMedicalVendor).ToList();
        }

        public MedicalVendor CreateMedicalVendor(MedicalVendorProfileEntity medicalVendorEntity)
        {
            if (medicalVendorEntity == null)
            {
                throw new ArgumentNullException("medicalVendorEntity");
            }
            //TODO: Copy constrotor for Organization. Is this a code smell? - Yasir
            var medicalVendor = medicalVendorEntity.Organization != null ? new MedicalVendor(_mapper.Map(medicalVendorEntity.Organization)) : new MedicalVendor(medicalVendorEntity.OrganizationId);

            medicalVendor.ContractId = medicalVendorEntity.ContractId;
            medicalVendor.MedicalVendorType = (MedicalVendorType)medicalVendorEntity.TypeId;
            medicalVendor.IsHospitalPartner = medicalVendorEntity.IsHospitalPartner;
            medicalVendor.ResultLetterCoBrandingFileId = medicalVendorEntity.ResultLetterCoBrandingFileId;
            medicalVendor.DoctorLetterFileId = medicalVendorEntity.DoctorLetterFileId;
            
            return medicalVendor;
        }

        public MedicalVendorProfileEntity CreateMedicalVendorEntity(MedicalVendor vendor)
        {
            var profileEntity = new MedicalVendorProfileEntity(vendor.Id)
            {
                ContractId = vendor.ContractId,
                TypeId = (long)vendor.MedicalVendorType,
                IsHospitalPartner = vendor.IsHospitalPartner,
                ResultLetterCoBrandingFileId = vendor.ResultLetterCoBrandingFileId,
                DoctorLetterFileId = vendor.DoctorLetterFileId
            };

            return profileEntity;
        }

    }
}