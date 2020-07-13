using System.Collections.Generic;

namespace Falcon.App.Core.Audit.ViewModel
{
    public class LoggedCollectionModelEditModel
    {
        public string ModelFullName { get; set; }
        public IEnumerable<string> JsonStrings { get; set; }
    }
}
