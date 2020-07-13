using System.Collections.Generic;
using Falcon.App.Core.Application.ViewModels;

namespace Falcon.App.Core.Communication.ViewModels
{
    public class EmailTemplateEditModel : ViewModelBase
    {
        public long Id { get; set; }

        public string Alias { get; set; }

        public string Body { get; set; }

        public string Subject { get; set; }

        public IEnumerable<string> TemplateMacros { get; set; }

        public long TemplateType { get; set; }

        public long NotificationTypeId { get; set; }

        public bool IsEditable { get; set; }
    }
}