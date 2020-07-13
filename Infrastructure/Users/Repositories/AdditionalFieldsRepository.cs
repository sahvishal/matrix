using AutoMapper;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Linq;
using Falcon.App.Core.Users;
using Falcon.App.Core.Users.Domain;
using System.Collections.Generic;
using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Infrastructure.Users.Repositories
{
    [DefaultImplementation]
    public class AdditionalFieldsRepository : PersistenceRepository, IAdditionalFieldsRepository
    {
        public IEnumerable<AdditionalFields> GetAll()
        {
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(myAdapter);
                var entities = (from af in linqMetaData.AdditionalFields
                                orderby af.Id
                                select af);
                return Mapper.Map<IEnumerable<AdditionalFieldsEntity>,IEnumerable<AdditionalFields>>(entities);
            }
        }
    }
}
