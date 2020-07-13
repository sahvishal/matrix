using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical
{
    public interface IDiabeticRetinopathyParserlogFactory
    {
        DiabeticRetinopathyParserlogListModel GetDiabeticRetinopathyParserlog(IEnumerable<DiabeticRetinopathyParserlog> diabeticRetinopathyParserlogs);
    }
}
