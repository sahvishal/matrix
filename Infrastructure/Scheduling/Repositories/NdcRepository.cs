using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Scheduling.Domain;
using Falcon.App.Core.Scheduling.Interfaces;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using Falcon.App.Core;

namespace Falcon.App.Infrastructure.Scheduling.Repositories
{
    [DefaultImplementation]
    public class NdcRepository : PersistenceRepository, INdcRepository
    {
        public IEnumerable<Ndc> GetByName(IEnumerable<string> names)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ndcs = from ec in linqMetaData.Ndc
                           where names.Contains(ec.ProductName)
                           select ec;
                return Mapper.Map<IEnumerable<NdcEntity>, IEnumerable<Ndc>>(ndcs);
            }
        }

        public IEnumerable<Ndc> GetByIds(IEnumerable<long> ids)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ndcs = from ec in linqMetaData.Ndc
                           where ids.Contains(ec.Id)
                           select ec;
                return Mapper.Map<IEnumerable<NdcEntity>, IEnumerable<Ndc>>(ndcs);
            }
        }

        public IEnumerable<Ndc> GetByNdcCode(IEnumerable<string> names)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ndcs = from ec in linqMetaData.Ndc
                           where names.Contains(ec.NdcCode)
                           select ec;
                return Mapper.Map<IEnumerable<NdcEntity>, IEnumerable<Ndc>>(ndcs);
            }
        }

        public IEnumerable<OrderedPair<long, string>> GetBySearchText(string serachText)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var ndcs = (from ec in linqMetaData.Ndc
                            where ec.ProductName.Contains(serachText)
                            select ec).ToArray();
                return ndcs.Select(x => new OrderedPair<long, string> { FirstValue = x.Id, SecondValue = x.ProductName });
            }
        }
    }
}
