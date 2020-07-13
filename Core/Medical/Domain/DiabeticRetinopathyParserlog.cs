using Falcon.App.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Falcon.App.Core.Medical.Domain
{
    public class DiabeticRetinopathyParserlog : DomainObjectBase
    {
        public long CustomerId { get; set; }
        public long EventId { get; set; }
        public string FileName { get; set; }
        public string ErrorMessage { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
