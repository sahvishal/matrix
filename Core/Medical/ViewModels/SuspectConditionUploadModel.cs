using Falcon.App.Core.Application.ViewModels;
using System.IO;

namespace Falcon.App.Core.Medical.ViewModels
{
    public class SuspectConditionUploadModel : ViewModelBase
    {
        public string Filename { get; set; }
        public string Status { get; set; }
        public string Date { get; set; }
        public long TotalCount { get; set; }
        public long SuccessfullUploadCount { get; set; }
        public long FailedUploadCount { get; set; }
        public string UploadedName { get; set; }
        public long UploadedBy { get; set; }

        public string FailName
        {
            get
            {
                var nam = Path.GetFileNameWithoutExtension(Filename);
                var ext = Path.GetExtension(Filename);
                if (nam != null)
                {
                    return nam + "_Failed" + ext;
                }
                return "";
            }
        }
    }
}
