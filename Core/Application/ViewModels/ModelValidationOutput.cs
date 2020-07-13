using System.Collections.Generic;

namespace Falcon.App.Core.Application.ViewModels
{
    public class ModelValidationOutput
    {
        public bool IsValid { get; set; }

        public List<ModelValidationItem> Errors { get; set; }

        public ModelValidationOutput()
        {
            IsValid = true;
        }
    }
}
