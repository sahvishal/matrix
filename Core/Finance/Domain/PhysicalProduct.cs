
using Falcon.App.Core.ValueTypes;

namespace Falcon.App.Core.Finance.Domain
{
    public class PhysicalProduct:Product
    {
        public Weight Weight { get; set; }
        public Length Height { get; set; }
        public Length Width { get; set; }
        public Length Depth { get; set; }
    }
}
