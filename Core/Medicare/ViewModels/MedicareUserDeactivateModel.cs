using System.Collections.Generic;

namespace Falcon.App.Core.Medicare.ViewModels
{
    public class MedicareUserDeactivateModel
    {
        public long EhrUserId { get; set; }
        public bool IsActive { get; set; }
    }
}
