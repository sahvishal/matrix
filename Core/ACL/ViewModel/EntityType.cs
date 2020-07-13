using System;

namespace Falcon.App.Core.ACL.ViewModel
{
    public class EntityType
    {
        public Type Type { get; private set; }

        public string ParameterName { get; private set; }

        public Type RepositoryType { get; private set; }

        public EntityType(Type type, Type repositoryType, string param)
        {
            Type = type;
            ParameterName = (string.IsNullOrEmpty(param) ? type.Name + "Id" : param).ToLower();
            RepositoryType = repositoryType;
        }

        public EntityType(Type type, Type repositoryType)
            : this(type, repositoryType, string.Empty)
        {

        }
    }
}