using AutoMapper;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.Domain;
using Falcon.App.Infrastructure.Repositories;
using Falcon.Data.EntityClasses;
using Falcon.Data.Linq;
using System.Linq;

namespace Falcon.App.Infrastructure.Application.Repositories
{
    [DefaultImplementation]
    public class ApplicationAuthenticationRepository : PersistenceRepository, IApplicationAuthenticationRepository
    {
        public ApplicationAuthentication GetByAppIdAndTokenId(string appId, string appToken)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.ApplicationAuthentication
                    .Where(x => x.ApplicationId == appId && x.Token == appToken && x.IsActive)
                    .FirstOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<ApplicationAuthenticationEntity, ApplicationAuthentication>(entity);
            }
        }

        public ApplicationAuthentication GetByAppId(string appId)
        {
            using (var adapter = PersistenceLayer.GetDataAccessAdapter())
            {
                var linqMetaData = new LinqMetaData(adapter);
                var entity = linqMetaData.ApplicationAuthentication
                    .Where(x => x.ApplicationId == appId && x.IsActive)
                    .FirstOrDefault();

                if (entity == null)
                    return null;
                return Mapper.Map<ApplicationAuthenticationEntity, ApplicationAuthentication>(entity);
            }
        }
    }
}
