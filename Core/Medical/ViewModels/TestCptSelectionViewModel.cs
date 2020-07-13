using System.Collections.Generic;
namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestCptSelectionViewModel
    {
        public string Name { get; set; }
        public long Id { get; set; }
        public IEnumerable<OrderedPair<string, long>> Tests { get; set; }
        public long TestId { get; set; }
        public List<HcpcsViewModel> HcpcsViewModels { get; set; }
        public List<TestHcpcsViewModel> ExistingMappings { get; set; }
    }
}
