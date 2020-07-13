using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    [DefaultImplementation]
    public class ZipDataRepository : PersistenceRepository, IZipDataRepository
    {
        public ZipData GetZipData(string zipCode, string city, string stateCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from zd in linqMetaData.ZipData where zipCode == zd.ZipCode && stateCode == zd.State select zd).ToArray();

                if (entities != null && entities.Any())
                {
                    if (entities.Count() == 1)
                        return Mapper.Map<ZipDataEntity, ZipData>(entities.Single());

                    var entity = (from e in entities
                                  where e.CityAliasMixedCase.ToLower().Replace(" ", "").Replace(".", "") == city.ToLower().Replace(" ", "").Replace(".", "")
                                  select e).FirstOrDefault();

                    if (entity == null)
                        return null;
                    return Mapper.Map<ZipDataEntity, ZipData>(entity);
                }

                entities = (from zd in linqMetaData.ZipData
                            where city.ToLower().Replace(" ", "").Replace(".", "") == zd.CityAliasMixedCase.ToLower().Replace(" ", "").Replace(".", "")
                                && stateCode == zd.State
                            select zd).ToArray();

                if (entities != null && entities.Count() == 1)
                    return Mapper.Map<ZipDataEntity, ZipData>(entities.Single());

                return null;
            }
        }

        public IEnumerable<ZipData> GetZipData(string zipCode, string stateCode)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from zd in linqMetaData.ZipData where zipCode == zd.ZipCode && stateCode == zd.State select zd).ToArray();
                if (entities != null && entities.Any())
                {
                    return Mapper.Map<IEnumerable<ZipDataEntity>, IEnumerable<ZipData>>(entities);
                }
                return null;
            }
        }

        public ZipData GetZipDataByZipCodeCity(string zipCode, string city)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);

                var entities = (from zd in linqMetaData.ZipData where zipCode == zd.ZipCode select zd).ToArray();

                if (entities != null && entities.Any())
                {
                    if (entities.Count() == 1)
                        return Mapper.Map<ZipDataEntity, ZipData>(entities.Single());

                    var entity = (from e in entities
                                  where e.CityAliasMixedCase.ToLower().Replace(" ", "").Replace(".", "") == city.ToLower().Replace(" ", "").Replace(".", "")
                                  select e).FirstOrDefault();

                    if (entity == null)
                        entity = (from e in entities select e).FirstOrDefault();
                    return Mapper.Map<ZipDataEntity, ZipData>(entity);
                }
                return null;
            }
        }
    }
}
