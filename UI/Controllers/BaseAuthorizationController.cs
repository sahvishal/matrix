using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Falcon.App.Core.ACL.ViewModel;

namespace Falcon.App.UI.Controllers
{
    public abstract partial class BaseAuthorizationController : Controller
    {
        protected BaseAuthorizationController()
        {
            SetEntityTypes();
        }

        public EntityType PrimaryEntityType { protected get; set; }

        public IEnumerable<EntityType> OtherEntityTypes { protected get; set; }

        public abstract void SetEntityTypes();

        public virtual IEnumerable<EntityType> GetEntityTypes()
        {
            if (PrimaryEntityType == null && (OtherEntityTypes == null || !OtherEntityTypes.Any()))
                return new EntityType[0];

            if (PrimaryEntityType == null) return OtherEntityTypes;

            var entityTypes = new List<EntityType>
            {
                PrimaryEntityType,
                new EntityType(PrimaryEntityType.Type, PrimaryEntityType.RepositoryType, DefaultParameterName)
            };

            if (OtherEntityTypes == null || !OtherEntityTypes.Any())
            {
                return entityTypes;
            }

            entityTypes.AddRange(OtherEntityTypes);

            if(entityTypes.GroupBy(x => x.ParameterName).Any(x => x.Count() > 1))
                throw new InvalidOperationException("Different entity types mapped to same parameter name.");

            return entityTypes;
        }

        public const string DefaultParameterName = "id";
    }
}