using Falcon.App.Core.Geo.Domain;

namespace Falcon.App.Core.Users.ViewModels
{
    public class OrganizationBasicInfoModel
    {
        public long Id { get; set; }
        public string Description { get; set;}
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}
