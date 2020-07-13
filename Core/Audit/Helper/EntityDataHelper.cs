using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Users.Domain;

namespace Falcon.App.Core.Audit.Helper
{
    public class EntityDataHelper
    {
        public static dynamic GetData(string propName, long entityId, IEnumerable<OrderedPair<string, Type>> domainTypes)
        {
            propName = propName.ToLower();

            var entityName = propName.EndsWith("id") ? propName.Substring(0, propName.LastIndexOf("id")) : propName;

            var typeData = domainTypes.SingleOrDefault(x => x.FirstValue.ToLower().Equals(entityName));

            if (typeData == null) return null;

            return GetData(typeData.SecondValue, entityId);
        }

        public static dynamic GetData(Type entityType, long entityId)
        {
            var tp = typeof(IUniqueItemRepository<>);
            dynamic repository = ApplicationManager.DependencyInjection.Resolve(tp.MakeGenericType(entityType));

            var data = repository.GetById(entityId);

            return data;
        }

        public static IEnumerable<OrderedPair<string, Type>> GetAllDomainTypes()
        {
            return Assembly.GetAssembly(typeof(User))
                .DefinedTypes.Where(d => !string.IsNullOrEmpty(d.Namespace) && d.Namespace.EndsWith("Domain"))
                .Select(d => new OrderedPair<string, Type>(d.Name, d))
                .ToArray();
        }
    }
}