using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Operations.ViewModels
{
    public class VanListModel : ViewModelBase
    {
        public IEnumerable<VanEditModel> VanModels { get; set; }
        
    }
}