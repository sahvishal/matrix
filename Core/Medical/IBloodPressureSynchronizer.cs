using System.Collections.Generic;
using System.Data;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IBloodPressureSynchronizer
    {
        string ErrorSummary { get; }
        IEnumerable<TestResult> Parse(DataRow dr);
        bool CheckIfDatatableIsValidforBpValues(DataTable dt);
        CardiovisionPressureReadings GetReadingsinDb();
    }
}