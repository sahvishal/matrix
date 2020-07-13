using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Medical;
using Falcon.App.Core.Medical.Domain;
using Falcon.App.Core.Medical.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Infrastructure.Medical.Factories
{
    [DefaultImplementation]
    public class DiabeticRetinopathyParserlogFactory : IDiabeticRetinopathyParserlogFactory
    {
       
        public DiabeticRetinopathyParserlogListModel GetDiabeticRetinopathyParserlog(IEnumerable<DiabeticRetinopathyParserlog> diabeticRetinopathyParserlogs)
        {
            var model = new DiabeticRetinopathyParserlogListModel();
            model.Collection = diabeticRetinopathyParserlogs.Select(m => new DiabeticRetinopathyParserlogViewModel()
            {
                EventId = m.EventId,
                CustomerId = m.CustomerId,
                ErrorMessage = m.ErrorMessage,
                FileName = m.FileName,
                DateCreated = m.DateCreated
            }).ToArray();

            return model;
        }
    }
}
