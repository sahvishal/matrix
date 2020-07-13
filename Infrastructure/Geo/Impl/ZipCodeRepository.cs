using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Exceptions;
using Falcon.App.Core.Extensions;
using Falcon.App.Core.Geo;
using Falcon.App.Core.Geo.Domain;
using Falcon.App.Core.Impl;
using Falcon.App.Core.Interfaces;
using Falcon.App.Infrastructure.Application.Impl;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.App.Infrastructure.Mappers;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;

namespace Falcon.App.Infrastructure.Geo.Impl
{
    public class ZipCodeRepository : PersistenceRepository, IZipCodeRepository
    {
        private readonly IMapper<ZipCode, ZipEntity> _mapper;

        public ZipCodeRepository()
            : this(new SqlPersistenceLayer(), new ZipCodeMapper())
        { }

        public ZipCodeRepository(IPersistenceLayer persistenceLayer, IMapper<ZipCode, ZipEntity> mapper)
            : base(persistenceLayer)
        {
            _mapper = mapper;
        }

        private List<ZipCode> FetchZipCode(Expression<Func<ZipEntity, bool>> filter)
        {
            List<ZipEntity> zipEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = linqMetaData.Zip.Where(filter).Where(z => z.IsActive).ToList();
                if (zipEntities.IsEmpty())
                {
                    throw new ObjectNotFoundInPersistenceException<ZipCode>();
                }
                return _mapper.MapMultiple(zipEntities).ToList();
            }
        }

        public ZipCode GetZipCode(long zipId)
        {
            Expression<Func<ZipEntity, bool>> filter = z => z.ZipId == zipId;
            try
            {
                return FetchZipCode(filter).Single();
            }
            catch (InvalidOperationException)
            {
                throw new DuplicateObjectException<ZipCode>();
            }
        }

        public IEnumerable<ZipCode> GetZipCode(string zipCode)
        {
            Expression<Func<ZipEntity, bool>> filter = z => z.ZipCode == zipCode;
            return FetchZipCode(filter);
        }

        public ZipCode GetZipCode(string zipCode, long cityId)
        {
            Expression<Func<ZipEntity, bool>> filter = z => z.ZipCode == zipCode && z.CityId == cityId;
            try
            {
                return FetchZipCode(filter).SingleOrDefault();
            }
            catch (InvalidOperationException)
            {
                throw new DuplicateObjectException<ZipCode>();
            }
        }

