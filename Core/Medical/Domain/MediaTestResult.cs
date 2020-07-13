using System.Collections.Generic;

namespace Falcon.App.Core.Medical.Domain
{
    public abstract class MediaTestResult : TestResult
    {
        public List<ResultMedia> Media { get; set; }

        protected MediaTestResult(long id)
            : base(id)
        {
            
        }
    }
}