using System;
using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Users.Domain;
using Falcon.App.Infrastructure.Users.Interfaces;
using Falcon.App.Infrastructure.Users.Mappers;
using Falcon.Data.EntityClasses;

namespace Falcon.App.Infrastructure.Users.Factories
{
    [DefaultImplementation]
    public class HospitalFacilityFactory : IHospitalFacilityFactory
    {
        private readonly IMapper<Organization, OrganizationEntity> _mapper;

        public HospitalFacilityFactory(IMapper<Organization,OrganizationEntity> mapper)
        {
            _mapper = mapper;
        }

        public HospitalFacilityFactory()
            :this(new OrganizationMapper())
        {}

        public List<HospitalFacility> CreateHospitalFacilities(IEnumerable<HospitalFacilityEntity> hospitalFacilityEntities)
        {
            if (hospitalFacilityEntities == null)
            {
                throw new ArgumentNullException("hospitalFacilityEntities");
            }

            return hospitalFacilityEntities.Select(CreateHospitalFacility).ToList();
        }

        public HospitalFacility CreateHospitalFacility(HospitalFacilityEntity hospitalFacilityEntity)
        {
            if (hospitalFacilityEntity == null)
            {
                throw new ArgumentNullException("hospitalFacilityEntity");
            }
            
            var hospitalFacility = hospitalFacilityEntity.Organization != null ? new HospitalFacility(_mapper.Map(hospitalFacilityEntity.Organization)) : new HospitalFacility(hospitalFacilityEntity.HospitalFacilityId);

            hospitalFacility.ContractId = hospitalFacilityEntity.ContractId;
            hospitalFacility.ResultLetterFileId = hospitalFacilityEntity.ResultLetterFileId;
            hospitalFacility.CannedMessage = hospitalFacilityEntity.CannedMessage;

            return hospitalFacility;
        }

        public HospitalFacilityEntity CreateHospitalFacilityEntity(HospitalFacility hospitalFacility)
        {
            var hospitalFacilityEntity = new HospitalFacilityEntity(hospitalFacility.Id)
            {
                ContractId = hospitalFacility.ContractId,
                ResultLetterFileId = hospitalFacility.ResultLetterFileId,
                CannedMessage = hospitalFacility.CannedMessage
            };

            return hospitalFacilityEntity;
        }
    }
}