        public List<ZipCode> GetZipCodeForCity(long cityId)
        {
            IEnumerable<ZipEntity> zipEntities;

            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = linqMetaData.Zip.
                    Join(linqMetaData.City, z => z.CityId, c => c.CityId, (z, c) => new { z, c }).
                    Join(linqMetaData.State, @t => @t.c.StateId, s => s.StateId, (@t, s) => new { @t, s }).
                    Where(@t => @t.t.c.CityId == cityId && @t.@t.z.IsActive).
                    Select(@t => @t.@t.z).ToList();
            }
            if (zipEntities.Count() < 1) return null;
            return _mapper.MapMultiple(zipEntities).ToList();

        }

        public List<ZipCode> GetAllZipCodes()
        {
            List<ZipEntity> zipEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = linqMetaData.Zip.Where(z => z.IsActive).ToList();
            }
            return _mapper.MapMultiple(zipEntities).ToList();
        }

        public List<ZipCode> GetAllExistingZipCodes(List<string> zipCodesToFetch)
        {
            var zipEntities = new List<ZipEntity>();
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                while (!zipCodesToFetch.IsEmpty())
                {
                    var linqMetaData = new LinqMetaData(myAdapter);
                    List<string> zipCodesToCheck = zipCodesToFetch.Take(1000).ToList();
                    zipEntities.AddRange(linqMetaData.Zip.Where(z => zipCodesToCheck.Contains(z.ZipCode)).
                        ToList());
                    zipCodesToFetch.RemoveRange(0, zipCodesToFetch.Count > 1000 ? 1000 :
                        zipCodesToFetch.Count);
                }
            }
            return _mapper.MapMultiple(zipEntities).ToList();
        }

        public List<ZipCode> GetZipCodesForState(long stateId)
        {
            IEnumerable<ZipEntity> zipEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = linqMetaData.Zip.
                    Join(linqMetaData.City, z => z.CityId, c => c.CityId, (z, c) => new { z, c }).
                    Join(linqMetaData.State, @t => @t.c.StateId, s => s.StateId, (@t, s) => new { @t, s }).
                    Where(@t => @t.s.StateId == stateId && @t.@t.z.IsActive).
                    Select(@t => @t.@t.z).ToList();
            }
            return _mapper.MapMultiple(zipEntities).ToList();
        }

        public ZipCode GetZipIdByZipCodeCityState(long stateId, long cityId, string zipCode)
        {
            ZipEntity zipEntity;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntity = linqMetaData.Zip.
                    Join(linqMetaData.City, z => z.CityId, c => c.CityId, (z, c) => new { z, c }).
                    Join(linqMetaData.State, @t => @t.c.StateId, s => s.StateId, (@t, s) => new { @t, s }).
                    Where(@t => @t.s.StateId == stateId && @t.@t.c.CityId == cityId && @t.@t.z.ZipCode == zipCode && @t.@t.z.IsActive).
                    Select(@t => @t.@t.z).SingleOrDefault();
            }
            return _mapper.Map(zipEntity);
        }

        public List<ZipCode> GetZipCodesForTerritory(long territoryId)
        {
            IEnumerable<ZipEntity> zipEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = linqMetaData.Zip.
                    Join(linqMetaData.TerritoryZip, z => z.ZipId, tz => tz.ZipId, (z, tz) => new { z, tz }).
                    Where(@t => @t.tz.TerritoryId == territoryId && @t.z.IsActive).
                    Select(@t => @t.z).ToList();
            }
            return _mapper.MapMultiple(zipEntities).ToList();
        }

        // As of now, this really doesn't belong in the repository (only depends on a method of the repository).
        // Also newing up instance of DistanceCalculator directly.
        public List<ZipCode> GetZipCodesInRadius(string zipCode, int rangeInMiles)
        {
            ZipCode originZipCode = null;
            try
            {
                originZipCode = GetZipCode(zipCode).FirstOrDefault();
            }
            catch (ObjectNotFoundInPersistenceException<ZipCode>)
            {
                return null;
            }

            if (originZipCode == null) return null;

            List<ZipCode> zipCodes = GetAllZipCodes(); // If optimization is needed, try grabbing all within square.

            IDistanceCalculator distanceCalculator = new DistanceCalculator();
            return zipCodes.Where(z =>
                                      {
                                          var distance =
                                              distanceCalculator.
                                                  DistanceBetweenTwoPoints(originZipCode.Latitude,
                                                                           originZipCode.Longitude,
                                                                           z.Latitude, z.Longitude);
                                          return distance >= 0 && distance < rangeInMiles;
                                      }).ToList();
        }

        public ZipCode Save(ZipCode zip)
        {
            var entity = _mapper.Map(zip);
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                if (!adapter.SaveEntity(entity, true))
                    throw new PersistenceFailureException();
            }
            zip.Id = entity.ZipId;
            return zip;
        }

        public string GetZipIdsInRange(string zipCode, int radius)
        {
            string zipIdstring = string.Empty;
            if (!string.IsNullOrEmpty(zipCode))
            {
                List<ZipCode> zipCodes = null;

                if (radius > 0)
                    zipCodes = GetZipCodesInRadius(zipCode, radius);
                else
                {
                    try
                    {
                        zipCodes = GetZipCode(zipCode).ToList();
                    }
                    catch
                    { }
                }

                if (zipCodes != null && zipCodes.Count > 0)
                {
                    var zipIdsInRange = zipCodes.Select(zcir => zcir.Id).ToList();

                    zipIdstring = "," + string.Join(",", zipIdsInRange) + ",";
                }
                else
                {
                    zipIdstring = ",0,";
                }
            }

            return zipIdstring;

        }

        public IEnumerable<ZipCode> GetZipCodesByZipCode(string[] zipCodes)
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var zipEntities = linqMetaData.Zip.Where(z => zipCodes.Contains(z.ZipCode) && z.IsActive).ToList();

                return _mapper.MapMultiple(zipEntities).ToArray();
            }
        }

        public List<ZipCode> GetZipCodesBetweenTwoRadius(string zipCode,int startRadiusInMiles, int endInMiles )
        {
            ZipCode originZipCode = null;
            try
            {
                originZipCode = GetZipCode(zipCode).FirstOrDefault();
            }
            catch (ObjectNotFoundInPersistenceException<ZipCode>)
            {
                return null;
            }

            if (originZipCode == null) return null;

            List<ZipCode> zipCodes = GetAllZipCodes(); // If optimization is needed, try grabbing all within square.

            IDistanceCalculator distanceCalculator = new DistanceCalculator();
            return zipCodes.Where(z =>
            {
                var distance =
                    distanceCalculator.
                        DistanceBetweenTwoPoints(originZipCode.Latitude,
                                                 originZipCode.Longitude,
                                                 z.Latitude, z.Longitude);
                return distance >= startRadiusInMiles && distance < endInMiles;
            }).ToList();
        }

        public List<ZipCode> GetAllZipCodesByCounteryId(long counterId)
        {
            List<ZipEntity> zipEntities;
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                zipEntities = (from zip in linqMetaData.Zip
                    join c in linqMetaData.City on zip.CityId equals c.CityId
                    join s in linqMetaData.State on c.StateId equals s.StateId
                    where s.CountryId == counterId
                    select zip).ToList(); 
                //zipEntities = linqMetaData.Zip.Where(z => z.IsActive).ToList();
            }

            return _mapper.MapMultiple(zipEntities).ToList();
        }

    }
}