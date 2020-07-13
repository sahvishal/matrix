using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    [DefaultImplementation]
    public class HospitalPartnerPackageRepository : PersistenceRepository, IHospitalPartnerPackageRepository
    {
        public void Save(HospitalPartnerPackage domainObject)
        {
            var entity = Mapper.Map<HospitalPartnerPackage, HospitalPartnerPackageEntity>(domainObject);

            if (domainObject == null) return;
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity))
                    throw new PersistenceFailureException();
            }
        }

        public void DeleteByHospitalPartnerId(long hospitalpartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(HospitalPartnerPackageEntity), new RelationPredicateBucket(HospitalPartnerPackageFields.HospitalpartnerId == hospitalpartnerId));
            }
        }

        public void Save(IEnumerable<HospitalPartnerPackage> hospitalPartnerPackags, long hospitalpartnerId)
        {
            DeleteByHospitalPartnerId(hospitalpartnerId);

            if (hospitalPartnerPackags.IsNullOrEmpty()) return;

            foreach (var hospitalPartnerPackage in hospitalPartnerPackags)
            {
                Save(hospitalPartnerPackage);
            }
        }

        public IEnumerable<HospitalPartnerPackage> GetByHospitalpartnerId(long hospitalpartnerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entities = linqMetaData.HospitalPartnerPackage.Where(x => x.HospitalpartnerId == hospitalpartnerId);

                return entities.IsNullOrEmpty() ? null : Mapper.Map<IEnumerable<HospitalPartnerPackageEntity>, IEnumerable<HospitalPartnerPackage>>(entities);
            }
        }
    }
}