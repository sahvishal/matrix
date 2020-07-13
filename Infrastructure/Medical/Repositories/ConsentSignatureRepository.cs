using System.Linq;
using AutoMapper;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    public class ConsentSignatureRepository : PersistenceRepository, IConsentSignatureRepository
    {
        public FluConsentSignature GetFluConsentSignature(long eventCustomerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from fcs in linqMetaData.FluConsentSignature
                              where fcs.EventCustomerId == eventCustomerId && fcs.IsActive
                              select fcs).SingleOrDefault();

                return Mapper.Map<FluConsentSignatureEntity, FluConsentSignature>(entity);
            }
        }

        public void Save()
        {

        }

        public void Deactivate()
        {

        }
    }
}
