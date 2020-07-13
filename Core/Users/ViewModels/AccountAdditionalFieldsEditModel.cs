
using Falcon.App.Core.Application.ViewModels;
namespace Falcon.App.Core.Users.ViewModels
{
    public class AccountAdditionalFieldsEditModel : ViewModelBase
    {
        public long AdditionalFieldId { get; set; }
        public string DisplayName { get; set; }
        public string FieldName { get; set; }
    }
}
