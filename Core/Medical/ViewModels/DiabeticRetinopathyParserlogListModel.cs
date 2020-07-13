using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Application.ViewModels;
using System.Collections.Generic;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class DiabeticRetinopathyParserlogListModel : ListModelBase<DiabeticRetinopathyParserlogViewModel, DiabeticRetinopathyParserlogListModelFilter>
    {
        public override IEnumerable<DiabeticRetinopathyParserlogViewModel> Collection { get; set; }
        
        public override DiabeticRetinopathyParserlogListModelFilter Filter { get; set; }
    }
}
