using Falcon.App.Core.Application.Attributes;
using Falcon.App.Core.Domain;

namespace Falcon.App.Core.Application.Domain
{
    public class Notes : DomainObjectBase   
    {
        public string Text { get; set; }
        [IgnoreAudit]
        public DataRecorderMetaData DataRecorderMetaData { get; set; }

        public override string ToString()
        {
            return this.Text;
        }
    }
}