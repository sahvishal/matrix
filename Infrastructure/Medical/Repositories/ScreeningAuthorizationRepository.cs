using System.Collections.Generic;
using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Medical.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.HelperClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Medical.Repositories
{
    public class ScreeningAuthorizationRepository : PersistenceRepository, IScreeningAuthorizationRepository
    {
        private readonly IMapper<ScreeningAuthorization, ScreeningAuthorizationEntity> _mapper;

        public ScreeningAuthorizationRepository()
            : this(new SqlPersistenceLayer(), new ScreeningAuthorizationMapper())
        { }

        public ScreeningAuthorizationRepository(IPersistenceLayer persistenceLayer, IMapper<ScreeningAuthorization, ScreeningAuthorizationEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        public bool SaveScreeningAuthorizations(List<ScreeningAuthorization> screeningAuthorizations)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var entitiesToSave = _mapper.MapMultiple(screeningAuthorizations);
                var entities = new EntityCollection<ScreeningAuthorizationEntity>();
                entities.AddRange(entitiesToSave);
                if (adapter.SaveEntityCollection(entities) == 0)
                    throw new PersistenceFailureException();
                return true;
            }
        }

        public IEnumerable<long> GetEventCustomersAuthorizedforanEvent(long eventId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                return (from ec in linqMetaData.EventCustomers
                        join sa in linqMetaData.ScreeningAuthorization on ec.EventCustomerId equals sa.EventCustomerId
                        where ec.EventId == eventId
                        select ec.EventCustomerId).ToArray();
            }
        }

        public ScreeningAuthorization GetAuthorization(long eventCustomerId)
        {
            using(var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entity = (from sa in linqMetaData.ScreeningAuthorization
                              where sa.EventCustomerId == eventCustomerId
                              select sa).FirstOrDefault();
                if (entity == null)
                    return null;
                return _mapper.Map(entity);
            }
        }
    }
}
