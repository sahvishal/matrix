using Falcon.App.Core.Application.Attributes;

namespace Falcon.App.Core.Medicare.ViewModels
{
    [NoValidationRequired]
    public class MedicareLogoutModel
    {
        public string EhrToken { get; set; }
    }
}
