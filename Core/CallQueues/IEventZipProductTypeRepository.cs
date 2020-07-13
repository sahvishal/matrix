using Falcon.App.Core.CallQueues.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues
{
   public interface IEventZipProductTypeRepository
    {

       EventZipProductType SaveEventZipProductType(EventZipProductType eventZipProductType);
       EventZipProductType SaveEventZipProductTypeSubstitute(EventZipProductType eventZipProductType);
        void DeleteEventZipProductType();
        void DeleteEventZipProductTypeSubstitute();
    }
}
