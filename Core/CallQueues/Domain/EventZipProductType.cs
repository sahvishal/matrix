using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.CallQueues.Domain
{
   public class EventZipProductType
    {
       public long Id { get; set; }
        public long ZipId { get; set; }
        public long ProductTypeId { get; set; }
    }
}
