using Falcon.App.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
   public interface IEventZipProductTypeService
    {
       void SaveEventZipProductType(ILogger logger);
       void EventZipProductTypeSubstitute(ILogger logger);
    }
}
