using System.Data;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical.Interfaces
{
    public interface ITestParser
    {
        string ErrorSummary { get; }
        TestResult Parse();
    }

    public interface ICsvTestParser
    {
        string ErrorSummary { get; }
        TestResult Parse(DataRow dr);   
    }
}