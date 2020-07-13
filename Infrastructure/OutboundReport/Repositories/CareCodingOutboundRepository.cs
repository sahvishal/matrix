using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.OutboundReport;
using Falcon.App.Core.OutboundReport.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.OutboundReport.Repositories
{
    [DefaultImplementation]
    public class CareCodingOutboundRepository : PersistenceRepository, ICareCodingOutboundRepository
    {
        public CareCodingOutbound GetByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from cco in linqMetaData.CareCodingOutbound where cco.CustomerId == customerId select cco).SingleOrDefault();

                return entity == null ? null : Mapper.Map<CareCodingOutboundEntity, CareCodingOutbound>(entity);
            }
        }

        private bool DeleteByCustomerId(long customerId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                adapter.DeleteEntitiesDirectly(typeof(CareCodingOutboundEntity), new RelationPredicateBucket(CareCodingOutboundFields.CustomerId == customerId));
            }

            return true;
        }

        public CareCodingOutbound Save(CareCodingOutbound domain)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entity = Mapper.Map<CareCodingOutbound, CareCodingOutboundEntity>(domain);
                DeleteByCustomerId(domain.CustomerId);

                if (!adapter.SaveEntity(entity, true))
                {
                    throw new PersistenceFailureException();
                }

                return Mapper.Map<CareCodingOutboundEntity, CareCodingOutbound>(entity);
            }
        }
    }
}
