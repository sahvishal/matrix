using System.Collections.Generic;
using Falcon.App.Core.Medical.Domain;
using HtmlAgilityPack;

namespace Falcon.App.Core.Medical
{
    public interface ITestNotPerformedHelper
    {
        void CreateTestNotPerformedPage(HtmlDocument resultDocument, IEnumerable<TestResult> testResults);
    }
}