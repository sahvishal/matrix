using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Sales.ViewModels
{
    [NoValidationRequired]
    public class MemberTermByAbsenceFilter
    {
        public long CorporateUploadId { get; set; }
        public string Tag { get; set; }

        public override string ToString()
        {
            return " Corporate Upload Id: " + CorporateUploadId + " Tag: " + Tag;
        }
    }
}
