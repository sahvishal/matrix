using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Sales.Enum;

namespace Falcon.App.Core.Sales.Domain
{
    public class HostImage : File
    {
        public HostImageType ImageType { get; set; }
        public string Title { get; set; }
        public string AlternateText { get; set; }

        public HostImage(long id)
            : base(id)
        {

        }
    }
}
