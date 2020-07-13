using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class TestHcpcsViewModel : ViewModelBase
    {
        public long TestId { get; set; }
        public string TestName { get; set; }
        public List<HcpcsViewModel> HcpcsList { get; set; }
    }
}
