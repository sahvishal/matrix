using System.Linq;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Enum;
using Falcon.App.Infrastructure.Interfaces;
using Falcon.Data.HelperClasses;
using Falcon.Data.EntityClasses;
using SD.LLBLGen.Pro.ORMSupportClasses;

namespace Falcon.App.Infrastructure.Repositories
{
    [DefaultImplementation]
    public class ConfigurationSettingRepository : PersistenceRepository, IConfigurationSettingRepository
    {
        public ConfigurationSettingRepository()
        {}

        public ConfigurationSettingRepository(IPersistenceLayer persistenceLayer)
            : base(persistenceLayer)
        {
            
        }

        public string GetConfigurationValue(ConfigurationSettingName settingName)
        {
            var settingEntities = new EntityCollection<GlobalConfigurationEntity>();
            var bucket = new RelationPredicateBucket(GlobalConfigurationFields.Name == settingName.ToString());
            using (var myAdapter = PersistenceLayer.GetDataAccessAdapter())
            {
                myAdapter.FetchEntityCollection(settingEntities, bucket);
            }

            return settingEntities.Single().Value;
        }
    }
}