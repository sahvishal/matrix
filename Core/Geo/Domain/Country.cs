using System.Collections.Generic;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class Country : DomainObjectBase
    {
        public string Name { get; set; }
        public List<State> States { get; set; }

        public Country()
        { }

        public Country(long countryId)
            : base(countryId)
        { }
    }
}


