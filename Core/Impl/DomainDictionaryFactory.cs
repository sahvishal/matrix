using System.Collections.Generic;
using Falcon.App.Core.Application;
using Falcon.App.Core.Application.Impl;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Impl
{
    public class DomainDictionaryFactory<Domain> : IDomainDictionaryFactory<Domain> where Domain : DomainObjectBase
    {
        private readonly IKeyValueDictionaryFactory<long, Domain> _keyValueDictionaryFactory;

        public DomainDictionaryFactory()
            : this(new KeyValueDictionaryFactory<long, Domain>())
        {}

        public DomainDictionaryFactory(IKeyValueDictionaryFactory<long, Domain> keyValueDictionaryFactory)
        {
            _keyValueDictionaryFactory = keyValueDictionaryFactory;
        }

        public Dictionary<long, Domain> GetDictionary(IEnumerable<Domain> domainObjects)
        {
            return _keyValueDictionaryFactory.GetDictionary(domainObjects, domainObject => domainObject.Id);
        }
    }
}