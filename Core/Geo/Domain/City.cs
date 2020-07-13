using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Geo.Domain
{
    public class City : DomainObjectBase
    {
        public string Name { get; set; }
        public long StateId { get; set; }
        public string Description { get; set; }
        public string CityCode { get; set; }
        
        public City()
        {}

        public City(long cityId)
            : base(cityId)
        {}
    }
}


