using Falcon.App.Core.Application.Domain;
using Falcon.App.Core.Domain;
using Falcon.App.Core.Medical.Enum;

namespace Falcon.App.Core.Medical.Domain
{
    public class ResultMedia : DomainObjectBase
    {
        public File File { get; set; }
        public File Thumbnail { get; set; }
        public ReadingSource? ReadingSource { get; set; }

        public ResultMedia()
        {}

        public ResultMedia(long resultImageId)
            : base(resultImageId)
        {}
    }
}