using System.Data;
using Falcon.App.Core.Medical.Domain;

namespace Falcon.App.Core.Medical
{
    public interface IGeTestParser
    {
        string ErrorSummary { get; }
        TestResult Parse(DataTable dtSourceFromExcel);
        bool CheckifDatatableisValidfortheTestType(DataTable dtSourceFromExcel);
    }
}